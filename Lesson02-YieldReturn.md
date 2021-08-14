When linkedList over list?

# Generics

# Generics
https://docs.microsoft.com/en-us/dotnet/standard/generics

```cs

```

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


