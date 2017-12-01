using BeeGraph.Core.Domain;
using BeeGraph.Infrastructure.Monads;

namespace BeeGraph.Core
{
    public class StatefulDialog
    {
        private Node _currentNode;

        public StatefulDialog(DialogGraph graph)
        {
            _currentNode = graph.StartNode;
        }

        public Maybe<Node> Talk(string userResponse)
        {
            var result = Dialog.Talk(_currentNode, userResponse);

            if (result.HasValue)
                _currentNode = result.Value;

            return result;
        }
    }
}