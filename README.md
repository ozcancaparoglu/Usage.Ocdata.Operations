# Usage.Ocdata.Operations
Example of using nuget package Ocdata.Operations
# PhoneBook

## Run The Project
You will need the following tools:

* [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
* [.Net Core 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [Docker Desktop](https://www.docker.com/products/docker-desktop)

## Installing

1) First you need to install Docker Desktop on your computer.

2) Right click to the docker-compose and open in terminal then copy and paste the following command;
```csharp
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```
3) On your browser go to http://localhost:5050 to open PgAdmin
  
  Username = test@test.com
  
  Password = Test.11

4) After the login;
  
  Add New Server -> General Name = Whatever you want
  
  Connection Tab -> Host = appdbs
  
  Username = admin
  
  Password = 6wuvirmipwpdd4qnu

5) Open Package Manager Console in project and select Usage.Domain enter the command below
```csharp
Update-Database
```
Migrations are written already.

If all goes well you good to go;

**Usage.Api** => http://localhost:8000/swagger/index

## Notes

- After the 2. step docker will give error and usage.api container will not be working. 

- When step 5 finishes delete the container and image and rerun the command
```csharp
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

this will just reevalute usage.api container and you are good to go with;

http://localhost:8000/swagger/index on your browser.

