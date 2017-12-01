using System.Linq;
using BeeGraph.Data;
using BeeGraph.Tests.Infrastructure;
using FsCheck.Xunit;

namespace BeeGraph.Tests.Integration
{
    public class NodeSpRepositoryTests
    {
        private readonly INodeRepository _nodeRepository;

        public NodeSpRepositoryTests()
        {
            _nodeRepository = TestContainer.Container.GetInstance<INodeRepository>();
        }

        [Property]
        public bool ContainsNodeAfterAddition(string body)
        {
            if (string.IsNullOrEmpty(body)) body = "1"; // TODO

            var entityId = _nodeRepository.CreateNode(body);
            var allNodes = _nodeRepository.GetAll();

            return allNodes.Any(n => n.Id == entityId);
        }
    }
}
