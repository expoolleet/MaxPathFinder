using System.Collections.Generic;

namespace MaxNetworkPathFindingAlgorithm.Classes
{
    internal static class Ford
    {
        public static List<Vertex> FindMaxPath(List<Vertex> vertices, List<Edge> edges, Vertex v1, Vertex v2)
        {
            Vertex.SortListByNumbers(vertices);

            vertices[vertices.IndexOf(v1)].Epsilon = 0;

            var pathVertices = new List<Vertex>() { v1, v2 };

            var pathEdges = new List<Edge>();

            int edgeIndex = 0;

            float max = 0;

            Edge potentialEdge = null;

            for (int i = vertices.IndexOf(v1) + 1; i <= vertices.IndexOf(v2); i++)
            {
                max = 0;

                for (int j = 0; j < edges.Count; j++)
                {
                    if (edges[j].IsLastVertex(vertices[i]))
                    {
                        if (edges[j].ContainsVertices(v1, v2))
                        {
                            potentialEdge = edges[j];
                        }
                        if ((edges[j].V1.Epsilon + edges[j].Length) > max)
                        {
                            max = edges[j].V1.Epsilon + edges[j].Length;
                            edgeIndex = j;
                        }
                    }
                }
                vertices[i].Epsilon = max;

                if (edges.Count != 0)
                {
                    pathEdges.Add(edges[edgeIndex]);
                }
            }
            if (potentialEdge != null && potentialEdge.Length == v2.Epsilon)
            {
                return pathVertices;
            }
            for (int i = vertices.IndexOf(v2); i >= 0; i--)
            {
                foreach (var edge in pathEdges)
                {
                    if (edge.IsLastVertex(vertices[i]))
                    {
                        if (!pathVertices.Contains(edge.V1))
                        {
                            pathVertices.Add(edge.V1);
                            i = edge.V1.Number;
                        }
                    }
                }
            }
            Vertex.SortListByNumbers(pathVertices);

            return pathVertices;
        }
    }
}
