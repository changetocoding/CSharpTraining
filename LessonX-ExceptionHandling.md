# Exception Handling
https://docs.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions

## The basics
- Try catch blocks
- You can have multiple catch blocks catching different types of exceptions
- finally always gets executed. Exception or not
```cs
try
{
   it.myPotentiallyThrowsMethod();
}
catch (ArgumentNullException ex)
{
   //code specifically for a ArgumentNullException
}
catch (Exception ex)
{
   //code for any other type of exception
}
finally
{
   //call this if exception occurs or not
  // normally used to clean up something, like disposing a db connection or network request (httpclient)
   it.Dispose();
}         
```
### You can create your own exceptions
```cs
    /// <summary>
    /// Exception to be thrown when number of returned transactions exceeds the hard limit
    /// </summary>
    public class TransactionsLimitExceededException : Exception
    {
        public TransactionsLimitExceededException()
        {
        }

        public TransactionsLimitExceededException(string message)
            : base(message)
        {
        }

        public TransactionsLimitExceededException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
```
### Enable/disable exceptions when debugging in Visual studio
When you run your application within Visual Studio, with the debugger running, you can set Visual Studio to break anytime a C# Exception is thrown. This can help you find exceptions in your code that you did not know existed.

To access Exception Settings, go to Debug -> Windows -> Exception Settings

Under “Common Language Runtime Exceptions” you can select the types of exceptions you want the debugger to break for automatically. I would suggest just toggling the checkbox for all. Once you break on an exception, you can then tell it to ignore that particular type of exception to exclude it, if you would like.
![image](https://user-images.githubusercontent.com/63453969/154751250-cf87c9a9-26c6-4e80-9424-b70017cd2376.png)

## Exceptions
Exceptions are only for exceptional situations. My thought process:

### David's thought process
What is the exceptional scenario (what is bad scenario, what can go wrong).  
What should I do in that scenario
- Return default or failed value
- use default value/ handle the problem/ try alterative method
- Throw exception

When throwing exception:
- Where should this be handled (aka how far up should it propagate)
- Do I need to roll back in my catch statement?

You should always apply the principle of all or nothing that is used in databases: Make sure you've not made partial changes that put your application/data model in a bad state

### In more detail:

1. Can I handle it within this method? Then handle it! Maybe you can retry what you wanted to do.
2. Does it matter if this fails? Unfortunately most of the time it does otherwise why else would you be calling the code... But examples are we store analytics. It doesn't matter if the analytics fail to save as it only affects us the developers so:
```cs
public void SaveAnalyticEvent(Analytic analyticEvent)
{
    try
    {
        _dbContext.Analytics.Add(analyticEvent);
        _dbContext.SaveChanges(); // this can throw an exception. But we don't care...
    }
    catch (Exception ex)
    {
         _logger.Error(ex);
    }
}
```
3. Does the caller need to know something has gone wrong? Then throw.
4. Should I rethrow a better exception
```cs
try
{
    if(input == null) return null; // notice here this is an bad situation they could handle. So they do.
    var dateValue = vectorPair.Split(',');
    var res = GetDateFromValue(float.Parse(dateValue[0])), float.Parse(dateValue[1]);
    return res;
}
catch (Exception)
{
    // here instead of throwing whatever exception from the Parse or index out of bounds from dateValue[1] a more useful error is thrown
    throw new ArgumentException("The string " + dateValue + " was not in the proper format");
}
```
5. TryXXX pattern. e.g. 'dict.TryGetValue[key];' or 'it.FirstOrDefault()'. Sometimes you should provide a version of the method that doesn't throw so the user of your method can make the choice if they care about the error.
6. Where should this be handled. An example is worked on a application that took 10 seconds to calculate data. If the calculation failed in one of the child methods most of the time we wanted it to propogate all the way to the controller and return an error http response. All or nothing.
7. All or nothing: Database transaction style
8. 


## Creating your own exception class
Must extend Exception()
```cs
/// <summary>
/// Exception to be thrown when number of returned transactions exceeds the hard limit
/// </summary>
public class TransactionsLimitExceededException : Exception
{
    public TransactionsLimitExceededException(string message) : base(message)
    {
    }
}
```

## Common pitfalls
### Suppressing exceptions
Don't do this. You are suppressing an exception. 
```cs
try
{
   it.myPotentiallyThrowsMethod();
}
catch ()
{
   // suppress
}
```
At the very least you should log the exception! And if you are suppressing an error then you probably shouldn't be throwing an exception. (Maybe return back a falsy value instead). 
```cs
try
{
   autosave();
}
catch ()
{
   // suppress - File is probably been read. Well we'll retry again in 2 minutes
}
```
### Throw and recatch
https://github.com/sawonorin/moneybox-withdrawal-master/blob/master/src/Moneybox.App/Features/TransferMoney.cs
```cs
public Transaction Execute(Transaction transaction)
{
    try
    {
        var lastTransaction = this._transactionRepository.GetLastTransactionByUserId(transaction.FromAccountId);
        if (lastTransaction != null)
        {
            if (lastTransaction.CompletionTime == null)
            {
                throw new InvalidOperationException("Another transaction is ongoing");
            }
        }

        // other code
        //...

        transaction.Succeeded = true;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Transfer Money Error");
        transaction.Succeeded = false;
        throw;
    }
    finally
    {
        transaction.CompletionTime = DateTime.Now;
        this._transactionRepository.Update(transaction);
    }

    return transaction;
}
```
No point throwing here if you are going to catch it again. Throwing an exception is signifcantly more expensive than doing an if statement.


### Catchall Try at high level
This is playing it way too oversafe and it is bad as it hides exceptions. My policy is that you should just let exceptions happen then fix them: Work out how to prevent them happening or fix the root cause.
```cs
// in a controller
        [HttpPost]
        public void DoIt()
        {
            try {
               DoIt();
            } catch(Exception e){
               _logger.Exception(e);
            }
        }
```

### Not handling exception in right place and throws exception elsewhere
Especially common with null pointer exception: When things go wrong somewhere else, a null is returned, and then attempted to be used in another method. So now things go wrong but the cause is not where the stack trace indicates.

### Throw vs throw ex
https://stackoverflow.com/questions/730250/is-there-a-difference-between-throw-and-throw-ex

- throw ex resets the stack trace (so your errors would appear to originate from your catch statement)
- throw doesn't - the original offender would be preserved.
```cs
private static void Method2()
{
    try
    {
        Method1();
    }
    catch (Exception ex)
    {
        //throw ex resets the stack trace Coming from Method 1 and propogates it to the caller
        throw ex;
    }
}

private static void Method1()
{
    try
    {
        throw new Exception("Inside Method1");
    }
    catch (Exception)
    {
        throw;
    }
}
```
