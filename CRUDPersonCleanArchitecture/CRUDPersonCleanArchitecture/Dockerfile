# Etapa 1: Construcción de la aplicación
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Establecer el directorio de trabajo en el contenedor
WORKDIR /app

# Copiar los archivos del proyecto y restaurar las dependencias
COPY ["CRUDPersonCleanArchitecture.csproj", "./"]
RUN dotnet restore

# Copiar el resto de los archivos y construir la aplicación	
COPY . .
RUN dotnet publish -c Release -o out

# Etapa 2: Imagen para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app
COPY --from=build /app/out .

# Exponer el puerto donde la API estará disponible (puerto 80 en este caso)
EXPOSE 80

# Comando para iniciar la aplicación
ENTRYPOINT ["dotnet", "CRUDPersonCleanArchitecture.dll"]
