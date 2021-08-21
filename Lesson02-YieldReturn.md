When linkedList over list?

# Generics
Compare LinkedList to List<T>. What if wanted to use different type like dateTime

https://docs.microsoft.com/en-us/dotnet/standard/generics

```cs
public class GenericClass<T>
{
    public void Add(T input) { }
}
```
For when you don't know the type.

# Yield return
```cs
        public IEnumerable<int> FourInARow()
        {
            yield return 10;
            yield return 20;
            yield return 15;
            yield return 25;
        }

        public IEnumerable<string> ReadBigrams()
        {
            var lines = File.ReadAllLines("c:\\path");
            List<string> results = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line.StartsWith("0x"))
                {
                    results.Add(Combine(line, next).Replace("Space", "__"));
                }
            }

            return results;
        }

        public string Combine(string first, string second)
        {
            return first + second;
        }

        public string[] _lines = new[]
        {
            "0x000D,10,1,0,,",
            "0x432A,4,6,0,, ",
            "0x432A,4,6,0,, ",
            "0x001D,1,1,0,, ",
            "0x432A,4,6,0,, ",
            "0x432A,4,6,0,, ",
            "0x5011,14,5,0,,",
            "0x001D,10,1,1,,",
            "0x0004,4,2,1,, ",
            "0x432A,4,6,0,, ",
            "0x0006,7,3,1,, ",
            "0x001D,1,1,0,, ",
            "0x432A,4,6,0,, ",
        };
```


# Make your linked list Ienumerable
Implement (Ienumerable)
Example here - https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics
```cs
        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
```

# Gottchas
Yield return - example 4 in a row
Example building list to return ,(common pattern)

Lazy vs eager loading
Enumerating twice (Example for. Break on % 4)

 
# Class Code
```csharp
class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var result = Transform(DateTime.Now, x => x.Year);
            var result2 = TransformToT<int>(DateTime.Now, x => x.Year);

            //var days = NextFourDays().ToList();
            //Console.WriteLine(days.Count());
            //foreach (var item in days)
            //{
            //    Console.WriteLine(item.ToLongDateString());
            //}
            var magic = MagicNumbersEnumerable();
            //Console.WriteLine(magic.ToList().Count());
            foreach (var item in magic.Take(10))
            {
                Console.WriteLine(item);
            }

            // lazy evaluation
            // Ienumberable .ToList, ToDictionary .ToArray or in a foreach
            // Same applies to linq
        }

        // generic
        public static int Transform<T>(T data, Func<T, int> transfrom)
        {
            return transfrom(data);
        }


        // generic
        public static T TransformToT<T>(DateTime data, Func<DateTime, T> transfrom)
        {
            return transfrom(data);
        }

        // return numbers not divisible by 2, 3,5,7,11
        public static IEnumerable<int> MagicNumbers()
        {
            var toReturn = new List<int>();
            int i = 0;
            while (true)
            {
                i++;
                if(i % 2 != 0 && i % 3 != 0 && i % 5 != 0 && i % 7 != 0)
                {
                    toReturn.Add(i);
                }
            }

            return toReturn;
        }

        public static IEnumerable<int> MagicNumbersEnumerable()
        {
            int i = 0;
            while (true)
            {
                i++;
                if (i % 2 != 0 && i % 3 != 0 && i % 5 != 0 && i % 7 != 0)
                {
                    yield return i;
                }
            }
        }

        public static IEnumerable<int> MagicNumbersForLoop()
        {
            var toReturn = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                if(i % 2 != 0 && i % 3 != 0 && i % 5 != 0 && i % 7 != 0)
                {
                    toReturn.Add(i);
                }
            }

            return toReturn;
        }

        public static IEnumerable<int> MagicNumbersEnumerableForLoop()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 != 0 && i % 3 != 0 && i % 5 != 0 && i % 7 != 0)
                {
                    yield return i;
                }
            }
        }


        public static IEnumerable<DateTime> NextFourDays()
        {
            yield return DateTime.Today;
            yield return DateTime.Today.AddDays(1);
            yield return DateTime.Today.AddDays(2);
            yield return DateTime.Today.AddDays(3);
        }
    }
```



# Homework
1. Make linked List generic
2. Count bi-grams. Given a string count character pairs. E.g "See the sea" 
```
se - 2
ee - 1
e_ - 2 (space)
_t - 1
th - 1
_s - 1
ea - 1
```
3. Pnl
In GSA folder you will find a file "pnl.csv". Your task is to transform it into a list of the _StrategyPnl_ class below:
```cs
    public class StrategyPnl
    {
        public string Strategy { get; set; }
        List<Pnl> Pnls { get; set; }
    }

    public class Pnl
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
```

I actually got this as part of an interview for a senior role and it's a good task that included a db and webserver. We'll slowly work through it.




