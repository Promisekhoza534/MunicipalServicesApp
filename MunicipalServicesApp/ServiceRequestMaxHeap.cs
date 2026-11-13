
using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public class ServiceRequestMaxHeap
    {
        private List<ServiceRequest> heap =
            new List<ServiceRequest>();

        private int GetPriority(ServiceRequest request)
        {
            switch (request.Priority.ToLower())
            {
                case "high":
                    return 3;

                case "medium":
                    return 2;

                case "low":
                    return 1;

                default:
                    return 0;
            }
        }

        public int Count
        {
            get { return heap.Count; }
        }

        public void Insert(ServiceRequest request)
        {
            if (request == null)
                return;

            heap.Add(request);

            int current = heap.Count - 1;

            while (current > 0)
            {
                int parent = (current - 1) / 2;

                if (GetPriority(heap[current]) <=
                    GetPriority(heap[parent]))
                    break;

                ServiceRequest temporary = heap[current];
                heap[current] = heap[parent];
                heap[parent] = temporary;

                current = parent;
            }
        }

        public ServiceRequest Peek()
        {
            if (heap.Count == 0)
                return null;

            return heap[0];
        }

        public ServiceRequest RemoveHighestPriority()
        {
            if (heap.Count == 0)
                return null;

            ServiceRequest highest = heap[0];

            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            int current = 0;

            while (true)
            {
                int left = (2 * current) + 1;
                int right = (2 * current) + 2;
                int largest = current;

                if (left < heap.Count &&
                    GetPriority(heap[left]) >
                    GetPriority(heap[largest]))
                {
                    largest = left;
                }

                if (right < heap.Count &&
                    GetPriority(heap[right]) >
                    GetPriority(heap[largest]))
                {
                    largest = right;
                }

                if (largest == current)
                    break;

                ServiceRequest temporary = heap[current];
                heap[current] = heap[largest];
                heap[largest] = temporary;

                current = largest;
            }

            return highest;
        }
    }
}
