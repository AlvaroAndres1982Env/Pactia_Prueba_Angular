CREATE DATABASE pactia

USE [pactia]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 5/09/2023 10:46:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [varchar](11) NULL,
	[Nombre] [varchar](200) NULL,
	[Apellido] [varchar](200) NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[usp_Usuarios]    Script Date: 5/09/2023 10:46:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alvaro Andres Serna Vasquez
-- Create date: 4 de Sep 2023
-- Description:	Administración de usuarios 
-- =============================================
CREATE PROCEDURE [dbo].[usp_Usuarios] 

@accion varchar(50),
@Id int =0, 
@Cedula varchar(11),
@Nombre varchar(200)='',
@Apellido varchar(200)=''

AS
BEGIN
 
if @accion = 'lista'
	SELECT [Id]
		  ,[Cedula]
		  ,[Nombre]
		  ,[Apellido]
	FROM [dbo].[usuarios]

if @accion = 'Guardar'
	INSERT INTO [dbo].[usuarios]
           ([Cedula]
           ,[Nombre]
           ,[Apellido])
     VALUES (@Cedula,@Nombre,@Apellido)

if @accion = 'Actualizar'
   UPDATE [dbo].[usuarios]
   SET [Cedula] = @Cedula
      ,[Nombre] = @Nombre
      ,[Apellido] = @Apellido
   WHERE  [Id] = @Id

if @accion = 'Eliminar'
	DELETE FROM [dbo].[usuarios] 
	WHERE [Id] =@Id 

END
GO
