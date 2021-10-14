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


## Gottachas
### Async all the way concept

### Configure await false

### Async Task vs Async void