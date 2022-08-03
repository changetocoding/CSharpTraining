# GSA

I actually got this as part of an interview for a senior role and it's a good task that included a db and webserver. We'll slowly work through it.

## Definitions
In this exercise, the following definitions apply:

(Trading) Strategy – a particular set of rules for managing an investment portfolio, resulting in a profit & loss (P&L) dollar number
each day. Each strategy trades in exactly one region.

Region – a major region of the world: Europe (EU), America (US) or Asia Pacific (AP).

Capital – Dollar amount invested in a strategy. Each strategy can have different amounts invested, and that amount can change
over time.

Daily Return - Daily P&L divided by capital at the start of the month.

## Files Provided
You have been provided with files pnl.csv, capital.csv and properties.csv. These contain source data for the project.

pnl.csv contains P&L data over time for 15 different trading strategies ‘Strategy1’ to ‘Strategy15’. The numbers are US$ P&L on a
single day for the strategy.

capital.csv contains the US$ amounts invested in each strategy at the beginning of the month.

properties.csv contains the (single) region of each strategy.


# Part 1 - Importing Pnl csv
In GSA folder you will find a file "pnl.csv". Your task is to transform it into a list of the _StrategyPnl_ class below:
```cs
    public class StrategyPnl
    {
        public string Strategy { get; set; }
        List<Pnl> Pnls { get; set; }
    }

    public class Pnl
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
```


# Part 2 Console App 
Create a console app that:
0. Import the Capitals


2. Given a list of strategies returns a time series of monthly capital values for the strategies.

e.g. Command:
```
Capital "Strategy1,Strategy2"
```
Response
```
strategy: Strategy1, date: 2017-01-01, capital: 1000
strategy: Strategy2, date: 2017-01-01, capital: 2000
```

2. Cumulative P&Ls
Returns a daily time series of cumulative P&Ls aggregated by region
e.g. Command:
```
cumulative-pnl EU
```
Response
```
date: 2017-01-01, cumulativePnl: 1000
date: 2017-01-01, cumulativePnl: 2000
```

Work together on the task. It may take longer than a week to complete

# Part 3 - Save to db
You task now is to save the pnl, capital and strategies (from properties) into a relational database and table structure

Your strategy class should now look more like this
```cs
    public partial class Strategy
    {
        public Strategy()
        {
            Capital = new HashSet<Capital>();
            Pnl = new HashSet<Pnl>();
        }

        public int StrategyId { get; set; }
        public string StratName { get; set; }
        public string Region { get; set; }

        public ICollection<Capital> Capital { get; set; }
        public ICollection<Pnl> Pnl { get; set; }
    }
```
