#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LibraryAspNetSix.Api/LibraryAspNetSix.Api.csproj", "LibraryAspNetSix.Api/"]
RUN dotnet restore "LibraryAspNetSix.Api/LibraryAspNetSix.Api.csproj"
COPY . .
WORKDIR "/src/LibraryAspNetSix.Api"
RUN dotnet build "LibraryAspNetSix.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibraryAspNetSix.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryAspNetSix.Api.dll"]