# Person CRUD App

Esta es una aplicación completa de gestión de personas que incluye un frontend desarrollado con Angular y un backend con .NET 6. La aplicación permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre una lista de personas.

## Características

- **Frontend**: Aplicación de una sola página (SPA) desarrollada con Angular.
- **Backend**: API RESTful desarrollada con .NET 6.
- **Operaciones CRUD**: Crear, listar, editar y eliminar personas.
- **Arquitectura**: CQRS, MediaTR, Repository
- **Base de datos**: Mysql

## Tecnologías utilizadas

- Angular
- .NET 6
- Node.js
- NGINX
- Docker
- TypeScript
- C#
- Mysql
- Docker-Compose

## Requisitos previos

Antes de comenzar, asegúrate de tener las siguientes herramientas instaladas en tu máquina:

- [Node.js](https://nodejs.org/)
- [Docker](https://www.docker.com/)
- [SDK de .NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) (opcional, para gestionar gráficamente la base de datos)

## Instalación y ejecución

### Ejecución local

#### Backend (.NET 6)

1. Despues de clonar el repositorio, navegar a la ruta donde esta el archivo **docker-compose.yml**
2. estando en la ruta abrir un cmd o un powershell y ejecutar el siguiente comando **docker-compose up --build**

#### Base de Datos (MySQL)

1. Despues de que los Contenedores se esten ejecutando ir a la base de datos (MySql workbench) y ejecutar el script que esta en el archivo **script db.txt**

#### Frontend (Angular)

1. Ingresar la ruta generada en el contenedor de mi-app-angular (http://localhost:4201/persons)
