
using System;

namespace MunicipalServicesApp
{
    public enum NodeColor
    {
        Red,
        Black
    }

    public class RedBlackRequestNode
    {
        public ServiceRequest Request { get; set; }
        public RedBlackRequestNode Left { get; set; }
        public RedBlackRequestNode Right { get; set; }
        public RedBlackRequestNode Parent { get; set; }
        public NodeColor Color { get; set; }

        public RedBlackRequestNode(ServiceRequest request)
        {
            Request = request;
            Color = NodeColor.Red;
        }
    }

    public class ServiceRequestRedBlackTree
    {
        private RedBlackRequestNode root;

        public void Insert(ServiceRequest request)
        {
            if (request == null)
                return;

            RedBlackRequestNode newNode =
                new RedBlackRequestNode(request);

            RedBlackRequestNode parent = null;
            RedBlackRequestNode current = root;

            while (current != null)
            {
                parent = current;

                int comparison = string.Compare(
                    request.RequestId,
                    current.Request.RequestId,
                    StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                    return;

                current = comparison < 0
                    ? current.Left
                    : current.Right;
            }

            newNode.Parent = parent;

            if (parent == null)
                root = newNode;
            else if (string.Compare(
                request.RequestId,
                parent.Request.RequestId,
                StringComparison.OrdinalIgnoreCase) < 0)
                parent.Left = newNode;
            else
                parent.Right = newNode;

            FixInsertion(newNode);
        }

        private void FixInsertion(RedBlackRequestNode node)
        {
            while (node != root &&
                   node.Parent.Color == NodeColor.Red)
            {
                if (node.Parent == node.Parent.Parent.Left)
                {
                    RedBlackRequestNode uncle =
                        node.Parent.Parent.Right;

                    if (uncle != null &&
                        uncle.Color == NodeColor.Red)
                    {
                        node.Parent.Color = NodeColor.Black;
                        uncle.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Right)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }

                        node.Parent.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        RotateRight(node.Parent.Parent);
                    }
                }
                else
                {
                    RedBlackRequestNode uncle =
                        node.Parent.Parent.Left;

                    if (uncle != null &&
                        uncle.Color == NodeColor.Red)
                    {
                        node.Parent.Color = NodeColor.Black;
                        uncle.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Left)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }

                        node.Parent.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        RotateLeft(node.Parent.Parent);
                    }
                }
            }

            root.Color = NodeColor.Black;
        }

        private void RotateLeft(RedBlackRequestNode node)
        {
            RedBlackRequestNode rightChild = node.Right;

            node.Right = rightChild.Left;

            if (rightChild.Left != null)
                rightChild.Left.Parent = node;

            rightChild.Parent = node.Parent;

            if (node.Parent == null)
                root = rightChild;
            else if (node == node.Parent.Left)
                node.Parent.Left = rightChild;
            else
                node.Parent.Right = rightChild;

            rightChild.Left = node;
            node.Parent = rightChild;
        }

        private void RotateRight(RedBlackRequestNode node)
        {
            RedBlackRequestNode leftChild = node.Left;

            node.Left = leftChild.Right;

            if (leftChild.Right != null)
                leftChild.Right.Parent = node;

            leftChild.Parent = node.Parent;

            if (node.Parent == null)
                root = leftChild;
            else if (node == node.Parent.Right)
                node.Parent.Right = leftChild;
            else
                node.Parent.Left = leftChild;

            leftChild.Right = node;
            node.Parent = leftChild;
        }

        public ServiceRequest Search(string requestId)
        {
            RedBlackRequestNode current = root;

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
