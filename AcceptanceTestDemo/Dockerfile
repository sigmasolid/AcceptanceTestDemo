FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AcceptanceTestDemo/AcceptanceTestDemo.csproj", "AcceptanceTestDemo/"]
RUN dotnet restore "AcceptanceTestDemo/AcceptanceTestDemo.csproj"
COPY . .
WORKDIR "/src/AcceptanceTestDemo"
RUN dotnet build "AcceptanceTestDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AcceptanceTestDemo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AcceptanceTestDemo.dll"]
