using System.Collections.Generic;
using BeeGraph.Core.Domain;

namespace BeeGraph.Core
{
    public interface IDialogService
    {
        IEnumerable<DialogGraph> GetAll();
    }
}