using BeeGraph.Core.Domain;
using BeeGraph.Infrastructure.Monads;

namespace BeeGraph.Core
{
    public interface IBeeGraphDialog
    {
        Maybe<Node> Talk(string userResponse);
    }
}
