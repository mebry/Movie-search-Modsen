FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/FilmCollection/FilmCollection.API/FilmCollection.API.csproj", "Services/FilmCollection/FilmCollection.API/"]
COPY ["Services/FilmCollection/FilmCollection.BusinessLogic/FilmCollection.BusinessLogic.csproj", "Services/FilmCollection/FilmCollection.BusinessLogic/"]
COPY ["Services/FilmCollection/FilmCollection.DataAccess/FilmCollection.DataAccess.csproj", "Services/FilmCollection/FilmCollection.DataAccess/"]
COPY ["Services/FilmCollection/FilmCollection.Shared/FilmCollection.Shared.csproj", "Services/FilmCollection/FilmCollection.Shared/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Services/FilmCollection/FilmCollection.API/FilmCollection.API.csproj"
COPY ./Services/FilmCollection/ ./Services/FilmCollection
COPY ./Shared/ ./Shared
WORKDIR "/src/Services/FilmCollection/FilmCollection.API"
RUN dotnet build "FilmCollection.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FilmCollection.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FilmCollection.API.dll"]