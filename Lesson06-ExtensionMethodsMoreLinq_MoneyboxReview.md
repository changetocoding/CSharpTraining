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


# Merging datasets
Group homework. Explain next week.
We want to combine the companies and employees. How do you go about doing that? And what return type should we use
```cs
public class Test {
    public ??? Merge(List<Company> companies, List<Employee> employees)
    {
      
    }
}

public class Company
{
    public int CompanyId { get; set; }
    public string Name { get; set; }
}

public class Employee
{
    public int CompanyId { get; set; }
    public string EmployeeName { get; set; }
}

```

# Homework
1. C# pub quiz test. Not allowed to use internet for it
2. Moneybox
3. Improve group project code base


Also have week off. Should do every 5 weeks. You guys need a break
