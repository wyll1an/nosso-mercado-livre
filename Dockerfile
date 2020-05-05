#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/NossoMercadoLivreAPI.Application/NossoMercadoLivreAPI.Application.csproj", "src/NossoMercadoLivreAPI.Application/"]
COPY ["src/NossoMercadoLivreAPI.Domain/NossoMercadoLivreAPI.Domain.csproj", "src/NossoMercadoLivreAPI.Domain/"]
COPY ["src/NossoMercadoLivreAPI.Infra.Data/NossoMercadoLivreAPI.Infra.Data.csproj", "src/NossoMercadoLivreAPI.Infra.Data/"]
RUN dotnet restore "src/NossoMercadoLivreAPI.Application/NossoMercadoLivreAPI.Application.csproj"
COPY . .
WORKDIR "/src/src/NossoMercadoLivreAPI.Application"
RUN dotnet build "NossoMercadoLivreAPI.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NossoMercadoLivreAPI.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NossoMercadoLivreAPI.Application.dll"]