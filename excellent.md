# 1. Look for the same or similar solutions to generics in .NET in other technologies, briefly compare them, and create a random list from task 2 in the selected technology.

## Technologies

### Java
- vary similar to C#
- there may be problems with type erasure as stated [here](https://en.wikipedia.org/wiki/Generics_in_Java#Generics_in_throws_clause)

### C++
- generics are created with `template`
- resolved compile time

### Python
- uses `typing`
- as stated [here](https://docs.python.org/3/library/typing.html) runtime dfoes not enforce function and variable type annotation

## Implementation

RandomCollection at [RandomCollection.cpp](./RandomCollection.cpp)


# 2. Do you know about any other query language similar to LINQ? Propose a solution with at least one of the queries from Task 1 in the language

Some:
- Java streams
- python's [pinq](https://macropy3.readthedocs.io/en/latest/pinq.html)
- Javascript and `Array`

Implementation at [index.js](./index.js)