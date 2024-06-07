
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["CV.Website/CV.Website.csproj", "CV.Website/"]
RUN dotnet restore "CV.Website/CV.Website.csproj"

COPY . .
WORKDIR "/src/CV.Website"
RUN dotnet build "CV.Website.csproj" -c Release -o /app/build

RUN dotnet publish "CV.Website.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CV.Website.dll"]
