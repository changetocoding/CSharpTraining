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

## Task 
Create a console app that:

1. Given a list of strategies returns a time series of monthly capital values for the strategies.

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
