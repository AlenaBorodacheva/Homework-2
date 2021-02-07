using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Vertex
    {
        public Vertex (int number)
        {
            Number = number;
        }
        public bool Visited { get; set; }
        public int Number { get; set; }
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
