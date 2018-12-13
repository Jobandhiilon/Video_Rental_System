USE [master]
GO
/****** Object:  Database [DbLogin]    Script Date: 14-12-2018 7:24:03 ******/
CREATE DATABASE [DbLogin]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DbLogin_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DbLogin.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DbLogin_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DbLogin.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DbLogin] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbLogin].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbLogin] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbLogin] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbLogin] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbLogin] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbLogin] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbLogin] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DbLogin] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbLogin] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbLogin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbLogin] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbLogin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbLogin] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbLogin] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbLogin] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbLogin] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DbLogin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbLogin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbLogin] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbLogin] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbLogin] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbLogin] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DbLogin] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbLogin] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DbLogin] SET  MULTI_USER 
GO
ALTER DATABASE [DbLogin] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbLogin] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DbLogin] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DbLogin] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DbLogin] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DbLogin] SET QUERY_STORE = OFF
GO
USE [DbLogin]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 14-12-2018 7:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[Phone] [nvarchar](255) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustRatting]    Script Date: 14-12-2018 7:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustRatting](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CustID] [varchar](50) NOT NULL,
	[Cnt] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieRatting]    Script Date: 14-12-2018 7:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieRatting](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MovieID] [varchar](50) NOT NULL,
	[Cnt] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 14-12-2018 7:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieID] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Year] [nvarchar](10) NULL,
	[Rental_Cost] [int] NULL,
	[Copies] [nvarchar](50) NULL,
	[Plot] [ntext] NULL,
	[Genre] [nvarchar](50) NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Register]    Script Date: 14-12-2018 7:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Register](
	[userid] [nchar](50) NULL,
	[password] [nchar](50) NULL,
	[fullname] [nchar](50) NULL,
	[age] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentedMovies]    Script Date: 14-12-2018 7:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentedMovies](
	[RMID] [int] IDENTITY(1,1) NOT NULL,
	[MovieIDFK] [int] NOT NULL,
	[CustIDFK] [int] NOT NULL,
	[DateRented] [varchar](50) NULL,
	[DateReturned] [varchar](50) NULL,
 CONSTRAINT [PK_RentedMovies] PRIMARY KEY CLUSTERED 
(
	[RMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbMovies]    Script Date: 14-12-2018 7:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbMovies](
	[MID] [int] IDENTITY(1,1) NOT NULL,
	[MovieID] [varchar](50) NULL,
	[MovieCopy] [int] NULL,
 CONSTRAINT [PK_tbMovies] PRIMARY KEY CLUSTERED 
(
	[MID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [DbLogin] SET  READ_WRITE 
GO
