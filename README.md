# Wedding Scheduler

This is a test simple project that should help learn how to write tests with XUnit

## Description

Inga and Sasha are getting married. This is a very happy event of their lives! 

But there are also some hustles:
their guests are busy people, it might be quite difficult to pick the day of week when everyone can come 
You can ask "what the hell? Are they true friends if they cannot afford a day-off??" They do love Inga and Sasha
but some of them have problems at the work, so, simply put, they cannot(

This application can help I&S to pick the right day when all the guests can come to their wedding.

The program reads days when guests are working and then should decide whether it is possible to have a wedding with all the guests or not with the following requirements:
 * If it is possible to have a day when everyone can come, the program should write message with the day number
    * if there are more than one day available, weekend days are preferred
 * If there is no day of week when everyone can come, program should write something disappointing   

In the `input.txt` file put N rows, every row describes guest in the following format:
```
<NAME>: <DAY OF WEEK> <DAY OF WEEK> ...
```

An example can be found in the file.

## Task

You need to cover with Unit-tests `WeddingService` using XUnit framework.

## Run Application

To run the application run the following command:
 ```
  docker-compose exec app dotnet run --project App
 ```

## Run Tests

To run tests execute the following command:
 ```
 docker-compose exec app dotnet test App.Tests
```