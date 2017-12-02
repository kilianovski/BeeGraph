using System.Collections.Generic;
using BeeGraph.Core.Domain;

namespace BeeGraph.Core
{
    public class DialogService
    {
        private readonly INodeProvider _nodeProvider;

        public DialogService(INodeProvider nodeProvider)
        {
            _nodeProvider = nodeProvider;
        }

        //public IEnumerable<DialogGraph> GetAll()
        //{
            
        //}
    }
}
