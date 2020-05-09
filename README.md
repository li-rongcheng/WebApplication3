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


### WebApplication3 (.net core 2.2)

- Depends on: RazorClassLib1 (netstandard2.0)

- Authentication (login), search "简单的硬编码登录例子"

- MediatR, FluentValidation, see:
  - MediatrController.cs, will output some error logging messages (just for demo)
  - files in MediatrExperiment/

- Registering multiple impls to the same interface, see: `Experiments/DiMultiImpl.cs`

- GraphQL Demo
  - Playground URL: https://localhost:5001/ui/playground

### WebApp1 (.net core 3.0)

- Areas routing: /RLTestArea

### WebApp2 (.net core 3.0)

- Depends on: RazorClassLib3 (.net core 3.0)
- Demo: can use Areas in RCL even if razor pages enabled (which conflict native areas routing)

### RazorClassLib1

- netstandard2.0, based on razor langage 3.0 of .net core 3.0
- Demo: Areas in RCL
- Referred by: WebApplication3 & WebApp2

### RazorClassLib2

- netstandard2.0, based on razor langage 3.0 of .net core 3.0
- blazor (razor component)

### BlazorApp1

- netcoreapp3.0
- Blazor server
