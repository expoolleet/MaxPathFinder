using System.Drawing.Drawing2D;

namespace MaxNetworkPathFindingAlgorithm.Classes
{
    internal class Edge
    {
        public Vertex V1 { get; set; }

        public Vertex V2 { get; set; }

        public float Length { get; private set; }

        public bool IsSelected { get; set; }

        public GraphicsPath EdgeLineGraphicsPath { get; private set; }

        public GraphicsPath EdgeArrowGraphicsPath { get; private set; }

        public Edge(Vertex v1, Vertex v2, float length, GraphicsPath line, GraphicsPath arrow)
        {
            V1 = v1;
            V2 = v2;
            Length = length;
            EdgeLineGraphicsPath = line;
            EdgeArrowGraphicsPath = arrow;
        }

        public bool IsLastVertex(Vertex v)
        {
            return V2 == v;
        }

        public bool ContainsVertex(Vertex v)
        {
            return V1 == v || V2 == v;
        }

        public bool ContainsVertices(Vertex v1, Vertex v2)
        {
            return (V1 == v1 && V2 == v2) || (V1 == v2 && V2 == v1);
        }

        public void ChangeGraphicsPaths(GraphicsPath line, GraphicsPath arrow)
        {
            EdgeArrowGraphicsPath = arrow;
            EdgeLineGraphicsPath = line;
        }
    }
}
