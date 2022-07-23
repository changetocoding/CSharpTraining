# Using
Can use with anything that implements IDisposable.  

Designed so can say hey before your get rid of me I need to clean up this system resources using outside of c#  
Main use cases:
- Databases
- Files
- Network connections

```csharp
public class MyClass : IDisposable{}
```

How to implement I disposable [here](http://dotnetmentors.com/c-sharp/implementing-finalize-and-dispose-of-net-framework.aspx)

# Files

## Locating/ Working with

```csharp
Directory.GetFiles(path); // Returns a list of FileInfo

Path.Combine(dir, filename);

var file = new FileInfo(path);
if(file.Exists)
{
	file.Rename(...)
}

// or can use this
File.Exists(path)
```

## Reading
Initially stream reader  
```csharp
StringBuilder sb = new StringBuilder();
using (StreamReader sr = new StreamReader("lastupdate.txt")) 
{
    while (sr.Peek() >= 0) 
    {
        sb.Append(sr.ReadLine());
    }
}
textbox.Text = sb.Tostring();
```

Streams is a pattern. 


Then new File api: simpler. No need to remember to close stream
```csharp
var lines = File.ReadAllLines(_path);
foreach (var line in lines)
{
	// Here I convert into my own class
	yield return MyClass.Parse(line);   // Using  a Parse method as C# way of converting text to object. Could have just done through constructor but constructors throwing exceptions is a bit contraverious. I'm for it (You should not be allowed to create a class in a bad state) but some ppl are against it.
}

```


## Writing
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file

```csharp

// Example #3: Write only some strings in an array to a file.
// The using statement automatically flushes AND CLOSES the stream and calls
// IDisposable.Dispose on the stream object.
// NOTE: do not use FileStream for text files because it writes bytes, but StreamWriter
// encodes the output as text.
using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt"))
{
	foreach (string line in lines)
	{
		// If the line doesn't contain the word 'Second', write the line to the file.
		if (!line.Contains("Second"))
		{
			file.WriteLine(line);
		}
	}
}



// WriteAllLines creates a file, writes a collection of strings to the file,
// and then closes the file.  You do NOT need to call Flush() or Close().
System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);

// use write all text if just one string with line breaks in it


File.AppendAllText(path, text + Environment.NewLine)


```


## CSVs
Will not cover but useful to know there is a popular Csv helper library for dealing with csv files: https://joshclose.github.io/CsvHelper/

# Exception handling

Gracefully handle things going horribly wrong

## Throwing exception
```csharp
throw new Exception("The problem");
```

Big difference between throw ex; and throw;!!!  
https://stackoverflow.com/questions/730250/is-there-a-difference-between-throw-and-throw-ex


## Try catch
```csharp
try
{
	Log.Information("Starting web host");
	CreateHostBuilder(args).Build().Run();
	return 0;
}
catch (Exception ex)
{
	Log.Fatal(ex, "Host terminated unexpectedly");
	return 1;
}
finally
{
	// Important!! this is always run even if there is return statement (will get run before return)
	Log.CloseAndFlush();
}
```

## Exceptional scenarios
Thinking: What is exceptional scenario (what is bad scenario).  
What should I do in that scenario
- Return default or failed value
- use default value/ handle the problem/ try alterative method
- Throw exception

When throwing exception:
- Where should this be handled (aka how far up should it propagate
- Do I need to roll back in my catch?

Database principle of all or nothing with commits is useful here. Make sure you've not made partial changes that put your application/data model in a bad state


## Creating your own exception class
Must extend Exception()


# Homework
1. (optional depending on how fast get through others) Create a file searcher application that given a directory and a filename returns files that match the name in that directory
2. New feature on phone book. Saving: Save the names and numbers to a text file automatically when a new name/number is added. Read from that file at the start
3. Review moneybox code time: 



