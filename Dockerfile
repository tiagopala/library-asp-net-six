FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
LABEL maintainer="tiagopala"

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./src /src

RUN dotnet restore "LibraryAspNetSix.Api.sln"
RUN dotnet build   "LibraryAspNetSix.Api.sln"

FROM build AS publish
RUN dotnet publish "LibraryAspNetSix.Api.sln" -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","LibraryAspNetSix.Api.dll"]