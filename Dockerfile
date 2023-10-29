FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5172
ENV ASPNETCORE_URLS=http://+:5172
USER app

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["toolbox-api.csproj", "./"]
RUN dotnet restore "toolbox-api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "toolbox-api.csproj" -c $configuration -o /app/build
RUN dotnet publish "toolbox-api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "toolbox-api.dll"]
