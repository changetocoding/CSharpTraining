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
### Builder pattern
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

An example of how you write the builder pattern (for example this will be useful for generating test cases)
```
    class DateBuilder
    {
        private DateTime _date;

        public DateBuilder()
        {
            _date = DateTime.Today;
        }

        // each builder method returns 'this'
        public DateBuilder Weekend()
        {
            while (_date.DayOfWeek != DayOfWeek.Saturday)
            {
                _date = _date.AddDays(1);
            }
            return this;
        }

        public DateBuilder WithDate(int day, int month, int year)
        {
            _date = new DateTime(year, month, day);
            return this;
        }

        public DateBuilder WithYear(int year)
        {
            _date = new DateTime(year, _date.Month, _date.Day);
            return this;
        }
        
        // The build method returns a constructed object
        public DateTime Build()
        {
            return _date; // normally would return a new object (otherwise next time build called, sharing same object = unexpected things happen) 
            // but as DateTime is immutable no need to do that
        }
    }

// usage
var date = new DateBuilder()
    .WithYear(2022)
    .Weekend()
    .Build();
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

# Class code
```cs
class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Constructor injection
            var myDependency = new MyDependency();
            var myClass = new MyClass(myDependency);
        }
    }

    class MyClass
    {
        private IMyDependency _myDependency;

        public MyClass(IMyDependency myDependency)
        {
            _myDependency = myDependency;  // newing up
        }

        public void Do3(MyDependency otherway)
        {
            // 1. only alive for this method: construct in method
            // 2. Should the control be at a higher level: i.e we are a private method
            // 3. Runtime (mostly data types: value determined when running) vs compile time constant: Contructor injector
            // 4. Reused by multiple methods
            // 5. Testing: Do I need to mock it out

           // var it = new MyDependency();
           _myDependency.Execute();
        }

        public void Do()
        {
            _myDependency.Execute();
        }

        public void Do2()
        {
            _myDependency.Execute();
        }
    }


    interface IMyDependency
    {
        void Execute();
    }

    class MyDependency:IMyDependency
    {
        public virtual void Execute()
        {}
    }
    class MyDependency2 : MyDependency
    {
        public override void Execute()
        {}
    }
```

# Homework
Follow this tutorial: https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage   
Add the factory pattern to an existing project
