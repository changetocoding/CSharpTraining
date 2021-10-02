# Hw review
- Moneybox
- Explain Extension methods in next lesson. And static classes
- Other HW

# Code review David's code and what would have done different

# More Linq
## To..
- ToList
- ToDictionary
- ToLookup

## GroupBy

## SelectMany
```cs
    class FileLoad
    {
        public static string[] _folders = new string[] {
            @"C:\Folder1",
        };

        public IEnumerable<string> ListFilesInDirectory()
        {
            var filesForEachFolder = _folders.Select(GetFiles); // what is the type of this?
            var flattened = filesForEachFolder.SelectMany(x => x); // what is the type of this?
            return flattened;
        }

        private static IEnumerable<string> GetFiles(string dir)
        {
            return Directory.GetFiles(dir, "*.html", SearchOption.TopDirectoryOnly).ToList();
        }
    }
```

# Extension Methods
Used to "extend" existing classes.


### Static class
- All methods must be static
- Cannot be initalised (can be used for singleton pattern - Only one instance of class allowed. But much better ways of doing singleton with a dependency injection framework)
- 


Use: 
- Singleton
- Extension Methods
- Constants variables
- BAD: global method

### Reasons:
- Library importing so can't change (unless subclass but problems with that)
- Convience methods don't want to add to a class


### How to write:
- static class
- static method
- Uses this key word



- Get to think about some examples know

```cs 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var list = new List<Mapping>()
            {
                new Mapping("aa", "bb"),
                new Mapping("ae", "bb"),
            };
            Console.WriteLine(string.Join(",", list.All()));
        }
    }

    public class Mapping
    {
        public Mapping(string source, string destination)
        {
            Source = source;
            Destination = destination;
        }

        public string Source { get; }
        public string Destination { get; }
        public string[] All => new string[] { Source, Destination };
    }

    public static class MappingExtensions
    {
        public static IEnumerable<string> All(this IEnumerable<Mapping> it)
        {
            return it.SelectMany(x => x.All).Where(x => x != null).Distinct();
        }
    }
```



# Homework
1. C# pub quiz test. Not allowed to use internet for it
```
Part 1 - Quiz. Can't use internet for these questions. Or visual studio
1. What is SOLID. List all 5
2. What is the difference between struct and class
3. List Data structures in c# e.g. List, ... 
4. What is sealed, abstract and virtual keywords 
5. What are the different access modifiers in c# (e.g. private). And what do they do 
6. What is the difference between "const", "static" and "static readonly" keywords
7. Write a line of code that throws an exception 
8. When should you use stringbuilder 
9. What is the CLR - Common Language Runtime
10. Why are strings immutable
11. What is diff beyween GetType(), is and typeof()
12. How is a dictionary implemented
13. What is the Equals/hashcode contract. Aka why are the equals() and hashcode() important on every method and important. 
14. What happens when there is a collision in a dictionary
15. What is a constructor. Write code for an example
16. What is the difference between method overloading and overriding. Give an example of each 
17. What is the main entry point of a c# application 
18. What is TDD? Explain the 3 steps in it. 
19. Explain difference between ref and out keywords in C#
20. What is the output for executing the following code?
public class TestClass
{
    private string a = "Unchanged";
    
    private void TestMethod(string b)
    {
        var newString = "Changed in TestMethod";
        b = newString;
        Console.WriteLine(b);
    }
    
    public void RunTest()
    {
        TestMethod(a);
        Console.WriteLine(a);
    }
}
var test = new TestClass();
test.RunTest();
```
2. Moneybox
3. Improve group project code base


Also have week off. Should do every 5 weeks. You guys need a break
