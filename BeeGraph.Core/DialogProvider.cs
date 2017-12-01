using System.Collections.Generic;
using System.Linq;
using BeeGraph.Core.Domain;
using BeeGraph.Data;

namespace BeeGraph.Core
{
    public class DialogProvider : IDialogProvider
    {
        private readonly INodeRepository _nodeRepository;
        private readonly INodeRelationRepository _relationRepository;

        public DialogProvider(
            INodeRepository nodeRepository,
            INodeRelationRepository relationRepository)
        {
            _nodeRepository = nodeRepository;
            _relationRepository = relationRepository;
        }

        public DialogGraph GetDialog()
        {
            var nodes = _nodeRepository.GetAll().ToList();
            var edgeRelations = _relationRepository.GetAllEdgeRelations().ToList();

            IEnumerable<Node> gluedNodes = GlueLogic.GlueNodes(nodes, edgeRelations);

            return new DialogGraph(gluedNodes);
        }        
    }
}