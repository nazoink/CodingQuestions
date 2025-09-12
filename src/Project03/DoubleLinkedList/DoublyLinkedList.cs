using System;
using System.Collections;
using System.Collections.Generic;

namespace DoubleLinkedListDemo
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public Node<T>? Head { get; private set; }
        public Node<T>? Tail { get; private set; }
        public int Count { get; private set; }

        public DoublyLinkedList() { }

        /// <summary>
        /// Sorts the linked list in-place using the specified comparer or the default comparer.
        /// </summary>
        public void Sort(IComparer<T>? comparer = null)
        {
            if (Count < 2) return;
            comparer ??= Comparer<T>.Default;
            var values = new List<T>(Count);
            var current = Head;
            while (current != null)
            {
                values.Add(current.Value);
                current = current.Next;
            }
            values.Sort(comparer);
            current = Head;
            int i = 0;
            while (current != null)
            {
                current.Value = values[i++];
                current = current.Next;
            }
        }

        /// <summary>
        /// Sorts the linked list in-place using the specified comparison delegate.
        /// </summary>
        public void Sort(Comparison<T> comparison)
        {
            if (Count < 2) return;
            var values = new List<T>(Count);
            var current = Head;
            while (current != null)
            {
                values.Add(current.Value);
                current = current.Next;
            }
            values.Sort(comparison);
            current = Head;
            int i = 0;
            while (current != null)
            {
                current.Value = values[i++];
                current = current.Next;
            }
        }

        public Node<T> AddFirst(T value)
        {
            var node = new Node<T>(value, this);
            if (Head is null)
            {
                Head = Tail = node;
            }
            else
            {
                node.Next = Head;
                Head.Prev = node;
                Head = node;
            }
            Count++;
            return node;
        }

        public Node<T> AddLast(T value)
        {
            var node = new Node<T>(value, this);
            if (Tail is null)
            {
                Head = Tail = node;
            }
            else
            {
                node.Prev = Tail;
                Tail.Next = node;
                Tail = node;
            }
            Count++;
            return node;
        }

        public Node<T> InsertAfter(Node<T> node, T value)
        {
            ValidateNode(node);
            var newNode = new Node<T>(value, this);
            newNode.Prev = node;
            newNode.Next = node.Next;
            if (node.Next != null)
                node.Next.Prev = newNode;
            node.Next = newNode;
            if (Tail == node)
                Tail = newNode;
            Count++;
            return newNode;
        }

        public Node<T> InsertBefore(Node<T> node, T value)
        {
            ValidateNode(node);
            var newNode = new Node<T>(value, this);
            newNode.Next = node;
            newNode.Prev = node.Prev;
            if (node.Prev != null)
                node.Prev.Next = newNode;
            node.Prev = newNode;
            if (Head == node)
                Head = newNode;
            Count++;
            return newNode;
        }

        public void Remove(Node<T> node)
        {
            ValidateNode(node);
            if (node.Prev != null)
                node.Prev.Next = node.Next;
            else
                Head = node.Next;
            if (node.Next != null)
                node.Next.Prev = node.Prev;
            else
                Tail = node.Prev;
            node.Next = node.Prev = null;
            node.List = null;
            Count--;
        }

        public void RemoveFirst()
        {
            if (Head is null)
                throw new InvalidOperationException("List is empty");
            Remove(Head);
        }

        public void RemoveLast()
        {
            if (Tail is null)
                throw new InvalidOperationException("List is empty");
            Remove(Tail);
        }

        public Node<T>? Find(Predicate<T> match)
        {
            var current = Head;
            while (current != null)
            {
                if (match(current.Value))
                    return current;
                current = current.Next;
            }
            return null;
        }

        public void MoveToFront(Node<T> node)
        {
            ValidateNode(node);
            if (Head == node) return;
            Remove(node);
            AddFirst(node.Value);
        }

        public void MoveToBack(Node<T> node)
        {
            ValidateNode(node);
            if (Tail == node) return;
            Remove(node);
            AddLast(node.Value);
        }

        public void MoveAfter(Node<T> node, Node<T> after)
        {
            ValidateNode(node);
            ValidateNode(after);
            if (node == after) return;
            Remove(node);
            InsertAfter(after, node.Value);
        }

        public void Swap(Node<T> a, Node<T> b)
        {
            ValidateNode(a);
            ValidateNode(b);
            if (a == b) return;
            var temp = a.Value;
            a.Value = b.Value;
            b.Value = temp;
        }

        public void Clear()
        {
            var current = Head;
            while (current != null)
            {
                var next = current.Next;
                current.Next = current.Prev = null;
                current.List = null;
                current = next;
            }
            Head = Tail = null;
            Count = 0;
        }

        private void ValidateNode(Node<T> node)
        {
            if (node is null)
                throw new ArgumentNullException(nameof(node));
            if (node.List != this)
                throw new InvalidOperationException("Node does not belong to this list");
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerable<T> Backward()
        {
            var current = Tail;
            while (current != null)
            {
                yield return current.Value;
                current = current.Prev;
            }
        }
    }
}
