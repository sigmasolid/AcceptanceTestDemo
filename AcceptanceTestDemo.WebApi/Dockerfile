FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AcceptanceTestDemo.WebApi/AcceptanceTestDemo.WebApi.csproj", "AcceptanceTestDemo.WebApi/"]
RUN dotnet restore "AcceptanceTestDemo.WebApi/AcceptanceTestDemo.WebApi.csproj"
COPY . .
WORKDIR "/src/AcceptanceTestDemo.WebApi"
RUN dotnet build "AcceptanceTestDemo.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AcceptanceTestDemo.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AcceptanceTestDemo.WebApi.dll"]
