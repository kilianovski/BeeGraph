using System.Collections.Generic;
using BeeGraph.Data.Entities;

namespace BeeGraph.Data
{
    public interface IEdgeRepository
    {
        int CreateEdge(string key);
        IEnumerable<EdgeEntity> GetAll();
    }
}
