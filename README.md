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

### Net5WebApi

- .net 5
- Web API project
- Enabled OpenAPI support when creating

Demo:

- Microsoft.ReverseProxy (aka. YARP)
- runtime restart service

### BlazorApp1 (.net core 3.0)

- Depends On: RazorClassLib2
- Blazor server
- Auth **NOT** enabled


Demo:
  - Internal razor component RLTestComponent
  - External razor components in RCL project RazorClassLib2
  - RazorClassLib2.Component2 parameters
  - MatBlazor (server side)

### BlazorApp2 (.net core 3.1)

Created on 2020-07-29, newer than BlazorApp1, for comparing with BlazorApp1,
which uses old blazor app template by vs2019

The main difference is at /Pages/_Host.cshtml

Project setting:

- Auth enabled

### WebApp1 (.net core 3.0)

Demo:
- Areas routing: /RLTestArea
- Electron.NET

### WebApp2

See project [README](WebApp2/README.md)

### WebApplication3

See project [README](WebApplication3/README.md)

### WebApp3RazorPages

See project [README](WebApp3RazorPages/README.md)

## WebAssembly Projects

### BlazorWebAssembly3AuthCoreHost

Blazor WebAssembly app with:
- Asp.net core host enabled (so there are 3 sub-projects for client, server and shared)
- PWA & Auth disabled

Demo:
- MatBlazor (client side)

### BlazorWebAssembply2PWA

Blazor WebAssembly app with:
- PWA enabled
- Auth & Asp.net core host disabled

No demo applied

## Lib Projects

### RazorClassLib1 (netstandard2.0, pages)

- Based on razor langage 3.0 of .net core 3.0
- Demo: Areas in RCL
- Referred by: WebApplication3 & WebApp2

### RazorClassLib2 (netstandard2.0, blazor)

- Based on razor langage 3.0 of .net core 3.0
- demo: blazor (razor component)
- Referred By: WebApp2, WebApp3RazorPages, BlazorApp1

