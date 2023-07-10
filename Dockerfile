FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ITS.PMT.Api/ITS.PMT.Api.csproj", "ITS.PMT.Api/"]
COPY ["ITS.PMT.Infrastructure/ITS.PMT.Infrastructure.csproj", "ITS.PMT.Infrastructure/"]
COPY ["ITS.PMT.Domain/ITS.PMT.Domain.csproj", "ITS.PMT.Domain/"]
RUN dotnet restore "ITS.PMT.Api/ITS.PMT.Api.csproj"
COPY . .
WORKDIR "/src/ITS.PMT.Api"
RUN dotnet build "ITS.PMT.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ITS.PMT.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Dev
ENTRYPOINT ["dotnet", "ITS.PMT.Api.dll"]
