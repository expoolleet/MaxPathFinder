using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MaxNetworkPathFindingAlgorithm.Classes;
using Svg;

namespace MaxNetworkPathFindingAlgorithm
{

    public enum GraphActions
    {
        TransformVertex,
        AddVertex,
        Remove,
        ConnectVertices
    }

    public partial class MainForm : Form
    {
        private GraphActions _graphAction = GraphActions.TransformVertex;

        private int _vertexCount;

        private float _vertexRadius = 10;

        private float _sizeMul = 1.5f;

        private float _thickness = 7;

        private bool _debounceInitialStart = false;

        private bool _isVertexDragActionEnabled = false;

        private Vertex _firstSelectedVertex = null;

        private Vertex _lastSelectedVertex = null;

        private Font _font;

        //private string _vertexSVGFile = @".\svg\circle.svg";
        //private string _vertexSvgFile = @".\svg\dotted_circle.svg";
        private string _vertexSvgStringData = "<svg width=\"800px\" height=\"800px\" xmlns=\"http://www.w3.org/2000/svg\">\r\n<circle cx=\"10\" cy =\"10\" r=\"10\"/>\r\n</svg>";

        private Bitmap _bitmap;

        private List<Vertex> _vertices;

        private List<Edge> _edges;

        public MainForm()
        {
            InitializeComponent();
            _bitmap = new Bitmap(Size.Width, Size.Height);

            pictureBoxGraph.Image = _bitmap;

            ResetGraph();

            _font = new Font("Roboto", 10 * _sizeMul);

            _vertexRadius *= _sizeMul;
        }

        private void ResetGraph()
        {
            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                g.Clear(Color.LightGray);
            }

            _vertexCount = 0;
            _vertices = new List<Vertex>();
            _edges = new List<Edge>();

            pictureBoxGraph.Invalidate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBoxGraph_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_graphAction)
            {
                case GraphActions.TransformVertex:
                    if (e.Button == MouseButtons.Left)
                    {
                        _isVertexDragActionEnabled = true;

                        //Debug.WriteLine($"{e.X}, {e.Y}");
                    }
                    break;
                default:
                    break;
            }
        }

        private void pictureBoxGraph_MouseClick(object sender, MouseEventArgs e)
        {
            switch (_graphAction)
            {
                case GraphActions.TransformVertex:
                    if (e.Button == MouseButtons.Right)
                    {
                        Debug.WriteLine($"right click on pos: {e.X}; {e.Y}");
                    }
                    break;
                case GraphActions.AddVertex:
                    if (!IsAnyVertexSelected() && e.Button == MouseButtons.Left)
                    {
                        AddVertex(e.X, e.Y);
                    }
                    break;
                case GraphActions.Remove:
                    RemoveObject(e.X, e.Y);
                    break;
                case GraphActions.ConnectVertices:

                    foreach (var vertex in _vertices)
                    {
                        if (vertex.IsSelected && _firstSelectedVertex == null)
                        {
                            _firstSelectedVertex = vertex;
                        }
                        else if (vertex.IsSelected && vertex != _firstSelectedVertex)
                        {
                            _lastSelectedVertex = vertex;
                            ConnectVertex(_firstSelectedVertex, _lastSelectedVertex);
                        }
                    }

                    pictureBoxGraph.Invalidate();
                    break;
            }
        }

        private void pictureBoxGraph_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var vertex in _vertices.ToList())
            {
                if (vertex.VertexGraphicsPath.IsVisible(e.X, e.Y))
                {
                    pictureBoxGraph.Invalidate();

                    if (_isVertexDragActionEnabled)
                    {
                        TransformVertex(e.X, e.Y);
                    }
                    else
                    {
                        vertex.IsSelected = true;
                    }
                }
                else
                {
                    pictureBoxGraph.Invalidate();

                    vertex.IsSelected = false;
                }
            }

            foreach(var edge in _edges.ToList())
            {
                if (edge.EdgeArrowGraphicsPath.IsVisible(e.X, e.Y))
                {
                    edge.IsSelected = true;
                }
                else
                {
                    edge.IsSelected = false;
                }
            }
        }

        private void pictureBoxGraph_MouseUp(object sender, MouseEventArgs e)
        {
            if ((_graphAction == GraphActions.TransformVertex || _graphAction == GraphActions.ConnectVertices || _graphAction == GraphActions.Remove))
            {
                _isVertexDragActionEnabled = false;
            }
        }

        private void pictureBoxGraph_Paint(object sender, PaintEventArgs e)
        {
            //if (!_debounceInitialStart)
            //{
            //    _debounceInitialStart = true;
            //    return;
            //}

            Graphics graphics = e.Graphics;

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RedrawEdges(graphics);

            RedrawVertices(graphics);
        }

        private void buttonVertexTransform_Click(object sender, EventArgs e)
        {
            _graphAction = GraphActions.TransformVertex;
            CancelVertexConnect();


        }

        private void buttonVertexAdd_Click(object sender, EventArgs e)
        {
            _graphAction = GraphActions.AddVertex;
            CancelVertexConnect();
        }

        private void buttonVertexRemove_Click(object sender, EventArgs e)
        {
            _graphAction = GraphActions.Remove;
            CancelVertexConnect();
        }

        private void buttonVertexConnect_Click(object sender, EventArgs e)
        {
            _graphAction = GraphActions.ConnectVertices;
            CancelVertexConnect();
        }
        private void buttonDeleteGraph_Click(object sender, EventArgs e)
        {
            ResetGraph();
        }

        private void AddVertex(int x, int y)
        {
            var graphicsPath = CreateGraphicsPath(_vertexSvgStringData);

            float X = x - graphicsPath.GetBounds().Width * _sizeMul / 2;

            float Y = y - graphicsPath.GetBounds().Height * _sizeMul / 2;

            graphicsPath.Transform(new Matrix(1 * _sizeMul, 0, 0, 1 * _sizeMul, X, Y));

            var vertex = new Vertex(x, y, _vertexRadius, ++_vertexCount, graphicsPath);

            _vertices.Add(vertex);

            pictureBoxGraph.Invalidate();
        }

        private void RemoveObject(int x, int y)
        {
            foreach (var vertex in _vertices.ToList())
            {
                if (vertex.VertexGraphicsPath.IsVisible(x, y))
                {
                    vertex.VertexGraphicsPath.Dispose();

                    _vertices.Remove(vertex);

                    foreach(var edge in _edges.ToList())
                    {
                        if (edge.ContainsVertex(vertex))
                        {
                            _edges.Remove(edge);
                        }
                    }

                    pictureBoxGraph.Invalidate();
                }
            }

            foreach (var edge in _edges.ToList())
            {
                if (edge.EdgeLineGraphicsPath.IsVisible(x,y) || edge.EdgeArrowGraphicsPath.IsVisible(x, y))
                {
                    edge.EdgeLineGraphicsPath.Dispose();

                    edge.EdgeArrowGraphicsPath.Dispose();

                    //edge.V1.IsConnectedWithEdge = false;
                    //edge.V2.IsConnectedWithEdge = false;

                    _edges.Remove(edge);

                    pictureBoxGraph.Invalidate();
                }
            }
        }

        private void TransformVertex(int x, int y)
        {
            foreach (var vertex in _vertices)
            {
                if (vertex.IsSelected)
                {
                    vertex.ChangePosition(x, y);
                }
            }
        }

        private void ConnectVertex(Vertex v1, Vertex v2)
        {
            foreach (var edge in _edges)
            {
                if (edge.ContainsVertices(v1, v2))
                    return;
            }

            var graphicsLine = CreateGraphicsPath(CreateLinePath(v1.X, v1.Y, v2.X, v2.Y));

            var graphicsArrow = CreateGraphicsPath(CreateArrowPath(v2.ArrowConnectPoint.X, v2.ArrowConnectPoint.Y));

            var egde = new Edge(v1, v2, 1, graphicsLine, graphicsArrow);

            _edges.Add(egde);

            //v1.IsConnectedWithEdge = true;
            // v2.IsConnectedWithEdge = true;

            _firstSelectedVertex = null;
            _lastSelectedVertex = null;
        }

        private void CancelVertexConnect()
        {
            _firstSelectedVertex = null;
            pictureBoxGraph.Invalidate();
        }

        private void RedrawVertices(Graphics graphics)
        {
            foreach (var vertex in _vertices)
            {
                //graphics.DrawPath(Pens.Gray, vertex.VertexGraphicsPath);
                graphics.DrawPath(new Pen(Color.Gray, _thickness), vertex.VertexGraphicsPath);


                //Debug.WriteLine(svg.ContainsAttribute("r"));
                string number = $"{vertex.Number}";

                //var offsetX = vertex.VertexGraphicsPath.GetBounds().Width / (3.5f + (number.Length == 2 ? -1 : 1));

                //var offsetY = vertex.VertexGraphicsPath.GetBounds().Height / 3;

                var offsetX = vertex.VertexGraphicsPath.GetBounds().Width / (2.5f + (number.Length == 2 ? -0.5f : 1));

                var offsetY = vertex.VertexGraphicsPath.GetBounds().Height / 2.5f;


                //var svg = SvgDocument.Open(_vertexSVGFile);
                //var bitmap = svg.Draw();
                // graphics.DrawImage(bitmap, vertex.X - offsetX * number.Length / 4 + number.Length, vertex.Y - offsetY / 3);

                if (vertex.IsSelected && (_graphAction == GraphActions.TransformVertex || _graphAction == GraphActions.ConnectVertices || _graphAction == GraphActions.Remove))
                {
                    graphics.DrawPath(new Pen(Color.Red, _thickness), vertex.VertexGraphicsPath);
                }

                if (_firstSelectedVertex == vertex)
                {
                    graphics.DrawPath(new Pen(Color.DarkRed, _thickness), vertex.VertexGraphicsPath);

                    graphics.FillPath(Brushes.PaleVioletRed, _firstSelectedVertex.VertexGraphicsPath);

                    graphics.DrawString(number, _font, Brushes.DarkRed, vertex.X - offsetX, vertex.Y - offsetY);
                }
                else
                {
                    graphics.FillPath(Brushes.LightCyan, vertex.VertexGraphicsPath);

                    graphics.DrawString(number, _font, Brushes.Gray, vertex.X - offsetX, vertex.Y - offsetY);
                }


                //if (_vertexMode == VertexModes.Transform || _vertexMode == VertexModes.Connect || _vertexMode == VertexModes.Remove)
                //{

                //}
            }
        }

        private float angle;

        private void RedrawEdges(Graphics graphics)
        {
            foreach (var edge in _edges)
            {
                var matrix = new Matrix();

                angle = (float)(Math.Atan2(edge.V2.Y - edge.V1.Y, edge.V2.X - edge.V1.X) * 180 / Math.PI);

                matrix.RotateAt(angle, new Point((int)edge.V2.X, (int)edge.V2.Y));
                //Debug.WriteLine(matrix.OffsetX + " " + matrix.OffsetY);

                //Debug.WriteLine(matrix.Elements[0].ToString());

                GraphicsPath line = CreateGraphicsPath(CreateLinePath(edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y));
                GraphicsPath arrow = CreateGraphicsPath(CreateArrowPath(edge.V2.ArrowConnectPoint.X, edge.V2.ArrowConnectPoint.Y));



                edge.ChangeGraphicsPaths(line, arrow);

                edge.EdgeArrowGraphicsPath.Transform(matrix);

                if (edge.IsSelected && _graphAction == GraphActions.Remove)
                {
                    graphics.DrawPath(new Pen(Brushes.Red, _thickness / 2), edge.EdgeLineGraphicsPath);
                    graphics.FillPath(Brushes.Red, edge.EdgeArrowGraphicsPath);
                }
                else
                {
                    graphics.DrawPath(new Pen(Brushes.Gray, _thickness / 2), edge.EdgeLineGraphicsPath);
                    graphics.FillPath(Brushes.Gray, edge.EdgeArrowGraphicsPath);
                }

                
                //graphics.DrawLine(new Pen(Brushes.Black, 4), edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y);
            }
        }

        private GraphicsPath CreateGraphicsPath(string svgStringData)
        {
            return SvgDocument.FromSvg<SvgDocument>(svgStringData).Path;
            //return SvgDocument.Open(svgFile).Path;
        }

        private string CreateLinePath(float x1, float y1, float x2, float y2)
        {
            x2 = (int)(x2 + -_vertexRadius * 1.5 * Math.Cos(angle * Math.PI / 180));
            y2 = (int)(y2 + -_vertexRadius * 1.5 * Math.Sin(angle * Math.PI / 180));
            //Debug.WriteLine(x2 + " " + x3);
            //return $"<svg width=\"800px\" height=\"800px\" xmlns=\"http://www.w3.org/2000/svg\">\r\n<path d=\"M{x1} {y1} L{x2} {y2} M{x2} {y2} L{x2 - 10} {y2 - 10} M{x2} {y2} L{x2 - 10} {y2 + 10}  Z\" stroke-width=\"0\"/>\r\n</svg>";
            return $"<svg width=\"800px\" height=\"800px\" xmlns=\"http://www.w3.org/2000/svg\">\r\n<path d=\"M{x1} {y1} L{x2} {y2}\" stroke-width=\"0\"/>\r\n</svg>";
        }

        private string CreateArrowPath(float x, float y)
        {
            float offset = 10;
            return $"<svg width=\"800px\" height=\"800px\" xmlns=\"http://www.w3.org/2000/svg\">\r\n  <path d=\"M{x} {y} L{x} {y + offset} L{x + offset} {y} L{x} {y - offset}Z\" stroke-width=\"0\"/>\r\n</svg>";
        }

        private bool IsAnyVertexSelected()
        {
            foreach (var vertex in _vertices)
            {
                if (vertex.IsSelected) return true;
            }
            return false;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CancelVertexConnect();

                e.SuppressKeyPress = true;
            }
        }
    }
}
