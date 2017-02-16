using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    public class AVLTree<T>
    where T : IComparable<T>
    {
        class Node<TNode>
            where TNode : IComparable<TNode>
        {
            public TNode data;
            public Node<TNode> left;
            public Node<TNode> right;
            public int height;

            public Node(TNode data)
            {
                this.data = data;
            }
        }
        private Node<T> root;
        static readonly int ALLOWED_IMBALANCE = 1;
        public AVLTree()
        {
            root = null;
        }
        public void Add(T element)
        {
            Insert(element, ref root);
        }
        public bool Contains(T element)
        {
            return Contains(element, root);
        }
        public bool IsEmpty()
        {
            return root == null;
        }
        public Tuple<bool, T> FindMin()
        {
            Node<T> nd = findMin(root);
            if (nd == null)
            {
                return new Tuple<bool, T>(false, default(T));
            }
            else
            {
                return new Tuple<bool, T>(true, nd.data);
            }
        }
        public Tuple<bool, T> FindMax()
        {
            Node<T> nd = findMax(root);
            if (nd == null)
            {
                return new Tuple<bool, T>(false, default(T));
            }
            else
            {
                return new Tuple<bool, T>(true, nd.data);
            }
        }
        public void remove(T element)
        {
            remove(element, ref root);
        }
        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(root);
            Console.WriteLine();
        }
        #region private helper functions
        private void InOrderDisplayTree(Node<T> current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.left);
                Console.WriteLine("({0})", current.data);
                InOrderDisplayTree(current.right);
            }
        }
        private void remove(T element, ref Node<T> t)
        {
            if (t == null)
                return;
            if (element.CompareTo(t.data) < 0)
                remove(element, ref t.left);
            else if (t.data.CompareTo(element) < 0)
                remove(element, ref t.right);
            else if (t.left != null && t.right != null)
            {
                t.data = findMin(t.right).data;
                remove(t.data, ref t.right);
            }
            else
            {
                Node<T> oldNode = t;
                t = (t.left != null) ? t.left : t.right;
            }
            balance(ref t);
        }
        private Node<T> findMin(Node<T> t)
        {
            if (t == null)
                return t;
            if (t.left == null)
                return t;
            return findMin(t.left);
        }
        private Node<T> findMax(Node<T> t)
        {
            if (t == null)
                return t;
            if (t.right == null)
                return t;
            return findMax(t.right);
        }
        private bool Contains(T element, Node<T> t)
        {
            if (t == null)
                return false;
            else if (element.CompareTo(t.data) < 0)
                return Contains(element, t.left);
            else if (t.data.CompareTo(element) < 0)
                return Contains(element, t.right);
            else
                return true;        //Match
        }
        private void Insert(T element, ref Node<T> current)
        {
            if (current == null)
            {
                current = new Node<T>(element);
            }
            else if (element.CompareTo(current.data) < 0)
            {
                Insert(element, ref current.left);
            }
            else if (element.CompareTo(current.data) > 0)
            {
                Insert(element, ref current.right);
            }
            balance(ref current);
            return;
        }
        private int height(Node<T> nod)
        {
            return nod == null ? -1 : nod.height;
        }
        private void balance(ref Node<T> t)
        {
            if (t == null)
                return;
            if (height(t.left) - height(t.right) > ALLOWED_IMBALANCE)
                if (height(t.left.left) >= height(t.left.right))
                    rotateWithLeftChild(ref t);
                else
                    doubleWithLeftChild(ref t);
            else
                if (height(t.right) - height(t.left) > ALLOWED_IMBALANCE)
                    if (height(t.right.right) >= height(t.right.left))
                        rotateWithRightChild(ref t);
                    else
                        doubleWithRightChild(ref t);
            t.height = Math.Max(height(t.left), height(t.right)) + 1;
        }
        private void doubleWithRightChild(ref Node<T> k3)
        {
            rotateWithLeftChild(ref k3.right);
            rotateWithRightChild(ref k3);
        }
        private void rotateWithRightChild(ref Node<T> k2)
        {
            Node<T> k1 = k2.right;
            k2.right = k1.left;
            k1.left = k2;
            k2.height = Math.Max(height(k2.left), height(k2.right)) + 1;
            k1.height = Math.Max(height(k1.left), k2.height) + 1;
            k2 = k1;
        }
        private void doubleWithLeftChild(ref Node<T> k3)
        {
            rotateWithRightChild(ref k3.left);
            rotateWithLeftChild(ref k3);
        }
        private void rotateWithLeftChild(ref Node<T> k2)
        {
            Node<T> k1 = k2.left;
            k2.left = k1.right;
            k1.right = k2;
            k2.height = Math.Max(height(k2.left), height(k2.right)) + 1;
            k1.height = Math.Max(height(k1.left), k2.height) + 1;
            k2 = k1;
        }
        #endregion
    }
}
