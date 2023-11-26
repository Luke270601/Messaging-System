FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Server Controller/Server Controller.csproj", "Server Controller/"]
RUN dotnet restore "Server Controller/Server Controller.csproj"
COPY . .
WORKDIR "/src/Server Controller"
RUN dotnet build "Server Controller.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Server Controller.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Server Controller.dll"]
