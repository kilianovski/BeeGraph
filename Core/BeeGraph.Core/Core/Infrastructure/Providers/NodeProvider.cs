using System.Collections.Generic;
using System.Linq;
using BeeGraph.Core.Domain;
using BeeGraph.Data;

namespace BeeGraph.Core
{
    public class NodeProvider : INodeProvider
    {
        private readonly INodeRepository _nodeRepository;
        private readonly INodeRelationRepository _relationRepository;

        public NodeProvider(
            INodeRepository nodeRepository,
            INodeRelationRepository relationRepository)
        {
            _nodeRepository = nodeRepository;
            _relationRepository = relationRepository;
        }

        public IEnumerable<Node> GetAll()
        {
            var nodes = _nodeRepository.GetAll().ToList();
            var edgeRelations = _relationRepository.GetAllEdgeRelations().ToList();

            IEnumerable<Node> gluedNodes = GlueLogic.GlueNodes(nodes, edgeRelations);

            return gluedNodes;
        }
    }
}