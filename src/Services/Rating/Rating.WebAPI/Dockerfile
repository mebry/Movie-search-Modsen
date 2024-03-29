FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Rating/Rating.WebAPI/Rating.WebAPI.csproj", "Services/Rating/Rating.WebAPI/"]
COPY ["Services/Rating/Rating.BusinessLogic/Rating.BusinessLogic.csproj", "Services/Rating/Rating.BusinessLogic/"]
COPY ["Services/Rating/Rating.DataAccess/Rating.DataAccess.csproj", "Services/Rating/Rating.DataAccess/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Services/Rating/Rating.WebAPI/Rating.WebAPI.csproj"
COPY ./Services/Rating/ ./Services/Rating/
COPY ./Shared/ ./Shared
WORKDIR "/src/Services/Rating/Rating.WebAPI"
RUN dotnet build "Rating.WebAPI.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Rating.WebAPI.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rating.WebAPI.dll"]