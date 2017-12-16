using System.Collections.Generic;
using BeeGraph.Data.Entities;

namespace BeeGraph.Data
{
    public interface IDialogRepository
    {
        int AddDialog(int startNodeId);
        IEnumerable<DialogEntity> GetAll();
    }
}