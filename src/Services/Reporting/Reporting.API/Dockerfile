FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Reporting.API/Reporting.API.csproj", "Services/Reporting/Reporting.API/"]
COPY ["Services/Reporting/Reporting.BusinessLogic/Reporting.BusinessLogic.csproj", "Services/Reporting/Reporting.BusinessLogic/"]
COPY ["Services/Reporting/Reporting.DataAccess/Reporting.DataAccess.csproj", "Services/Reporting/Reporting.DataAccess/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Services/Reportin/Reporting.API/Reporting.API.csproj"
COPY . .
WORKDIR "/src/Services/Reportin/Reporting.API"
RUN dotnet build "Reporting.API.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Reporting.API.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reporting.API.dll"]