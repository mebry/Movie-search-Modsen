FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Authentication/Authentication.API/Authentication.API.csproj", "Services/Authentication/Authentication.API/"]
COPY ["Services/Authentication/Authentication.BusinessLogic/Authentication.BusinessLogic.csproj", "Services/Authentication/Authentication.BusinessLogic/"]
COPY ["Services/Authentication/DataAccess/DataAccess.csproj", "Services/Authentication/Authentication.DataAccess/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Services/Authentication/Authentication.API/Authentication.API.csproj"
COPY ./Services/Authentication/ ./Services/Authentication
COPY ./Shared/ ./Shared
WORKDIR "/src/Services/Authentication/Authentication.API"
RUN dotnet build "Authentication.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authentication.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authentication.API.dll"]