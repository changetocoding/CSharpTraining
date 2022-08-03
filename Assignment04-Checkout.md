# Checkout

Your boss asks you to build a checkout counter (such as in a super market).

We sell products with the following prices:  
A:50, B:30, C:20, D:5

## Task 1
The checkout must process a string of characters like "ACDAB" and calculate the total cost of the items (in this case 155 = (50+20+5+50+30)

Example input output
```
ACB
Total is: 100
```

# Task 2
Marketing has come up with a discount. They want to offer 10% off when you buy more than 10 items.

Submit a new Solution that does this

# Task 3
Marketting has come up with an additional discount to get rid of some old stock:

Discounts: 
-	Buy one get one free on B
-	3 for the price of 2 on D

Submit a solution that has the features from all 3 tasks

Example input output
```
BB
Total is: 30

ADDD
Total is: 60
```

# Task 4 
The stores want to track additional information about the products. Such as weight and Product Type.

Update your solution to use a Product class to represent the products:  
A - price:50, weight: 2, type: Electronics  
B - price:30, weight: 20, type: Household Goods   
C - price:20, weight: 10, type: Groceries  
D - price:5, weight: 1, type: Groceries   
E - price:8, weight: 1.2, type: Groceries   
F - price:25, weight: 1, type: Alcohol   

And output the categories and total weight of the products

Example input output
```
BB
Total is: 30
Weight is: 40
Categories: Household Goods

AED
Total is: 63
Weight is: 4.2
Categories: Electronics, Groceries
```
