FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Rating.WebAPI/Rating.WebAPI.csproj", "Rating.WebAPI/"]
COPY ["Rating.BusinessLogic/Rating.BusinessLogic.csproj", "Rating.BusinessLogic/"]
COPY ["Rating.DataAccess/Rating.DataAccess.csproj", "Rating.DataAccess/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Rating.WebAPI/Rating.WebAPI.csproj"
COPY . .
WORKDIR "/src/Rating.WebAPI"
RUN dotnet build "Rating.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rating.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rating.WebAPI.dll"]