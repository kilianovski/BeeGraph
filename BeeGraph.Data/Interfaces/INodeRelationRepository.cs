using System.Collections.Generic;
using BeeGraph.Data.Entities;

namespace BeeGraph.Data
{
    public interface INodeRelationRepository
    {
        int AddRelation(int edgeId, int fromNodeId, int toNodeId);
        IEnumerable<EdgeToNodeRelation> GetAll();
    }
}
