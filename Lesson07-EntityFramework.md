# Entity framework
Databases. The thing I managed to successfully avoid at Uni only to learn can't work without it...


## Get students to explain what they know and give examples


## ORM
Entity Framework is an [Object-relational mapping library](https://en.wikipedia.org/wiki/Object-relational_mapping). It handles the gritty work so the interface between your application and the database is easier to code.

In past would:
1. Create a db connection
2. Open the db connection
3. Execute whatever sql statement wanted
4. Have to convert the result into the type you needed
5. Close the connection
6. Manage your DB connection pooling

So much code writing. EF solves it.

## EF6 vs EFCore
EF6 is the entity framework for .net framework projects (old .net)
EFCore is for .net core projects. 

They are dev'd in parallel but there are big breaking changes between them. We will focus on EFCore


You already know alot of this so please explain:
1. Connection Strings 
2. Db context
3. Should you use dbcontext in using statements or as is?
4. When does query get executed

### Connection strings.
```csharp
<connectionStrings>
  <add name="cerviondemoEntities" connectionString="metadata=res://*/DatabaseModel.cervionEDM.csdl|res://*/DatabaseModel.cervionEDM.ssdl|res://*/DatabaseModel.cervionEDM.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DEVBOX;initial catalog=cerviondemo;user id=sa;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
</connectionStrings>
```
This is your connection to your database

### Db context
Db context is your api for talking to the database

### Using/IDisposable
IDisposable interface is designed for closing down and releasing resources outside of your system: Like files and db connections.

```csharp
using(var it = new MyResource()){
   ... Do stuff
}
// Resource is released
```

### When query gets executed is important.
*SaveChanges()*: Executes write changes against db. In multithreaded environment have to be careful: If two threads accessing same context and save changes get called by one, the changes of the other thread are also written

*ToList()*: normally for queries


# HW.

## Merging datasets  practise of extension methods too
Group homework. Explain next week.
We want to combine the companies and employees. How do you go about doing that? And what return type should we use

Then write as an extension method
```cs
public class Test {
    public ??? Merge(List<Company> companies, List<Employee> employees)
    {
      
    }
}

public class Company
{
    public int CompanyId { get; set; }
    public string Name { get; set; }
}

public class Employee
{
    public int CompanyId { get; set; }
    public string EmployeeName { get; set; }
}

```

## DB 
- Create a console app that works with the database (inserting new records from the user, querying the database etc...)

### Sql setup
1. Download Sql server mgt. studio: https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15
2. Download sql server express localdb: https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15
3. Download database and restore it to localdb instance: https://docs.microsoft.com/en-us/sql/samples/adventureworks-install-configure?view=sql-server-ver15&tabs=ssms
4. Create new project: Make sure .net core console app. Add Entityframework nuget package (make sure entity framework core one)
5. Crack on

In sql server mgt server was [ComputerName]\SQLEXPRESS
My connection string was "Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;"


