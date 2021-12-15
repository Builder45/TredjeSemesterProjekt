#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BeboerWeb.MVC/BeboerWeb.MVC.csproj", "BeboerWeb.MVC/"]
COPY ["BeboerWeb.API.Contract/BeboerWeb.API.Contract.csproj", "BeboerWeb.API.Contract/"]
RUN dotnet restore "BeboerWeb.MVC/BeboerWeb.MVC.csproj"
COPY . .
WORKDIR "/src/BeboerWeb.MVC"
RUN dotnet build "BeboerWeb.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BeboerWeb.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BeboerWeb.MVC.dll"]
