#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ManagedIdentity.Svc/ManagedIdentity.Svc.csproj", "ManagedIdentity.Svc/"]
RUN dotnet restore "ManagedIdentity.Svc/ManagedIdentity.Svc.csproj"
COPY . .
WORKDIR "/src/ManagedIdentity.Svc"
RUN dotnet build "ManagedIdentity.Svc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ManagedIdentity.Svc.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ManagedIdentity.Svc.dll"]