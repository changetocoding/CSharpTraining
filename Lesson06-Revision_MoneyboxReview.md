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

# Merging datasets (sean to teach)
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

Also have week off. Should do every 5 weeks. You guys need a break
