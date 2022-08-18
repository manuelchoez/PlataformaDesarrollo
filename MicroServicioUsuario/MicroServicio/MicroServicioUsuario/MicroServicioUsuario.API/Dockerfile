#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MicroServicioUsuario.API/MicroServicioUsuario.API.csproj", "MicroServicioUsuario.API/"]
RUN dotnet restore "MicroServicioUsuario.API/MicroServicioUsuario.API.csproj"
COPY . .
WORKDIR "/src/MicroServicioUsuario.API"
RUN dotnet build "MicroServicioUsuario.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroServicioUsuario.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroServicioUsuario.API.dll"]