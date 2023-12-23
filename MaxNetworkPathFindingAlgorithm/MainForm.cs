using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MaxNetworkPathFindingAlgorithm.Classes;
using Svg;

namespace MaxNetworkPathFindingAlgorithm
{

    public enum VertexModes
    {
        Transform,
        Add,
        Remove,
        Connect
    }

    public partial class MainForm : Form
    {
        private VertexModes _vertexMode = VertexModes.Transform;

        private int _vertexCount;

        private float _vertexRadius = 1.5f;

        private float _vertexThickness = 5;

        private bool _debounceInitialStart = false;

        private bool _isVertexDragActionEnabled = false;

        private Vertex _firstSelectedVertex = null;

        private Vertex _lastSelectedVertex = null;

        private Font _font;

        //private string _vertexSVGFile = @".\svg\circle.svg";
        //private string _vertexSvgFile = @".\svg\dotted_circle.svg";
        private string _vertexSvgStringData = "<?xml version=\"1.0\" ?>\r\n<svg width=\"800px\" height=\"800px\" xmlns=\"http://www.w3.org/2000/svg\">\r\n <!--viewBox=\"0 0 24 24\"--> \r\n<title/>\r\n<g id =\"DottedCircle\">\r\n<circle cx=\"12\" cy =\"12\" r=\"10\" stroke=\"black\" stroke-width=\"2\" fill=\"none\"/>\r\n</g>\r\n</svg>";

        private Bitmap _bitmap;

        private List<Vertex> _vertices;

        private List<Edge> _edges;

        public MainForm()
        {
            InitializeComponent();
            _bitmap = new Bitmap(Size.Width, Size.Height);

            pictureBoxGraph.Image = _bitmap;

            ResetGraph();

            _font = new Font("Roboto", 10 * _vertexRadius);
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
            switch (_vertexMode)
            {
                case VertexModes.Transform:
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
            switch (_vertexMode)
            {
                case VertexModes.Transform:
                    if (e.Button == MouseButtons.Right)
                    {
                        Debug.WriteLine("right click");
                    }
                    break;
                case VertexModes.Add:
                    if (!IsAnyVertexSelected())
                    {
                        AddVertex(e.X, e.Y);
                    }
                    break;
                case VertexModes.Remove:
                    RemoveVertex(e.X, e.Y);
                    break;
                case VertexModes.Connect:

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
        }

        private void pictureBoxGraph_MouseUp(object sender, MouseEventArgs e)
        {
            if ((_vertexMode == VertexModes.Transform || _vertexMode == VertexModes.Connect || _vertexMode == VertexModes.Remove))
            {
                _isVertexDragActionEnabled = false;
            }
        }

        private void pictureBoxGraph_Paint(object sender, PaintEventArgs e)
        {
            if (!_debounceInitialStart)
            {
                _debounceInitialStart = true;
                return;
            }

            Graphics graphics = e.Graphics;

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RedrawEdges(graphics);

            RedrawVertices(graphics);
         
        }

        private void buttonVertexTransform_Click(object sender, EventArgs e)
        {
            _vertexMode = VertexModes.Transform;
        }

        private void buttonVertexAdd_Click(object sender, EventArgs e)
        {
            _vertexMode = VertexModes.Add;
        }

        private void buttonVertexRemove_Click(object sender, EventArgs e)
        {
            _vertexMode = VertexModes.Remove;
        }

        private void buttonVertexConnect_Click(object sender, EventArgs e)
        {
            _vertexMode = VertexModes.Connect;
        }
        private void buttonDeleteGraph_Click(object sender, EventArgs e)
        {
            ResetGraph();
        }

        private void AddVertex(int x, int y)
        {
            var graphicsPath = CreateGraphicsPath(_vertexSvgStringData);

            float X = x - graphicsPath.GetBounds().Width * _vertexRadius / 2;

            float Y = y - graphicsPath.GetBounds().Height * _vertexRadius / 2;

            graphicsPath.Transform(new Matrix(1 * _vertexRadius, 0, 0, 1 * _vertexRadius, X, Y));

            var vertex = new Vertex(x, y, _vertexRadius, ++_vertexCount, graphicsPath);

            _vertices.Add(vertex);

            pictureBoxGraph.Invalidate();
        }

        private void RemoveVertex(int x, int y)
        {
            foreach (var vertex in _vertices.ToList())
            {
                if (vertex.VertexGraphicsPath.IsVisible(x, y))
                {
                    vertex.VertexGraphicsPath.Dispose();

                    _vertices.Remove(vertex);

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

            var egde = new Edge(v1, v2, 1);

            _edges.Add(egde);

            v1.IsConnectedWithEdge = true;
            v2.IsConnectedWithEdge = true;

            _firstSelectedVertex = null;
            _lastSelectedVertex = null;

            Debug.WriteLine("connected");
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
                graphics.DrawPath(new Pen(Color.Gray, _vertexThickness), vertex.VertexGraphicsPath);


                //Debug.WriteLine(svg.ContainsAttribute("r"));
                string number = $"{vertex.Number}";

                var offsetX = vertex.VertexGraphicsPath.GetBounds().Width / (3.5f + (number.Length == 2 ? -1 : 1));

                var offsetY = vertex.VertexGraphicsPath.GetBounds().Height / 3;



                //var svg = SvgDocument.Open(_vertexSVGFile);
                //var bitmap = svg.Draw();
                // graphics.DrawImage(bitmap, vertex.X - offsetX * number.Length / 4 + number.Length, vertex.Y - offsetY / 3);

                if (vertex.IsSelected && (_vertexMode == VertexModes.Transform || _vertexMode == VertexModes.Connect || _vertexMode == VertexModes.Remove))
                {
                    graphics.DrawPath(new Pen(Color.Red, _vertexThickness), vertex.VertexGraphicsPath);
                }

                if (_firstSelectedVertex == vertex)
                {
                    graphics.DrawPath(new Pen(Color.DarkRed, _vertexThickness), vertex.VertexGraphicsPath);

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

        private void RedrawEdges(Graphics graphics)
        {
            foreach (var edge in _edges)
            {
                graphics.DrawLine(new Pen(Brushes.Black, 4), edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y);
            }
        }

        private GraphicsPath CreateGraphicsPath(string svgStringData)
        {
            return SvgDocument.FromSvg<SvgDocument>(svgStringData).Path;
            //return SvgDocument.Open(svgFile).Path;
        }

        private bool IsAnyVertexSelected()
        {
            foreach(var vertex in _vertices)
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
