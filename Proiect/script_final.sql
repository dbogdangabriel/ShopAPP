USE [master]
GO
/****** Object:  Database [dbShop]    Script Date: 02-Jun-21 4:24:21 PM ******/
CREATE DATABASE [dbShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbShop', FILENAME = N'C:\Users\Bogdan\dbShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbShop_log', FILENAME = N'C:\Users\Bogdan\dbShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbShop] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbShop] SET  MULTI_USER 
GO
ALTER DATABASE [dbShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbShop] SET QUERY_STORE = OFF
GO
USE [dbShop]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [dbShop]
GO
/****** Object:  Table [dbo].[Cars_shop]    Script Date: 02-Jun-21 4:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars_shop](
	[CarID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Price] [nvarchar](50) NULL,
	[Color] [nvarchar](50) NULL,
	[ImageUrl] [varchar](250) NULL,
 CONSTRAINT [PK_Cars_shop] PRIMARY KEY CLUSTERED 
(
	[CarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart_Cars]    Script Date: 02-Jun-21 4:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart_Cars](
	[CarID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Price] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart_PC]    Script Date: 02-Jun-21 4:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart_PC](
	[PCID] [int] IDENTITY(1,1) NOT NULL,
	[CPU] [nvarchar](50) NULL,
	[Price] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 02-Jun-21 4:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[name] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[total] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginTbl]    Script Date: 02-Jun-21 4:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginTbl](
	[LoginID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PC_shop]    Script Date: 02-Jun-21 4:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PC_shop](
	[PCID] [int] IDENTITY(1,1) NOT NULL,
	[CPU] [nvarchar](50) NULL,
	[GPU] [nvarchar](50) NULL,
	[RAM] [nvarchar](50) NULL,
	[Storage] [nvarchar](50) NULL,
	[Storage_type] [bit] NULL,
	[ImageUrl] [varchar](250) NULL,
	[Price] [nvarchar](50) NULL,
 CONSTRAINT [PK_PC_shop] PRIMARY KEY CLUSTERED 
(
	[PCID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImport]    Script Date: 02-Jun-21 4:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImport](
	[Id] [varchar](50) NOT NULL,
	[Name] [varchar](50) NULL,
	[Price] [money] NULL,
	[Quantity] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cars_shop] ON 

INSERT [dbo].[Cars_shop] ([CarID], [Name], [Type], [Price], [Color], [ImageUrl]) VALUES (1, N'Ford Fiesta', N'Street', N'15000', N'Blue', N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\imagini_masini_ii\ford_fiesta.jpg')
INSERT [dbo].[Cars_shop] ([CarID], [Name], [Type], [Price], [Color], [ImageUrl]) VALUES (2, N'Volskwagen Golf 6', N'Street', N'25000', N'Blue', N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\imagini_masini_ii\volkswagen_ar.jpg')
INSERT [dbo].[Cars_shop] ([CarID], [Name], [Type], [Price], [Color], [ImageUrl]) VALUES (3, N'Opel Astra', N'Street', N'14500', N'Red', N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\imagini_masini_ii\OpelAstra.jpg')
INSERT [dbo].[Cars_shop] ([CarID], [Name], [Type], [Price], [Color], [ImageUrl]) VALUES (4, N'Dacia Logan', N'Street', N'7900', N'Grey', N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\imagini_masini_ii\dacia_logan.jpg')
INSERT [dbo].[Cars_shop] ([CarID], [Name], [Type], [Price], [Color], [ImageUrl]) VALUES (5, N'Peugeot 308', N'Street', N'17000', N'Black', N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\imagini_masini_ii\peugeot308.jpg')
INSERT [dbo].[Cars_shop] ([CarID], [Name], [Type], [Price], [Color], [ImageUrl]) VALUES (6, N'BMW 320', N'Street', N'32000', N'Blue', N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\imagini_masini_ii\bmw320.jpg')
INSERT [dbo].[Cars_shop] ([CarID], [Name], [Type], [Price], [Color], [ImageUrl]) VALUES (7, N'Chevrolet Orlando', N'Street', N'16000', N'Grey', N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\imagini_masini_ii\chevrolet.jpg')
INSERT [dbo].[Cars_shop] ([CarID], [Name], [Type], [Price], [Color], [ImageUrl]) VALUES (8, N'Audi A4 New', N'Racing', N'35000', N'Grey', N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\imagini_masini_ii\audi_a4jpg.jpg')
INSERT [dbo].[Cars_shop] ([CarID], [Name], [Type], [Price], [Color], [ImageUrl]) VALUES (9, N'Audi A5', N'Street', N'32000', N'White', N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\imagini_masini_ii\audi_a5.jpg')
INSERT [dbo].[Cars_shop] ([CarID], [Name], [Type], [Price], [Color], [ImageUrl]) VALUES (10, N'Audi Q5', N'4x4', N'33000', N'Aqua', N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\imagini_masini_ii\audi_q5.jpg')
INSERT [dbo].[Cars_shop] ([CarID], [Name], [Type], [Price], [Color], [ImageUrl]) VALUES (11, N'Volkswagen AR', N'4x4', N'35000', N'Brown', N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\imagini_masini_ii\volkswagen_ar.jpg')
INSERT [dbo].[Cars_shop] ([CarID], [Name], [Type], [Price], [Color], [ImageUrl]) VALUES (13, N'Volvo XC90', N'4x4', N'39000', N'Grey', N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\imagini_masini_ii\volvo_xc90jpg.jpg')
INSERT [dbo].[Cars_shop] ([CarID], [Name], [Type], [Price], [Color], [ImageUrl]) VALUES (14, N'BMW M3', N'Street', N'66000', N'White', N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\imagini_masini_ii\BMW_M3.jpg')
INSERT [dbo].[Cars_shop] ([CarID], [Name], [Type], [Price], [Color], [ImageUrl]) VALUES (15, N'BMW E69', N'Street', N'30000', N'Black', N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\imagini_masini_ii\BMW_E69.jpg')
INSERT [dbo].[Cars_shop] ([CarID], [Name], [Type], [Price], [Color], [ImageUrl]) VALUES (16, N'Tesla X', N'4x4', N'69000', N'Blue', N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\imagini_masini_ii\TeslaX.jpg')
SET IDENTITY_INSERT [dbo].[Cars_shop] OFF
GO
SET IDENTITY_INSERT [dbo].[Cart_Cars] ON 

INSERT [dbo].[Cart_Cars] ([CarID], [Name], [Price]) VALUES (1, N'Ford Fiesta', N'15000')
INSERT [dbo].[Cart_Cars] ([CarID], [Name], [Price]) VALUES (4, N'Dacia Logan', N'7900')
INSERT [dbo].[Cart_Cars] ([CarID], [Name], [Price]) VALUES (5, N'Peugeot 308', N'17000')
INSERT [dbo].[Cart_Cars] ([CarID], [Name], [Price]) VALUES (7, N'Chevrolet Orlando', N'16000')
SET IDENTITY_INSERT [dbo].[Cart_Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Cart_PC] ON 

INSERT [dbo].[Cart_PC] ([PCID], [CPU], [Price]) VALUES (1, N'I5', N'1000')
INSERT [dbo].[Cart_PC] ([PCID], [CPU], [Price]) VALUES (2, N'I5', N'10000')
INSERT [dbo].[Cart_PC] ([PCID], [CPU], [Price]) VALUES (3, N'I3', N'900')
INSERT [dbo].[Cart_PC] ([PCID], [CPU], [Price]) VALUES (4, N'I3', N'950')
INSERT [dbo].[Cart_PC] ([PCID], [CPU], [Price]) VALUES (5, N'I5', N'1500')
SET IDENTITY_INSERT [dbo].[Cart_PC] OFF
GO
INSERT [dbo].[Clients] ([name], [address], [phone], [total]) VALUES (N'Jonny Yeah', N'Cluj-Napoca 14', N'041561454165', N'70250')
GO
SET IDENTITY_INSERT [dbo].[LoginTbl] ON 

INSERT [dbo].[LoginTbl] ([LoginID], [Username], [Password], [Email]) VALUES (1, N'user1', N'pass1', N'user1@gmail.com')
INSERT [dbo].[LoginTbl] ([LoginID], [Username], [Password], [Email]) VALUES (2, N'user2', N'pass2', N'user2@gmail.com')
SET IDENTITY_INSERT [dbo].[LoginTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[PC_shop] ON 

INSERT [dbo].[PC_shop] ([PCID], [CPU], [GPU], [RAM], [Storage], [Storage_type], [ImageUrl], [Price]) VALUES (1, N'I5', N'GTX 1050', N'8GB', N'1TB', 0, N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\Imagini_pc_ii\pc1.jpg', N'1000')
INSERT [dbo].[PC_shop] ([PCID], [CPU], [GPU], [RAM], [Storage], [Storage_type], [ImageUrl], [Price]) VALUES (2, N'I5', N'RTX3090', N'12GB', N'2TB', 1, N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\Imagini_pc_ii\pc2.jpg', N'10000')
INSERT [dbo].[PC_shop] ([PCID], [CPU], [GPU], [RAM], [Storage], [Storage_type], [ImageUrl], [Price]) VALUES (3, N'I3', N'GT1030', N'4GB', N'512GB', 0, N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\Imagini_pc_ii\pc3.jpg', N'900')
INSERT [dbo].[PC_shop] ([PCID], [CPU], [GPU], [RAM], [Storage], [Storage_type], [ImageUrl], [Price]) VALUES (4, N'I3', N'Radeon RX 550', N'4GB', N'512GB', 1, N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\Imagini_pc_ii\pc4.jpg', N'950')
INSERT [dbo].[PC_shop] ([PCID], [CPU], [GPU], [RAM], [Storage], [Storage_type], [ImageUrl], [Price]) VALUES (5, N'I5', N'GTX1650', N'6GB', N'1TB', 1, N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\Imagini_pc_ii\pc5.jpg', N'1500')
INSERT [dbo].[PC_shop] ([PCID], [CPU], [GPU], [RAM], [Storage], [Storage_type], [ImageUrl], [Price]) VALUES (6, N'I7', N'GTX 1660 Ti', N'6GB', N'512GB', 1, N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\Imagini_pc_ii\pc6.jpg', N'1200')
INSERT [dbo].[PC_shop] ([PCID], [CPU], [GPU], [RAM], [Storage], [Storage_type], [ImageUrl], [Price]) VALUES (7, N'I7 ', N'GTX 1070', N'4 GB', N'512 GB', 0, N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\Imagini_pc_ii\pc7.jpg', N'1300')
INSERT [dbo].[PC_shop] ([PCID], [CPU], [GPU], [RAM], [Storage], [Storage_type], [ImageUrl], [Price]) VALUES (8, N'I5', N'GTX 1660', N'4GB', N'512GB', 0, N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\Imagini_pc_ii\pc8.jpg', N'800')
INSERT [dbo].[PC_shop] ([PCID], [CPU], [GPU], [RAM], [Storage], [Storage_type], [ImageUrl], [Price]) VALUES (9, N'I3 ', N'Radeon R9 Fury', N'6GB', N'512GB', 1, N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\Imagini_pc_ii\pc9.jpg', N'900')
INSERT [dbo].[PC_shop] ([PCID], [CPU], [GPU], [RAM], [Storage], [Storage_type], [ImageUrl], [Price]) VALUES (10, N'I5', N'Radeon RX 590', N'4GB', N'1TB', 0, N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\Imagini_pc_ii\pc10.jpg', N'950')
INSERT [dbo].[PC_shop] ([PCID], [CPU], [GPU], [RAM], [Storage], [Storage_type], [ImageUrl], [Price]) VALUES (11, N'i3', N'GTX 1060', N'4GB', N'512GB', 0, N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\Imagini_pc_ii\pc11.jpg', N'2000')
INSERT [dbo].[PC_shop] ([PCID], [CPU], [GPU], [RAM], [Storage], [Storage_type], [ImageUrl], [Price]) VALUES (12, N'i3', N'GTX 1050', N'6GB', N'1TB', 1, N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\Imagini_pc_ii\pc12.jpg', N'1700')
INSERT [dbo].[PC_shop] ([PCID], [CPU], [GPU], [RAM], [Storage], [Storage_type], [ImageUrl], [Price]) VALUES (13, N'i5', N'GTX 1070', N'6GB', N'1TB', 1, N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\Imagini_pc_ii\pc13.jpg', N'1500')
INSERT [dbo].[PC_shop] ([PCID], [CPU], [GPU], [RAM], [Storage], [Storage_type], [ImageUrl], [Price]) VALUES (14, N'i3', N'GTX 1080', N'8GB', N'2TB', 1, N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\Imagini_pc_ii\pc14.jpg', N'1500')
INSERT [dbo].[PC_shop] ([PCID], [CPU], [GPU], [RAM], [Storage], [Storage_type], [ImageUrl], [Price]) VALUES (15, N'i7', N'GTX 2080', N'8GB', N'1TB', 1, N'C:\Users\Bogdan\source\repos\II\proj\Proiect\Proiect\Imagini_pc_ii\pc15.jpg', N'3500')
SET IDENTITY_INSERT [dbo].[PC_shop] OFF
GO
ALTER TABLE [dbo].[Cart_Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Cars_Cars_shop] FOREIGN KEY([CarID])
REFERENCES [dbo].[Cars_shop] ([CarID])
GO
ALTER TABLE [dbo].[Cart_Cars] CHECK CONSTRAINT [FK_Cart_Cars_Cars_shop]
GO
ALTER TABLE [dbo].[Cart_PC]  WITH CHECK ADD  CONSTRAINT [FK_Cart_PC_PC_shop] FOREIGN KEY([PCID])
REFERENCES [dbo].[PC_shop] ([PCID])
GO
ALTER TABLE [dbo].[Cart_PC] CHECK CONSTRAINT [FK_Cart_PC_PC_shop]
GO
/****** Object:  StoredProcedure [dbo].[sp_Car_Insert]    Script Date: 02-Jun-21 4:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_Car_Insert]
(
	@CarID int output,
	@Name nvarchar(50),
	@Type nvarchar(50),
	@Price nvarchar(50),
	@Color nvarchar(50),
	@ImageUrl varchar(250)

)
as
	insert into Cars_shop(Name, Type, Price, Color, ImageUrl)
	values(@Name, @Type, @Price, @Color, @ImageUrl)
	set @CarID = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[sp_Car_update]    Script Date: 02-Jun-21 4:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_Car_update]
(
	@CarID int output,
	@Name nvarchar(50),
	@Type nvarchar(50),
	@Price nvarchar(50),
	@Color nvarchar(50),
	@ImageUrl varchar(250)

)
as
	update Cars_shop set Name = @Name, Type = @Type, Price = @Price, Color = @Color, ImageUrl= @ImageUrl
	where CarID = @CarID 
GO
/****** Object:  StoredProcedure [dbo].[sp_Client_insert]    Script Date: 02-Jun-21 4:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_Client_insert]
(
@name nvarchar(50),
@address nvarchar(50),
@phone nvarchar(50),
@total nvarchar(50)
)
as
insert into Clients(name, address, phone, total) 
	values (@name, @address, @phone, @total)

GO
/****** Object:  StoredProcedure [dbo].[sp_PC_Cart]    Script Date: 02-Jun-21 4:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create procedure [dbo].[sp_PC_Cart]

as
Begin set nocount on
SET IDENTITY_INSERT Cart_PC ON
	insert into Cart_PC(PCID ,CPU, Price) select PCID, CPU, PRICE from PC_shop 
	SET IDENTITY_INSERT Cart_PC OFF
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PC_Insert]    Script Date: 02-Jun-21 4:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[sp_PC_Insert]
(
	@PCID int output,
	@CPU nvarchar(50),
	@GPU nvarchar(50),
	@RAM nvarchar(50),
	@Storage nvarchar(50),
	@Storage_type bit,
	@Price nvarchar(50),
	@ImageUrl varchar(250)

)
as
	insert into PC_shop(CPU, GPU, RAM, Storage, Storage_type, Price, ImageUrl)
	values(@CPU, @GPU, @RAM, @Storage, @Storage_type, @Price, @ImageUrl)
	set @PCID = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[sp_PC_update]    Script Date: 02-Jun-21 4:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[sp_PC_update]
(
	@PCID int output,
	@CPU nvarchar(50),
	@GPU nvarchar(50),
	@RAM nvarchar(50),
	@Storage nvarchar(50),
	@Storage_type bit,
	@Price nvarchar(50),
	@ImageUrl varchar(250)

)
as
	update PC_shop set CPU = @CPU, GPU = @GPU, RAM = @RAM, Storage = @Storage, Storage_type = @Storage_type, Price = @Price, ImageUrl = @ImageUrl
	where PCID = @PCID 
GO
USE [master]
GO
ALTER DATABASE [dbShop] SET  READ_WRITE 
GO
