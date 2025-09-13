// See https://aka.ms/new-console-template for more information
// src/Project04/Stack/Program.cs
using System;
using System.Text;

namespace StackDemo;

internal static class Program
{
	static void Main()
	{
		Console.WriteLine("Stack demo: Push, Peek, Pop, IsEmpty\n");

		var stack = new Stack<char>();

		// Push sequence
		Console.WriteLine("Pushing: A, B, C");
		stack.Push('A');
		stack.Push('B');
		stack.Push('C'); // top now 'C'

		// Peek (should be 'C' and should not remove)
		Console.WriteLine($"Peek: {stack.Peek()} (Count: {stack.Count})");
		Console.WriteLine($"IsEmpty: {stack.IsEmpty}\n");

		// Pop sequence
		Console.WriteLine("Popping:");
		while (!stack.IsEmpty)
		{
			Console.WriteLine($"  Pop -> {stack.Pop()} (Remaining: {stack.Count})");
		}
		Console.WriteLine($"IsEmpty after pops: {stack.IsEmpty}\n");

		// Reverse the provided string example
		var input = "I will make this string reversed";
		Console.WriteLine($"Original: {input}");
		var revStack = new Stack<char>();
		foreach (var ch in input) revStack.Push(ch);

		var sb = new StringBuilder();
		while (!revStack.IsEmpty) sb.Append(revStack.Pop());

		Console.WriteLine($"Reversed: {sb}\n");

		// Example: Bounded stack (capacity = 3)
		Console.WriteLine("Bounded stack demo (capacity = 3):");
		var bounded = new Stack<int>(3);
		bounded.Push(10);
		bounded.Push(20);
		bounded.Push(30);
		Console.WriteLine($"Count after 3 pushes: {bounded.Count}");
		try
		{
			Console.WriteLine("Attempting to push 40 (should throw)...");
			bounded.Push(40);
		}
		catch (InvalidOperationException ex)
		{
			Console.WriteLine($"Exception: {ex.Message}");
		}
		Console.WriteLine($"Top of stack: {bounded.Peek()}");
		while (!bounded.IsEmpty)
		{
			Console.WriteLine($"Pop: {bounded.Pop()}");
		}
		Console.WriteLine($"IsEmpty: {bounded.IsEmpty}\n");

		// Other small examples: Peek/Pop on empty to show exception behavior (commented)
		// Uncomment to observe exceptions:
		// var emptyStack = new Stack<int>();
		// var _ = emptyStack.Peek(); // throws InvalidOperationException
	}
}
