using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(99);
            tree.Add(37);
            tree.Add(45);
            tree.Add(23);
            tree.Add(3);
            tree.Add(22);
            tree.Add(16);
            tree.DisplayTree();
        }
    }
}
