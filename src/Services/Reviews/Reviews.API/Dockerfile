FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Reviews/Reviews.API/Reviews.API.csproj", "Services/Reviews/Reviews.API/"]
COPY ["Services/Reviews/Reviews.BusinessLogic/Reviews.BusinessLogic.csproj", "Services/Reviews/Reviews.BusinessLogic/"]
COPY ["Services/Reviews/Reviews.DataAccess/Reviews.DataAccess.csproj", "Services/Reviews/Reviews.DataAccess/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Services/Reviews/Reviews.API/Reviews.API.csproj"
COPY ./Services/Reviews/ ./Services/Reviews/
COPY ./Shared/ ./Shared
WORKDIR "/src/Services/Reviews/Reviews.API"
RUN dotnet build "Reviews.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Reviews.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reviews.API.dll"]