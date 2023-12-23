using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxNetworkPathFindingAlgorithm.Classes
{
    internal class Edge
    {
        public Vertex V1 { get; set; }

        public Vertex V2 { get; set; }

        public float Length { get; private set; }

        public Edge(Vertex v1, Vertex v2, float length) 
        {
            V1 = v1;
            V2 = v2;
            Length = length;
        }

        public bool ContainsVertices(Vertex v1, Vertex v2)
        {
            if (V1 == v1 && V2 == v2 || V1 == v2 && V2 == v1) return true;
            else return false;
        }
    }
}
