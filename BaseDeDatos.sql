
-- =============================================
-- BASE DE DATOS: CrudUsuarios
-- =============================================

IF DB_ID('CrudUsuarios') IS NULL
BEGIN
    CREATE DATABASE CrudUsuarios;
END;
GO

USE CrudUsuarios;
GO

-- =============================================
-- TABLA: Usuarios
-- =============================================

IF OBJECT_ID('dbo.Usuarios', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Usuarios
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nombre VARCHAR(100) NOT NULL,
        FechaNacimiento DATE NOT NULL,
        Sexo CHAR(1) NOT NULL
    );
END;
GO

-- =============================================
-- PROCEDIMIENTO ALMACENADO: CRUD
-- =============================================

IF OBJECT_ID('dbo.SP_GestionarUsuarios', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GestionarUsuarios;
GO

CREATE PROCEDURE dbo.SP_GestionarUsuarios
    @Accion VARCHAR(20),
    @Id INT = NULL,
    @Nombre VARCHAR(100) = NULL,
    @FechaNacimiento DATE = NULL,
    @Sexo CHAR(1) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'AGREGAR'
    BEGIN
        INSERT INTO dbo.Usuarios
        (Nombre, FechaNacimiento, Sexo)
        VALUES
        (@Nombre, @FechaNacimiento, @Sexo);

        SELECT SCOPE_IDENTITY() AS IdGenerado;
    END
    ELSE IF @Accion = 'MODIFICAR'
    BEGIN
        UPDATE dbo.Usuarios
        SET Nombre = @Nombre,
            FechaNacimiento = @FechaNacimiento,
            Sexo = @Sexo
        WHERE Id = @Id;
    END
    ELSE IF @Accion = 'CONSULTAR'
    BEGIN
        SELECT Id, Nombre, FechaNacimiento, Sexo
        FROM dbo.Usuarios;
    END
    ELSE IF @Accion = 'ELIMINAR'
    BEGIN
        DELETE FROM dbo.Usuarios
        WHERE Id = @Id;
    END
    ELSE
    BEGIN
        RAISERROR('Accion no valida', 16, 1);
        RETURN;
    END
END;
GO
