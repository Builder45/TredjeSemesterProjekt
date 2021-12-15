#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BeboerWeb.API/BeboerWeb.API.csproj", "BeboerWeb.API/"]
COPY ["BeboerWeb.Persistence/BeboerWeb.Persistence.csproj", "BeboerWeb.Persistence/"]
COPY ["BeboerWeb.Domain/BeboerWeb.Domain.csproj", "BeboerWeb.Domain/"]
COPY ["BeboerWeb.Application/BeboerWeb.Application.csproj", "BeboerWeb.Application/"]
COPY ["BeboerWeb.API.Contract/BeboerWeb.API.Contract.csproj", "BeboerWeb.API.Contract/"]
RUN dotnet restore "BeboerWeb.API/BeboerWeb.API.csproj"
COPY . .
WORKDIR "/src/BeboerWeb.API"
RUN dotnet build "BeboerWeb.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BeboerWeb.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BeboerWeb.API.dll"]
