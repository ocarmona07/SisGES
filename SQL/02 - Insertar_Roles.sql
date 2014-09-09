/***************************************************
  Insertar Roles del sistema
****************************************************/

USE SisGEN;
INSERT  INTO dbo.GEN_Rol
        ( Rol, Descripcion )
VALUES  ( 'Administrador', 'Acceso a todos los módulos del sistema.' ) ,
        ( 'Asesor Familiar', 'Ingresar, modificar familias o personas.' ) ,
        ( 'Asesor Laboral', 'Ingresar, modificar familias o personas.' )
GO