using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Person
{
  public int Id { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public int Age { get; set; }
  public string? City { get; set; }
}

public class PeopleContext : DbContext
{
  public DbSet<Person> People { get; set; }

  public PeopleContext(DbContextOptions<PeopleContext> options) : base(options) { }
}

class Program
{
  static void Main(string[] args)
  {
    var options = new DbContextOptionsBuilder<PeopleContext>()
      .UseInMemoryDatabase(databaseName: "PeopleDb")
      .Options;

    using var context = new PeopleContext(options);
    if (!context.People.Any())
    {
      var people = GenerateMockPeople(1000);
      context.People.AddRange(people);
      context.SaveChanges();
    }

    // Example LINQ query: Get all people older than 30
    var results = context.People.Where(p => p.Age > 30).ToList();
    Console.WriteLine($"People older than 30: {results.Count}");

    // Find the first person named Alex (case-insensitive)
    var firstAlex = context.People.FirstOrDefault(p => p.FirstName != null && p.FirstName.Equals("Alex", StringComparison.OrdinalIgnoreCase));
    if (firstAlex is not null)
    {
      Console.WriteLine($"First Alex: {firstAlex.FirstName} {firstAlex.LastName}, Age: {firstAlex.Age}, City: {firstAlex.City}");
    }
    else
    {
      Console.WriteLine("No person named Alex found.");
    }

    // Lambda query: people with age < 30, select FirstName and Age into anonymous object
    var youngPeople = context.People
      .Where(p => p.Age < 30)
      .Select(p => new { p.FirstName, p.Age })
      .ToList();

    Console.WriteLine($"People younger than 30: {youngPeople.Count}");
    foreach (var person in youngPeople)
    {
      Console.WriteLine($"Name: {person.FirstName}, Age: {person.Age}");
    }
  }

  static List<Person> GenerateMockPeople(int count)
  {
    var firstNames = new[] { "John", "Jane", "Alex", "Chris", "Pat", "Sam", "Taylor", "Jordan", "Morgan", "Casey" };
    var lastNames = new[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Martinez", "Lee" };
    var cities = new[] { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose" };
    var rand = new Random();
    var people = new List<Person>();
    for (int i = 1; i <= count; i++)
    {
      var person = new Person
      {
        Id = i,
        FirstName = firstNames[rand.Next(firstNames.Length)],
        LastName = lastNames[rand.Next(lastNames.Length)],
        Age = rand.Next(18, 80),
        City = cities[rand.Next(cities.Length)]
      };
      people.Add(person);
    }
    return people;
  }
}