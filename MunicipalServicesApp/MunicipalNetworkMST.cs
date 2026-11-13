
using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public class MunicipalNetworkMST
    {
        private class Edge
        {
            public string From;
            public string To;
            public int Weight;

            public Edge(string from, string to, int weight)
            {
                From = from;
                To = to;
                Weight = weight;
            }
        }

        private List<string> vertices = new List<string>();
        private List<Edge> edges = new List<Edge>();

        public MunicipalNetworkMST()
        {
            AddVertex("Municipal Depot");
            AddVertex("Soshanguve");
            AddVertex("Pretoria North");
            AddVertex("Hammanskraal");
            AddVertex("Community Centre");

            // Illustrative connection costs, not real distances.
            AddEdge("Municipal Depot", "Soshanguve", 4);
            AddEdge("Municipal Depot", "Pretoria North", 3);
            AddEdge("Soshanguve", "Hammanskraal", 5);
            AddEdge("Soshanguve", "Community Centre", 2);
            AddEdge("Pretoria North", "Community Centre", 4);
            AddEdge("Pretoria North", "Hammanskraal", 7);
            AddEdge("Community Centre", "Hammanskraal", 3);
        }

        public void AddVertex(string vertex)
        {
            if (!vertices.Contains(vertex))
                vertices.Add(vertex);
        }

        public void AddEdge(string from, string to, int weight)
        {
            AddVertex(from);
            AddVertex(to);

            edges.Add(new Edge(from, to, weight));
        }

        public List<string> BuildMinimumSpanningTree(string start)
        {
            List<string> result = new List<string>();

            if (!vertices.Contains(start))
                return result;

            HashSet<string> visited = new HashSet<string>();
            visited.Add(start);

            int totalWeight = 0;

            while (visited.Count < vertices.Count)
            {
                Edge smallestEdge = null;

                foreach (Edge edge in edges)
                {
                    bool connectsVisitedToUnvisited =
                        (visited.Contains(edge.From) &&
                         !visited.Contains(edge.To)) ||
                        (visited.Contains(edge.To) &&
                         !visited.Contains(edge.From));

                    if (connectsVisitedToUnvisited &&
                        (smallestEdge == null ||
                         edge.Weight < smallestEdge.Weight))
                    {
                        smallestEdge = edge;
                    }
                }

                if (smallestEdge == null)
                {
                    result.Add("The network is disconnected.");
                    return result;
                }

                string newVertex = visited.Contains(smallestEdge.From)
                    ? smallestEdge.To
                    : smallestEdge.From;

                visited.Add(newVertex);
                totalWeight += smallestEdge.Weight;

                result.Add(
                    smallestEdge.From + " - " +
                    smallestEdge.To + " (Weight: " +
                    smallestEdge.Weight + ")");
            }

            result.Add("Total MST Weight: " + totalWeight);

            return result;
        }
    }
}