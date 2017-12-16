﻿using System.Linq;
using BeeGraph.Data;
using BeeGraph.Data.Entities;
using BeeGraph.Tests.Infrastructure;
using FsCheck.Xunit;

namespace BeeGraph.Tests.Integration
{
    public class NodeRelationSpRepositoryTests
    {
        private readonly INodeRelationRepository _relationRepository;
        private readonly IEdgeRepository _edgeRepository;
        private readonly INodeRepository _nodeRepository;

        public NodeRelationSpRepositoryTests()
        {
            _relationRepository = TestContainer.Container.GetInstance<INodeRelationRepository>();
            _edgeRepository = TestContainer.Container.GetInstance<IEdgeRepository>();
            _nodeRepository = TestContainer.Container.GetInstance<INodeRepository>();
        }

        [Property]
        public bool ContainsNodeAfterAddition()
        {
            // arrange
            var allNodes = _nodeRepository.GetAll().ToList();
            var allEdges = _edgeRepository.GetAll().ToList();

            EdgeEntity edge = allEdges.PickRandomElem();

            NodeEntity fromNode = allNodes.PickRandomElem();
            NodeEntity toNode = allNodes.PickRandomElem();

            // act
            int newRelationId = _relationRepository.AddRelation(edge.Id, fromNode.Id, toNode.Id);
            var allRelations = _relationRepository.GetAll();

            // assert
            return allRelations.Any(r => 
                                        r.Id == newRelationId
                                        && r.EdgeId == edge.Id
                                        && r.FromNodeId == fromNode.Id
                                        && r.ToNodeId == toNode.Id);
        }
    }
}
