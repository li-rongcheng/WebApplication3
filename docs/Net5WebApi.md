Back to [parent README](../README.md)

# Net5WebApi

- .net 5
- Web API project
- Enabled OpenAPI support when creating

## YARP

Demo: Microsoft.ReverseProxy (aka. YARP)

Steps:

- Start this project  
- Navigate to http://localhost:5000, page will be redirected to 6park.com
- From Net5WebApi.Cli project root, execute: `do yarp test http://www.google.com`
- Navigate to http://localhost:5000, page will be redirected to google.com

## Runtime Restart

Demo: Runtime restart asp.net core web application service

Step (approach 1):

- Launch this project by `dotnet run` (not `dotnet watch run`)
- Simply do `ctrl+c`

Steps (approach 2):

- Launch this project by `dotnet run` or `dotnet watch run`
- From Net5WebApi.Cli project root, execute: `do sys reset`

Step (approach 3):

- Launch this project by `dotnet run` or `dotnet watch run`
- Navigate to https://localhost:5001/swagger/index.html
- Execute `/api/WeatherForecast/blow-me-up`

## JWT Auth

Demo: authentication/authorization using JWT token

**Remarks:**

- Use postgresql docker image as database server

**Setups:**

- Install docker desktop, go to directory of `Net5WebApi\docker-compose`, then run:
  
  `docker-compose -f postgresql.yml up`

- Install dotnet-ef:

  `dotnet tool install --global dotnet-ef`

- Go to directory of `Net5WebApi.Data`, then run:

  `update-database.bat`

  > if need to add migration, run `add-migration "some_description"` first
