USE [BazaPodataka]
GO
/****** Object:  Table [dbo].[Proizvod]    Script Date: 07/23/2018 19:23:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proizvod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](max) NOT NULL,
	[Opis] [nvarchar](max) NULL,
	[Kategorija] [nvarchar](max) NULL,
	[Proizvodjac] [nvarchar](max) NULL,
	[Dobavljac] [nvarchar](max) NULL,
	[Cena] [float] NOT NULL,
 CONSTRAINT [PK_dbo.Proizvod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
