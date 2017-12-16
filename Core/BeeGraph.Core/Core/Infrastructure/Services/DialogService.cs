using System.Collections.Generic;
using System.Linq;
using BeeGraph.Core.Domain;
using BeeGraph.Data;

namespace BeeGraph.Core
{
    public class DialogService : IDialogService
    {
        private readonly INodeProvider _nodeProvider;
        private readonly IDialogRepository _dialogRepository;

        public DialogService(
            INodeProvider nodeProvider,
            IDialogRepository dialogRepository)
        {
            _nodeProvider = nodeProvider;
            _dialogRepository = dialogRepository;
        }

        public IEnumerable<DialogGraph> GetAll()
        {
            var nodes = _nodeProvider.GetAll();
            var dialogs = _dialogRepository.GetAll();

            return dialogs
                .Select(d => nodes.First(n => n.Id == d.StartNodeId))
                .Select(n => new DialogGraph(n));
        }
    }
}
