USE master;
IF ( EXISTS ( SELECT    name
              FROM      master.dbo.sysdatabases
              WHERE     ( '[' + name + ']' = 'SisGEN'
                          OR name = 'SisGEN'
                        ) ) )
    BEGIN
        EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'SisGEN'
        ALTER DATABASE SisGEN
        SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
        DROP DATABASE SisGEN                      	
    END
GO

CREATE DATABASE SisGEN
GO

USE SisGEN
GO

/*==============================================================*/
/* Table: FAM_Familias                                          */
/*==============================================================*/
CREATE TABLE FAM_Familias
    (
      IdFamilia INT NOT NULL ,
      Folio INT NOT NULL ,
      RUTUsuario INT NOT NULL ,
      NombreFamilia VARCHAR(50) NOT NULL ,
      Direccion VARCHAR(MAX) NOT NULL ,
      ReferenciaDir VARCHAR(MAX) NULL ,
      Telefono1 INT NOT NULL ,
      Telefono2 INT NULL ,
      IdGestorFamiliar INT NOT NULL ,
      EstadoApoLaboral BIT NOT NULL ,
      CONSTRAINT PK_FAM_FAMILIAS PRIMARY KEY ( IdFamilia )
    )
GO

/*==============================================================*/
/* Table: FAM_IntegrantesFamilia                                */
/*==============================================================*/
CREATE TABLE FAM_IntegrantesFamilia
    (
      IdFamilia INT NOT NULL ,
      RUT INT NOT NULL ,
      CONSTRAINT PK_FAM_INTEGRANTESFAMILIA PRIMARY KEY ( IdFamilia )
    )
GO

/*==============================================================*/
/* Table: GEN_EstadoCivil                                       */
/*==============================================================*/
CREATE TABLE GEN_EstadoCivil
    (
      IdEstadoCivil INT IDENTITY ,
      EstadoCivil VARCHAR(30) NOT NULL ,
      Descripcion VARCHAR(MAX) NULL ,
      CONSTRAINT PK_GEN_ESTADOCIVIL PRIMARY KEY ( IdEstadoCivil )
    )
GO

/*==============================================================*/
/* Table: GEN_GestoresFamiliares                                */
/*==============================================================*/
CREATE TABLE GEN_GestoresFamiliares
    (
      IdGestorFamiliar INT IDENTITY ,
      Nombres VARCHAR(30) NOT NULL ,
      ApPaterno VARCHAR(30) NOT NULL ,
      ApMaterno VARCHAR(30) NULL ,
      Telefono INT NOT NULL ,
      Email VARCHAR(100) NOT NULL ,
      CONSTRAINT PK_GEN_GESTORESFAMILIARES PRIMARY KEY ( IdGestorFamiliar )
    )
GO

/*==============================================================*/
/* Table: GEN_Parentescos                                       */
/*==============================================================*/
CREATE TABLE GEN_Parentescos
    (
      IdParentesco INT IDENTITY ,
      Parentesco VARCHAR(30) NOT NULL ,
      Descripcion VARCHAR(MAX) NULL ,
      CONSTRAINT PK_GEN_PARENTESCOS PRIMARY KEY ( IdParentesco )
    )
GO

/*==============================================================*/
/* Table: GEN_Rol                                               */
/*==============================================================*/
CREATE TABLE GEN_Rol
    (
      IdRol INT IDENTITY ,
      Rol VARCHAR(20) NOT NULL ,
      Descripcion VARCHAR(MAX) NULL ,
      CONSTRAINT PK_GEN_ROL PRIMARY KEY ( IdRol )
    )
GO

/*==============================================================*/
/* Table: GEN_Usuarios                                          */
/*==============================================================*/
CREATE TABLE GEN_Usuarios
    (
      RUT INT NOT NULL ,
      DV CHAR(1) NOT NULL ,
      Nombres VARCHAR(30) NOT NULL ,
      ApPaterno VARCHAR(30) NOT NULL ,
      ApMaterno VARCHAR(30) NOT NULL ,
      Fono INT NULL ,
      Celular INT NOT NULL ,
      Email VARCHAR(50) NOT NULL ,
      Imagen VARCHAR(MAX) NOT NULL ,
      IdRol INT NOT NULL ,
      Clave VARCHAR(20) NOT NULL ,
      Estado BIT NOT NULL ,
      CONSTRAINT PK_GEN_USUARIOS PRIMARY KEY ( RUT )
    )
GO

/*==============================================================*/
/* Table: INT_Integrantes                                       */
/*==============================================================*/
CREATE TABLE INT_Integrantes
    (
      RUT INT NOT NULL ,
      DV CHAR(1) NOT NULL ,
      Nombres VARCHAR(30) NOT NULL ,
      ApPaterno VARCHAR(30) NOT NULL ,
      ApMaterno VARCHAR(30) NOT NULL ,
      IdParentesco INT NOT NULL ,
      Sexo BIT NOT NULL ,
      FechaNac DATE NOT NULL ,
      IdEstadoCivil INT NOT NULL ,
      IdNivelEscolar INT NOT NULL ,
      IdOcupacion INT NOT NULL ,
      DescOcupacion VARCHAR(MAX) NULL ,
      CONSTRAINT PK_INT_INTEGRANTES PRIMARY KEY ( RUT )
    )
GO

/*==============================================================*/
/* Table: INT_NivelesEscolaridad                                */
/*==============================================================*/
CREATE TABLE INT_NivelesEscolaridad
    (
      IdNivelEscolar INT IDENTITY ,
      NivelEscolar VARCHAR(30) NOT NULL ,
      Descripcion VARCHAR(MAX) NULL ,
      CONSTRAINT PK_INT_NIVELESESCOLARIDAD PRIMARY KEY ( IdNivelEscolar )
    )
GO

/*==============================================================*/
/* Table: INT_Ocupaciones                                       */
/*==============================================================*/
CREATE TABLE INT_Ocupaciones
    (
      IdOcupacion INT IDENTITY ,
      Ocupacion VARCHAR(30) NOT NULL ,
      Descripcion VARCHAR(MAX) NULL ,
      CONSTRAINT PK_INT_OCUPACIONES PRIMARY KEY ( IdOcupacion )
    )
GO

ALTER TABLE FAM_Familias
ADD CONSTRAINT FK_FAM_FAMI_REFERENCE_GEN_USUA FOREIGN KEY (RUTUsuario)
REFERENCES GEN_Usuarios (RUT)
GO

ALTER TABLE FAM_Familias
ADD CONSTRAINT FK_FAM_FAMI_REFERENCE_GEN_GEST FOREIGN KEY (IdGestorFamiliar)
REFERENCES GEN_GestoresFamiliares (IdGestorFamiliar)
GO

ALTER TABLE FAM_IntegrantesFamilia
ADD CONSTRAINT FK_FAM_INTE_REFERENCE_FAM_FAMI FOREIGN KEY (IdFamilia)
REFERENCES FAM_Familias (IdFamilia)
GO

ALTER TABLE FAM_IntegrantesFamilia
ADD CONSTRAINT FK_FAM_INTE_REFERENCE_INT_INTE FOREIGN KEY (RUT)
REFERENCES INT_Integrantes (RUT)
GO

ALTER TABLE GEN_Usuarios
ADD CONSTRAINT FK_GEN_USUA_REFERENCE_GEN_ROL FOREIGN KEY (IdRol)
REFERENCES GEN_Rol (IdRol)
GO

ALTER TABLE INT_Integrantes
ADD CONSTRAINT FK_INT_INTE_REFERENCE_GEN_ESTA FOREIGN KEY (IdEstadoCivil)
REFERENCES GEN_EstadoCivil (IdEstadoCivil)
GO

ALTER TABLE INT_Integrantes
ADD CONSTRAINT FK_INT_INTE_REFERENCE_GEN_PARE FOREIGN KEY (IdParentesco)
REFERENCES GEN_Parentescos (IdParentesco)
GO

ALTER TABLE INT_Integrantes
ADD CONSTRAINT FK_INT_INTE_REFERENCE_INT_NIVE FOREIGN KEY (IdNivelEscolar)
REFERENCES INT_NivelesEscolaridad (IdNivelEscolar)
GO

ALTER TABLE INT_Integrantes
ADD CONSTRAINT FK_INT_INTE_REFERENCE_INT_OCUP FOREIGN KEY (IdOcupacion)
REFERENCES INT_Ocupaciones (IdOcupacion)
GO
