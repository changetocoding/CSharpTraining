# Dependency injection 
Not to be confused with 5th SOLID principle (Dependency inversion). I do confuse them all the time... What are other 4.  

Good explaination here [stackoverflow](https://stackoverflow.com/questions/3912504/difference-between-inversion-of-control-dependency-inversion-and-decouplin).
Both trying to achieve decoupling. Dependency Inversion by seperating into classes and libaries. Dependency Injection by magically providing those seperated classes when you need them.

**Magic**. Magic usually bad but dependency injection is simple magic that works well.


## Patterns
Two common problems trying to solve:

1. Object creation
2. Dependencies
3. Singletons

## Object Creation and Dependencies
How to create objects can be problematic. Especially if they have dependencies that they need to work (prefer componsition over inheritance) 

In the beginning was: setting up everything in the constructor. But that was bad. Very bad. Why?
```csharp
public class MyClass {
    public MyClass(){
        myDependency = new MyDependency();
    }
}
```
But sometimes should do it this way. Aka in your dictionary class you created an array is a dependency. But it is internal working that no one needs to know about so should be done above.
But in Moneybox project Account class, the INotificationService & IAccountRepository should not be created within the constructor.

### Constructor Injection
So a common pattern was **Constructor Injection**
```csharp
var myDependency = new MyDependency();
var myClass = new MyClass(myDependency);
```

Much better. This is the best when you do when you have no DI. And useful in alot of cases.

Problems though:
- Can have long chains - imagine takes 5 constructor arguments, and those take thier own.... Example from some code I wrote bellow:
```csharp
var bbgApi = new BloombergDesktopApi(bbgHost, bbgPort);
var pullDbService = new PullDbService();
var genericContractDbService = new GenericContractDbService();
var roller = new Roller(pullDbService);
var pullService = new PullService(pullDbService, bbgApi, genericContractDbService, roller);
var azureFileUpload = new AzureFileService(azureFileStorageConnectionString, azureFileStorageContainer, _log);
var csvExporter = new CsvExporter(pullDbService, azureFileUpload, pullService);
var referenceDataJob = new ReferenceDataJob(new GenericTickBuilderBbgHelper(new BloombergGenericTickerService(bbgApi)), new PositionDbService());
```
- Singletons: see below
- Do this in alot of places. Violates Dont repeat yourself principle. (factory pattern below can solve this)

### Factories & builder pattern
Two other patterns attempt to help with this:
Factories - Can be used to centralise the pace

```csharp
public static class Factory
{
    /// <summary>
    /// Decides which class to instantiate. Can also sort dependencies here too
    /// </summary>
    public static Position Get(int level)
    {
        switch (level)
        {
            case 0:
                return new Manager(new FancyComputer());
            case 1:
            case 2:
                return new Clerk(new BasicComputer());
            default:
                return new Programmer(new FancyComputer());
        }
    }
}

static void Main()
{
    var position = Factory.Get(i);
}
```

```csharp
    public static class Class1Factory
    {
        public static CsvExporter Create()
        {
            var bbgApi = new BloombergDesktopApi(bbgHost, bbgPort);
            var pullDbService = new PullDbService();
            var genericContractDbService = new GenericContractDbService();
            var roller = new Roller(pullDbService);
            var pullService = new PullService(pullDbService, bbgApi, genericContractDbService, roller);
            var azureFileUpload = new AzureFileService(azureFileStorageConnectionString, azureFileStorageContainer, _log);
            var csvExporter = new CsvExporter(pullDbService, azureFileUpload, pullService);
            return csvExporter;
        }
    }
    
    
var it = Class1Factory.Create();
```
Builder pattern. Wont go into it but see it in .net core alot:
```csharp
var server = Host
  .CreateDefaultBuilder(args)
  .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>()
            .UseSerilog();
    })
  .Build();
  
server.Run();
```

## Singletons
Only one instance alive *ever*. This is very important in alot of scenarios, e.g.: Services, Stores.

It is actually a hard problem to solve (Have to prevent someone accidently constructing it somewhere else, 
It has to be done in a thread safe way to prevent a race condition - two threads trying to construct it at the same time,
Constructing it lazily)

This is how to implement it [csharpindepth](https://csharpindepth.com/Articles/Singleton). Read through this as it explains why.
```csharp
public sealed class Singleton
{
    private static readonly Lazy<Singleton> _lazy = new Lazy<Singleton>(() => new Singleton());

    public static Singleton Instance => _lazy.Value;

    private Singleton()
    {
    }
}
```

Depenency injection resolves this: Guarantees only one in the DI store and as long as use that one always all go. No need to write funky code.


# Dependency injection in .net core
.net core web projects come with DI automatically. In your start up can do

```csharp
public class Startup
{
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MyDependencyClass>();            
        services.AddSingleton<IMyService, MyService>();            
        services.AddTransient<DbContext>();
       
        ...
    }
}

public class FirstController{
    public FirstController(MyDependencyClass myClass){
        // Rocks up by magic
    }
}
```

## Lifestyles
Very important.
Singleton: means only one of it. Ever. That gets reused. Solves singleton problem easily  
Transient: Each time requested creates a new one. Good example is db context -> if singleton and another thread calls save changes in middle of your operation then your   operation also gets saved. Not good...  
Scoped



# Homework
Follow this tutorial: https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage
Add the factory pattern to an existing project
