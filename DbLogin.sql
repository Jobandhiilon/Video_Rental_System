USE [master]
GO
/****** Object:  Database [DbLogin]    Script Date: 11-12-2018 15:34:14 ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 11-12-2018 15:34:15 ******/
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
/****** Object:  Table [dbo].[CustRatting]    Script Date: 11-12-2018 15:34:15 ******/
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
/****** Object:  Table [dbo].[MovieRatting]    Script Date: 11-12-2018 15:34:15 ******/
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
/****** Object:  Table [dbo].[Movies]    Script Date: 11-12-2018 15:34:15 ******/
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
/****** Object:  Table [dbo].[Register]    Script Date: 11-12-2018 15:34:15 ******/
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
/****** Object:  Table [dbo].[RentedMovies]    Script Date: 11-12-2018 15:34:15 ******/
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
/****** Object:  Table [dbo].[tbMovies]    Script Date: 11-12-2018 15:34:15 ******/
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
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1509, N'Joban', N'Dhillon', N'2/45 wintere rd', N'0225248214')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1510, N'Shiv', N'Rajput', N'58 Papakura rd', N'0225426584')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1511, N'harry', N'sharma', N'7/45 Charlie rd', N'0262642622')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1512, N'Garry', N'singh', N'48 huia rd', N'0251541151')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1513, N'Sharma', N'Mandeep', N'85 mt wellington', N'0224151621')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1514, N'Karan', N'Singh', N'45 CBD garden', N'0265541151')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1515, N'Richard', N'leu', N'2 Princess street', N'20215115111')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1516, N'Harman', N'preet', N'20 Kingston street', N'0222515151')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1517, N'Moh', N'aslam', N'2 station rd', N'0261515841')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1518, N'Leon', N'Dhillon', N'2/45 kolmar rd', N'0265915184')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1520, N'Rehman', N'singh', N'2 dominion street', N'0214845114')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1521, N'@joban', N'#dhillon7', N'2 papatoetoe', N'05215051155')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1522, N'Gurii', N'Dhillon', N'2 albert street', N'212102111')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[CustRatting] ON 

INSERT [dbo].[CustRatting] ([id], [CustID], [Cnt]) VALUES (13, N'1509', 2)
INSERT [dbo].[CustRatting] ([id], [CustID], [Cnt]) VALUES (14, N'1512', 3)
INSERT [dbo].[CustRatting] ([id], [CustID], [Cnt]) VALUES (15, N'1510', 2)
INSERT [dbo].[CustRatting] ([id], [CustID], [Cnt]) VALUES (16, N'1513', 2)
INSERT [dbo].[CustRatting] ([id], [CustID], [Cnt]) VALUES (17, N'1515', 1)
SET IDENTITY_INSERT [dbo].[CustRatting] OFF
SET IDENTITY_INSERT [dbo].[MovieRatting] ON 

INSERT [dbo].[MovieRatting] ([id], [MovieID], [Cnt]) VALUES (12, N'554', 5)
INSERT [dbo].[MovieRatting] ([id], [MovieID], [Cnt]) VALUES (13, N'557', 1)
INSERT [dbo].[MovieRatting] ([id], [MovieID], [Cnt]) VALUES (14, N'563', 1)
INSERT [dbo].[MovieRatting] ([id], [MovieID], [Cnt]) VALUES (15, N'555', 3)
SET IDENTITY_INSERT [dbo].[MovieRatting] OFF
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (554, N'4.5', N'Gangland', N'2012', 2, N'1', N'The movie is about gangsters', N'pop')
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (555, N'5', N'Love Bites', N'2015', 5, N'8', N'The romatic movie', N'Jazz')
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (556, N'3', N'Disney', N'2010', 2, N'7', N'Its all about wildlife', N'Hip Hop')
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (557, N'3.4', N'Romantic', N'2007', 2, N'10', N'Love&Romance', N'Soft music')
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (559, N'4', N'Jaurasic Park 2', N'2018', 5, N'8', N'the movie about dianasours', N'pop')
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (560, N'4.5', N'PBX 1', N'2016', 5, N'5', N'The first album of moosewala', N'HIP HOP')
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (561, N'4', N'Ready', N'2007', 2, N'10', N'This is a romantic movie', N'Jazz')
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (562, N'5', N'Harry potter', N'2018', 5, N'9', N'Its a hollywood movie', N'pop')
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (563, N'5', N'Rowdy Rathore', N'2008', 2, N'11', N'the life of a policeman', N'Hip Hop')
SET IDENTITY_INSERT [dbo].[Movies] OFF
INSERT [dbo].[Register] ([userid], [password], [fullname], [age]) VALUES (N'123789                                            ', N'123456                                            ', N'joaba                                             ', 20)
INSERT [dbo].[Register] ([userid], [password], [fullname], [age]) VALUES (N'456123                                            ', N'123456                                            ', N'Joban                                             ', 12)
INSERT [dbo].[Register] ([userid], [password], [fullname], [age]) VALUES (N'96321                                             ', N'123456                                            ', N'joban                                             ', 12)
INSERT [dbo].[Register] ([userid], [password], [fullname], [age]) VALUES (N'123741                                            ', N'123456                                            ', N'garry                                             ', 12)
SET IDENTITY_INSERT [dbo].[RentedMovies] ON 

INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (28, 554, 1509, N'11-12-2018', N'11-12-2018')
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (29, 554, 1509, N'11-12-2018', N'11-12-2018')
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (31, 563, 1510, N'11-12-2018', N'11-12-2018')
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (32, 555, 1510, N'11-12-2018', N'11-12-2018')
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (33, 555, 1513, N'11-12-2018', N'11-12-2018')
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (34, 555, 1512, N'11-12-2018', N'Date Returned')
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (35, 554, 1512, N'11-12-2018', N'Date Returned')
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (36, 554, 1513, N'11-12-2018', N'Date Returned')
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (37, 554, 1515, N'11-12-2018', N'11-12-2018')
SET IDENTITY_INSERT [dbo].[RentedMovies] OFF
SET IDENTITY_INSERT [dbo].[tbMovies] ON 

INSERT [dbo].[tbMovies] ([MID], [MovieID], [MovieCopy]) VALUES (14, N'554', 7)
INSERT [dbo].[tbMovies] ([MID], [MovieID], [MovieCopy]) VALUES (15, N'555', 7)
INSERT [dbo].[tbMovies] ([MID], [MovieID], [MovieCopy]) VALUES (16, N'556', 7)
INSERT [dbo].[tbMovies] ([MID], [MovieID], [MovieCopy]) VALUES (17, N'557', 10)
INSERT [dbo].[tbMovies] ([MID], [MovieID], [MovieCopy]) VALUES (19, N'559', 8)
INSERT [dbo].[tbMovies] ([MID], [MovieID], [MovieCopy]) VALUES (20, N'560', 5)
INSERT [dbo].[tbMovies] ([MID], [MovieID], [MovieCopy]) VALUES (21, N'561', 10)
INSERT [dbo].[tbMovies] ([MID], [MovieID], [MovieCopy]) VALUES (22, N'562', 9)
INSERT [dbo].[tbMovies] ([MID], [MovieID], [MovieCopy]) VALUES (23, N'563', 11)
SET IDENTITY_INSERT [dbo].[tbMovies] OFF
USE [master]
GO
ALTER DATABASE [DbLogin] SET  READ_WRITE 
GO
