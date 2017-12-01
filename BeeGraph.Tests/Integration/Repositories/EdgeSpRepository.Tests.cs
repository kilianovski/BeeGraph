using System.Linq;
using BeeGraph.Data;
using BeeGraph.Tests.Infrastructure;
using FsCheck.Xunit;

namespace BeeGraph.Tests.Integration
{
    public class EdgeSpRepositoryTests
    {
        private readonly IEdgeRepository _edgeRepository;

        public EdgeSpRepositoryTests()
        {
            _edgeRepository = TestContainer.Container.GetInstance<IEdgeRepository>();
        }

        [Property]
        public bool ContainsNodeAfterAddition(string edgeKey)
        {
            if (string.IsNullOrEmpty(edgeKey)) edgeKey = "1"; // TODO

            var entityId = _edgeRepository.CreateEdge(edgeKey);
            var allEdges = _edgeRepository.GetAll();

            return allEdges.Any(n => n.Id == entityId);

        }
    }
}
