


Resources
- Internet access
- https://github.com/zbma/linq-exercises


Objectives
- All the class should 



Home work
```
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main()
	{
		var people = new List<Person>()
		{
			new Person("Bill", "Smith", 41),
			new Person("Sarah", "Jones", 22),
			new Person("Stacy","Baker", 21),
			new Person("Vivianne","Dexter", 19 ),
			new Person("Bob","Smith", 49 ),
			new Person("Brett","Baker", 51 ),
			new Person("Mark","Parker", 19),
			new Person("Alice","Thompson", 18),
			new Person("Evelyn","Thompson", 58 ),
			new Person("Mort","Martin", 58),
			new Person("Eugene","deLauter", 84 ),
			new Person("Gail","Dawson", 19 ),
		};
		
		//write linq statement for the people with last name that starts with the letter D

		
    
		//write linq statement for all the people who are have the surname Thompson and Baker. Write all the first names to the console

    
		//Console.WriteLine("Number of people who's last name starts with the letter D " + people1.Count());
		
		//Write linq statement for first Person Older Than 40 In Descending Alphabetical Order By First Name
		//var person2 = people ;
		
		//Console.WriteLine("First Person Older Than 40 in Descending Order by First Name " + person2.ToString());
    
    // write a linq statement that finds all the people who are part of a family. (aka there is at least one other person with the same surname. This will involve using more than linq
	
	public class Person
	{
		public Person(string firstName, string lastName, int age)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;
		}
		
		public string FirstName {get;set;}
		public string LastName {get;set;}
		public int Age {get;set;}
		
		//override ToString to return the person's FirstName LastName Age
	}
}
```
