FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY . .

# Informe o caminho do projeto API
ARG PROJECT_PATH=src/Orcamento.Api/Orcamento.Api.csproj

# Restore
RUN dotnet restore "$PROJECT_PATH"

# Publicação
RUN dotnet publish "$PROJECT_PATH" \
    -c Release \
    -o /app/publish \
    --no-restore

# ==========================================
# STAGE 2 - RUNTIME
# ==========================================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

COPY --from=build /app/publish .

EXPOSE 8082

ENTRYPOINT ["dotnet", "Orcamento.Api.dll"]
