FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Film/Film.API/Film.API.csproj", "Services/Film/Film.API/"]
COPY ["Services/Film/Film.BusinessLogic/Film.BusinessLogic.csproj", "Services/Film/Film.BusinessLogic/"]
COPY ["Services/Film/Film.DataAccess/Film.DataAccess.csproj", "Services/Film/Film.DataAccess/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Services/Film/Film.API/Film.API.csproj"
COPY ./Services/Film/ ./Services/Film
COPY ./Shared/ ./Shared
WORKDIR "/src/Services/Film/Film.API"
RUN dotnet build "Film.API.csproj" -c Debug  -o /app/build

FROM build AS publish
RUN dotnet publish "Film.API.csproj" -c Debug  -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Film.API.dll"]