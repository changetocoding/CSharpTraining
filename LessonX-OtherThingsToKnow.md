# Should cover earlier. But here we are
Homework
Code review comments from project

## Structs 
Common interview question - "what is the difference between a struct and a class"

https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct

Basically a class
```cs
public struct Coords
{
    public Coords(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }

    public override string ToString() => $"({X}, {Y})";
}
```

From the c# documentation: "Typically, you use structure types to design small data-centric types that provide little or no behavior. For example, .NET uses structure types to represent a number"

Some limitations:
- Must always have a value: Can't be null
- You can't declare a parameterless constructor (Not true anymore but read [this](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct#parameterless-constructors-and-field-initializers))
- Can't inherit


## Properties
```cs


```

## enums
Think of them as what you want to do when you have more options than true or false
```cs
enum Cars
{
    Toyata,
    Ford,
    BMW,
    Ferrari
}
```

This is bad. Why? and what should you use instead
```cs
switch (type)
{
    case "pnl":
        // code
    case "capital":
        // code
    default:
        return null;
}
```
