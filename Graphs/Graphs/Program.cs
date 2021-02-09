using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var graph = new Graph();
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);
            var v4 = new Vertex(4);
            var v5 = new Vertex(5);
            var v6 = new Vertex(6);
            var v7 = new Vertex(7);

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);

            graph.AddEdge(v1, v2, 5);
            graph.AddEdge(v1, v3, 3);
            graph.AddEdge(v3, v4, 8);
            graph.AddEdge(v2, v5);
            graph.AddEdge(v2, v6, 4);
            graph.AddEdge(v6, v5, 6);
            graph.AddEdge(v5, v6, 7);

            graph.PrintMatrix(graph);

            graph.PrintList(graph.BFS(v1),v1);
            graph.PrintList(graph.DFS(v1), v1);
            Console.WriteLine("\n");
            graph.PrintMatrix(graph);


            Console.ReadLine();
        }
    }
}
