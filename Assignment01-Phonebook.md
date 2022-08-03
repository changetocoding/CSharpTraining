# Phonebook

# Phonebook part I: Create phonebook
You've been tasked to design the phone book on a phone. 
The only problem is it on one of those old Nokia brick phones. So there is **some** limitations on the storage.


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

## Extenstion to Part 1 (hard):
6. You are only allowed to store the telephone number as a number type. Imagine an old brick phone with limited memory: a string would be too big  

7. (optional for bonus points) You only allowed to store 4 characters of the name, Or if it's easier store the name as an int. These restrictions might cause a name/number pair to accidentally override another but this is acceptable  

# Phonebook part 2:
*Requirements: Lesson on reading a file and exception handling*

Add a New feature on phone book. Saving: Save the names and numbers to a text file automatically when a new name/number is added. Read from that file at the start
