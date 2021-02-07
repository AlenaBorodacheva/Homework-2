using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Graph
    {
        List<Vertex> Vertexes = new List<Vertex>();
        List<Edge> Edges = new List<Edge>();
        List<Vertex> list = new List<Vertex>();
        public int VertexCount => Vertexes.Count;
        public int EdgeCount => Edges.Count;
        public void AddVertex(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }
        public void AddEdge(Vertex from, Vertex to, int weight = 1)
        {
            var edge = new Edge(from, to, weight);
            Edges.Add(edge);
        }
        public int[,] GetMatrix()
        {
            var matrix = new int[Vertexes.Count+1, Vertexes.Count+1];
            foreach (var edge in Edges)
            {
                var row = edge.From.Number;
                var column = edge.To.Number;
                matrix[row, column] = edge.Weight;
            }
            return matrix;
        }
        public void PrintMatrix(Graph graph)
        {
            var matrix = graph.GetMatrix();
            Console.Write("   ");
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.Write(" " + i);
            }
            Console.Write("\n    ");
            for (int j = 0; j < graph.VertexCount; j++)
            {
                Console.Write("_ ");
            }
            Console.WriteLine();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.Write(i + "  |");
                for (int j = 0; j < graph.VertexCount; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public List<Vertex> GetVertexList(Vertex vertex)
        {
            var result = new List<Vertex>();
            foreach (var edge in Edges)
            {
                if(edge.From == vertex)
                {
                    result.Add(edge.To);
                }
            }
            return result;
        }
        public List<Vertex> BFS(Vertex start)
        {
            var list = new List<Vertex> { start };
            for (int i = 0; i < list.Count; i++)
            {
                var vertex = list[i];
                foreach (var v in GetVertexList(vertex))
                {
                    if (!v.Visited)
                    {
                        v.Visited = true;
                        list.Add(v);
                    }
                }
            }
            list.RemoveAt(0);
            return list;
        }

        public List<Vertex> DFS(Vertex start)
        {
            foreach (var v in GetVertexList(start))
            {
                if (!v.Visited)
                {
                    v.Visited = true;
                    list.Add(v);
                    DFS(v);
                }
            }
            return list;
        }
        public void PrintList(List<Vertex> list, Vertex start)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Visited = false;
            }

            Console.WriteLine("\n");
            Console.Write(start.Number + " ");
            foreach (var v in list)
            {
                Console.Write(v.Number + " ");
            }
        }
    }
}
