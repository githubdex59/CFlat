FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Docs/Docs.csproj", "Docs/"]
COPY ["CFlat/CFlat.csproj", "CFlat/"]
RUN dotnet restore "Docs/Docs.csproj"
RUN dotnet restore "CFlat/CFlat.csproj" 
COPY . . 
WORKDIR "/src/Docs"
RUN ls ../CFlat
RUN dotnet build "Docs.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Docs.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/Docs/Static ./Static
RUN ls
EXPOSE 8080
ENTRYPOINT ["dotnet", "Docs.dll"]
