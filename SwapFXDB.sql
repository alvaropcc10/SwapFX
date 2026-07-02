CREATE DATABASE SwapFXDB
GO
USE [SwapFXDB]
GO
CREATE TABLE [dbo].[Usuario] ([Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, [Nombres] NVARCHAR(100) NULL, [Apellidos] NVARCHAR(100) NULL, [Dni] NVARCHAR(20) NULL, [Telefono] NVARCHAR(20) NULL, [Email] NVARCHAR(150) NULL, [Password] NVARCHAR(200) NULL, [IsActive] BIT NULL, [Tipo] CHAR(1) NULL, [FechaRegistro] DATE NULL, [IdentidadValidada] BIT NULL)
GO
CREATE TABLE [dbo].[Moneda] ([Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, [Codigo] NVARCHAR(3) NULL, [Nombre] NVARCHAR(50) NULL, [Simbolo] NVARCHAR(5) NULL, [IsActive] BIT NULL)
GO
CREATE TABLE [dbo].[CuentaBancaria] ([Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, [UsuarioId] INT NULL, [Banco] NVARCHAR(100) NULL, [Titular] NVARCHAR(150) NULL, [TipoCuenta] NVARCHAR(50) NULL, [NumeroCuenta] NVARCHAR(30) NULL, [Cci] NVARCHAR(30) NULL, [Moneda] NVARCHAR(3) NULL, [EsPrincipal] BIT NULL, [IsActive] BIT NULL, CONSTRAINT FK_CuentaBancaria_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id))
GO
CREATE TABLE [dbo].[Oferta] ([Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, [UsuarioId] INT NULL, [Tipo] CHAR(1) NULL, [MonedaOrigenId] INT NULL, [MonedaDestinoId] INT NULL, [Monto] DECIMAL(18,2) NULL, [TipoCambio] DECIMAL(18,4) NULL, [FechaPublicacion] DATETIME NULL, [FechaExpiracion] DATETIME NULL, [Estado] NVARCHAR(30) NULL, [Notas] NVARCHAR(500) NULL, [IsActive] BIT NULL, CONSTRAINT FK_Oferta_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id), CONSTRAINT FK_Oferta_MonedaOrigen FOREIGN KEY (MonedaOrigenId) REFERENCES Moneda(Id), CONSTRAINT FK_Oferta_MonedaDestino FOREIGN KEY (MonedaDestinoId) REFERENCES Moneda(Id))
GO
CREATE TABLE [dbo].[Transaccion] ([Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, [Codigo] NVARCHAR(20) NULL, [OfertaCompraId] INT NULL, [OfertaVentaId] INT NULL, [CompradorId] INT NULL, [VendedorId] INT NULL, [MontoOrigen] DECIMAL(18,2) NULL, [MontoDestino] DECIMAL(18,2) NULL, [TipoCambioAplicado] DECIMAL(18,4) NULL, [EstadoActual] NVARCHAR(30) NULL, [FechaInicio] DATETIME NULL, [FechaFinalizacion] DATETIME NULL, [IsActive] BIT NULL, CONSTRAINT FK_Transaccion_OfertaCompra FOREIGN KEY (OfertaCompraId) REFERENCES Oferta(Id), CONSTRAINT FK_Transaccion_OfertaVenta FOREIGN KEY (OfertaVentaId) REFERENCES Oferta(Id), CONSTRAINT FK_Transaccion_Comprador FOREIGN KEY (CompradorId) REFERENCES Usuario(Id), CONSTRAINT FK_Transaccion_Vendedor FOREIGN KEY (VendedorId) REFERENCES Usuario(Id))
GO
CREATE TABLE [dbo].[EstadoTransaccion] ([Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, [TransaccionId] INT NULL, [Estado] NVARCHAR(30) NULL, [FechaCambio] DATETIME NULL, [UsuarioResponsableId] INT NULL, [Comentario] NVARCHAR(500) NULL, CONSTRAINT FK_EstadoTransaccion_Transaccion FOREIGN KEY (TransaccionId) REFERENCES Transaccion(Id))
GO
CREATE TABLE [dbo].[Comprobante] ([Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, [TransaccionId] INT NULL, [UsuarioId] INT NULL, [NombreArchivo] NVARCHAR(200) NULL, [RutaArchivo] NVARCHAR(500) NULL, [FormatoArchivo] NVARCHAR(10) NULL, [TamanoBytes] BIGINT NULL, [NumeroOperacion] NVARCHAR(50) NULL, [FechaTransferencia] DATETIME NULL, [FechaSubida] DATETIME NULL, CONSTRAINT FK_Comprobante_Transaccion FOREIGN KEY (TransaccionId) REFERENCES Transaccion(Id))
GO
CREATE TABLE [dbo].[Calificacion] ([Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, [TransaccionId] INT NULL, [UsuarioCalificadorId] INT NULL, [UsuarioCalificadoId] INT NULL, [Puntuacion] INT NULL, [Comentario] NVARCHAR(280) NULL, [FechaCalificacion] DATETIME NULL, CONSTRAINT FK_Calificacion_Transaccion FOREIGN KEY (TransaccionId) REFERENCES Transaccion(Id), CONSTRAINT FK_Calificacion_Calificador FOREIGN KEY (UsuarioCalificadorId) REFERENCES Usuario(Id), CONSTRAINT FK_Calificacion_Calificado FOREIGN KEY (UsuarioCalificadoId) REFERENCES Usuario(Id))
GO
CREATE TABLE [dbo].[Disputa] ([Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, [TransaccionId] INT NULL, [UsuarioReportanteId] INT NULL, [Motivo] NVARCHAR(100) NULL, [Descripcion] NVARCHAR(1000) NULL, [Estado] NVARCHAR(30) NULL, [Resolucion] NVARCHAR(1000) NULL, [FechaReporte] DATETIME NULL, [FechaResolucion] DATETIME NULL, [AdminResolutorId] INT NULL, CONSTRAINT FK_Disputa_Transaccion FOREIGN KEY (TransaccionId) REFERENCES Transaccion(Id))
GO
CREATE TABLE [dbo].[DocumentoIdentidad] ([Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, [UsuarioId] INT NULL, [TipoDoc] NVARCHAR(20) NULL, [NumeroDoc] NVARCHAR(20) NULL, [RutaArchivo] NVARCHAR(500) NULL, [Estado] NVARCHAR(20) NULL, [Observacion] NVARCHAR(500) NULL, [FechaSubida] DATETIME NULL, [FechaRevision] DATETIME NULL, CONSTRAINT FK_DocumentoIdentidad_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id))
GO
CREATE TABLE [dbo].[Notificacion] ([Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, [UsuarioId] INT NULL, [Tipo] NVARCHAR(50) NULL, [Mensaje] NVARCHAR(500) NULL, [Leida] BIT NULL, [FechaCreacion] DATETIME NULL, CONSTRAINT FK_Notificacion_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id))
GO
SET IDENTITY_INSERT [dbo].[Moneda] ON
INSERT [dbo].[Moneda] ([Id],[Codigo],[Nombre],[Simbolo],[IsActive]) VALUES (1,N'PEN',N'Sol peruano',N'S/',1)
INSERT [dbo].[Moneda] ([Id],[Codigo],[Nombre],[Simbolo],[IsActive]) VALUES (2,N'USD',N'Dolar americano',N'$',1)
INSERT [dbo].[Moneda] ([Id],[Codigo],[Nombre],[Simbolo],[IsActive]) VALUES (3,N'EUR',N'Euro',N'EUR',1)
SET IDENTITY_INSERT [dbo].[Moneda] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON
INSERT [dbo].[Usuario] ([Id],[Nombres],[Apellidos],[Dni],[Telefono],[Email],[Password],[IsActive],[Tipo],[FechaRegistro],[IdentidadValidada]) VALUES (1,N'Admin',N'SwapFX',N'00000000',N'999999999',N'admin@swapfx.com',N'Admin2026!',1,N'A','2026-01-01',1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
