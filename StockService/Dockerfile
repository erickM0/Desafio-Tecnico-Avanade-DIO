# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia o arquivo de projeto e restaura dependências
COPY ["StockService.API/StockService.API.csproj", "StockService.API/"]
COPY ["StockService.Domain/StockService.Domain.csproj", "StockService.Domain/"]
COPY ["StockService.Infra/StockService.Infra.csproj", "StockService.Infra/"]
RUN dotnet restore "StockService.API/StockService.API.csproj"

# Copia o restante do código e compila
COPY . ./
RUN dotnet publish "StockService.API\StockService.API.csproj" -c Release -o /app/publish

# Etapa 2: Runtime (imagem menor, só com o necessário pra rodar)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copia os artefatos compilados da etapa de build
COPY --from=build /app/publish .

# Expõe a porta do micro serviço
EXPOSE 8080

# Comando de entrada
ENTRYPOINT ["dotnet", "StockService.API.dll"]
