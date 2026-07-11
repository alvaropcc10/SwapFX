CREATE TABLE IF NOT EXISTS "Usuario" (
    "Id" SERIAL PRIMARY KEY,
    "Nombres" VARCHAR(100),
    "Apellidos" VARCHAR(100),
    "Dni" VARCHAR(20),
    "Telefono" VARCHAR(20),
    "Email" VARCHAR(150),
    "Password" VARCHAR(200),
    "IsActive" BOOLEAN,
    "Tipo" CHAR(1),
    "FechaRegistro" DATE,
    "IdentidadValidada" BOOLEAN
);

CREATE TABLE IF NOT EXISTS "Moneda" (
    "Id" SERIAL PRIMARY KEY,
    "Codigo" VARCHAR(3),
    "Nombre" VARCHAR(50),
    "Simbolo" VARCHAR(5),
    "IsActive" BOOLEAN
);

CREATE TABLE IF NOT EXISTS "CuentaBancaria" (
    "Id" SERIAL PRIMARY KEY,
    "UsuarioId" INT,
    "Banco" VARCHAR(100),
    "Titular" VARCHAR(150),
    "TipoCuenta" VARCHAR(50),
    "NumeroCuenta" VARCHAR(30),
    "Cci" VARCHAR(30),
    "Moneda" VARCHAR(3),
    "EsPrincipal" BOOLEAN,
    "IsActive" BOOLEAN,
    CONSTRAINT "FK_CuentaBancaria_Usuario" FOREIGN KEY ("UsuarioId") REFERENCES "Usuario"("Id")
);

CREATE TABLE IF NOT EXISTS "Oferta" (
    "Id" SERIAL PRIMARY KEY,
    "UsuarioId" INT,
    "Tipo" CHAR(1),
    "MonedaOrigenId" INT,
    "MonedaDestinoId" INT,
    "Monto" DECIMAL(18,2),
    "TipoCambio" DECIMAL(18,4),
    "FechaPublicacion" TIMESTAMP,
    "FechaExpiracion" TIMESTAMP,
    "Estado" VARCHAR(30),
    "Notas" VARCHAR(500),
    "IsActive" BOOLEAN,
    CONSTRAINT "FK_Oferta_Usuario" FOREIGN KEY ("UsuarioId") REFERENCES "Usuario"("Id"),
    CONSTRAINT "FK_Oferta_MonedaOrigen" FOREIGN KEY ("MonedaOrigenId") REFERENCES "Moneda"("Id"),
    CONSTRAINT "FK_Oferta_MonedaDestino" FOREIGN KEY ("MonedaDestinoId") REFERENCES "Moneda"("Id")
);

CREATE TABLE IF NOT EXISTS "Transaccion" (
    "Id" SERIAL PRIMARY KEY,
    "Codigo" VARCHAR(20),
    "OfertaCompraId" INT,
    "OfertaVentaId" INT,
    "CompradorId" INT,
    "VendedorId" INT,
    "MontoOrigen" DECIMAL(18,2),
    "MontoDestino" DECIMAL(18,2),
    "TipoCambioAplicado" DECIMAL(18,4),
    "EstadoActual" VARCHAR(30),
    "FechaInicio" TIMESTAMP,
    "FechaFinalizacion" TIMESTAMP,
    "IsActive" BOOLEAN,
    CONSTRAINT "FK_Transaccion_OfertaCompra" FOREIGN KEY ("OfertaCompraId") REFERENCES "Oferta"("Id"),
    CONSTRAINT "FK_Transaccion_OfertaVenta" FOREIGN KEY ("OfertaVentaId") REFERENCES "Oferta"("Id"),
    CONSTRAINT "FK_Transaccion_Comprador" FOREIGN KEY ("CompradorId") REFERENCES "Usuario"("Id"),
    CONSTRAINT "FK_Transaccion_Vendedor" FOREIGN KEY ("VendedorId") REFERENCES "Usuario"("Id")
);

CREATE TABLE IF NOT EXISTS "EstadoTransaccion" (
    "Id" SERIAL PRIMARY KEY,
    "TransaccionId" INT,
    "Estado" VARCHAR(30),
    "FechaCambio" TIMESTAMP,
    "UsuarioResponsableId" INT,
    "Comentario" VARCHAR(500),
    CONSTRAINT "FK_EstadoTransaccion_Transaccion" FOREIGN KEY ("TransaccionId") REFERENCES "Transaccion"("Id")
);

CREATE TABLE IF NOT EXISTS "Comprobante" (
    "Id" SERIAL PRIMARY KEY,
    "TransaccionId" INT,
    "UsuarioId" INT,
    "NombreArchivo" VARCHAR(200),
    "RutaArchivo" VARCHAR(500),
    "FormatoArchivo" VARCHAR(10),
    "TamanoBytes" BIGINT,
    "NumeroOperacion" VARCHAR(50),
    "FechaTransferencia" TIMESTAMP,
    "FechaSubida" TIMESTAMP,
    CONSTRAINT "FK_Comprobante_Transaccion" FOREIGN KEY ("TransaccionId") REFERENCES "Transaccion"("Id")
);

CREATE TABLE IF NOT EXISTS "Calificacion" (
    "Id" SERIAL PRIMARY KEY,
    "TransaccionId" INT,
    "UsuarioCalificadorId" INT,
    "UsuarioCalificadoId" INT,
    "Puntuacion" INT,
    "Comentario" VARCHAR(280),
    "FechaCalificacion" TIMESTAMP,
    CONSTRAINT "FK_Calificacion_Transaccion" FOREIGN KEY ("TransaccionId") REFERENCES "Transaccion"("Id"),
    CONSTRAINT "FK_Calificacion_Calificador" FOREIGN KEY ("UsuarioCalificadorId") REFERENCES "Usuario"("Id"),
    CONSTRAINT "FK_Calificacion_Calificado" FOREIGN KEY ("UsuarioCalificadoId") REFERENCES "Usuario"("Id")
);

CREATE TABLE IF NOT EXISTS "Disputa" (
    "Id" SERIAL PRIMARY KEY,
    "TransaccionId" INT,
    "UsuarioReportanteId" INT,
    "Motivo" VARCHAR(100),
    "Descripcion" VARCHAR(1000),
    "Estado" VARCHAR(30),
    "Resolucion" VARCHAR(1000),
    "FechaReporte" TIMESTAMP,
    "FechaResolucion" TIMESTAMP,
    "AdminResolutorId" INT,
    CONSTRAINT "FK_Disputa_Transaccion" FOREIGN KEY ("TransaccionId") REFERENCES "Transaccion"("Id")
);

CREATE TABLE IF NOT EXISTS "DocumentoIdentidad" (
    "Id" SERIAL PRIMARY KEY,
    "UsuarioId" INT,
    "TipoDoc" VARCHAR(20),
    "NumeroDoc" VARCHAR(20),
    "RutaArchivo" VARCHAR(500),
    "Estado" VARCHAR(20),
    "Observacion" VARCHAR(500),
    "FechaSubida" TIMESTAMP,
    "FechaRevision" TIMESTAMP,
    CONSTRAINT "FK_DocumentoIdentidad_Usuario" FOREIGN KEY ("UsuarioId") REFERENCES "Usuario"("Id")
);

CREATE TABLE IF NOT EXISTS "Notificacion" (
    "Id" SERIAL PRIMARY KEY,
    "UsuarioId" INT,
    "Tipo" VARCHAR(50),
    "Mensaje" VARCHAR(500),
    "Leida" BOOLEAN,
    "FechaCreacion" TIMESTAMP,
    CONSTRAINT "FK_Notificacion_Usuario" FOREIGN KEY ("UsuarioId") REFERENCES "Usuario"("Id")
);

CREATE TABLE IF NOT EXISTS "BitacoraTransaccion" (
    "Id" SERIAL PRIMARY KEY,
    "TransaccionId" INT NOT NULL,
    "EstadoAnterior" VARCHAR(30) NOT NULL,
    "EstadoNuevo" VARCHAR(30) NOT NULL,
    "UsuarioResponsableId" INT NOT NULL,
    "Comentario" VARCHAR(500),
    "FechaCambio" TIMESTAMP NOT NULL,
    CONSTRAINT "FK_BitacoraTransaccion_Transaccion" FOREIGN KEY ("TransaccionId") REFERENCES "Transaccion"("Id")
);

CREATE TABLE IF NOT EXISTS "EvidenciaDisputa" (
    "Id" SERIAL PRIMARY KEY,
    "DisputaId" INT NOT NULL,
    "UsuarioId" INT NOT NULL,
    "NombreArchivo" VARCHAR(200) NOT NULL,
    "RutaArchivo" VARCHAR(500) NOT NULL,
    "FormatoArchivo" VARCHAR(10) NOT NULL,
    "FechaSubida" TIMESTAMP NOT NULL,
    CONSTRAINT "FK_EvidenciaDisputa_Disputa" FOREIGN KEY ("DisputaId") REFERENCES "Disputa"("Id")
);

INSERT INTO "Moneda" ("Codigo", "Nombre", "Simbolo", "IsActive") VALUES ('PEN', 'Sol peruano', 'S/', true);
INSERT INTO "Moneda" ("Codigo", "Nombre", "Simbolo", "IsActive") VALUES ('USD', 'Dolar americano', '$', true);
INSERT INTO "Moneda" ("Codigo", "Nombre", "Simbolo", "IsActive") VALUES ('EUR', 'Euro', 'EUR', true);

INSERT INTO "Usuario" ("Nombres", "Apellidos", "Dni", "Telefono", "Email", "Password", "IsActive", "Tipo", "FechaRegistro", "IdentidadValidada")
VALUES ('Admin', 'SwapFX', '00000000', '999999999', 'admin@swapfx.com', 'Admin2026!', true, 'A', '2026-01-01', true);
