
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Staffs/Staff.API/Staff.API.csproj", "Services/Staffs/Staff.API/"]
COPY ["Services/Staffs/Staff.BusinessLogic/Staff.BusinessLogic.csproj", "Services/Staffs/Staff.BusinessLogic/"]
COPY ["Services/Staffs/Staff.DataAccess/Staff.DataAccess.csproj", "Services/Staffs/Staff.DataAccess/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Services/Staffs/Staff.API/Staff.API.csproj"
COPY ./Services/Staffs/ ./Services/Staffs
COPY ./Shared/ ./Shared
WORKDIR "/src/Services/Staffs/Staff.API"
RUN dotnet build "Staff.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Staff.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Staff.API.dll"]