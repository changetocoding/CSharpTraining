# Async Await

## Describe difference between Async and multithreading
Imagine you want tea. You go to the kitchen you start the kettle. Now you have to wait for it to finish. In JS you would not be able do anything else while you wait.

AJAX behaves more like a human. As soon as you start the kettle (the aysnc request). You can now do something else like check your phone. As soon as the kettle finishes it makes a noise (The interrupt). You stop what you are doing, finish making the tea (Executing the promise), then can go back to whatever you are doing.

This is different from multi-threading/parrallelism. In the above example with Multi-threading you would have two people in the kitchen: One boiling the water, the other doing other stuff.

Another Explaination: https://stackoverflow.com/questions/34680985/what-is-the-difference-between-asynchronous-programming-and-multithreading.

## Async in C#
- Network requests
- Db operations
- Controllers

## How to Async
- Method that contains keyword _async_ and returns _Task_ or _Task_<_T>_
- It must contain at least one await keyword
```cs
public async Task Subscribe(string proposalUniqueId)
{
    await SomeOtherAsyncMethod();
}
```
## Async teaching code
```cs
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var it = new Class1();
await it.DoWork();


internal class Class1
{
    public async Task DoWork()
    {
        Console.WriteLine("Start");
        var task = this.Wait10();
        Console.WriteLine("Do some other work");

        var res = await task;
        Console.WriteLine("The task returned" + res);
    }


    public async Task<int> Wait10()
    {
        var res = 10;
        Console.WriteLine("Pre wait");
        //Thread.Sleep(5 * 1000);
        //await Task.Delay(5 * 1000);
        await Task.Run(() =>
        {
            Thread.Sleep(2 * 1000);
            Console.WriteLine("Any task works");
        });
     
        Console.WriteLine("Control returned");
        return res;
    } 
}
```

When it comes to an async method it will fire off the request but not pause execution until it gets to an await:
```cs
public async Task Subscribe(string proposalUniqueId)
{
    var task1 = FireSomeAsyncMethod();
    var task2 = FireSomeOtherAsyncMethod();
    // do some other tasks
    
    await task2; // Only now will execution be paused until this completes
    await task1; // Only now will execution be paused until this completes
}
```
By pause execution I mean it will give up control until the task is complete. Other code can execute. This is opposed to for example _Thread.Sleep()_ where nothing else can execute until it finishes

    
## Examples
In a signalr hub
```cs
public async Task Subscribe(string proposalUniqueId)
{
    await Groups.AddToGroupAsync(Context.ConnectionId, proposalUniqueId);
    await Clients.Group(proposalUniqueId).SendAsync("newSubscribe");
}
```
        
In a controller
```cs
[HttpPost]
[Route("SupportingDoc")]
public async Task UploadFile(IFormFile file)
{
    await _service.UploadSupportingDoc(file.FileName, file.OpenReadStream());
}
```

Using httpClient
```cs
public class ItProxy
{
        public ItProxy(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<CompanyProfile> GetInfo(string companyNo)
        {
            var client = _httpClientFactory.CreateClient();
            var uriBuilder = new UriBuilder(_urlCompanyInfo + companyNo);
            return await client.GetFromJsonAsync<CompanyProfile>(uriBuilder.Uri).ConfigureAwait(false);
        }
}
```



## Gottachas
### Async all the way concept

### Configure await false
https://devblogs.microsoft.com/dotnet/configureawait-faq/

### Async Task vs Async void
Always use Async Task as callers can await it. The only time to use Async void is when it is an event handler




# Homework
### Reading
- https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/
- https://learn.microsoft.com/en-us/dotnet/csharp/async

### Practice
In an existing project you talk to a database. Convert it to an async program:  
Use SaveChangesAsync and ToListAsync  
Async all the way!
