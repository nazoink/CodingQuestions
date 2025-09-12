using System;
using DoubleLinkedListDemo;

namespace DoubleLinkedListDemo
{
	internal class Program
	{
		static void Main()
		{
			var cookies = new[]
			{
				new Cookie { Brand = "ChocoCrunch", CaloriesPerServing = 200, Ingredients = "Wheat, Cocoa, Sugar", SugarGrams = 12.5, GrainType = TypeOfGrain.Wheat, IsGlutenFree = false },
				new Cookie { Brand = "OatBite", CaloriesPerServing = 150, Ingredients = "Oat, Honey", SugarGrams = 8.0, GrainType = TypeOfGrain.Oat, IsGlutenFree = false },
				new Cookie { Brand = "SugarSnap", CaloriesPerServing = 220, Ingredients = "Rice, Sugar", SugarGrams = 15.0, GrainType = TypeOfGrain.Rice, IsGlutenFree = true },
				new Cookie { Brand = "Healthie", CaloriesPerServing = 100, Ingredients = "Almond, Corn", SugarGrams = 4.0, GrainType = TypeOfGrain.Almond, IsGlutenFree = true }
			};

			var list = new DoublyLinkedList<Cookie>();

			// AddLast three cookies
			var n1 = list.AddLast(cookies[0]);
			var n2 = list.AddLast(cookies[1]);
			var n3 = list.AddLast(cookies[2]);
			Console.WriteLine("After AddLast:");
			PrintList(list);
			PrintList(list, reverse: true);

			// Insert "Healthie" after "OatBite"
			var n4 = list.InsertAfter(n2, cookies[3]);
			Console.WriteLine("\nAfter InsertAfter OatBite:");
			PrintList(list);

			// Find "SugarSnap" and update Calories
			var sugarSnapNode = list.Find(c => c.Brand == "SugarSnap");
			if (sugarSnapNode != null)
			{
				sugarSnapNode.Value.CaloriesPerServing = 210;
				Console.WriteLine("\nUpdated SugarSnap Calories to 210:");
				PrintList(list);
			}

			// Move "ChocoCrunch" to back
			list.MoveToBack(n1);
			Console.WriteLine("\nAfter MoveToBack ChocoCrunch:");
			PrintList(list);

			// Move "Healthie" to front
			list.MoveToFront(n4);
			Console.WriteLine("\nAfter MoveToFront Healthie:");
			PrintList(list);

			// Swap "OatBite" and "SugarSnap"
			list.Swap(n2, n3);
			Console.WriteLine("\nAfter Swap OatBite and SugarSnap:");
			PrintList(list);

			// Remove "OatBite"
			list.Remove(n2);
			Console.WriteLine("\nAfter Remove OatBite:");
			PrintList(list);
			PrintList(list, reverse: true);

			// Example: Sort by Brand (alphabetical)
			list.Sort((a, b) => string.Compare(a.Brand, b.Brand, StringComparison.Ordinal));
			Console.WriteLine("\nAfter Sort by Brand:");
			PrintList(list);

			// Example: Sort by CaloriesPerServing (ascending)
			list.Sort((a, b) => a.CaloriesPerServing.CompareTo(b.CaloriesPerServing));
			Console.WriteLine("\nAfter Sort by CaloriesPerServing:");
			PrintList(list);
		}

		static void PrintList(DoublyLinkedList<Cookie> list, bool reverse = false)
		{
			Console.WriteLine(reverse ? "Backward:" : "Forward:");
			int i = 0;
			var items = reverse ? list.Backward() : list;
			foreach (var item in items)
			{
				Console.WriteLine($"  [{i++}] {item}");
			}
		}
	}
}


