using System.Linq;
using BeeGraph.Data.Impl;
using BeeGraph.Data.Interfaces;
using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace BeeGraph.Tests.Integration
{
    public class NodeSpRepositoryTests
    {
        private readonly INodeRepository _nodeRepository;

        public NodeSpRepositoryTests()
        {
            _nodeRepository = new NodeSpRepository();            
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
