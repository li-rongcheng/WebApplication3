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

## Experiments

- authentication (login), search "¼òµ¥µÄÓ²±àÂëµÇÂ¼Àý×Ó"
- mediatr, fluentvalidation, see:
  - MediatrController.cs
  - files in MediatrExperiment/
- Registering multiple impls to the same interface, see:
  `Experiments/DiMultiImpl.cs`
