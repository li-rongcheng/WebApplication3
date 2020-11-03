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

### WebApp2 (.net core 3.1)

- Target Framework: .net core 3.1 (upgraded from .net core 3.0)
- Depends on: RazorClassLib1, RazorClassLib2

**Demo for Razor Pages:**
  - Use Areas in RCL even if razor pages enabled (which conflicts with native
    areas routing), demo: https://localhost:5001/myfeature/page1
  - Integrate razor pages with MVC
  - Use razor page layout with mvc layout:
    - Razor page can have its own layout the same with that in mvc, i.e. put
      layout under `Pages/Shared/_Layout.cshtml`, and refer to it in
      `Pages/_ViewStart.cshtml`
    - Demo of using razor page layout with razor component layout, see
      [WebApp3RazorPages (.net core 3.1)](#webapp3razorpages.net-core-3.1)

**Demo for Blazor Server:**
  - Use razor component in RCL, demo: https://localhost:5001/counter
  - Integrate server side blazor (razor component) for razor pages and MVC
    - See: [Integrate ASP.NET Core Razor components into Razor Pages and MVC apps | Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/core/blazor/integrate-components?view=aspnetcore-3.1)

**Demo for REST API:**
  - REST API doc using Swashbuckle,
    - Demo: [Get started with Swashbuckle and ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio)
    - Visit: https://localhost:5001/swagger

### WebApplication3 (.net core 2.2)

- Depends on: RazorClassLib1 (netstandard2.0)
- Authentication (login), search "简单的硬编码登录例子"
- FluentValidation, see: DiController.cs
- MVC global exception filter, see: CustomExceptionFilterAttribute.cs
- Registering multiple impls to the same interface, see: `Experiments/DiMultiImpl.cs`
- GraphQL Demo
  - Playground URL: https://localhost:5001/ui/playground

### WebApp3RazorPages (.net core 3.1)

- Depends on: RazorClassLib2

Demo:
  - Integrate with server side blazor (razor component)
    - See: [Integrate ASP.NET Core Razor components into Razor Pages and MVC apps | Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/core/blazor/integrate-components?view=aspnetcore-3.1)
    - Visit: https://localhost:5001/counter
  - Layout:
    - For razor pages, the default layout is defined in "Pages/_ViewStart.cshtml" 
    - For razor components, the default layout is defined in "Pages/_Host.cshtml"
    - demo about using page layout with mvc, see section [WebApp2 (.net core 3.1)](#webapp2.net-core-3.1)
  - Razor pages routing:
    - If @page does not specify anything, the routing will follow the file path
      under the "Pages" folder, i.e. "Pages/Path1/Page2.cshtml" will be mapped
      to https://localhost:5001/path1/page2
  - Integrate with Vue.js
    - Source: `\WebApp3RazorPages\Pages\Page1.cshtml`
    - Demo: https://localhost:5001/page1

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

