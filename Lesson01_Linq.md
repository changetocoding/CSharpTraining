
# Resources
- Internet access
- https://github.com/zbma/linq-exercises


# Objectives
- Understand common linq functions groupby, sum, select, where


# Code
Linq: Pull vs push

IEnumerable: you can iterate through me

Have to implement 3 things

yield return keyword as simpler way of doing it.



1. Lists, Arrays ...

2. Iterate

3 for ... /if ... 

4. Ienumberable : list, array, dictionary ... implements this.

5. foreach 
iteratble.GetEnumerator();
iteratble.MoveNext();
var a = iteratble.Current()
// Call user code within braces {...}

6. Anyone can define thier own Ienumberable

7. Linq - since enumberables are so important. Lets create some helper methods to do common stuff on them. But we work out how to do it efficently and lazily so you dont have to


8. Yield Return Keywords
        public static IEnumerable<int> DavidsEnumerable2YieldImpl()
        {
            var i = 0;
            while (true)
            {
                yield return i;
                i++;
				
		if(i>100)
			yield break;
            }
        }


9. Lazily executed. Only executes when you need it to


# Home work
```csharp
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
	
	
		//1. write linq display every name ordered alphabetically
		
		//1. write linq statement for the people with last name that starts with the letter D
		//Console.WriteLine("Number of people who's last name starts with the letter D " + people1.Count());


    
		//2. write linq statement for all the people who are have the surname Thompson and Baker. Write all the first names to the console



		//3. write linq to convert the list of people to a dictionary keyed by first name
    
		
		// 4. Write linq statement for first Person Older Than 40 In Descending Alphabetical Order By First Name
		//Console.WriteLine("First Person Older Than 40 in Descending Order by First Name " + person2.ToString());
    
    //5. write a linq statement that finds all the people who are part of a family. (aka there is at least one other person with the same surname.
    
                //6. Write a linq statement that finds which of the following numbers are multiples of 4 or 6
            List<int> mixedNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };


            // 7. How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
	
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

	
```
    public interface ILinkedList
    {
        /// <summary>
        /// add at position
        /// </summary>
        void Add(int postion, string data);
        /// <summary>
        /// add after data
        /// </summary>
        void Add(string dataToAddAfter, string nextData);
        /// <summary>
        /// add at start
        /// </summary>
        void Add(string data);


        void Delete(int postion);
        void Delete(string data);

        string Get(int position);

        string Replace(string oldData, string newData);
    }	
```
