#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Member.API/Member.API.csproj", "Services/Member.API/"]
COPY ["Data/PMTDataAccess/PMTDataAccess.csproj", "Data/PMTDataAccess/"]
COPY ["Utilities/EventBus.Messages/EventBus.Messages.csproj", "Utilities/EventBus.Messages/"]
RUN dotnet restore "Services/Member.API/Member.API.csproj"
COPY . .
WORKDIR "/src/Services/Member.API"
RUN dotnet build "Member.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Member.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Member.API.dll"]