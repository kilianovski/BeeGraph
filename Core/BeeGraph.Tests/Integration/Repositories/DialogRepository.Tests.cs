using System.Linq;
using BeeGraph.Data;
using BeeGraph.Tests.Infrastructure;
using FsCheck.Xunit;

namespace BeeGraph.Tests.Integration
{
    public class DialogRepository
    {
        private readonly INodeRepository _nodeRepository;
        private readonly IDialogRepository _dialogRepository;

        public DialogRepository()
        {
            _nodeRepository = TestContainer.Container.GetInstance<INodeRepository>();
            _dialogRepository = TestContainer.Container.GetInstance<IDialogRepository>();
        }

        [Property]
        public bool ContainsNodeAfterAddition()
        {
            // arrange
            var startNode = _nodeRepository.GetAll().ToList().PickRandomElem();
            
            // act
            var dialogId = _dialogRepository.AddDialog(startNode.Id);

            // assert
            var allDialogs = _dialogRepository.GetAll();

            return allDialogs.Any(d => d.Id == dialogId && d.StartNodeId == startNode.Id);
        }
    }
}
