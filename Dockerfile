# Usar la imagen base de .NET 8.0 SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos de proyecto y restaurar dependencias
COPY ["Backend_JhonCorredor.sln", "."]
COPY ["Entity/Entity.csproj", "Entity/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["Web/Web.csproj", "Web/"]
COPY ["Diagram/Diagram.csproj", "Diagram/"]

RUN dotnet restore

# Copiar el resto del código fuente
COPY . .

# Construir la aplicación
RUN dotnet build "Web/Web.csproj" -c Release -o /app/build

# Publicar la aplicación
FROM build AS publish
RUN dotnet publish "Web/Web.csproj" -c Release -o /app/publish

# Usar la imagen base de .NET 8.0 runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "Web.dll"]