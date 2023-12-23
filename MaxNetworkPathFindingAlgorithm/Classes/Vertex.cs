using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExCSS;

namespace MaxNetworkPathFindingAlgorithm.Classes
{
    internal class Vertex
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public int Number { get; private set; }
        public float R { get; private set; }
        public bool IsSelected { get; set; }
        public bool IsConnectedWithEdge { get; set; }

        public GraphicsPath VertexGraphicsPath { get; private set; }
        public Vertex(float x, float y, float r, int num, GraphicsPath path) 
        {
            X = x;
            Y = y;
            R = r;
            Number = num;
            VertexGraphicsPath = path;
        }

        public void ShowInfo()
        {
            Debug.WriteLine($"({X}; {Y}), R = {R}");
        }

        public void ChangePosition(float x, float y)
        {
            // X = x - VertexGraphicsPath.GetBounds().Width * R / 2;
            // Y = y - VertexGraphicsPath.GetBounds().Height * R / 2;
            float offsetX = x - VertexGraphicsPath.GetBounds().Width * R / 2;
            float offsetY = y - VertexGraphicsPath.GetBounds().Height * R / 2;
            
            var matrix = new Matrix();

            matrix.Translate(x - X, y - Y, MatrixOrder.Append);

            VertexGraphicsPath.Transform(matrix);

            X = x;
            Y = y;
        }

        public void Delete()
        {
            X = 0;
            Y = 0;
            R = 0;
            Number = 0;
            IsSelected = false;
            VertexGraphicsPath = null;        
        }
    }
}
