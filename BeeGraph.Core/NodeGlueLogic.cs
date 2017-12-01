using System;
using System.Collections.Generic;
using System.Linq;
using BeeGraph.Core.Domain;
using BeeGraph.Data.Entities;

namespace BeeGraph.Core
{
    public static class GlueLogic
    {
        public static IEnumerable<Node> GlueNodes(List<NodeEntity> nodes, List<EdgeRelationEntity> edgeRelations)
        {
            var mappedNodes = nodes.Select(MapNodeEntity).ToList();
            var resolveNode = GetNodeResolver(mappedNodes);
            var gluedNodes = edgeRelations.Select(e => GlueNodes(e, resolveNode));
            return gluedNodes;
        }

        private static Node GlueNodes(EdgeRelationEntity rel, Func<int, Node> resolveNode)
        {
            var fromNode = resolveNode(rel.FromNodeId);
            var toNode = resolveNode(rel.ToNodeId);

            var edge = new Edge(rel.EdgeKey, toNode);

            return fromNode.WithNewOutEdge(edge);
        }

        private static Func<int, Node> GetNodeResolver(IEnumerable<Node> nodes)
        {
            var dict = nodes.ToDictionary(n => n.Id);
            return id => dict[id];
        }

        private static Node MapNodeEntity(NodeEntity e) => new Node(e.Id, e.Body);
    }
}
