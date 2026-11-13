
using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public class ServiceRequestGraph
    {
        private Dictionary<string, List<string>> adjacencyList =
            new Dictionary<string, List<string>>();

        public ServiceRequestGraph()
        {
            AddVertex("Submitted");
            AddVertex("Assigned");
            AddVertex("In Progress");
            AddVertex("Completed");
            AddVertex("Rejected");

            AddEdge("Submitted", "Assigned");
            AddEdge("Assigned", "In Progress");
            AddEdge("In Progress", "Completed");
            AddEdge("Submitted", "Rejected");
        }

        public void AddVertex(string vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = new List<string>();
            }
        }

        public void AddEdge(string from, string to)
        {
            AddVertex(from);
            AddVertex(to);

            if (!adjacencyList[from].Contains(to))
            {
                adjacencyList[from].Add(to);
            }
        }

        // Breadth-First Search
        public List<string> BreadthFirstSearch(string start)
        {
            List<string> result = new List<string>();

            if (!adjacencyList.ContainsKey(start))
                return result;

            Queue<string> queue = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                result.Add(current);

                foreach (string neighbour in adjacencyList[current])
                {
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(neighbour);
                        queue.Enqueue(neighbour);
                    }
                }
            }

            return result;
        }

        // Depth-First Search
        public List<string> DepthFirstSearch(string start)
        {
            List<string> result = new List<string>();
            HashSet<string> visited = new HashSet<string>();

            if (adjacencyList.ContainsKey(start))
            {
                DFSHelper(start, visited, result);
            }

            return result;
        }

        private void DFSHelper(
            string current,
            HashSet<string> visited,
            List<string> result)
        {
            visited.Add(current);
            result.Add(current);

            foreach (string neighbour in adjacencyList[current])
            {
                if (!visited.Contains(neighbour))
                {
                    DFSHelper(neighbour, visited, result);
                }
            }
        }
    }
}
