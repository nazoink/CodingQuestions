// src/Project04/Stack/Stack.cs
using System;

namespace StackDemo;

/// <summary>
/// A simple generic LIFO stack implemented with singly-linked nodes.
/// All operations are O(1).
/// </summary>
/// <typeparam name="T">Type of items stored in the stack.</typeparam>
public sealed class Stack<T>
{
	/// <summary>Number of items in the stack.</summary>
	public int Count { get; private set; }

	/// <summary>True when the stack contains no elements.</summary>
	public bool IsEmpty => Count == 0;

	private readonly int? _capacity; // null means unlimited
	private Node? _head;

	private sealed class Node
	{
		public Node(T value, Node? next)
		{
			Value = value;
			Next = next;
		}

		public T Value { get; }
		public Node? Next { get; set; }
	}

	/// <summary>
	/// Creates a stack with unlimited capacity.
	/// </summary>
	public Stack() { }

	/// <summary>
	/// Creates a stack with a maximum number of items.
	/// </summary>
	/// <param name="capacity">Maximum number of items allowed in the stack. Must be positive.</param>
	public Stack(int capacity)
	{
		if (capacity <= 0)
			throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be positive.");
		_capacity = capacity;
	}

	/// <summary>
	/// Pushes an item onto the top of the stack. Throws if the stack is full (when bounded).
	/// </summary>
	/// <param name="item">Item to push (null allowed for reference types).</param>
	public void Push(T item)
	{
		if (_capacity.HasValue && Count == _capacity.Value)
			throw new InvalidOperationException("Stack is full.");
		_head = new Node(item, _head);
		Count++;
	}

	/// <summary>
	/// Removes and returns the item at the top of the stack.
	/// Throws InvalidOperationException if the stack is empty.
	/// </summary>
	/// <returns>Top item</returns>
	public T Pop()
	{
		if (_head is null)
			throw new InvalidOperationException("Stack is empty.");

		var value = _head.Value;
		_head = _head.Next;
		Count--;
		return value;
	}

	/// <summary>
	/// Returns the item at the top of the stack without removing it.
	/// Throws InvalidOperationException if the stack is empty.
	/// </summary>
	public T Peek()
	{
		if (_head is null)
			throw new InvalidOperationException("Stack is empty.");

		return _head.Value;
	}
}
