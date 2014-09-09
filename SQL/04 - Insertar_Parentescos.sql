/***************************************************
  Insertar Parentescos
****************************************************/

USE SisGEN;
INSERT  INTO dbo.GEN_Parentescos
        ( Parentesco, Descripcion )
VALUES  ( 'Jefe de Familia', 'Integrante a cargo del grupo familiar' ) ,
		( 'Cónyuge', 'Esposo/a asociado al jefe de familia' ) ,
		( 'Hijo/a', 'Hijo/a del jefe de familia y/o cónyuge' ) ,
		( 'Nieto/a', 'Nieto/a del jefe de familia' ) ,
		( 'Sobrino/a', 'Sobrino/a del jefe de familia' ) ,
		( 'Hermano/a', 'Hermano/a del jefe de familia' ) ,
		( 'Primo/a', 'Primo/a del jefe de familia' ) ,
		( 'Tio/a', 'Tio/a del jefe de familia' ) ,
		( 'Abuelo/a', 'Abuelo/a del jefe de familia' )
GO