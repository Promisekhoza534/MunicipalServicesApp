
using System;

namespace MunicipalServicesApp
{
    // A node in the binary tree
    public class ServiceRequestTreeNode
    {
        public string RequestId { get; set; }
        public ServiceRequest Request { get; set; }
        public ServiceRequestTreeNode Left { get; set; }
        public ServiceRequestTreeNode Right { get; set; }

        public ServiceRequestTreeNode(ServiceRequest request)
        {
            RequestId = request.RequestId;
            Request = request;
            Left = null;
            Right = null;
        }
    }

    // Binary Search Tree for service requests
    public class ServiceRequestBinarySearchTree
    {
        private ServiceRequestTreeNode root;

        public void Insert(ServiceRequest request)
        {
            if (request == null)
                return;

            root = InsertNode(root, request);
        }

        private ServiceRequestTreeNode InsertNode(
            ServiceRequestTreeNode current,
            ServiceRequest request)
        {
            if (current == null)
                return new ServiceRequestTreeNode(request);

            int comparison = string.Compare(
                request.RequestId,
                current.RequestId,
                StringComparison.OrdinalIgnoreCase);

            if (comparison < 0)
                current.Left = InsertNode(current.Left, request);
            else if (comparison > 0)
                current.Right = InsertNode(current.Right, request);

            return current;
        }

        public ServiceRequest Search(string requestId)
        {
            ServiceRequestTreeNode current = root;

            while (current != null)
            {
                int comparison = string.Compare(
                    requestId,
                    current.RequestId,
                    StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                    return current.Request;

                if (comparison < 0)
                    current = current.Left;
                else
                    current = current.Right;
            }

            return null;
        }
    }
}