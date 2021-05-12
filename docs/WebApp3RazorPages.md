Back to [parent README](../README.md)

# WebApp3RazorPages (.net core 3.1)

Dependent project: `Libs/RazorClassLib2`

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

