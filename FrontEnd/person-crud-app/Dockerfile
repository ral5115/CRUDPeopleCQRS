# Etapa 1: Construcción de la aplicación Angular
FROM node:18 AS build

# Crear el directorio de trabajo en el contenedor
WORKDIR /app

# Copiar los archivos del proyecto al contenedor
COPY package.json package-lock.json ./
RUN npm install

# Copiar el resto de los archivos del proyecto
COPY . .

# Compilar la aplicación Angular
RUN npm run build --prod

# Etapa 2: Configuración del servidor NGINX
FROM nginx:alpine

# Copiar los archivos compilados de la aplicación desde la etapa de construcción
COPY --from=build /app/dist/person-crud-app /usr/share/nginx/html

# Exponer el puerto 80 para acceder a la aplicación
EXPOSE 80

# Iniciar NGINX
CMD ["nginx", "-g", "daemon off;"]
