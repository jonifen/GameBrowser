FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
COPY . /app
WORKDIR /app/GameBrowser.Api
RUN dotnet restore "GameBrowser.Api.csproj"
RUN dotnet build "GameBrowser.Api.csproj" -c Release -o ../app/build

FROM build AS publish
COPY . /app
WORKDIR /app/GameBrowser.Api
RUN dotnet publish "GameBrowser.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
EXPOSE 443
ENTRYPOINT [ "dotnet", "GameBrowser.Api.dll" ]