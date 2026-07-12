# SwapFX - Plataforma Web P2P de Intercambio de Divisas

## Integrantes
- 24200430 - CRISOSTOMO CERVANTES, Alvaro Paul
- 22200555 - YUEN HORNA, Javier Orlando

## Curso
Desarrollo de Ambiente Web - Seccion S-001
Profesor: CHANG URIBE LUIS ALBERTO
Universidad ESAN

## Stack Tecnologico
- Backend: ASP.NET Core Web API .NET 10
- Base de datos: SQL Server (ALVAROW11)
- Autenticacion: JWT
- ORM: Entity Framework Core 10

## Como ejecutar
1. Ejecutar SwapFXDB.sql en SQL Server Management Studio conectado a ALVAROW11
2. dotnet restore
3. cd SwapFX.API && dotnet run
4. Abrir http://localhost:5000/swagger

## Endpoints
- POST /api/usuario/signup - Registro
- POST /api/usuario/signin - Login (devuelve JWT)
- GET /api/oferta - Listar ofertas (requiere token)
- GET /api/oferta/{id} - Obtener oferta (requiere token)
- POST /api/oferta - Crear oferta (requiere token)
- PUT /api/oferta - Editar oferta (requiere token)
- DELETE /api/oferta/{id} - Eliminar oferta (requiere token)

## Usuario admin
- Email: admin@swapfx.com
- Password: Admin2026!

## Despliegue en produccion

- Frontend: https://swapfx-frontend.onrender.com
- Backend API: https://swapfx-backend.onrender.com/swagger
- Base de datos: Supabase PostgreSQL

## Integrantes
- 24200430 - CRISOSTOMO CERVANTES, Alvaro Paul
- 22200555 - YUEN HORNA, Javier Orlando
