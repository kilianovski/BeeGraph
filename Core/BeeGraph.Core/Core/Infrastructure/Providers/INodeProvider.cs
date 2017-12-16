using System.Collections.Generic;
using BeeGraph.Core.Domain;

namespace BeeGraph.Core
{
    public interface INodeProvider
    {
        IEnumerable<Node> GetAll();
    }
}
