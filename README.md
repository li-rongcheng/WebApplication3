# WebApplication3 Solution

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

## App Projects

### Net5WebApi/Net5WebApi

See project [README](Net5WebApi/README.md)

### BlazorApps/BlazorApp1 (.net core 3.0)

See project [README](BlazorApp1/README.md)

### BlazorApps/BlazorApp2 (.net core 3.1)

See project [README](BlazorApp2/README.md)

### WebApp1 (.net core 3.1)

See project [README](WebApp1/README.md)

### WebApp2

See project [README](WebApp2/README.md)

### WebApplication3

See project [README](WebApplication3/README.md)

### WebApp3RazorPages

See project [README](WebApp3RazorPages/README.md)

## WebAssembly Projects

### BlazorAssembly/BlazorWebAssembly3AuthCoreHost

See project [README](BlazorWebAssembly3AuthCoreHost/README.md)

### BlazorAssembly/BlazorWebAssembply2PWA

See project [README](BlazorWebAssembply2PWA/README.md)

## Lib Projects

### Libs/RazorClassLib1 (netstandard2.0, pages)

See project [README](RazorClassLib1/README.md)

### Libs/RazorClassLib2 (netstandard2.0, blazor)

See project [README](RazorClassLib2/README.md)
