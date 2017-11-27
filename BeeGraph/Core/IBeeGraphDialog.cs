using BeeGraph.Domain;
using BeeGraph.Infrastructure;

namespace BeeGraph.Core
{
    public interface IBeeGraphDialog
    {
        Maybe<Node> Talk(string userResponse);
    }
}
