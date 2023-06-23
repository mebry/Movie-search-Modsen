
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Staff/Staff.API/Staff.API.csproj", "Services/Staff/Staff.API/"]
COPY ["Services/Staff/Staff.BusinessLogic/Staff.BusinessLogic.csproj", "Services/Staff/Staff.BusinessLogic/"]
COPY ["Services/Staff/Staff.DataAccess/Staff.DataAccess.csproj", "Services/Staff/Staff.DataAccess/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Services/Staff/Staff.API/Staff.API.csproj"
COPY ./Services/Staff/ ./Services/Staff
COPY ./Shared/ ./Shared
WORKDIR "/src/Services/Staff/Staff.API"
RUN dotnet build "Staff.API.csproj" -c Debug  -o /app/build

FROM build AS publish
RUN dotnet publish "Staff.API.csproj" -c Debug  -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Staff.API.dll"]