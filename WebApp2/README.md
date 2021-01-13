Back to parent [README](../readme.md)

# WebApp2 (.net core 3.1)

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

