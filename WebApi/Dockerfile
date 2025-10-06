# ---- build stage ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Proje dosyasını kopyala (layer cache için iyi)
COPY WebApi.csproj ./
RUN dotnet restore WebApi.csproj

# Tüm kaynakları kopyala ve publish et
COPY . .
RUN dotnet publish WebApi.csproj -c Release -o /app

# ---- runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Publish çıktısını runtime imajına kopyala
COPY --from=build /app ./

# Render PORT env değişkeni verir; Kestrel bu porta bağlanmalı
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}

# Lokal test için varsayılan port
ENV PORT=8080
EXPOSE 8080

# Proje adı WebApi.csproj → çalıştırılacak DLL: WebApi.dll
ENTRYPOINT ["dotnet", "WebApi.dll"]
