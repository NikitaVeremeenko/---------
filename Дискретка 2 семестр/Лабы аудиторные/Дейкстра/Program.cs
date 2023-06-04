using System;
using System.Collections.Generic;

public class DijkstraAlgorithm
{
    private int VerticesCount;
    private List<Edge>[] AdjacencyList;

    public DijkstraAlgorithm(int verticesCount)
    {
        VerticesCount = verticesCount;
        AdjacencyList = new List<Edge>[verticesCount];
        for (int i = 0; i < verticesCount; i++)
        {
            AdjacencyList[i] = new List<Edge>();
        }
    }

    public void AddEdge(int source, int destination, int weight)
    {
        AdjacencyList[source].Add(new Edge(destination, weight));
        AdjacencyList[destination].Add(new Edge(source, weight));
    }

    public void Dijkstra(int source)
    {
        int[] distances = new int[VerticesCount];
        bool[] visited = new bool[VerticesCount];

        for (int i = 0; i < VerticesCount; i++)
        {
            distances[i] = int.MaxValue;
            visited[i] = false;
        }

        distances[source] = 0;

        for (int count = 0; count < VerticesCount - 1; count++)
        {
            int u = MinimumDistance(distances, visited);
            visited[u] = true;

            foreach (Edge edge in AdjacencyList[u])
            {
                int v = edge.Destination;
                int weight = edge.Weight;

                if (!visited[v] && distances[u] != int.MaxValue && distances[u] + weight < distances[v])
                {
                    distances[v] = distances[u] + weight;
                }
            }
        }

        PrintDistances(distances);
    }

    private int MinimumDistance(int[] distances, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < VerticesCount; v++)
        {
            if (!visited[v] && distances[v] <= min)
            {
                min = distances[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    private void PrintDistances(int[] distances)
    {
        Console.WriteLine("Vertex\tDistance");

        for (int i = 0; i < VerticesCount; i++)
        {
            Console.WriteLine($"{i}\t{distances[i]}");
        }
    }
}

public class Edge
{
    public int Destination { get; }
    public int Weight { get; }

    public Edge(int destination, int weight)
    {
        Destination = destination;
        Weight = weight;
    }
}

public class Program
{
    public static void Main()
    {
        int verticesCount = 12;
        DijkstraAlgorithm dijkstra = new DijkstraAlgorithm(verticesCount);
        
        
        dijkstra.AddEdge(0, 1, 26);
        dijkstra.AddEdge(0, 2, 19);
        dijkstra.AddEdge(0, 3, 86);
        dijkstra.AddEdge(1, 4, 16);
        dijkstra.AddEdge(1, 5, 66);
        dijkstra.AddEdge(2, 6, 4);
        dijkstra.AddEdge(2, 7, 51);
        dijkstra.AddEdge(4, 7, 21);
        dijkstra.AddEdge(6, 8, 21);
        dijkstra.AddEdge(8, 5, 24);
        dijkstra.AddEdge(8, 7, 34);
        dijkstra.AddEdge(5, 9, 13);
        dijkstra.AddEdge(5, 10, 43);
        dijkstra.AddEdge(9, 11, 25);
        dijkstra.AddEdge(10, 3, 31);
        dijkstra.AddEdge(10, 11, 44);
        dijkstra.AddEdge(11, 3, 22);
        dijkstra.AddEdge(7, 10, 9);

        int source = 0;
        dijkstra.Dijkstra(source);
    }
}
