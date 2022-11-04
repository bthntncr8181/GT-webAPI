FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GTBack.WebAPI/GTBack.WebAPI.csproj", "GTBack.WebAPI/"]
COPY ["GTBack.Core/GTBack.Core.csproj", "GTBack.Core/"]
COPY ["GTBack.Repository/GTBack.Repository.csproj", "GTBack.Repository/"]
COPY ["GTBack.Service/GTBack.Service.csproj", "GTBack.Service/"]

RUN dotnet restore "GTBack.WebAPI/GTBack.WebAPI.csproj"
COPY . .
WORKDIR "/src/GTBack.WebAPI"
RUN dotnet build "GTBack.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GTBack.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GTBack.WebAPI
.dll"]