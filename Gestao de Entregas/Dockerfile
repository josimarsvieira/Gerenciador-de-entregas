#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Gestao de Entregas/Gestao de Entregas.csproj", "Gestao de Entregas/"]
RUN dotnet restore "Gestao de Entregas/Gestao de Entregas.csproj"
COPY . .
WORKDIR "/src/Gestao de Entregas"
RUN dotnet build "Gestao de Entregas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gestao de Entregas.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gestao de Entregas.dll"]