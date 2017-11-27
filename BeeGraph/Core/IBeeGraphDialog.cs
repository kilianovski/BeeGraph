using BeeGraph.Domain;

namespace BeeGraph.Core
{
    public interface IBeeGraphDialog
    {
        Node Talk(int nodeId, string userResponse);
    }
}
