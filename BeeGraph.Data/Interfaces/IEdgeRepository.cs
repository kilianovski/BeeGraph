using System.Collections.Generic;
using BeeGraph.Domain;

namespace BeeGraph.Data
{
    public interface IEdgeRepository
    {
        int CreateEdge(string key);
        IEnumerable<Edge> GetAll();
    }
}
