#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/GondorsLegacy.Services.Reservation/GondorsLegacy.Services.Reservation.csproj", "src/Services/GondorsLegacy.Services.Reservation/"]
COPY ["src/Common/GondorsLegacy.Domain/GondorsLegacy.Domain.csproj", "src/Common/GondorsLegacy.Domain/"]
COPY ["src/Common/GondorsLegacy.Infrastructure/GondorsLegacy.Infrastructure.csproj", "src/Common/GondorsLegacy.Infrastructure/"]
COPY ["src/Common/GondorsLegacy.Application/GondorsLegacy.Application.csproj", "src/Common/GondorsLegacy.Application/"]
COPY ["src/Common/GondorsLegacy.CrossCuttingCorners/GondorsLegacy.CrossCuttingCorners.csproj", "src/Common/GondorsLegacy.CrossCuttingCorners/"]
RUN dotnet restore "src/Services/GondorsLegacy.Services.Reservation/GondorsLegacy.Services.Reservation.csproj"
COPY . .
WORKDIR "/src/src/Services/GondorsLegacy.Services.Reservation"
RUN dotnet build "GondorsLegacy.Services.Reservation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GondorsLegacy.Services.Reservation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GondorsLegacy.Services.Reservation.dll"]
