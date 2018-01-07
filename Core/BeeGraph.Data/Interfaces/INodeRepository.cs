using System.Collections.Generic;
using BeeGraph.Data.Entities;
using BeeGraph.Infrastructure.Monads;

namespace BeeGraph.Data
{
    public interface INodeRepository
    {
        int CreateNode(string body);
        IEnumerable<NodeEntity> GetAll();
        Maybe<NodeEntity> Get(int id);

        void Delete(int id);
    }
}
