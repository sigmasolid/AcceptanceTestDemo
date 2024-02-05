FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DadJoke.WebApi/DadJoke.WebApi.csproj", "DadJoke.WebApi/"]
RUN dotnet restore "DadJoke.WebApi/DadJoke.WebApi.csproj"
COPY . .
WORKDIR "/src/DadJoke.WebApi"
RUN dotnet build "DadJoke.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DadJoke.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DadJoke.WebApi.dll"]
