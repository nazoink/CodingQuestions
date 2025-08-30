using System;

namespace LinkedListApp
{
	// Node class representing each element in the linked list
	public class LinkedListNode
	{
		public string Name { get; set; }
		public DateTime Dob { get; set; }
		public string FavoriteFood { get; set; }
		public LinkedListNode Next { get; set; }

		public LinkedListNode(string name, DateTime dob, string favoriteFood)
		{
			Name = name;
			Dob = dob;
			FavoriteFood = favoriteFood;
			Next = null;
		}
	}

	// LinkedList class
	public class LinkedList
	{
		private LinkedListNode head;

		public void Add(string name, DateTime dob, string favoriteFood)
		{
			var newNode = new LinkedListNode(name, dob, favoriteFood);
			if (head == null)
			{
				head = newNode;
			}
			else
			{
				LinkedListNode current = head;
				while (current.Next != null)
				{
					current = current.Next;
				}
				current.Next = newNode;
			}
		}

		// Remove node at a specific index (0-based)
		public bool RemoveAt(int index)
		{
			if (index < 0 || head == null)
				return false;
			if (index == 0)
			{
				head = head.Next;
				return true;
			}
			LinkedListNode current = head;
			int count = 0;
			while (current.Next != null && count < index - 1)
			{
				current = current.Next;
				count++;
			}
			if (current.Next == null)
				return false;

            var removeAt = current.Next;
			current.Next = current.Next.Next;
            removeAt = null;

			return true;
		}

		// Insert node at a specific index (0-based)
		public bool InsertAt(int index, string name, DateTime dob, string favoriteFood)
		{
			if (index < 0)
				return false;
			var newNode = new LinkedListNode(name, dob, favoriteFood);
			if (index == 0)
			{
				newNode.Next = head;
				head = newNode;
				return true;
			}
			LinkedListNode current = head;
			int count = 0;
			while (current != null && count < index - 1)
			{
				current = current.Next;
				count++;
			}
			if (current == null)
				return false;
			newNode.Next = current.Next;
			current.Next = newNode;
			return true;
		}

		// Sort the linked list by Name (ascending)
		public void SortByName()
		{
			if (head == null || head.Next == null)
				return;
			// Convert to list for sorting
			var nodes = new System.Collections.Generic.List<LinkedListNode>();
			LinkedListNode current = head;
			while (current != null)
			{
				nodes.Add(current);
				current = current.Next;
			}
			nodes.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
			// Rebuild linked list
			for (int i = 0; i < nodes.Count - 1; i++)
			{
				nodes[i].Next = nodes[i + 1];
			}
			nodes[nodes.Count - 1].Next = null;
			head = nodes[0];
		}

		public void PrintAll()
		{
			LinkedListNode current = head;
			while (current != null)
			{
				Console.WriteLine($"Name: {current.Name}, DOB: {current.Dob:yyyy-MM-dd}, Favorite Food: {current.FavoriteFood}");
				current = current.Next;
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var list = new LinkedList();
			list.Add("Alice", new DateTime(1990, 5, 1), "Pizza");
			list.Add("Bob", new DateTime(1985, 12, 15), "Sushi");
			list.Add("Charlie", new DateTime(2000, 7, 23), "Ice Cream");

			Console.WriteLine("Linked List Contents:");
			list.PrintAll();

			// Example: Insert at index 1
			Console.WriteLine("\nInserting 'Diana' at index 1:");
			list.InsertAt(1, "Diana", new DateTime(1995, 3, 10), "Burger");
			list.PrintAll();

			// Example: Remove at index 2
			Console.WriteLine("\nRemoving node at index 2:");
			list.RemoveAt(2);
			list.PrintAll();

			// Example: Sort by Name
			Console.WriteLine("\nSorting by Name:");
			list.SortByName();
			list.PrintAll();
		}
	}
}
