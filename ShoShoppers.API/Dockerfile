FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShoShoppers.API/ShoShoppers.API.csproj", "ShoShoppers.API/"]
COPY ["ShoShoppers.Bll/ShoShoppers.Bll.csproj", "ShoShoppers.Bll/"]
COPY ["ShoShoppers.Dal/ShoShoppers.Dal.csproj", "ShoShoppers.Dal/"]
RUN dotnet restore "ShoShoppers.API/ShoShoppers.API.csproj"
COPY . .
WORKDIR "/src/ShoShoppers.API"
RUN dotnet build "ShoShoppers.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoShoppers.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM node:18.7.0 AS node-builder
WORKDIR /node
COPY ./ShoShoppers.ClientApp /node
RUN npm install
RUN npm run build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=node-builder /node/build ./wwwroot
ENTRYPOINT ["dotnet", "ShoShoppers.API.dll"]
