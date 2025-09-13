// UnitTesting/StackTests.cs
using System.Text;
using NUnit.Framework;
using StackDemo;

namespace UnitTesting;

[TestFixture]
public class StackTests
{
	[Test]
	public void PushPop_HappyPath()
	{
		// Arrange
		var s = new Stack<int>();
		s.Push(1);
		s.Push(2);
		s.Push(3);

		// Act / Assert
		// Act & Assert
		Assert.AreEqual(3, s.Pop());
		Assert.AreEqual(2, s.Pop());
		Assert.AreEqual(1, s.Pop());
		Assert.IsTrue(s.IsEmpty);
		Assert.AreEqual(0, s.Count);
	}

	[Test]
	public void Peek_DoesNotRemove()
	{
		// Arrange
		var s = new Stack<string>();
		s.Push("x");

		// Act
		var top = s.Peek();

		// Assert
		Assert.AreEqual("x", top);
		Assert.IsFalse(s.IsEmpty);
		Assert.AreEqual(1, s.Count);
	}

	[Test]
	public void Pop_OnEmpty_ThrowsInvalidOperationException()
	{
		// Arrange
		var s = new Stack<int>();

		// Act / Assert
		var ex = Assert.Throws<InvalidOperationException>(() => s.Pop());
		Assert.AreEqual("Stack is empty.", ex?.Message);
	}

	[Test]
	public void Peek_OnEmpty_ThrowsInvalidOperationException()
	{
		// Arrange
		var s = new Stack<int>();

		// Act / Assert
		var ex = Assert.Throws<InvalidOperationException>(() => s.Peek());
		Assert.AreEqual("Stack is empty.", ex?.Message);
	}

	[Test]
	public void ReverseString_UsingStack_Works()
	{
		// Arrange
		var input = "abcdef";
		var s = new Stack<char>();
		foreach (var c in input) s.Push(c);

		// Act
		var sb = new StringBuilder();
		while (!s.IsEmpty) sb.Append(s.Pop());
		var reversed = sb.ToString();

		// Assert
		Assert.AreEqual("fedcba", reversed);
	}

	[Test]
	public void BoundedStack_PushUpToCapacity_AllowsPushes()
	{
		// Arrange
		var s = new Stack<int>(2);
		s.Push(1);
		s.Push(2);

		// Assert
		Assert.AreEqual(2, s.Count);
		Assert.AreEqual(2, s.Peek());
	}

	[Test]
	public void BoundedStack_PushOverCapacity_Throws()
	{
		// Arrange
		var s = new Stack<int>(2);
		s.Push(1);
		s.Push(2);

		// Act & Assert
		var ex = Assert.Throws<InvalidOperationException>(() => s.Push(3));
		Assert.AreEqual("Stack is full.", ex?.Message);
	}

	[Test]
	public void BoundedStack_PopAndPeek_WorkAsExpected()
	{
		// Arrange
		var s = new Stack<string>(2);
		s.Push("a");
		s.Push("b");

		// Act & Assert
		Assert.AreEqual("b", s.Peek());
		Assert.AreEqual("b", s.Pop());
		Assert.AreEqual("a", s.Pop());
		Assert.IsTrue(s.IsEmpty);
	}
}
