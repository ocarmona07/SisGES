/***************************************************
  Insertar Estados Civil
****************************************************/

USE SisGEN;
INSERT  INTO dbo.GEN_EstadoCivil
        ( EstadoCivil, Descripcion )
VALUES  ( 'Soltero/a', '' ) ,
        ( 'Casado/a', '' ) ,
        ( 'Conviviente', '' ) ,
        ( 'Separado/a', '' ) ,
        ( 'Divorciado/a', '' ) ,
        ( 'Viudo/a', '' )
GO