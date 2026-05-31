---
title: SpaceMission2026

---

# SpaceMission2026

## Overview

SpaceMission2026 is a C# console application that simulates astronauts navigating through a space grid to reach a space station using the shortest available path.

---

1. ##  Features

~~~~ 
* Reads a dynamic space map from the console.
* Supports between 1 and 3 astronauts.
* Finds the shortest path from each astronaut to the destination (`F`).
* Uses the Breadth-First Search (BFS) algorithm for pathfinding.
* Marks the discovered path with `*`.
* Detects astronauts that cannot reach the destination.
* Sorts successful missions by shortest path length.
* Includes input validation and error handling.
* Uses object-oriented design and separation of concerns.
~~~~
---
2. ## Technologies
~~~~
* C#
* .NET
* Object-Oriented Programming (OOP)
* Breadth-First Search (BFS)
* Multidimensional Arrays
* Queue Data Structure
* Git & GitHub
~~~~
---
3. ## Project Structure

* ### Astronaut
~~~~
Represents an astronaut and stores:

* Name
* Starting row
* Starting column
~~~~
* ### MissionResult
~~~~
Stores:

* Astronaut name
* Number of steps
* Final map with the discovered path
~~~~
* ### PathFinder
~~~~
Responsible for:

* BFS traversal
* Path reconstruction
* Shortest path discovery
* Matrix path visualization
~~~~
* ### Program
~~~~
Responsible for:

* Reading input
* Validation
* Creating astronauts
* Executing pathfinding
* Displaying results
~~~~
---

4. ## Algorithm

The application uses Breadth-First Search (BFS) to guarantee the shortest path when all movement costs are equal.

For every visited cell, the previous position is stored in a path matrix. Once the destination is found, the path is reconstructed by tracing backwards from `F` to the astronaut's starting position.

---

## OOP & Design Principles

The project applies:

1. ### Encapsulation

Pathfinding logic is hidden inside the `PathFinder` class.

2. ### Abstraction

`Program.cs` interacts with pathfinding through methods without knowing the internal implementation.

3. ### Single Responsibility Principle (SRP)

* `Astronaut` stores astronaut data.
* `MissionResult` stores mission results.
* `PathFinder` handles pathfinding logic.
* `Program` handles application flow.

4. ### Separation of Concerns

Input, business logic, and output responsibilities are separated into dedicated classes.

---

## Validation

The application validates:

* Multidimensional Arrays
* Number of astronauts
* Presence of a destination (`F`)
* Correct row length
* Invalid map configurations

---

## Future Improvements

Planned improvements:

* Dijkstra algorithm implementation for weighted movement costs (`D` cells).

---

## Learning Outcomes

Through this project I practiced:

* Multidimensional Arrays
* BFS pathfinding
* Queue usage
* Path reconstruction
* OOP design
* SOLID principles
* Refactoring and code organization
* Git/GitHub 

---

![Output](Screenshots/Output.png)

