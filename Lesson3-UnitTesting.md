# Unit testing
This was funny - http://web.archive.org/web/20160521015258/https://lostechies.com/derickbailey/2009/02/11/solid-development-principles-in-motivational-pictures/

## Why we test



## TDD - Test driven development



## Triple 'A' - Arrange, Act, Assert


## 


# Homework
From now on when sumbitting your homework you are expected to have a unit test with each one.

Secondly in this course homeworks will be similar to work. Where you gradually work on a project over several weeks and sometimes we'll leave an assignment and come back to it weeks later. This will teach you how to write good maintainable code.

Thirdly how do you fancy group work

## Tasks
### 1. Write unit tests for (gsa part I) assignment  
### 2. Phonebook part I:  
You've been tasked to design the phone book on a phone. 

You should create a command line phone book application that must:
1. Have an option to add a name and an *11* digit number. The number may begin with a 0.
```
STORE david 07900001234
OK
STORE work 02080000110
OK
STORE peter 12345678901
OK
```
2. Have an option to retrieve a number given a name
```
GET peter
OK 12345678901
```
3. Have an option to delete/remove a name. It must return the number of the deleted person to confirm the deletion was successful
```
DEL peter
OK 12345678901
```
4. Have an option to Update the number for a person. Returns the previous number to confirm the update was successful  
```
UPDATE david 07700000000
OK last no was - 07900001234
```
5. (optional for bonus points) Have an option to delete/remove a number. You don't have to return anything
```
DEL 02080000110
OK
```


The only problem is it on one of those old Nokia brick phones. So there is **some** limitations on the storage
6. You only allowed to store 4 characters of the name, or the name as an int
7. You are only allowed to store the telephone number as a long as a string would be too big

These restrictions might cause a name/number pair to accidentally override another but this is acceptable
