USE [master]
GO
/****** Object:  Database [DrugStore]    Script Date: 12/12/2022 9:06:32 AM ******/
CREATE DATABASE [DrugStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DrugStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DrugStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DrugStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DrugStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DrugStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DrugStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DrugStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DrugStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DrugStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DrugStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DrugStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [DrugStore] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DrugStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DrugStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DrugStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DrugStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DrugStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DrugStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DrugStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DrugStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DrugStore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DrugStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DrugStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DrugStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DrugStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DrugStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DrugStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DrugStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DrugStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DrugStore] SET  MULTI_USER 
GO
ALTER DATABASE [DrugStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DrugStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DrugStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DrugStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DrugStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DrugStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DrugStore] SET QUERY_STORE = OFF
GO
USE [DrugStore]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/12/2022 9:06:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 12/12/2022 9:06:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] NOT NULL,
	[Phone] [varchar](12) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Active] [bit] NULL,
	[FullName] [text] NULL,
	[RoleID] [int] NULL,
	[CustomerID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Agent]    Script Date: 12/12/2022 9:06:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agent](
	[AgentID] [int] NOT NULL,
	[AgentName] [text] NULL,
	[AgentAddress] [text] NULL,
	[AgentEmail] [text] NULL,
	[AgentPhone] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AgentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/12/2022 9:06:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CatID] [int] NOT NULL,
	[CatName] [text] NULL,
	[Description] [text] NULL,
	[Thumb] [text] NULL,
	[Title] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[CatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/12/2022 9:06:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] NOT NULL,
	[FullName] [text] NULL,
	[Birthday] [datetime] NULL,
	[Address] [text] NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [varchar](12) NULL,
	[Password] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 12/12/2022 9:06:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[ManuID] [int] NOT NULL,
	[ManuName] [text] NULL,
	[ManuAddress] [text] NULL,
	[ManuPhone] [int] NULL,
	[ManuEmail] [text] NULL,
	[ManuCountry] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ManuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 12/12/2022 9:06:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailID] [int] NOT NULL,
	[OrderID] [int] NULL,
	[SID] [int] NULL,
	[OrderNumber] [int] NULL,
	[Quantity] [int] NULL,
	[Discount] [int] NULL,
	[Total] [int] NULL,
	[ShipDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/12/2022 9:06:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] NOT NULL,
	[CustomerID] [int] NULL,
	[OrderDate] [datetime] NULL,
	[ShipDate] [datetime] NULL,
	[TransactID] [int] NULL,
	[Deleted] [bit] NULL,
	[Paid] [bit] NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentID] [int] NULL,
	[Note] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pages]    Script Date: 12/12/2022 9:06:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pages](
	[PageID] [int] NOT NULL,
	[PageName] [text] NULL,
	[Contents] [text] NULL,
	[Thumb] [nvarchar](250) NULL,
	[Published] [bit] NULL,
	[Title] [nvarchar](250) NULL,
	[MetaDesc] [nvarchar](250) NULL,
	[MetaKey] [nvarchar](250) NULL,
	[Alias] [nvarchar](250) NULL,
	[CreatedAt] [datetime] NULL,
	[Ordering] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 12/12/2022 9:06:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplement]    Script Date: 12/12/2022 9:06:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplement](
	[SID] [int] NOT NULL,
	[SName] [text] NULL,
	[SLink] [text] NULL,
	[ManuID] [int] NULL,
	[CatID] [int] NULL,
	[Uses] [text] NULL,
	[Ingredient] [text] NULL,
	[Directions] [text] NULL,
	[Warnings] [text] NULL,
	[OtherInfo] [text] NULL,
	[InactiveIngredient] [text] NULL,
	[Price] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactStatus]    Script Date: 12/12/2022 9:06:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactStatus](
	[TransactID] [int] NOT NULL,
	[Status] [nvarchar](50) NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Category] ([CatID], [CatName], [Description], [Thumb], [Title]) VALUES (1, N'Stomach Functional Food', N'Stomach group', N'stomach', N'stomach ')
INSERT [dbo].[Category] ([CatID], [CatName], [Description], [Thumb], [Title]) VALUES (2, N'Cardiovascular Functional Food', N'Cardiovascular group', NULL, N'Cardiovascular')
INSERT [dbo].[Category] ([CatID], [CatName], [Description], [Thumb], [Title]) VALUES (3, N'Blood Sugar Functional Food', N'Blood sugar group', NULL, N'Blood Sugar Functional Food')
INSERT [dbo].[Category] ([CatID], [CatName], [Description], [Thumb], [Title]) VALUES (4, N'Respiratory Functional Food', N'Respiratory Group', NULL, N'Respiratory Functional Food')
INSERT [dbo].[Category] ([CatID], [CatName], [Description], [Thumb], [Title]) VALUES (5, N'Nervous Functional Food', N'Nervous group', NULL, N'Nervous Functional Food')
INSERT [dbo].[Category] ([CatID], [CatName], [Description], [Thumb], [Title]) VALUES (6, N'Musculoskeletal Functional Food', N'Musculoskeletal Group', NULL, N'Musculoskeletal Functional Food')
INSERT [dbo].[Category] ([CatID], [CatName], [Description], [Thumb], [Title]) VALUES (7, N'Beauty Care Functional Food', N'Beauty Care Group', NULL, N'Beauty Care Functional Food')
INSERT [dbo].[Category] ([CatID], [CatName], [Description], [Thumb], [Title]) VALUES (8, N'Ear/Eye/Nose Functional Food', N'ear/eye/nose group', NULL, N'Ear/Eye/Nose Functional Food')
INSERT [dbo].[Category] ([CatID], [CatName], [Description], [Thumb], [Title]) VALUES (50, N'Others', N'others group goes here', NULL, N'Others')
GO
INSERT [dbo].[Manufacturer] ([ManuID], [ManuName], [ManuAddress], [ManuPhone], [ManuEmail], [ManuCountry]) VALUES (1, N'LiveSpo', N'Ha Noi', 21546287, N'livespo@gmail.com', N'Viet Nam')
INSERT [dbo].[Manufacturer] ([ManuID], [ManuName], [ManuAddress], [ManuPhone], [ManuEmail], [ManuCountry]) VALUES (2, N'Paul Brands', N'New York, USA', 123456789, N'paulbrands@gmail.com', N'USA')
INSERT [dbo].[Manufacturer] ([ManuID], [ManuName], [ManuAddress], [ManuPhone], [ManuEmail], [ManuCountry]) VALUES (3, N'Mediplantex', N'56 duong Giai Phong, quan Thanh Xuan – Ha noi', 243864336, N'mkt@mediplantex.com', N'Viet Nam')
INSERT [dbo].[Manufacturer] ([ManuID], [ManuName], [ManuAddress], [ManuPhone], [ManuEmail], [ManuCountry]) VALUES (4, N'France', N'Paris', 15948762, N'fr@gmail.com', N'France')
INSERT [dbo].[Manufacturer] ([ManuID], [ManuName], [ManuAddress], [ManuPhone], [ManuEmail], [ManuCountry]) VALUES (5, N'IMC', N'Lô 38-2 Khu CN Quang Minh 1,  Quang Minh, Me Linh, Ha Noi', NULL, N'info@imc.net.vn', N'Viet Nam')
INSERT [dbo].[Manufacturer] ([ManuID], [ManuName], [ManuAddress], [ManuPhone], [ManuEmail], [ManuCountry]) VALUES (6, N'BLACKMORES', N'Queensland ', 123456789, N'info@blackmores.com', N'Austrailia')
INSERT [dbo].[Manufacturer] ([ManuID], [ManuName], [ManuAddress], [ManuPhone], [ManuEmail], [ManuCountry]) VALUES (7, N'DHG Pharma', N'288 Bis, Nguyen Van Cu Street, An Hoa Ward, Ninh Kieu District, Can Tho City', 123456789, N'dhgpharma@dhgpharma.com.vn', N'Viet Nam')
INSERT [dbo].[Manufacturer] ([ManuID], [ManuName], [ManuAddress], [ManuPhone], [ManuEmail], [ManuCountry]) VALUES (8, N'Vitabiotics', N'1 Apsley Way, London, NW2 7HF', 123456798, N'vitabotics@gmail.com', N'United Kingdom')
INSERT [dbo].[Manufacturer] ([ManuID], [ManuName], [ManuAddress], [ManuPhone], [ManuEmail], [ManuCountry]) VALUES (9, N'Mamori', N'Tokyo', 123456789, N'mamori@gmail.com', N'Japan')
GO
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description]) VALUES (1, N'Admin', N'Admin')
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description]) VALUES (2, N'Staff', N'This is staff description')
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description]) VALUES (3, N'Agent', N'Agent')
GO
INSERT [dbo].[Supplement] ([SID], [SName], [SLink], [ManuID], [CatID], [Uses], [Ingredient], [Directions], [Warnings], [OtherInfo], [InactiveIngredient], [Price]) VALUES (2, N'Cumargold New Stomach Support Turmeric Tablets', N'CumarGold224515551.png', 2, 1, N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', 360000)
INSERT [dbo].[Supplement] ([SID], [SName], [SLink], [ManuID], [CatID], [Uses], [Ingredient], [Directions], [Warnings], [OtherInfo], [InactiveIngredient], [Price]) VALUES (3, N'Max Biolife', N'france-maxbiolife224713518.png', 3, 1, N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', 130000)
INSERT [dbo].[Supplement] ([SID], [SName], [SLink], [ManuID], [CatID], [Uses], [Ingredient], [Directions], [Warnings], [OtherInfo], [InactiveIngredient], [Price]) VALUES (4, N'Probiotic Colon (Box of 15 tubes x 5ml)', N'Untitled221044873.jpg', 1, 1, N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', 594122)
INSERT [dbo].[Supplement] ([SID], [SName], [SLink], [ManuID], [CatID], [Uses], [Ingredient], [Directions], [Warnings], [OtherInfo], [InactiveIngredient], [Price]) VALUES (5, N'Trang Phuc Linh Plus (2 blisters x 10 tablets)', N'imc-trangphuclinh225202343.png', 4, 1, N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', 185000)
INSERT [dbo].[Supplement] ([SID], [SName], [SLink], [ManuID], [CatID], [Uses], [Ingredient], [Directions], [Warnings], [OtherInfo], [InactiveIngredient], [Price]) VALUES (6, N'An Tri Vuong (Box of 3 blisters x 10 tablets)', N'imc-antrivuong225401643.jpg', 1, 1, N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', 175000)
INSERT [dbo].[Supplement] ([SID], [SName], [SLink], [ManuID], [CatID], [Uses], [Ingredient], [Directions], [Warnings], [OtherInfo], [InactiveIngredient], [Price]) VALUES (7, N'Ecogreen Faz (Box of 30 tablets)', N'paulbrand-faz225845551.png', 5, 2, N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', 300000)
INSERT [dbo].[Supplement] ([SID], [SName], [SLink], [ManuID], [CatID], [Uses], [Ingredient], [Directions], [Warnings], [OtherInfo], [InactiveIngredient], [Price]) VALUES (8, N'Blackmores CoQ10 150mg (Bottle of 30 tablets)', N'blackmores-coq10220052825.png', 6, 2, N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', 545000)
INSERT [dbo].[Supplement] ([SID], [SName], [SLink], [ManuID], [CatID], [Uses], [Ingredient], [Directions], [Warnings], [OtherInfo], [InactiveIngredient], [Price]) VALUES (9, N'NattoEnzym (3 blisters x 10 tablets/box)', N'dhgpharma-nattoenzym220741494.jpg', 7, 2, N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', 118000)
INSERT [dbo].[Supplement] ([SID], [SName], [SLink], [ManuID], [CatID], [Uses], [Ingredient], [Directions], [Warnings], [OtherInfo], [InactiveIngredient], [Price]) VALUES (10, N'Nattoenzyme Red Rice (Box of 60 tablets)', N'dhgpharma-nattoenzymredrice220935058.jpg', 7, 2, N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', 420000)
INSERT [dbo].[Supplement] ([SID], [SName], [SLink], [ManuID], [CatID], [Uses], [Ingredient], [Directions], [Warnings], [OtherInfo], [InactiveIngredient], [Price]) VALUES (11, N'Vitabiotics Cardioace Original (2 blisters x 15 tablets/box)', N'vitabiotics-cardioace221118849.png', 8, 1, N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', 369000)
INSERT [dbo].[Supplement] ([SID], [SName], [SLink], [ManuID], [CatID], [Uses], [Ingredient], [Directions], [Warnings], [OtherInfo], [InactiveIngredient], [Price]) VALUES (13, N'Preventing stroke Mamori Nattokinase (Box of 60 tablets)', N'mamori-nattokinase221346419.png', 9, 2, N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', N'Lorem ispum', 638000)
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Customers]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([SID])
REFERENCES [dbo].[Supplement] ([SID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([TransactID])
REFERENCES [dbo].[TransactStatus] ([TransactID])
GO
ALTER TABLE [dbo].[Supplement]  WITH CHECK ADD FOREIGN KEY([CatID])
REFERENCES [dbo].[Category] ([CatID])
GO
ALTER TABLE [dbo].[Supplement]  WITH CHECK ADD FOREIGN KEY([ManuID])
REFERENCES [dbo].[Manufacturer] ([ManuID])
GO
USE [master]
GO
ALTER DATABASE [DrugStore] SET  READ_WRITE 
GO
