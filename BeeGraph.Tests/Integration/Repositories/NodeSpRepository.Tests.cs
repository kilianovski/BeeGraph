using System.Linq;
using BeeGraph.Data.Interfaces;
using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace BeeGraph.Tests.Integration
{
    public class NodeSpRepositoryTests
    {
        private readonly INodeRepository _nodeRepository;

        [Property]
        public bool ContainsNewlyCreatedEntity(string body)
        {
            if (string.IsNullOrEmpty(body)) body = "1"; // TODO

            var entityId = _nodeRepository.CreateNode(body);
            var allNodes = _nodeRepository.GetAll();

            return allNodes.Any(n => n.Id == entityId);

        }
    }
}
