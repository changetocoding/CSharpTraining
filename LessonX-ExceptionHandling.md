# Exception Handling

## The basics
- Try catch blocks
- You can have multiple catch blocks catching different types of exceptions
- finally always gets executed. Exception or no
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

## Exceptions
Exceptions are only for exceptional situations
1. Can I handle it within this method? Then handle it! Maybe you can retry
2. Does it matter if this fails? Unfortunately most of the time it does otherwise why else would you be calling the code... But examples are 
3. TryXXX pattern. e.g. 'dict.TryGetValue[key];' or 'it.FirstOrDefault()'. Provide a version of the method that doesn't throw so the user of your method can make the choice if they care about the error.
4.

## Common pitfalls
### Suppressing exceptions
Don't do this. You are suppressing an error. 
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
If you are suppressing an error then you probably shouldn't be throwing an exception. (Maybe return back a value instead)
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
No point throwing here if you are 

