USE [master]
GO
/****** Object:  Database [JobOfferManagerDB]    Script Date: 14/06/2025 10:28:35 a. m. ******/
CREATE DATABASE [JobOfferManagerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JobOfferManagerDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\JobOfferManagerDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JobOfferManagerDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\JobOfferManagerDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [JobOfferManagerDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JobOfferManagerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JobOfferManagerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JobOfferManagerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JobOfferManagerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JobOfferManagerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JobOfferManagerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET RECOVERY FULL 
GO
ALTER DATABASE [JobOfferManagerDB] SET  MULTI_USER 
GO
ALTER DATABASE [JobOfferManagerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JobOfferManagerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JobOfferManagerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JobOfferManagerDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JobOfferManagerDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JobOfferManagerDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'JobOfferManagerDB', N'ON'
GO
ALTER DATABASE [JobOfferManagerDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [JobOfferManagerDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [JobOfferManagerDB]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 14/06/2025 10:28:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[IdDepartment] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractTypes]    Script Date: 14/06/2025 10:28:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_ContractType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 14/06/2025 10:28:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 14/06/2025 10:28:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[IdCountry] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpirationTimes]    Script Date: 14/06/2025 10:28:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpirationTimes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Range] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_ExpirationTimes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobOffers]    Script Date: 14/06/2025 10:28:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobOffers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Address] [varchar](100) NULL,
	[IdCity] [int] NOT NULL,
	[IdSalary] [int] NOT NULL,
	[HideSalary] [bit] NOT NULL,
	[IdContractType] [int] NOT NULL,
	[IdExpirationTime] [int] NOT NULL,
	[IdUserWhoRegisteredIt] [int] NOT NULL,
	[IdUserWhoModifiedIt] [int] NULL,
	[PublishedAt] [datetime] NULL,
	[ExpiredAt] [datetime] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_JobOffers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salaries]    Script Date: 14/06/2025 10:28:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salaries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Range] [varchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Salaries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 14/06/2025 10:28:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](500) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 
GO
INSERT [dbo].[Cities] ([Id], [Name], [IsDeleted], [IdDepartment], [CreatedAt], [UpdatedAt]) VALUES (1, N'Bogotá', 0, 1, CAST(N'2025-06-11T20:19:03.957' AS DateTime), CAST(N'2025-06-11T20:19:03.957' AS DateTime))
GO
INSERT [dbo].[Cities] ([Id], [Name], [IsDeleted], [IdDepartment], [CreatedAt], [UpdatedAt]) VALUES (2, N'Medellín', 0, 2, CAST(N'2025-06-11T20:19:03.957' AS DateTime), CAST(N'2025-06-11T20:19:03.957' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[ContractTypes] ON 
GO
INSERT [dbo].[ContractTypes] ([Id], [Name], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (1, N'Indefinido', 0, CAST(N'2025-06-11T19:53:10.263' AS DateTime), CAST(N'2025-06-11T19:53:10.263' AS DateTime))
GO
INSERT [dbo].[ContractTypes] ([Id], [Name], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (2, N'Definido', 0, CAST(N'2025-06-11T19:53:10.263' AS DateTime), CAST(N'2025-06-11T19:53:10.263' AS DateTime))
GO
INSERT [dbo].[ContractTypes] ([Id], [Name], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (3, N'Por obra o servicio', 0, CAST(N'2025-06-11T19:53:10.263' AS DateTime), CAST(N'2025-06-11T19:53:10.263' AS DateTime))
GO
INSERT [dbo].[ContractTypes] ([Id], [Name], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (4, N'Pasantía', 0, CAST(N'2025-06-11T19:53:10.263' AS DateTime), CAST(N'2025-06-11T19:53:10.263' AS DateTime))
GO
INSERT [dbo].[ContractTypes] ([Id], [Name], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (5, N'Medio tiempo', 0, CAST(N'2025-06-11T19:53:10.263' AS DateTime), CAST(N'2025-06-11T19:53:10.263' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ContractTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 
GO
INSERT [dbo].[Countries] ([Id], [Name], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (1, N'Colombia', 0, CAST(N'2025-06-11T20:04:07.380' AS DateTime), CAST(N'2025-06-11T20:04:07.380' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 
GO
INSERT [dbo].[Departments] ([Id], [Name], [IsDeleted], [IdCountry], [CreatedAt], [UpdatedAt]) VALUES (1, N'Bogotá D.C.', 0, 1, CAST(N'2025-06-11T20:08:43.997' AS DateTime), CAST(N'2025-06-11T20:08:43.997' AS DateTime))
GO
INSERT [dbo].[Departments] ([Id], [Name], [IsDeleted], [IdCountry], [CreatedAt], [UpdatedAt]) VALUES (2, N'Antioquia', 0, 1, CAST(N'2025-06-11T20:09:56.400' AS DateTime), CAST(N'2025-06-11T20:09:56.400' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[ExpirationTimes] ON 
GO
INSERT [dbo].[ExpirationTimes] ([Id], [Name], [Range], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (1, N'7 días', 7, 0, CAST(N'2025-06-11T20:51:54.160' AS DateTime), CAST(N'2025-06-11T20:51:54.160' AS DateTime))
GO
INSERT [dbo].[ExpirationTimes] ([Id], [Name], [Range], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (2, N'15 días', 15, 0, CAST(N'2025-06-11T20:51:54.160' AS DateTime), CAST(N'2025-06-11T20:51:54.160' AS DateTime))
GO
INSERT [dbo].[ExpirationTimes] ([Id], [Name], [Range], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (3, N'30 días', 30, 0, CAST(N'2025-06-11T20:51:54.160' AS DateTime), CAST(N'2025-06-11T20:51:54.160' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ExpirationTimes] OFF
GO
SET IDENTITY_INSERT [dbo].[JobOffers] ON 
GO
INSERT [dbo].[JobOffers] ([Id], [Title], [Description], [IsDeleted], [Address], [IdCity], [IdSalary], [HideSalary], [IdContractType], [IdExpirationTime], [IdUserWhoRegisteredIt], [IdUserWhoModifiedIt], [PublishedAt], [ExpiredAt], [CreatedAt], [UpdatedAt]) VALUES (1, N'Oferta Test 1', N'Esto es una prueba', 0, N'Cra A #01-01', 1, 2, 1, 1, 3, 1, NULL, CAST(N'2025-06-11T20:58:04.670' AS DateTime), CAST(N'2025-07-11T20:58:04.670' AS DateTime), CAST(N'2025-06-11T20:58:04.670' AS DateTime), CAST(N'2025-06-11T20:58:04.670' AS DateTime))
GO
INSERT [dbo].[JobOffers] ([Id], [Title], [Description], [IsDeleted], [Address], [IdCity], [IdSalary], [HideSalary], [IdContractType], [IdExpirationTime], [IdUserWhoRegisteredIt], [IdUserWhoModifiedIt], [PublishedAt], [ExpiredAt], [CreatedAt], [UpdatedAt]) VALUES (2, N'Oferta test 2', N'Esto es una oferta de prueba', 0, N'Cra 4 #08-09', 2, 6, 0, 1, 1, 1, NULL, CAST(N'2025-06-13T19:45:58.100' AS DateTime), CAST(N'2025-06-13T19:45:58.100' AS DateTime), CAST(N'2025-06-13T19:45:58.100' AS DateTime), CAST(N'2025-06-14T00:23:13.623' AS DateTime))
GO
INSERT [dbo].[JobOffers] ([Id], [Title], [Description], [IsDeleted], [Address], [IdCity], [IdSalary], [HideSalary], [IdContractType], [IdExpirationTime], [IdUserWhoRegisteredIt], [IdUserWhoModifiedIt], [PublishedAt], [ExpiredAt], [CreatedAt], [UpdatedAt]) VALUES (3, N'Oferta test 3', N'Esto es una oferta de prueba modificada', 1, N'Cra 4 #08-09', 2, 4, 0, 5, 3, 3, 1, CAST(N'2025-06-13T20:55:29.627' AS DateTime), CAST(N'2025-06-13T20:55:29.627' AS DateTime), CAST(N'2025-06-13T20:55:29.627' AS DateTime), CAST(N'2025-06-14T01:17:33.347' AS DateTime))
GO
INSERT [dbo].[JobOffers] ([Id], [Title], [Description], [IsDeleted], [Address], [IdCity], [IdSalary], [HideSalary], [IdContractType], [IdExpirationTime], [IdUserWhoRegisteredIt], [IdUserWhoModifiedIt], [PublishedAt], [ExpiredAt], [CreatedAt], [UpdatedAt]) VALUES (4, N'Oferta Test 4', N'Esto es una prueba desde REST', 0, N'Cra A #01-02', 1, 2, 0, 1, 3, 1, NULL, CAST(N'2025-06-14T03:08:02.107' AS DateTime), CAST(N'2025-06-14T03:08:02.107' AS DateTime), CAST(N'2025-06-14T03:08:02.107' AS DateTime), CAST(N'2025-06-14T03:08:02.107' AS DateTime))
GO
INSERT [dbo].[JobOffers] ([Id], [Title], [Description], [IsDeleted], [Address], [IdCity], [IdSalary], [HideSalary], [IdContractType], [IdExpirationTime], [IdUserWhoRegisteredIt], [IdUserWhoModifiedIt], [PublishedAt], [ExpiredAt], [CreatedAt], [UpdatedAt]) VALUES (5, N'Oferta Test 5', N'Esto es una segunda prueba desde REST', 0, N'Cra 45 #02-02', 2, 2, 0, 1, 1, 1, 2, CAST(N'2025-06-14T03:08:53.510' AS DateTime), CAST(N'2025-06-21T03:08:53.510' AS DateTime), CAST(N'2025-06-14T03:08:53.510' AS DateTime), CAST(N'2025-06-14T03:13:52.217' AS DateTime))
GO
INSERT [dbo].[JobOffers] ([Id], [Title], [Description], [IsDeleted], [Address], [IdCity], [IdSalary], [HideSalary], [IdContractType], [IdExpirationTime], [IdUserWhoRegisteredIt], [IdUserWhoModifiedIt], [PublishedAt], [ExpiredAt], [CreatedAt], [UpdatedAt]) VALUES (6, N'Oferta Test 6', N'Esto es una prueba desde REST', 1, N'Cra A #01-03', 1, 2, 0, 1, 3, 1, 2, CAST(N'2025-06-14T03:09:57.393' AS DateTime), CAST(N'2025-07-14T03:09:57.393' AS DateTime), CAST(N'2025-06-14T03:09:57.393' AS DateTime), CAST(N'2025-06-14T03:19:32.077' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[JobOffers] OFF
GO
SET IDENTITY_INSERT [dbo].[Salaries] ON 
GO
INSERT [dbo].[Salaries] ([Id], [Name], [Range], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (1, N'Menos de 1 SMMLV', N'Menos de $1.300.000', 0, CAST(N'2025-06-11T20:00:27.343' AS DateTime), CAST(N'2025-06-11T20:00:27.343' AS DateTime))
GO
INSERT [dbo].[Salaries] ([Id], [Name], [Range], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (2, N'1 a 1.5 SMMLV', N'$1.300.000 – $1.950.000', 0, CAST(N'2025-06-11T20:00:27.343' AS DateTime), CAST(N'2025-06-11T20:00:27.343' AS DateTime))
GO
INSERT [dbo].[Salaries] ([Id], [Name], [Range], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (3, N'1.5 a 2.5 SMMLV', N'$1.950.001 – $3.250.000', 0, CAST(N'2025-06-11T20:00:27.343' AS DateTime), CAST(N'2025-06-11T20:00:27.343' AS DateTime))
GO
INSERT [dbo].[Salaries] ([Id], [Name], [Range], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (4, N'2.5 a 4 SMMLV', N'$3.250.001 – $5.200.000', 0, CAST(N'2025-06-11T20:00:27.343' AS DateTime), CAST(N'2025-06-11T20:00:27.343' AS DateTime))
GO
INSERT [dbo].[Salaries] ([Id], [Name], [Range], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (5, N'4 a 6 SMMLV', N'$5.200.001 – $7.800.000', 0, CAST(N'2025-06-11T20:00:27.343' AS DateTime), CAST(N'2025-06-11T20:00:27.343' AS DateTime))
GO
INSERT [dbo].[Salaries] ([Id], [Name], [Range], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (6, N'6 a 10 SMMLV', N'$7.800.001 – $13.000.000', 0, CAST(N'2025-06-11T20:00:27.343' AS DateTime), CAST(N'2025-06-11T20:00:27.343' AS DateTime))
GO
INSERT [dbo].[Salaries] ([Id], [Name], [Range], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (7, N'10 a 15 SMMLV', N'$13.000.001 – $19.500.000', 0, CAST(N'2025-06-11T20:00:27.343' AS DateTime), CAST(N'2025-06-11T20:00:27.343' AS DateTime))
GO
INSERT [dbo].[Salaries] ([Id], [Name], [Range], [IsDeleted], [CreatedAt], [UpdatedAt]) VALUES (8, N'Más de 15 SMMLV', N'Más de $19.500.000', 0, CAST(N'2025-06-11T20:00:27.343' AS DateTime), CAST(N'2025-06-11T20:00:27.343' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Salaries] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [CreatedAt], [UpdatedAt], [Role]) VALUES (1, N'UsuarioAdmin', N'UsuarioAdmin@gmail.com', N'UsuarioAdmin123', CAST(N'2025-06-11T23:54:26.363' AS DateTime), CAST(N'2025-06-11T19:37:19.883' AS DateTime), N'Admin')
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [CreatedAt], [UpdatedAt], [Role]) VALUES (2, N'UsuarioReclutador', N'UsuarioReclutador@gmail.com', N'Reclutador123', CAST(N'2025-06-13T17:51:50.390' AS DateTime), CAST(N'2025-06-13T17:51:50.390' AS DateTime), N'Recruiter')
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [CreatedAt], [UpdatedAt], [Role]) VALUES (3, N'Usuario1', N'Usuario1@gmail.com', N'Usuario123', CAST(N'2025-06-13T17:51:50.390' AS DateTime), CAST(N'2025-06-13T17:51:50.390' AS DateTime), N'User')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Cities] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Cities] ADD  DEFAULT (NULL) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Cities] ADD  DEFAULT (NULL) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[ContractTypes] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ContractTypes] ADD  DEFAULT (NULL) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ContractTypes] ADD  DEFAULT (NULL) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[Countries] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Countries] ADD  DEFAULT (NULL) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Countries] ADD  DEFAULT (NULL) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[Departments] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Departments] ADD  DEFAULT (NULL) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Departments] ADD  DEFAULT (NULL) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[ExpirationTimes] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ExpirationTimes] ADD  DEFAULT (NULL) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ExpirationTimes] ADD  DEFAULT (NULL) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[JobOffers] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[JobOffers] ADD  DEFAULT ((0)) FOR [HideSalary]
GO
ALTER TABLE [dbo].[JobOffers] ADD  DEFAULT (NULL) FOR [PublishedAt]
GO
ALTER TABLE [dbo].[JobOffers] ADD  DEFAULT (NULL) FOR [ExpiredAt]
GO
ALTER TABLE [dbo].[JobOffers] ADD  DEFAULT (NULL) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[JobOffers] ADD  DEFAULT (NULL) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[Salaries] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Salaries] ADD  DEFAULT (NULL) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Salaries] ADD  DEFAULT (NULL) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (NULL) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (NULL) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('User') FOR [Role]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Departments] FOREIGN KEY([IdDepartment])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_Departments]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Countries] FOREIGN KEY([IdCountry])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Countries]
GO
ALTER TABLE [dbo].[JobOffers]  WITH CHECK ADD  CONSTRAINT [FK_JobOffers_Cities] FOREIGN KEY([IdCity])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[JobOffers] CHECK CONSTRAINT [FK_JobOffers_Cities]
GO
ALTER TABLE [dbo].[JobOffers]  WITH CHECK ADD  CONSTRAINT [FK_JobOffers_Contracttypes] FOREIGN KEY([IdContractType])
REFERENCES [dbo].[ContractTypes] ([Id])
GO
ALTER TABLE [dbo].[JobOffers] CHECK CONSTRAINT [FK_JobOffers_Contracttypes]
GO
ALTER TABLE [dbo].[JobOffers]  WITH CHECK ADD  CONSTRAINT [FK_JobOffers_ExpirationTimes] FOREIGN KEY([IdExpirationTime])
REFERENCES [dbo].[ExpirationTimes] ([Id])
GO
ALTER TABLE [dbo].[JobOffers] CHECK CONSTRAINT [FK_JobOffers_ExpirationTimes]
GO
ALTER TABLE [dbo].[JobOffers]  WITH CHECK ADD  CONSTRAINT [FK_JobOffers_Salaries] FOREIGN KEY([IdSalary])
REFERENCES [dbo].[Salaries] ([Id])
GO
ALTER TABLE [dbo].[JobOffers] CHECK CONSTRAINT [FK_JobOffers_Salaries]
GO
ALTER TABLE [dbo].[JobOffers]  WITH CHECK ADD  CONSTRAINT [FK_JobOffers_UsersA] FOREIGN KEY([IdUserWhoRegisteredIt])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[JobOffers] CHECK CONSTRAINT [FK_JobOffers_UsersA]
GO
ALTER TABLE [dbo].[JobOffers]  WITH CHECK ADD  CONSTRAINT [FK_JobOffers_UsersB] FOREIGN KEY([IdUserWhoModifiedIt])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[JobOffers] CHECK CONSTRAINT [FK_JobOffers_UsersB]
GO
USE [master]
GO
ALTER DATABASE [JobOfferManagerDB] SET  READ_WRITE 
GO
