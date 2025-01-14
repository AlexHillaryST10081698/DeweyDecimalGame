// RedBlackTree.cs
using System;
using System.Text;

namespace DeweyDecimalApplication.Classes
{
    public class RedBlackTree<TKey> where TKey : IComparable<TKey>
    {
        public class Node
        {
            public TKey Key;
            public DeweyNode Value; 
            public Node Left, Right;
            public bool IsRed;
            public int Depth; // Added depth property
        }

        private Node root;
        private StringBuilder treeContents = new StringBuilder();

        public void Insert(TKey key, DeweyNode value)
        {
            root = Insert(root, key, value, 0);
            root.IsRed = false;
        }
        public Node GetRoot()
        {
            return root;
        }
        // Inserts data into nodes
        private Node Insert(Node node, TKey key, DeweyNode value, int depth)
        {
            if (node == null)
            {
                return new Node { Key = key, Value = value, IsRed = true, Depth = depth };
            }

            int cmp = key.CompareTo(node.Key);
            if (cmp < 0)
            {
                node.Left = Insert(node.Left, key, value, depth + 1);
            }
            else if (cmp > 0)
            {
                node.Right = Insert(node.Right, key, value, depth + 1);
            }
            else
            {
                // Handle duplicates if necessary
            }

            if (IsRed(node.Right) && !IsRed(node.Left))
                node = RotateLeft(node);
            if (IsRed(node.Left) && IsRed(node.Left.Left))
                node = RotateRight(node);
            if (IsRed(node.Left) && IsRed(node.Right))
                FlipColors(node);

            return node;
        }

        // Handle Colour change
        private bool IsRed(Node node)
        {
            return node != null && node.IsRed;
        }

        private Node RotateLeft(Node h)
        {
            Node x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.IsRed = h.IsRed;
            h.IsRed = true;
            return x;
        }

        private Node RotateRight(Node h)
        {
            Node x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.IsRed = h.IsRed;
            h.IsRed = true;
            return x;
        }

        private void FlipColors(Node h)
        {
            h.IsRed = true;
            h.Left.IsRed = false;
            h.Right.IsRed = false;
        }

        public void PrintTree()
        {
            treeContents.Clear();
            AppendTreeContents(root, 0);
            Console.WriteLine("Red-Black Tree Contents:");
            Console.WriteLine(treeContents.ToString());
        }

        private void AppendTreeContents(Node node, int depth)
        {
            if (node != null)
            {
                AppendTreeContents(node.Left, depth + 1);
                treeContents.AppendLine($"{new string(' ', depth * 2)}{node.Key}: {node.Value.Description}");

                // Include children of the node
                AppendTreeContents(node.Right, depth + 1);
            }
        }

        public string GetTreeContents()
        {
            treeContents.Clear();
            AppendTreeContents(root, 0);
            return treeContents.ToString();
        }
    }
}
