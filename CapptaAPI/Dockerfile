#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Sonda.Api/Sonda.Api.csproj", "Sonda.Api/"]
RUN dotnet restore "Sonda.Api/Sonda.Api.csproj"
COPY . .
WORKDIR "/src/Sonda.Api"
RUN dotnet build "Sonda.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sonda.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sonda.Api.dll"]