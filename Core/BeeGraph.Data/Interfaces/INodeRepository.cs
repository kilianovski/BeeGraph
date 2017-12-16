using System.Collections.Generic;
using BeeGraph.Data.Entities;

namespace BeeGraph.Data
{
    public interface INodeRepository
    {
        int CreateNode(string body);
        IEnumerable<NodeEntity> GetAll();
    }
}
