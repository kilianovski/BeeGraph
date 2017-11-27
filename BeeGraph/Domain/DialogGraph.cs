﻿using System.Collections.Generic;

namespace BeeGraph.Domain
{
    public class DialogGraph
    {
        public IEnumerable<Node> Nodes { get; }

        public DialogGraph(IEnumerable<Node> nodes)
        {
            Nodes = nodes;
        }
    }
}
