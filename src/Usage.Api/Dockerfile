#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Usage.Api/Usage.Api.csproj", "src/Usage.Api/"]
COPY ["src/Usage.Application/Usage.Application.csproj", "src/Usage.Application/"]
COPY ["src/Usage.Domain/Usage.Domain.csproj", "src/Usage.Domain/"]
RUN dotnet restore "src/Usage.Api/Usage.Api.csproj"
COPY . .
WORKDIR "/src/src/Usage.Api"
RUN dotnet build "Usage.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Usage.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Usage.Api.dll"]