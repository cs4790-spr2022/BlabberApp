# BlabberApp

BlabberApp a Twitter-like .NETcore class project that will be used throughout this semester.  Each assignment will use the same project directory and be identified using `git tags` such as `hw01`, `hw02`, etc.  I will grade the assignment with the specified tag, so be sure to complete the assignment before you tag it! Both the code and the tag needs to be pushed to Github to receive credit.

You can do your development on your own personal computer or use the class server at `ubuntu-s-1vcpu-1gb-sfo2-01` IP:64.225.37.60

## Homework 02 (90 points)

In this assignment you will be to add business domain classes, interfaces, in-memory storage, and initial unit-tests to your project.

The tag for this assignment will be `hw02`. Use these commands:

- `cd BlabberApp`
- `dotnet new classlib -o DataStore`
- `dotnet new mstest -o DataStoreTest`
- `dotnet new classlib -o Domain`
- `dotnet new mstest -o DomainTest`

Code requirements:

- Create an initial business domain classes.  Such as *ID*, *Notification*, *Blab*. (30 points)
- Create an in-memory DataStore concrete class. (30 points)
- Write unit-tests for the concrete classes. (30 points)



When totally complete execute these `git` commands:

- `git tag vhw02`
- `git push -u master origin`
