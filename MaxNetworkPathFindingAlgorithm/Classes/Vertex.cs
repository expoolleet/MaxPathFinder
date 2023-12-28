using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace MaxNetworkPathFindingAlgorithm.Classes
{
    public struct EdgeConnectPoint
    {
        public float X, Y;

        public override string ToString()
        {
            return $"{X}; {Y}";
        }
    }

    internal class Vertex
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public int Number { get;  set; }
        public float R { get; private set; }
        public bool IsSelected { get; set; }
        
        public float Epsilon { get; set; }

        public GraphicsPath VertexGraphicsPath { get; private set; }

        public EdgeConnectPoint ArrowConnectPoint { get; private set; }

        public Vertex(float x, float y, float r, int num, GraphicsPath path) 
        {
            X = x;
            Y = y;
            R = r;
            Number = num;
            VertexGraphicsPath = path;

            var connectPoint = new EdgeConnectPoint()
            {
                X = this.X - this.R * 2,
                Y = this.Y
            };
            ArrowConnectPoint = connectPoint;
        }

        public void ShowInfo()
        {
            Debug.WriteLine($"({X}; {Y}), R = {R}");
        }

        public void ChangePosition(float x, float y)
        {
            var matrix = new Matrix();

            matrix.Translate(x - X, y - Y, MatrixOrder.Append);

            VertexGraphicsPath.Transform(matrix);

            X = x;
            Y = y;

            var connectPoint = new EdgeConnectPoint()
            {
                X = this.X - this.R * 2,
                Y = this.Y
            };
            ArrowConnectPoint = connectPoint;
        }

        public static void SortListByNumbers(List<Vertex> vertices)
        {
            for (int i = 0; i < vertices.Count - 1; i++)
            {      
                for (int j = 0; j < vertices.Count - 1; j++)
                {
                    if (vertices[j].Number > vertices[j + 1].Number)
                    {
                        var ver = vertices[j];
                        vertices[j] = vertices[j + 1];
                        vertices[j + 1] = ver;
                    }
                }           
            }
        }

        public override string ToString()
        {
            return $"\nКоординаты: x: {X}; y:{Y}\nНомер: {Number}\nРасстояние до вершины: {Epsilon}";
        }
    }
}
