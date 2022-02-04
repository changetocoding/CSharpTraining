# Null coalasing operators
Ever done this?
```cs
var res = "A useful default";
if (wraps.FirstOrDefault() != null)
{
    if (wraps.FirstOrDefault().Text != null)
    {
        res = wraps.FirstOrDefault().Text;
    }
}
```
There is a simpler way
```cs
var res = wraps.FirstOrDefault()?.Text ?? "A useful default";
```
### Conditional access
```cs
obj?.Value
```
This checks if 'obj' is null, and if it is null does not try to access the property/method. Instead returns null. This prevents null pointer execption throwing when 'obj' is null

### Null coalasing
```cs
var res = obj ?? new MyClass();
```
If the value is of obj is null it will use the value on right hand side of the operator. This is very usefull with nullables (like int?)

### HasValue .Value
For nullables can use the HasValue property to check if it has a value 
```cs
public void MethodName(int? number)
{
    if (number.HasValue)
    {
        DoSomething(number.Value);
    }
}
```
