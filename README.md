# WebApplication

## Overall

Search [MCN] for all mcn noes

## DB generation

- install EF core global command:
  ```
  dotnet tool install -g dotnet-ef
  ```
- do:
  ```
  dotnet-ef migrations add <migration-name>
  dotnet-ef database update
  ```

## Projects


## WebApplication3 (.net core 2.0)

- depends on RazorClassLib1 (netstandard2.0)
- Authentication (login), search "¼òµ¥µÄÓ²±àÂëµÇÂ¼Àý×Ó"
- MediatR, FluentValidation, see:
  - MediatrController.cs
  - files in MediatrExperiment/
- Registering multiple impls to the same interface, see:
  `Experiments/DiMultiImpl.cs`
- GraphQL Demo
  - Playground URL: https://localhost:5001/ui/playground

## WebApp1 (.net core 3.0)

- Areas routing: WebApp1

## WebApp2 (.net core 3.0)

- Depend on RazorClassLib3 (.net core 3.0)
- RCL razor pages (via dependency to RazorClassLib3) 

## Others

RazorClassLib2 
- netstandard2.0, based on razor langage 3.0 of .net core 3.0
- blazor (razor component)

BlazorApp1
- netcoreapp3.0
- Blazor server
