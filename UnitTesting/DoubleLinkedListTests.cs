using System;
using DoubleLinkedListDemo;
using NUnit.Framework;

namespace UnitTesting
{
    [TestFixture]
    public class DoubleLinkedListTests
    {
        private DoublyLinkedList<Cookie> _list;
        private Cookie _cookie1, _cookie2, _cookie3;

        [SetUp]
        public void SetUp()
        {
            _list = new DoublyLinkedList<Cookie>();
            _cookie1 = new Cookie { Brand = "A", CaloriesPerServing = 100, Ingredients = "Wheat", SugarGrams = 5, GrainType = TypeOfGrain.Wheat, IsGlutenFree = false };
            _cookie2 = new Cookie { Brand = "B", CaloriesPerServing = 120, Ingredients = "Oat", SugarGrams = 6, GrainType = TypeOfGrain.Oat, IsGlutenFree = false };
            _cookie3 = new Cookie { Brand = "C", CaloriesPerServing = 90, Ingredients = "Rice", SugarGrams = 4, GrainType = TypeOfGrain.Rice, IsGlutenFree = true };
        }

        [Test]
        public void Test_AddLast_AddFirst_Count_Traversal()
        {
            // Arrange
            // Act
            var n1 = _list.AddLast(_cookie1);
            var n2 = _list.AddFirst(_cookie2);
            var n3 = _list.AddLast(_cookie3);
            // Assert
            Assert.AreEqual(3, _list.Count);
            CollectionAssert.AreEqual(new[] { _cookie2, _cookie1, _cookie3 }, _list);
            CollectionAssert.AreEqual(new[] { _cookie3, _cookie1, _cookie2 }, _list.Backward());
        }

        [Test]
        public void Test_InsertAfter_InsertBefore()
        {
            // Arrange
            var n1 = _list.AddLast(_cookie1);
            var n2 = _list.AddLast(_cookie2);
            // Act
            var n3 = _list.InsertAfter(n1, _cookie3);
            // Assert
            CollectionAssert.AreEqual(new[] { _cookie1, _cookie3, _cookie2 }, _list);
            var n4 = _list.InsertBefore(n1, new Cookie { Brand = "D" });
            Assert.AreEqual("D", _list.Head.Value.Brand);
        }

        [Test]
        public void Test_Remove_NodeAndCount()
        {
            // Arrange
            var n1 = _list.AddLast(_cookie1);
            var n2 = _list.AddLast(_cookie2);
            // Act
            _list.Remove(n1);
            // Assert
            Assert.AreEqual(1, _list.Count);
            Assert.AreEqual(_cookie2, _list.Head.Value);
            Assert.IsNull(n1.Next);
            Assert.IsNull(n1.Prev);
            Assert.IsNull(n1.List);
        }

        [Test]
        public void Test_MoveToFront_MoveToBack()
        {
            // Arrange
            var n1 = _list.AddLast(_cookie1);
            var n2 = _list.AddLast(_cookie2);
            var n3 = _list.AddLast(_cookie3);
            // Act
            _list.MoveToFront(n3);
            // Assert
            Assert.AreEqual(_cookie3, _list.Head.Value);
            _list.MoveToBack(n3);
            Assert.AreEqual(_cookie3, _list.Tail.Value);
        }

        [Test]
        public void Test_Swap_AdjacentAndNonAdjacent()
        {
            // Arrange
            var n1 = _list.AddLast(_cookie1);
            var n2 = _list.AddLast(_cookie2);
            var n3 = _list.AddLast(_cookie3);
            // Act
            _list.Swap(n1, n3);
            // Assert
            Assert.AreEqual(_cookie3, n1.Value);
            Assert.AreEqual(_cookie1, n3.Value);
            // Adjacent
            _list.Swap(n1, n2);
            Assert.AreEqual(_cookie2, n1.Value);
            Assert.AreEqual(_cookie3, n2.Value);
        }

        [Test]
        public void Test_FindAndUpdate()
        {
            // Arrange
            _list.AddLast(_cookie1);
            _list.AddLast(_cookie2);
            // Act
            var node = _list.Find(c => c.Brand == "B");
            node.Value.CaloriesPerServing = 999;
            // Assert
            Assert.AreEqual(999, _list.Tail.Value.CaloriesPerServing);
        }

        [Test]
        public void Edge_RemoveFromEmpty_Throws()
        {
            // Arrange/Act/Assert
            Assert.Throws<InvalidOperationException>(() => _list.RemoveFirst());
            Assert.Throws<InvalidOperationException>(() => _list.RemoveLast());
        }

        [Test]
        public void Edge_InsertWithNullNode_Throws()
        {
            // Arrange/Act/Assert
            Assert.Throws<ArgumentNullException>(() => _list.InsertAfter(null, _cookie1));
            Assert.Throws<ArgumentNullException>(() => _list.InsertBefore(null, _cookie1));
        }

        [Test]
        public void Edge_RemoveDetachedNode_Throws()
        {
            // Arrange
            var n1 = new Node<Cookie>(_cookie1, null);
            // Act/Assert
            Assert.Throws<InvalidOperationException>(() => _list.Remove(n1));
        }
    }
}
