using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using MaxNetworkPathFindingAlgorithm.Classes;
using Svg;

namespace MaxNetworkPathFindingAlgorithm
{
    public enum GraphActions
    {
        TransformVertex,
        AddVertex,
        Remove,
        ConnectVertices,
        FindMaxPath
    }

    public partial class MainForm : Form
    {
        private GraphActions _graphAction = GraphActions.TransformVertex;

        private int _vertexCount;

        private float _vertexRadius = 10;

        private float _sizeMul = 1.5f;

        private float _thickness = 7;
        private float fdsdfsa;
        private bool _isVertexDragActionEnabled = false;

        private bool _isPathFinded = false;

        private Vertex _firstSelectedVertex = null;

        private Vertex _lastSelectedVertex = null;

        private Font _font;

        private string _vertexSvgStringData = "<svg width=\"800px\" height=\"800px\" xmlns=\"http://www.w3.org/2000/svg\">\r\n<circle cx=\"10\" cy =\"10\" r=\"10\"/>\r\n</svg>";

        private Bitmap _bitmap;

        private List<Vertex> _vertices;

        private List<Vertex> _verticesPath;

        private List<Edge> _edges;

        public MainForm()
        {
            InitializeComponent();

            _bitmap = new Bitmap(MaximumSize.Width, MaximumSize.Height);

            pictureBoxGraph.Image = _bitmap;

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
            ResetGraph();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            CancelVertexConnectionOrAlgorithm();
        }

        private void pictureBoxGraph_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_graphAction)
            {
                case GraphActions.TransformVertex:
                    if (e.Button == MouseButtons.Left)
                    {
                        _isVertexDragActionEnabled = true;
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
                        foreach (var vertex in _vertices)
                        {
                            if (vertex.VertexGraphicsPath.IsVisible(e.X, e.Y))
                            {
                                FormVertexDialog formVertexDialog = new FormVertexDialog(this);

                                if (formVertexDialog.ShowDialog() == DialogResult.OK && int.TryParse(formVertexDialog.textBoxVertexNumber.Text, out int number))
                                {
                                    if (number < 100)
                                    {
                                        formVertexDialog.Focus();
                                        vertex.Number = number;
                                        pictureBoxGraph.Invalidate();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Введите двухзначный номер", "Отмена операции", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case GraphActions.AddVertex:
                    if (!IsAnyVertexSelected() && e.Button == MouseButtons.Left)
                    {
                        AddVertex(e.X, e.Y);
                    }
                    break;
                case GraphActions.Remove:
                    if (e.Button == MouseButtons.Left)
                    {
                        RemoveObject(e.X, e.Y);
                    }
                    break;
                case GraphActions.ConnectVertices:
                    if (e.Button == MouseButtons.Left)
                    {
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
                    }
                    break;
                case GraphActions.FindMaxPath:
                    if (e.Button == MouseButtons.Left)
                    {
                        foreach (var vertex in _vertices.ToList())
                        {
                            if (vertex.IsSelected && _firstSelectedVertex == null)
                            {
                                _isPathFinded = false;

                                _firstSelectedVertex = vertex;
                            }
                            else if (vertex.IsSelected && vertex != _firstSelectedVertex)
                            {
                                _lastSelectedVertex = vertex;

                                _verticesPath = Ford.FindMaxPath(_vertices, _edges, _firstSelectedVertex, _lastSelectedVertex);

                                _isPathFinded = true;

                                _firstSelectedVertex = null;

                                _lastSelectedVertex = null;

                                textBoxPath.Text = "{";
                                for (int i = 0; i < _verticesPath.Count; i++)
                                {
                                    textBoxPath.Text += (i != _verticesPath.Count - 1) ? $"{_verticesPath[i].Number}, " : $"{_verticesPath[i].Number}" + "}";
                                }
                            }
                        }
                        pictureBoxGraph.Invalidate();
                    }
                    break;
            }
        }

        private void pictureBoxGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (TryGetSelectedVertex(out Vertex selectedVertex) && _isVertexDragActionEnabled)
            {
                TransformVertex(selectedVertex, e.X, e.Y);
            }
            foreach (var vertex in _vertices.ToList())
            {
                if (vertex.VertexGraphicsPath.IsVisible(e.X, e.Y))
                {
                    if (!CheckIfAnyVertexIsSelected())
                    {
                        vertex.IsSelected = true;
                    }
                }
                else
                {
                    vertex.IsSelected = false;
                }    
            }
            foreach (var edge in _edges.ToList())
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
            pictureBoxGraph.Invalidate();
        }

        private bool TryGetSelectedVertex(out Vertex v)
        {
            foreach (var vertex in _vertices.ToList())
            {
                if (vertex.IsSelected)
                {
                    v = vertex;
                    return true;
                }

            }
            v = null;
            return false;
        }

        private bool CheckIfAnyVertexIsSelected()
        {
            foreach (var vertex in _vertices.ToList())
            {
                if (vertex.IsSelected)
                    return true;
            }
            return false;
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
            Graphics graphics = e.Graphics;

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RedrawEdges(graphics);

            RedrawVertices(graphics);
        }

        private void buttonVertexTransform_Click(object sender, EventArgs e)
        {
            _graphAction = GraphActions.TransformVertex;
            CancelVertexConnectionOrAlgorithm();
            toolStripStatusLabel.Text = "Выбранное действие: " + buttonVertexTransform.Text;
        }

        private void buttonVertexAdd_Click(object sender, EventArgs e)
        {
            _graphAction = GraphActions.AddVertex;
            CancelVertexConnectionOrAlgorithm();
            toolStripStatusLabel.Text = "Выбранное действие: " + buttonVertexAdd.Text;
        }

        private void buttonVertexRemove_Click(object sender, EventArgs e)
        {
            _graphAction = GraphActions.Remove;
            CancelVertexConnectionOrAlgorithm();
            toolStripStatusLabel.Text = "Выбранное действие: " + buttonVertexRemove.Text;
        }

        private void buttonVertexConnect_Click(object sender, EventArgs e)
        {
            _graphAction = GraphActions.ConnectVertices;
            CancelVertexConnectionOrAlgorithm();
            toolStripStatusLabel.Text = "Выбранное действие: " + buttonVertexConnect.Text;
        }

        private void buttonFord_Click(object sender, EventArgs e)
        {
            _graphAction = GraphActions.FindMaxPath;
            CancelVertexConnectionOrAlgorithm();
            toolStripStatusLabel.Text = "Выбранное действие: " + buttonFord.Text;
        }

        private void buttonDeleteGraph_Click(object sender, EventArgs e)
        {
            CancelVertexConnectionOrAlgorithm();
            ResetGraph();
            toolStripStatusLabel.Text = "Граф удален";
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            FormHelper formHelper = new FormHelper();
            formHelper.Show();

            CancelVertexConnectionOrAlgorithm();
            toolStripStatusLabel.Text = "Выбранное действие: " + buttonHelp.Text;
        }

        private void AddVertex(int x, int y)
        {
            if (_vertexCount > 99)
                return;

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

                    foreach (var edge in _edges.ToList())
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
                if (edge.EdgeLineGraphicsPath.IsVisible(x, y) || edge.EdgeArrowGraphicsPath.IsVisible(x, y))
                {
                    edge.EdgeLineGraphicsPath.Dispose();

                    edge.EdgeArrowGraphicsPath.Dispose();

                    _edges.Remove(edge);

                    pictureBoxGraph.Invalidate();
                }
            }
        }

        private void TransformVertex(Vertex vertex, int x, int y)
        {
            if (x > 0 && x < pictureBoxGraph.Width && y > 0 && y < pictureBoxGraph.Height)
            {
                vertex.ChangePosition(x, y);
            }
        }

        private void ConnectVertex(Vertex v1, Vertex v2)
        {
            foreach (var edge in _edges)
            {
                if (edge.ContainsVertices(v1, v2))
                    return;
            }

            var graphicsLine = CreateGraphicsPath(CreateLinePath(v1.X, v1.Y, v2.X, v2.Y, 0));
            var graphicsArrow = CreateGraphicsPath(CreateArrowPath(v2.ArrowConnectPoint.X, v2.ArrowConnectPoint.Y));

            FormEdgeDialog formEdgeDialog = new FormEdgeDialog(this);

            if (formEdgeDialog.ShowDialog() == DialogResult.OK && float.TryParse(formEdgeDialog.textBoxEdgeLength.Text, out float length))
            {
                formEdgeDialog.Focus();

                var egde = new Edge(v1, v2, length, graphicsLine, graphicsArrow);

                _edges.Add(egde);
            }
            _firstSelectedVertex = null;
            _lastSelectedVertex = null;
        }

        private void CancelVertexConnectionOrAlgorithm()
        {
            _firstSelectedVertex = null;
            _isPathFinded = false;
            pictureBoxGraph.Invalidate();
            textBoxPath.Text = string.Empty;
        }

        private void RedrawVertices(Graphics graphics)
        {
            foreach (var vertex in _vertices)
            {
                string number = $"{vertex.Number}";

                var offsetX = vertex.VertexGraphicsPath.GetBounds().Width / (2.5f + (number.Length == 2 ? -0.5f : 1));
                var offsetY = vertex.VertexGraphicsPath.GetBounds().Height / 2.5f;

                if (vertex.IsSelected && (_graphAction == GraphActions.TransformVertex || _graphAction == GraphActions.ConnectVertices || _graphAction == GraphActions.Remove))
                {
                    graphics.DrawPath(new Pen(Color.Red, _thickness), vertex.VertexGraphicsPath);
                    graphics.FillPath(Brushes.LightCyan, vertex.VertexGraphicsPath);
                    graphics.DrawString(number, _font, Brushes.Gray, vertex.X - offsetX, vertex.Y - offsetY);
                }
                else if (_firstSelectedVertex == vertex)
                {
                    graphics.DrawPath(new Pen(Color.DarkRed, _thickness), vertex.VertexGraphicsPath);
                    graphics.FillPath(Brushes.PaleVioletRed, _firstSelectedVertex.VertexGraphicsPath);
                    graphics.DrawString(number, _font, Brushes.DarkRed, vertex.X - offsetX, vertex.Y - offsetY);
                }
                else if (_isPathFinded && _graphAction == GraphActions.FindMaxPath)
                {
                    var font = new Font("Roboto", 11 * _sizeMul, FontStyle.Bold);

                    if (_verticesPath.Contains(vertex))
                    {
                        graphics.DrawPath(new Pen(Color.Red, _thickness), vertex.VertexGraphicsPath);
                        graphics.FillPath(Brushes.LightCyan, vertex.VertexGraphicsPath);
                    }
                    else
                    {
                        graphics.DrawPath(new Pen(Color.Gray, _thickness), vertex.VertexGraphicsPath);
                        graphics.FillPath(Brushes.LightCyan, vertex.VertexGraphicsPath);
                    }
                    graphics.DrawString(number, _font, Brushes.Gray, vertex.X - offsetX, vertex.Y - offsetY);
                    graphics.DrawString(vertex.Epsilon.ToString(), font, Brushes.Black, vertex.X, vertex.Y - 3 * _vertexRadius);
                }
                else
                {
                    graphics.DrawPath(new Pen(Color.Gray, _thickness), vertex.VertexGraphicsPath);
                    graphics.FillPath(Brushes.LightCyan, vertex.VertexGraphicsPath);
                    graphics.DrawString(number, _font, Brushes.Gray, vertex.X - offsetX, vertex.Y - offsetY);
                }
            }
        }

        private void RedrawEdges(Graphics graphics)
        {
            foreach (var edge in _edges)
            {
                var matrix = new Matrix();

                float angle = (float)(Math.Atan2(edge.V2.Y - edge.V1.Y, edge.V2.X - edge.V1.X) * 180 / Math.PI);

                matrix.RotateAt(angle, new Point((int)edge.V2.X, (int)edge.V2.Y));

                GraphicsPath line = CreateGraphicsPath(CreateLinePath(edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y, angle));
                GraphicsPath arrow = CreateGraphicsPath(CreateArrowPath(edge.V2.ArrowConnectPoint.X, edge.V2.ArrowConnectPoint.Y));

                edge.ChangeGraphicsPaths(line, arrow);

                edge.EdgeArrowGraphicsPath.Transform(matrix);

                string number = $"{edge.Length}";

                float offsetX = (edge.V2.X + edge.V1.X) * 0.02f;
                float offsetY = (edge.V2.Y + edge.V1.Y) * 0.02f;

                float x = (edge.V2.X + edge.V1.X) / 2 - offsetX;
                float y = (edge.V2.Y + edge.V1.Y) / 2 - offsetY;

                float widthMul = 15;
                float height = 25;

                if (edge.IsSelected && _graphAction == GraphActions.Remove)
                {
                    graphics.DrawPath(new Pen(Brushes.Red, _thickness / 2), edge.EdgeLineGraphicsPath);
                    graphics.FillPath(Brushes.Red, edge.EdgeArrowGraphicsPath);

                    graphics.DrawRectangle(new Pen(Brushes.Red, _thickness), x, y, number.Length * widthMul, height);
                }
                else if (_isPathFinded && _graphAction == GraphActions.FindMaxPath)
                {
                    bool isContain = false;

                    for (int i = 0; i < _verticesPath.Count - 1; i++)
                    {
                        if (edge.ContainsVertices(_verticesPath[i], _verticesPath[i + 1]))
                        {
                            graphics.DrawPath(new Pen(Brushes.Red, _thickness / 2), edge.EdgeLineGraphicsPath);
                            graphics.FillPath(Brushes.Red, edge.EdgeArrowGraphicsPath);
                            graphics.DrawRectangle(new Pen(Brushes.Red, _thickness), x, y, number.Length * widthMul, height);
                            isContain = true;
                            break;
                        }
                    }
                    if (!isContain)
                    {
                        graphics.DrawPath(new Pen(Brushes.Gray, _thickness / 2), edge.EdgeLineGraphicsPath);
                        graphics.FillPath(Brushes.Gray, edge.EdgeArrowGraphicsPath);
                        graphics.DrawRectangle(new Pen(Brushes.Gray, _thickness), x, y, number.Length * widthMul, height);
                    }
                }
                else
                {
                    graphics.DrawPath(new Pen(Brushes.Gray, _thickness / 2), edge.EdgeLineGraphicsPath);
                    graphics.FillPath(Brushes.Gray, edge.EdgeArrowGraphicsPath);
                    graphics.DrawRectangle(new Pen(Brushes.Gray, _thickness), x, y, number.Length * widthMul, height);
                }
                graphics.FillRectangle(Brushes.LightCyan, x, y, number.Length * widthMul, height);
                graphics.DrawString(number, _font, Brushes.Gray, x, y);
            }
        }

        private GraphicsPath CreateGraphicsPath(string svgStringData)
        {
            return SvgDocument.FromSvg<SvgDocument>(svgStringData).Path;
        }

        private string CreateLinePath(float x1, float y1, float x2, float y2, float angle)
        {
            float offsetMul = 1.5f;

            x2 = (int)(x2 + -_vertexRadius * offsetMul * Math.Cos(angle * Math.PI / 180));
            y2 = (int)(y2 + -_vertexRadius * offsetMul * Math.Sin(angle * Math.PI / 180));

            return $"<svg width=\"800px\" height=\"800px\" xmlns=\"http://www.w3.org/2000/svg\">\r\n<path d=\"M{x1} {y1} L{x2} {y2}\" stroke-width=\"0\"/>\r\n</svg>";
        }

        private string CreateArrowPath(float x, float y)
        {
            float offset = 12;

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
                CancelVertexConnectionOrAlgorithm();

                e.SuppressKeyPress = true;
            }
        }

        public void OnKeyPressed(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            var textBox = sender as TextBox;

            if (number == 45 && textBox.SelectionStart == 0)
            { }
            else if (!char.IsDigit(number) && number != 8)
            {
                if (!textBox.Text.Contains(','))
                {
                    if (number == 46 || number == 44)
                    {
                        if (textBox.Text.Length == 0 || (textBox.Text.Length == 1 && textBox.Text.Contains('-')))
                        {
                            textBox.Text += "0";
                        }
                        textBox.Text += ",";
                    }
                }
                textBox.Select(textBox.Text.Length, 0);

                e.Handled = true;
            }
            else if (number == 48)
            {
                if (textBox.SelectionStart == 0 && textBox.Text.Length == 0 ||
                    textBox.Text.Contains(',') && textBox.SelectionStart > 1 ||
                    textBox.Text.Contains('-') && textBox.SelectionStart > 1 ||
                    textBox.Text.Any(char.IsDigit) && textBox.SelectionStart > 0)
                { }
                if (textBox.SelectionStart == 1 && textBox.Text.Contains('-'))
                {
                    textBox.Text += "0,";
                    textBox.Select(textBox.Text.Length, 0);
                    e.Handled = true;
                }
                if (textBox.Text.Contains('0') && textBox.SelectionStart == 1)
                {
                    e.Handled = true;
                }
            }
            else if (textBox.Text.Contains('0') && textBox.SelectionStart == 1 && Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void buttonAuthor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автором программы является студент ПГУ им. Шевченко Щербак Георгий", "Проект курсовой работы", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
