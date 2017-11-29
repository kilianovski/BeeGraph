using System.Collections.Generic;
using BeeGraph.Domain;

namespace BeeGraph.Data.Interfaces
{
    public interface INodeRepository
    {
        IEnumerable<Node> GetAll();
        int CreateNode(string body);
    }
}
