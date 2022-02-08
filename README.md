# Wedding Scheduler

This is a test simple project that should help learn how to write tests with XUnit

## Description

Inga and Sasha are getting married. This is a very happy event of their lives! 

But there are also some hustles:
their guests are busy people, it might be quite difficult to pick the day of week when everyone can come. 
You can ask "What the hell? Are they really true friends if they cannot afford a day-off??" They do love Inga and Sasha
but some of them have problems at the work, so, simply put, they cannot(

This application can help I&S to pick the right day when all the guests can come to their wedding.

The program reads days when guests are working and then should decide whether it is possible to have a wedding with all the guests or not with the following requirements:
 * If it is possible to have a day when everyone can come, the program should write message with the day number when to have a weding
    * if there are more than one day available, the day needs to be picked based on the _weekday priorities_
 * If there is no day of week when everyone can come, program should 
    * write something disappointing 
    * write names of guests that if they were not invited all the rest can make it.
    Of course, I&S wants all the guests come, so the amount of not invited guests should be as small as possible. 
    In case of multiple days available, pick day according to _weekday priorities_   

##### Weekday priorities
 1. Saturday
 2. Sunday
 3. Friday
 4. Thursday
 5. Wednesday
 6. Tuesday
 7. Monday

### Input file

In the `input.txt` file put N rows, every row describes guest in the following format:
```
<NAME>: <DAY OF WEEK> <DAY OF WEEK> ...
```
`<NAME>` - string with the name of the guest

`<DAY OF WEEK>` - the index of the day in the week. 1 - Monday, 2 - Tuesday, ..., 7 - Sunday.
Day of weeks should be separated with one space only. The number should be not less than 1 and not greater than 7.

A built-in example can be found in the file.

## Examples

#### Case 1. Everyone can come to the wedding

Given the following working schedule:

| Guest name | Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday |
|------------|--------|---------|-----------|----------|--------|----------|--------|
| Lev        |        | X       | X         | X        | X      |          |        |
| Mariya     |        | X       | X         | X        | X      |          |        |
| Katya      |        | X       | X         | X        | X      |          |        |
| Lenar      |        |         | X         | X        | X      |          |        |
| Kesha      |        |         |           |          | X      | X        |        |

In this case, no one is working on **Mondays** and **Sundays** and the wedding can be arranged in 
any of these days. Given the _weekday priorities_ Sunday is preferred over Monday, so the program should 
write that it's possible to invite everyone and the picked day will be **Sunday**


#### Case 2. Not everyone can come to the wedding

Given the following working schedule:

| Guest name | Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday |
|------------|--------|---------|-----------|----------|--------|----------|--------|
| Lev        | X      | X       | X         | X        | X      | X        | X      |
| Mariya     |        | X       | X         | X        | X      |          |        |
| Katya      |        | X       | X         | X        | X      |          |        |
| Lenar      |        |         | X         | X        | X      | X        | X      |
| Kesha      |        |         |           |          | X      | X        |        |

In this case, there are no days when everyone is not working. They day when the least people are working is **Monday** (Lev),
so, we we don't invite him, then everyone can come to the wedding

#### Case 3. Guests are very busy people

Given the following working schedule:

| Guest name | Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday |
|------------|--------|---------|-----------|----------|--------|----------|--------|
| Lev        | X      | X       | X         | X        | X      | X        | X      |
| Mariya     |        | X       | X         | X        | X      |          |        |
| Katya      |        | X       | X         | X        | X      |          |        |
| Lenar      | X      | X       | X         | X        | X      | X        | X      |
| Kesha      |        |         |           |          | X      | X        |        |

In this case, there are no days when everyone is not working. Moreover, there are no days 
when just one person cannot make it. Days with least amount of people that cannot make it are:
**Monday** and **Sunday**. Given the _weekday priorities_ Sunday is preferred over Monday, so 
program should propose to not invite Lenar and Lev.

## Task

You need to cover with Unit-tests
  1. `WeddingService`
  2. `Application` 

classes using XUnit framework.
The XUnit framework is already added to the `App.Tests` solution and one simple test is already added 
(`SimpleTest`). Also, to write tests the main solution should be _referenced_. This is already done, 
so you can just start wring tests for the classes from the main project.

The program should meet requirement from the above. There might be some bugs in the program.
Feel free to fix them ;)

For the `Application` class there are some dependencies. It's a good practice to use Mocks for the 
dependencies. It's recommended to use [Moq](https://github.com/moq/moq4) library. Keep in mind that
the library is not included in the project unlike XUnit, so add the library as a dependency for the
test solution. Read more about how to add PackageReference in the solution 
[here](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package)

## Run Application

### Initialization

To initialize the application start containers by executing the following command:

```
docker-compose up -d
```

### Run program

Then, to execute the program, execute the following command:
 ```
  docker-compose exec app dotnet run --project App
 ```

## Run Tests

To run tests execute the following command (application has to be initialized and container is started):
 ```
 docker-compose exec app dotnet test App.Tests
```

## Stop application

To stop application bring down the container with command:

```
docker-compose down
```