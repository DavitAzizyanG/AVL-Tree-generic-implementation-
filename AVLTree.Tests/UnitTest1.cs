using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AVLTree;

namespace AVLTree.Tests
{
    [TestClass]
    public class AvlTreeUnitTests
    {
        [TestMethod]
        public void Insert()
        {
            AVLTree<int> tree1 = new AVLTree<int>();
            tree1.Add(99);
            tree1.Add(23);
            tree1.Add(45);
            tree1.Add(99);
            tree1.Add(37);
            tree1.Add(16);
            tree1.Add(22);
            tree1.Add(3);
            Assert.AreEqual(tree1.Contains(99), true);
            Assert.AreEqual(tree1.Contains(16), true);
            Assert.AreEqual(tree1.Contains(37), true);
            Assert.AreEqual(tree1.Contains(22), true);
            Assert.AreEqual(tree1.Contains(3), true);
        }
        [TestMethod]
        public void Contains()
        {
            AVLTree<int> tree1 = new AVLTree<int>();
            bool f1 = tree1.Contains(99);
            Assert.AreEqual(f1, false);
            tree1.Add(99);
            tree1.Add(23);
            tree1.Add(45);
            tree1.Add(99);
            tree1.Add(37);
            tree1.Add(16);
            tree1.Add(22);
            tree1.Add(3);
            Assert.AreEqual(tree1.Contains(3), true);
            Assert.AreEqual(tree1.Contains(37), true);
            Assert.AreEqual(tree1.Contains(22), true);
            Assert.AreEqual(tree1.Contains(25), false);
            Assert.AreEqual(tree1.Contains(23), true);
            Assert.AreEqual(tree1.Contains(99), true);
        }
        [TestMethod]
        public void IsEmpty()
        {
            AVLTree<int> tree2 = new AVLTree<int>();
            Assert.AreEqual(tree2.IsEmpty(), true);
            tree2.Add(12);
            Assert.AreEqual(tree2.IsEmpty(), false);
        }
        [TestMethod]
        public void FindMin()
        {
            AVLTree<int> tree1 = new AVLTree<int>();
            tree1.Add(99);
            tree1.Add(23);
            tree1.Add(45);
            tree1.Add(99);
            tree1.Add(37);
            tree1.Add(16);
            tree1.Add(22);
            tree1.Add(3);
            Assert.AreEqual(tree1.FindMin().Item1, true);
            Assert.AreEqual(tree1.FindMin().Item2, 3);
        }
        [TestMethod]
        public void FindMax()
        {
            AVLTree<int> tree1 = new AVLTree<int>();
            tree1.Add(99);
            tree1.Add(23);
            tree1.Add(45);
            tree1.Add(99);
            tree1.Add(37);
            tree1.Add(16);
            tree1.Add(22);
            tree1.Add(3);
            Assert.AreEqual(tree1.FindMax().Item1, true);
            Assert.AreEqual(tree1.FindMax().Item2, 99);
        }
        [TestMethod]
        public void Remove()
        {
            AVLTree<int> tree1 = new AVLTree<int>();
            tree1.Add(99);
            tree1.Add(23);
            tree1.Add(45);
            tree1.Add(99);
            tree1.Add(37);
            tree1.Add(16);
            tree1.Add(22);
            tree1.Add(3);
            Assert.AreEqual(tree1.Contains(45), true);
            tree1.remove(45);
            Assert.AreEqual(tree1.Contains(45), false);
        }
    }
}
