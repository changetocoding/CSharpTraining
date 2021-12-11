### Querying
.Where()  
.Any()  

### Updating a record
```csharp
using (var db = new MyContextDB())
{
    var result = db.Books.SingleOrDefault(b => b.BookNumber == bookNumber);
    if (result != null)
    {
        result.SomeValue = "Some new value";
        db.SaveChanges();
    }
}
```

### Relationships aka related entities
Find them annoying (don't mean with Lore). Leads to problems with lazy loading




### Loading related properties
- Lazy loading - When accessed will try to load it.
- Eager Loading using ".Includes()"
- Personally prefer no loading (https://docs.microsoft.com/en-us/ef/core/querying/related-data/eager)

Also with entity framework occassionally tries to do really dumb queries with include so beware of that


### Directly executing a query on db

# Some tips from microsoft
- https://docs.microsoft.com/en-us/ef/core/performance/efficient-querying

### Viewing query entity framework executes
https://docs.microsoft.com/en-us/ef/core/logging-events-diagnostics/simple-logging


### Delete all rows in table
To delete a few rows can do something like this
```
using (var context = new EntityContext())
{
    var toDelete = context.Votes.Where(x => ...);
    context.Votes.RemoveRange(toDelete);
    context.SaveChanges();
}
```
Do not call .ToList() in .Where() as will fetch the data and just want it executed against the database

If deleting all rows above is too slow if more than 1000 rows This is faster (obviously deletes all data in table):
```
using (var context = new EntityContext())
{
    context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TableName]");
    context.SaveChanges();
}
```
Can also instead execute a "Delete ..." command. 

### Unit testing
Unit tests should not connect to your database. End of.

What I do is write my classes so they take data and are agnostic to where data came from (database, website, file)

And have an intergation test project. Here I have code that may hit the database. So here will have a few tests that maybe load or do some interaction with the database. These tests are normally a pain: e.g. a test that tests a method that deletes some rows from the db, you have delete the rows if they are there (incase the last test failed and didnt clean up the data), add the rows, then execute the test.



Put into practise all we've learnt today on your project

1. Deleting rows  
2. Updating by Id  
3. delete entire table  
4. execute sql against database to fetch a sum  
5. Delete through ef an entity and all its relations  
6. Anything else i missed  
