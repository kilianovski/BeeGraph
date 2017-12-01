using System;
using System.Collections.Generic;
using System.Linq;
using BeeGraph.Core.Domain;
using BeeGraph.Data;
using BeeGraph.Data.Entities;

namespace BeeGraph.Core
{
    public class DialogFactory : IDialogFactory
    {
        private readonly INodeRepository _nodeRepository;
        private readonly IEdgeRepository _edgeRepository;
        private readonly INodeRelationRepository _relationRepository;

        public DialogFactory(
            INodeRepository nodeRepository,
            IEdgeRepository edgeRepository,
            INodeRelationRepository relationRepository)
        {
            _nodeRepository = nodeRepository;
            _edgeRepository = edgeRepository;
            _relationRepository = relationRepository;
        }

        public DialogGraph GetDialog()
        {
            var nodes = _nodeRepository.GetAll().ToList();
            var edgeRelations = _relationRepository.GetAllEdgeRelations();

            var mappedNodes = nodes.Select(MapNodeEntity).ToList();
            var resolveNode = GetNodeResolver(mappedNodes);

            var gluedNodes = edgeRelations.Select(e => GlueNodes(e, resolveNode));

            return new DialogGraph(gluedNodes);
        }

        private Node GlueNodes(EdgeRelationEntity rel, Func<int, Node> resolveNode)
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

        //private static (int edgeId, IEnumerable<NodeEntity> fromNodes, IEnumerable<NodeEntity> toNodes) 
        //    NodeRelationsResultSelector(
        //    (EdgeToNodesRelation rel, IEnumerable<NodeEntity> toNodes) pack,
        //    IEnumerable<NodeEntity> fromNodes)
        //{
        //    return (pack.rel.EdgeId, fromNodes, pack.toNodes);
        //}

        //private static (EdgeToNodesRelation rel, IEnumerable<NodeEntity> toNodes) 
        //        ToNodesResultSelector(EdgeToNodesRelation rel, IEnumerable<NodeEntity> toNodes) => (rel, toNodes);

        ////private static Edge GlueEdge(List<Node> mappedNodes, EdgeEntity e, List<EdgeToNodesRelation> relations)
        ////{
        ////    var fromNodes = mappedNodes.Join(relations, n => n.Id, r => r.FromNodeId, (n, _) => n);
        ////    var toNodes = mappedNodes.Join(relations, n => n.Id, r => r.ToNodeId, (n, _) => n);

        ////    return new Edge(e.Id, e.Key,)
        ////}


        private static Node MapNodeEntity(NodeEntity e) => new Node(e.Id, e.Body);

        
    }
}