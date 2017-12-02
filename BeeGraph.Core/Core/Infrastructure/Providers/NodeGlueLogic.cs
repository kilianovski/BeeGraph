using System;
using System.Collections.Generic;
using System.Linq;
using BeeGraph.Core.Domain;
using BeeGraph.Data.Entities;

namespace BeeGraph.Core
{
    public static class GlueLogic
    {
        // TODO use builder to maintain immutability
        public static IEnumerable<Node> GlueNodes(List<NodeEntity> nodes, List<EdgeRelationEntity> edgeRelations)
        {
            var mappedNodes = nodes.Select(MapNodeEntity).ToList();
            var resolveNode = GetNodeResolver(mappedNodes);
            edgeRelations.ForEach(e => GlueNodes(e, resolveNode));
            return mappedNodes;
        }

        private static void GlueNodes(EdgeRelationEntity rel, Dictionary<int, Node> nodeMap)
        {
            var fromNode = nodeMap[rel.FromNodeId];
            var toNode = nodeMap[rel.ToNodeId];

            var edge = new Edge(rel.EdgeKey, toNode);

            fromNode.AppendEdge(edge);
        }

        private static Dictionary<int, Node> GetNodeResolver(IEnumerable<Node> nodes) => 
            nodes.ToDictionary(n => n.Id);

        private static Node MapNodeEntity(NodeEntity e) => new Node(e.Id, e.Body);
    }
}
