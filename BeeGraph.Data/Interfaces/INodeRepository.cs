using System.Collections.Generic;
using BeeGraph.Domain;

namespace BeeGraph.Data
{
    public interface INodeRepository
    {
        IEnumerable<Node> GetAll();
        int CreateNode(string body);
    }
}
