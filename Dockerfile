# Stage 1 - bygg programmet
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

# kopiera projektfilen installera beronden
COPY *.csproj ./
RUN dotnet restore

# kopiera av koden och bygg appen
COPY  . ./
RUN dotnet publish -c Release -o /app/publish

# steg 2 - Runtime-miljö
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT [ "dotnet", "ConsoleApp-CICD-gruppuppgift.dll" ]