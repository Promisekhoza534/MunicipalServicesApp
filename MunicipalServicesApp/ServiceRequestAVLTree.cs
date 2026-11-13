
using System;

namespace MunicipalServicesApp
{
    public class AVLRequestNode
    {
        public ServiceRequest Request { get; set; }
        public AVLRequestNode Left { get; set; }
        public AVLRequestNode Right { get; set; }
        public int Height { get; set; }

        public AVLRequestNode(ServiceRequest request)
        {
            Request = request;
            Height = 1;
        }
    }

    public class ServiceRequestAVLTree
    {
        private AVLRequestNode root;

        private int GetHeight(AVLRequestNode node)
        {
            return node == null ? 0 : node.Height;
        }

        private int GetBalance(AVLRequestNode node)
        {
            return node == null ? 0 :
                GetHeight(node.Left) - GetHeight(node.Right);
        }

        private void UpdateHeight(AVLRequestNode node)
        {
            node.Height = 1 + Math.Max(
                GetHeight(node.Left),
                GetHeight(node.Right));
        }

        private AVLRequestNode RotateRight(AVLRequestNode y)
        {
            AVLRequestNode x = y.Left;
            AVLRequestNode temporary = x.Right;

            x.Right = y;
            y.Left = temporary;

            UpdateHeight(y);
            UpdateHeight(x);

            return x;
        }

        private AVLRequestNode RotateLeft(AVLRequestNode x)
        {
            AVLRequestNode y = x.Right;
            AVLRequestNode temporary = y.Left;

            y.Left = x;
            x.Right = temporary;

            UpdateHeight(x);
            UpdateHeight(y);

            return y;
        }

        public void Insert(ServiceRequest request)
        {
            if (request == null)
                return;

            root = InsertNode(root, request);
        }

        private AVLRequestNode InsertNode(
            AVLRequestNode node, ServiceRequest request)
        {
            if (node == null)
                return new AVLRequestNode(request);

            int comparison = string.Compare(
                request.RequestId,
                node.Request.RequestId,
                StringComparison.OrdinalIgnoreCase);

            if (comparison < 0)
                node.Left = InsertNode(node.Left, request);
            else if (comparison > 0)
                node.Right = InsertNode(node.Right, request);
            else
                return node;

            UpdateHeight(node);

            int balance = GetBalance(node);

            // Left-Left case
            if (balance > 1 &&
                string.Compare(request.RequestId,
                    node.Left.Request.RequestId,
                    StringComparison.OrdinalIgnoreCase) < 0)
                return RotateRight(node);

            // Right-Right case
            if (balance < -1 &&
                string.Compare(request.RequestId,
                    node.Right.Request.RequestId,
                    StringComparison.OrdinalIgnoreCase) > 0)
                return RotateLeft(node);

            // Left-Right case
            if (balance > 1 &&
                string.Compare(request.RequestId,
                    node.Left.Request.RequestId,
                    StringComparison.OrdinalIgnoreCase) > 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            // Right-Left case
            if (balance < -1 &&
                string.Compare(request.RequestId,
                    node.Right.Request.RequestId,
                    StringComparison.OrdinalIgnoreCase) < 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        public ServiceRequest Search(string requestId)
        {
            AVLRequestNode current = root;

            while (current != null)
            {
                int comparison = string.Compare(
                    requestId,
                    current.Request.RequestId,
                    StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                    return current.Request;

                current = comparison < 0
                    ? current.Left
                    : current.Right;
            }

            return null;
        }
    }
}
