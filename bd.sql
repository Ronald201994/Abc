CREATE DATABASE Abc
GO

USE Abc 
GO

CREATE TABLE Cargo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Descripcion NVARCHAR(255),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME DEFAULT GETDATE(),
    Activo BIT DEFAULT 1,
    UsuarioCreacion NVARCHAR(100) NULL,
    UsuarioModificacion NVARCHAR(100) NULL
);

CREATE TABLE Afp (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME DEFAULT GETDATE(),
    Activo BIT DEFAULT 1,
    UsuarioCreacion NVARCHAR(100) NULL,
    UsuarioModificacion NVARCHAR(100) NULL
);

CREATE TABLE Empleado (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Apellidos NVARCHAR(50) NOT NULL,
    FechaNacimiento DATE,
    FechaIngreso DATE,
    Sueldo DECIMAL(18, 2) CHECK (Sueldo > 0),
    CargoId INT NOT NULL,
    AfpId INT NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME DEFAULT GETDATE(),
    Activo BIT DEFAULT 1,
    UsuarioCreacion NVARCHAR(100) NULL,
    UsuarioModificacion NVARCHAR(100) NULL,
    FOREIGN KEY (CargoId) REFERENCES Cargo(Id),
    FOREIGN KEY (AfpId) REFERENCES Afp(Id)
);

CREATE INDEX idx_CargoId ON Empleado(CargoId);
CREATE INDEX idx_AfpId ON Empleado(AfpId);

CREATE TABLE Role (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Descripcion NVARCHAR(255),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME DEFAULT GETDATE(),
    Activo BIT DEFAULT 1,
    UsuarioCreacion NVARCHAR(100) NULL,
    UsuarioModificacion NVARCHAR(100) NULL
);

CREATE TABLE Usuario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario NVARCHAR(50) NOT NULL UNIQUE,
    Contrasenia NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100),
    RoleId INT NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME DEFAULT GETDATE(),
    Activo BIT DEFAULT 1,
    UsuarioCreacion NVARCHAR(100) NULL,
    UsuarioModificacion NVARCHAR(100) NULL,
    FOREIGN KEY (RoleId) REFERENCES Role(Id)
);

CREATE INDEX idx_RoleId ON Usuario(RoleId);

-- Insertar registros en Cargo
INSERT INTO Cargo (Nombre, Descripcion, UsuarioCreacion) VALUES 
('Gerente', 'Responsable de la gestión general de la empresa', 'administrador@abc.com'),
('Desarrollador', 'Encargado del desarrollo de software', 'administrador@abc.com'),
('Analista', 'Especialista en análisis de sistemas', 'administrador@abc.com');

-- Insertar registros en Afp
INSERT INTO Afp (Nombre, Descripcion, UsuarioCreacion) VALUES 
('AFP Horizonte', 'Administradora de Fondos de Pensiones Horizonte', 'administrador@abc.com'),
('AFP Integra', 'Administradora de Fondos de Pensiones Integra', 'administrador@abc.com'),
('AFP Prima', 'Administradora de Fondos de Pensiones Prima', 'administrador@abc.com');

-- Insertar registros en Empleado
INSERT INTO Empleado (Nombre, Apellidos, FechaNacimiento, FechaIngreso, Sueldo, CargoId, AfpId, UsuarioCreacion) VALUES 
('Juan', 'Pérez', '1985-03-15', '2020-01-10', 3500.00, 1, 1, 'administrador@abc.com');

-- Insertar registros en Role
INSERT INTO Role (Nombre, Descripcion, UsuarioCreacion) VALUES 
('Administrador', 'Usuario con todos los privilegios', 'administrador@abc.com'),
('Usuario', 'Usuario con acceso limitado', 'administrador@abc.com'),
('Invitado', 'Usuario con acceso solo de lectura', 'administrador@abc.com');

-- Insertar registros en Usuario
INSERT INTO Usuario (NombreUsuario, Contrasenia, Email, RoleId, UsuarioCreacion) VALUES 
('administrador', 'contraseña123', 'administrador@abc.com', 1, 'administrador@abc.com');

-- Consultar todos los usuarios activos
SELECT * FROM Usuario WHERE Activo = 1;

SELECT * FROM Empleado