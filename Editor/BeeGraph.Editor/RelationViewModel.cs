using System.Collections.Generic;
using BeeGraph.Core.Domain;
using BeeGraph.Data.Entities;

namespace BeeGraph.Editor
{
    class RelationViewModel
    {
        public Node FromNode { get; set; }
        public Node ToNode { get; set; }
        public Edge Edge { get; set; }

        public IEnumerable<NodeEntity> Nodes { get; set; }
        public IEnumerable<EdgeEntity> Edges { get; set; }
    }
}
