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


### BlazorApp1 (.net core 3.0)

- Depends On: RazorClassLib2
- Blazor server

Demo:
  - Internal razor component RLTestComponent
  - External razor components in RCL project RazorClassLib2
  - RazorClassLib2.Component2 parameters
  - MatBlazor

### WebApp1 (.net core 3.0)

Demo:
- Areas routing: /RLTestArea
- Electron.NET

### WebApp2 (.net core 3.1)

- Target Framework: .net core 3.1 (upgraded from .net core 3.0)
- Depends on: RazorClassLib1, RazorClassLib2

Demo:
  - Use Areas in RCL even if razor pages enabled (which conflicts with native areas routing)
  - Integrate razor pages with MVC
  - Integrate server side blazor (razor component) for razor pages and MVC
    - See: [Integrate ASP.NET Core Razor components into Razor Pages and MVC apps | Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/core/blazor/integrate-components?view=aspnetcore-3.1)
  - REST API doc using Swashbuckle,
    - See: [Get started with Swashbuckle and ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio)
    - Visit: https://localhost:5001/swagger

### WebApplication3 (.net core 2.2)

- Depends on: RazorClassLib1 (netstandard2.0)
- Authentication (login), search "简单的硬编码登录例子"
- MediatR, FluentValidation, see:
  - MediatrController.cs, will output some error logging messages (just for demo)
  - files in MediatrExperiment/
- Registering multiple impls to the same interface, see: `Experiments/DiMultiImpl.cs`
- GraphQL Demo
  - Playground URL: https://localhost:5001/ui/playground

### WebApp3RazorPages (.net core 3.1)

- Depends on: RazorClassLib2

Demo:
  - Integrate with server side blazor (razor component)
    - See: [Integrate ASP.NET Core Razor components into Razor Pages and MVC apps | Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/core/blazor/integrate-components?view=aspnetcore-3.1)
    - Visit: https://localhost:5001/counter

## WebAssembly Projects

### BlazorWebAssembly3AuthCoreHost

Blazor WebAssembly app with:
- Asp.net core host enabled (so there are 3 sub-projects for client, server and shared)
- PWA & Auth disabled

No demo applied so far

### BlazorWebAssembply2PWA

Blazor WebAssembly app with:
- PWA enabled
- Auth & Asp.net core host disabled

No demo applied so far

## Lib Projects

### RazorClassLib1 (netstandard2.0, pages)

- Based on razor langage 3.0 of .net core 3.0
- Demo: Areas in RCL
- Referred by: WebApplication3 & WebApp2

### RazorClassLib2 (netstandard2.0, blazor)

- Based on razor langage 3.0 of .net core 3.0
- demo: blazor (razor component)
- Referred By: WebApp2, WebApp3RazorPages, BlazorApp1

