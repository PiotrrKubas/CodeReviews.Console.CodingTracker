# Coding Tracker

My second C# CRUD application. 

Console based application to track time spent coding.

## Requirements

- [X] This is an application where you’ll log occurrences of a habit.

- [X] Users need to be able to input the date of the occurrence of the habit

- [X] The application should store and retrieve data from a real database

- [X] When the application starts, it should create a sqlite database, if one isn’t present.

- [X] It should also create a table in the database, where the habit will be logged.

- [X] You'll need to create a "CodingSession" class in a separate file. It will contain the properties of your coding session: Id, StartTime, EndTime, Duration

- [X] You should handle all possible errors so that the application never crashes.

- [X] You need to use Dapper ORM for the data access instead of ADO.NET.

- [X] Follow the DRY Principle, and avoid code repetition.

- [X] Your project needs to contain a Read Me file where you'll explain how your app works.

- [X] To show the data on the console, you should use the "Spectre.Console" library.

- [X] The user shouldn't input the duration of the session. It should be calculated based on the Start and End times, in a separate "CalculateDuration" method.

- [X] The user should be able to input the start and end times manually.

- [X] When reading from the database, you can't use an anonymous object, you have to read your table into a List of Coding Sessions.

## Features

* App will create database and table when they are not currently existing.
* Console based UI
  * 
* Date must be inserted in dd.mm.yyyy format
* Date cannot be in the future
* Every input is protected from potential errors

## Challenges

* I've had a break during this project so i had to work with code that I didn't remember
* Using SQLite commands for the first time was really challenging for me

## Areas to improve

* I need to start planning my code instead of going with the flow
* In next project i will focus on splitting project into more files, working in on big file of code is not great in terms of readability
* I want to get comfortable using Debugger in Visual Studio
* I will start using comments so getting back to code would be easier

## Known issues

* There is a visual bug with stopwatch that I don't know how to fix
