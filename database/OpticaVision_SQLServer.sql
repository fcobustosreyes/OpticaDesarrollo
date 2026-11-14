-- Base de datos básica para el proyecto Óptica Visión (SQL Server).
IF DB_ID(N'OpticaVision') IS NULL
    CREATE DATABASE OpticaVision;
GO
USE OpticaVision;
GO

IF OBJECT_ID('dbo.Productos','U') IS NULL
CREATE TABLE dbo.Productos (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    Codigo NVARCHAR(30) NOT NULL UNIQUE,
    Nombre NVARCHAR(120) NOT NULL,
    Categoria NVARCHAR(60) NOT NULL DEFAULT '',
    Marca NVARCHAR(60) NOT NULL DEFAULT '',
    Modelo NVARCHAR(60) NOT NULL DEFAULT '',
    Precio DECIMAL(10,2) NOT NULL DEFAULT 0,
    Existencias INT NOT NULL DEFAULT 0,
    Descripcion NVARCHAR(300) NOT NULL DEFAULT '',
    Activo BIT NOT NULL DEFAULT 1
);
GO
IF OBJECT_ID('dbo.Clientes','U') IS NULL
CREATE TABLE dbo.Clientes (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(120) NOT NULL,
    Telefono NVARCHAR(30) NOT NULL DEFAULT '',
    Correo NVARCHAR(120) NOT NULL DEFAULT '',
    Activo BIT NOT NULL DEFAULT 1
);
GO
IF OBJECT_ID('dbo.Proveedores','U') IS NULL
CREATE TABLE dbo.Proveedores (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(120) NOT NULL,
    Telefono NVARCHAR(30) NOT NULL DEFAULT '',
    Correo NVARCHAR(120) NOT NULL DEFAULT '',
    Activo BIT NOT NULL DEFAULT 1
);
GO
IF OBJECT_ID('dbo.Citas','U') IS NULL
CREATE TABLE dbo.Citas (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    Cliente NVARCHAR(120) NOT NULL,
    Fecha DATETIME2 NOT NULL,
    Servicio NVARCHAR(80) NOT NULL,
    Estado NVARCHAR(30) NOT NULL,
    Notas NVARCHAR(300) NOT NULL DEFAULT ''
);
GO
IF OBJECT_ID('dbo.Ventas','U') IS NULL
CREATE TABLE dbo.Ventas (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Cliente NVARCHAR(120) NOT NULL,
    CodigoProducto NVARCHAR(30) NOT NULL,
    Producto NVARCHAR(120) NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    FormaPago NVARCHAR(30) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);
GO
IF OBJECT_ID('dbo.Compras','U') IS NULL
CREATE TABLE dbo.Compras (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Proveedor NVARCHAR(120) NOT NULL,
    CodigoProducto NVARCHAR(30) NOT NULL,
    Producto NVARCHAR(120) NOT NULL,
    Cantidad INT NOT NULL,
    CostoUnitario DECIMAL(10,2) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);
GO

-- Registros de demostración iniciales para que la pantalla no aparezca vacía.
IF NOT EXISTS (SELECT 1 FROM dbo.Productos WHERE Codigo='AR-001')
    INSERT INTO dbo.Productos(Codigo,Nombre,Categoria,Marca,Modelo,Precio,Existencias,Descripcion)
    VALUES ('AR-001','Armazón clásico','Armazones','Óptica Visión','Clásico',850,12,'Producto de muestra');
IF NOT EXISTS (SELECT 1 FROM dbo.Productos WHERE Codigo='LE-001')
    INSERT INTO dbo.Productos(Codigo,Nombre,Categoria,Marca,Modelo,Precio,Existencias,Descripcion)
    VALUES ('LE-001','Lentes transparentes','Lentes','Óptica Visión','Antirreflejo',1200,8,'Producto de muestra');
IF NOT EXISTS (SELECT 1 FROM dbo.Clientes WHERE Nombre='Cliente de ejemplo')
    INSERT INTO dbo.Clientes(Nombre,Telefono,Correo) VALUES ('Cliente de ejemplo','','');
IF NOT EXISTS (SELECT 1 FROM dbo.Proveedores WHERE Nombre='Proveedor de ejemplo')
    INSERT INTO dbo.Proveedores(Nombre,Telefono,Correo) VALUES ('Proveedor de ejemplo','','');
GO
