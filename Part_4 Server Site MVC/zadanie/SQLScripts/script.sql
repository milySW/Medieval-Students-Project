USE [master]
GO
/****** Object:  Database [MedievalStudents]    Script Date: 20.05.2019 04:09:27 ******/
CREATE DATABASE [MedievalStudents]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MedievalStudents', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MedievalStudents.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MedievalStudents_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MedievalStudents_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MedievalStudents] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MedievalStudents].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MedievalStudents] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MedievalStudents] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MedievalStudents] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MedievalStudents] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MedievalStudents] SET ARITHABORT OFF 
GO
ALTER DATABASE [MedievalStudents] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MedievalStudents] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MedievalStudents] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MedievalStudents] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MedievalStudents] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MedievalStudents] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MedievalStudents] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MedievalStudents] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MedievalStudents] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MedievalStudents] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MedievalStudents] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MedievalStudents] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MedievalStudents] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MedievalStudents] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MedievalStudents] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MedievalStudents] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MedievalStudents] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MedievalStudents] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MedievalStudents] SET  MULTI_USER 
GO
ALTER DATABASE [MedievalStudents] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MedievalStudents] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MedievalStudents] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MedievalStudents] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MedievalStudents] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MedievalStudents] SET QUERY_STORE = OFF
GO
USE [MedievalStudents]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 20.05.2019 04:09:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nick] [nvarchar](31) NOT NULL,
	[FirstName] [nvarchar](31) NOT NULL,
	[LastName] [nvarchar](31) NOT NULL,
	[PasswordString] [nvarchar](63) NOT NULL,
	[PathToPhoto] [nvarchar](31) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginHistory]    Script Date: 20.05.2019 04:09:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateOfLogging] [datetime] NOT NULL,
	[UserID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvailablePoints]    Script Date: 20.05.2019 04:09:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvailablePoints](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nick] [varchar](63) NOT NULL,
	[Points] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[PlayersLoggedWithLast10Logs]    Script Date: 20.05.2019 04:09:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PlayersLoggedWithLast10Logs] AS
SELECT Accounts.Nick, AvailablePoints.Points, Accounts.FirstName, Accounts.LastName, Accounts.PasswordString AS Password FROM Accounts
INNER JOIN AvailablePoints ON AvailablePoints.Nick = Accounts.Nick WHERE Accounts.ID IN 
(SELECT TOP 10 UserID FROM LoginHistory ORDER  BY ID DESC);
GO
/****** Object:  Table [dbo].[Score]    Script Date: 20.05.2019 04:09:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Score](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[POINTS] [int] NOT NULL,
	[PlayerID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[PlayersView]    Script Date: 20.05.2019 04:09:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PlayersView] AS
SELECT AvailablePoints.Nick, Score.Points AS Score FROM AvailablePoints
INNER JOIN Score ON Score.PlayerID = AvailablePoints.ID WHERE Score.ID IN 
(SELECT TOP 10 ID FROM Score ORDER  BY Points);
GO
/****** Object:  View [dbo].[History]    Script Date: 20.05.2019 04:09:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[History] AS
SELECT Accounts.Nick, Accounts.FirstName, Accounts.LastName, LoginHistory.DateOfLogging AS DATE FROM Accounts
INNER JOIN LoginHistory ON Accounts.ID = LoginHistory.UserID 
GO
/****** Object:  Table [dbo].[CharacterSkins]    Script Date: 20.05.2019 04:09:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CharacterSkins](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Skin1] [int] NOT NULL,
	[Skin2] [int] NOT NULL,
	[Skin3] [int] NOT NULL,
	[Skin4] [int] NOT NULL,
	[Skin5] [int] NOT NULL,
	[Skin6] [int] NOT NULL,
	[PlayerID] [int] NOT NULL,
	[WastedPoints] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FavouriteCharacter]    Script Date: 20.05.2019 04:09:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavouriteCharacter](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FavourtieClass] [varchar](31) NOT NULL,
	[PlayerID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (1, N'Dorotuch', N'Miłosz', N'Gajowczyk', N'ALAMAKOTA', N'~/images/Dorotuch.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (2, N'Mily', N'Bartek', N'Nowak', N'password', N'~/images/profile.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (3, N'Lexa', N'Dorota', N'Kowalska', N'password2', N'~/images/Lexa.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (4, N'Sami', N'Janek', N'Żmuduch', N'SAMUELEK', N'~/images/Sami.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (5, N'Felek', N'Bartek', N'Mouse', N'KOTKOTKOT', N'~/images/profile.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (6, N'Benek', N'Oluch', N'Żmuduch', N'PASSWORD3', N'~/images/profile.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (7, N'qdqde', N'Martin', N'Zgworek', N'alohaaloha', N'~/images/profile.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (8, N'Milosz', N'Czupurek', N'Myszurek', N'aloaloalo', N'~/images/Milosz.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (9, N'Mietek', N'Anna', N'Gawron', N'mietekmietek', N'~/images/Mietek.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (10, N'Sami&Mily', N'Bartłomiej', N'Kowalczyk', N'12345678', N'~/images/Sami&Mily.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (11, N'Sami2701', N'Krystian', N'Nowak', N'samisamisami', N'~/images/Sami2701.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (12, N'NewAccount', N'Miłosz', N'Gajowczyk', N'newnewnew', N'~/images/profile.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (13, N'New', N'Franek', N'Sinatra', N'password9', N'~/images/profile.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (14, N'NewNew', N'Miłos', N'Gajowczyk', N'password12', N'~/images/profile.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (15, N'KREDEK', N'Janek', N'Oluch', N'KREDEKKK', N'~/images/profile.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (16, N'GRUBY', N'Patryk', N'Raźniak', N'GRUBY123', N'~/images/profile.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (18, N'Damian', N'Damian', N'asdf', N'DAMIANMAKOTA', N'~/images/Damian.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (22, N'ZIOMEK', N'Eustachy', N'XYZ', N'alaalaala', N'~/images/profile.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (23, N'JJ', N'Janek', N'Lanek', N'nwmnwmnwm', N'~/images/profile.png')
INSERT [dbo].[Accounts] ([ID], [Nick], [FirstName], [LastName], [PasswordString], [PathToPhoto]) VALUES (24, N'NowyTest', N'NowyTest', N'a', N'testtest1', N'~/images/NowyTest.png')
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[AvailablePoints] ON 

INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (1, N'Sami2701', 72743)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (2, N'Felek', 7738)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (3, N'Milosz', 17198)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (4, N'Programmer', 6372)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (5, N'Sami&Mily', 4286)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (6, N'Samuel', 3913)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (7, N'Mily', 4129)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (8, N'qdqde', 3847)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (9, N'pro2701', 4710)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (10, N'Arek', 5232)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (11, N'Domi', 3056)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (12, N'lastTest', 3040)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (13, N'Mietek', 5090)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (14, N'Gabel', 2915)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (15, N'dmian', 2909)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (16, N'Sami', 2854)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (17, N'Lexa', 2382)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (18, N'Michael', 1928)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (19, N'afea', 1654)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (20, N'ih[o', 627)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (21, N'Dorotuch', 786)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (22, N'REGWR', 123)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (23, N'AAAAAAAAA', 59)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (24, N'Benek', 88)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (25, N'aaafas', 56)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (26, N'ZIOMEK', 55)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (27, N'sss', 47)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (28, N'jjjjjjk', 47)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (29, N'aada', 36)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (30, N'fda', 28)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (31, N'fcs', 25)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (32, N'koo', 24)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (33, N'dsaasd', 22)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (34, N'Noob', 22)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (35, N'ddas', 22)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (36, N'scd', 19)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (37, N'acac', 16)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (38, N'Miloszel', 0)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (39, N'KREDEK', 138)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (40, N'GRUBY', 137)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (41, N'acsa', 33)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (42, N'km', 63)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (43, N'Damian', 705)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (45, N'BaseTest', 70)
INSERT [dbo].[AvailablePoints] ([ID], [Nick], [Points]) VALUES (46, N'koy', 56)
SET IDENTITY_INSERT [dbo].[AvailablePoints] OFF
SET IDENTITY_INSERT [dbo].[CharacterSkins] ON 

INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (3, 0, 0, 0, 0, 0, 0, 1, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (4, 0, 0, 0, 0, 1, 0, 2, 2400)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (5, 0, 0, 0, 0, 0, 0, 3, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (6, 0, 0, 0, 0, 0, 0, 4, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (7, 0, 0, 0, 0, 0, 0, 5, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (9, 0, 0, 0, 0, 0, 0, 6, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (10, 0, 1, 0, 0, 0, 0, 7, 2100)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (11, 0, 0, 0, 0, 0, 0, 8, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (12, 0, 0, 0, 0, 0, 0, 9, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (13, 0, 0, 0, 0, 0, 0, 10, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (14, 0, 0, 0, 0, 0, 0, 11, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (15, 0, 0, 0, 0, 0, 0, 12, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (16, 0, 0, 0, 0, 0, 0, 13, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (17, 0, 0, 0, 0, 0, 0, 14, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (19, 0, 0, 0, 0, 0, 0, 15, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (20, 0, 0, 0, 0, 0, 0, 16, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (21, 0, 0, 0, 0, 0, 1, 17, 1800)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (22, 0, 0, 0, 0, 0, 0, 18, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (23, 0, 0, 0, 0, 0, 0, 19, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (25, 0, 0, 0, 0, 0, 0, 20, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (26, 0, 0, 0, 0, 0, 0, 21, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (27, 0, 0, 0, 0, 0, 0, 22, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (28, 0, 0, 0, 0, 0, 0, 23, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (29, 0, 0, 0, 0, 0, 0, 24, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (30, 0, 0, 0, 0, 0, 0, 25, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (31, 0, 0, 0, 0, 0, 0, 26, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (32, 0, 0, 0, 0, 0, 0, 27, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (33, 0, 0, 0, 0, 0, 0, 28, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (34, 0, 0, 0, 0, 0, 0, 29, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (35, 0, 0, 0, 0, 0, 0, 30, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (36, 0, 0, 0, 0, 0, 0, 31, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (37, 0, 0, 0, 0, 0, 0, 32, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (38, 0, 0, 0, 0, 0, 0, 33, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (39, 0, 0, 0, 0, 0, 0, 34, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (40, 0, 0, 0, 0, 0, 0, 35, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (41, 0, 0, 0, 0, 0, 0, 36, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (42, 0, 0, 0, 0, 0, 0, 37, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (43, 0, 0, 0, 0, 0, 0, 38, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (44, 0, 0, 0, 0, 0, 0, 39, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (45, 0, 0, 0, 0, 0, 0, 40, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (46, 0, 0, 0, 0, 0, 0, 41, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (47, 0, 0, 0, 0, 0, 0, 42, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (48, 0, 0, 0, 0, 0, 0, 43, 0)
INSERT [dbo].[CharacterSkins] ([ID], [Skin1], [Skin2], [Skin3], [Skin4], [Skin5], [Skin6], [PlayerID], [WastedPoints]) VALUES (50, 0, 0, 0, 0, 0, 0, 45, 0)
SET IDENTITY_INSERT [dbo].[CharacterSkins] OFF
SET IDENTITY_INSERT [dbo].[FavouriteCharacter] ON 

INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (1, N'Analyst', 1)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (4, N'Algebraist', 2)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (5, N'Analyst', 3)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (6, N'Algebraist', 4)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (7, N'Algebraist', 3)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (8, N'Analyst', 5)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (9, N'Algebraist', 6)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (10, N'Analyst', 2)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (11, N'Analyst', 7)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (12, N'Analyst', 8)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (13, N'Analyst', 9)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (14, N'Programmer', 10)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (15, N'Algebraist', 11)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (16, N'Analyst', 12)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (17, N'Programmer', 13)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (18, N'Programmer', 3)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (19, N'Analyst', 14)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (20, N'Algebraist', 15)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (21, N'Analyst', 16)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (22, N'Algebraist', 17)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (23, N'Analyst', 13)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (24, N'Programmer', 18)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (25, N'Analyst', 10)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (26, N'Programmer', 19)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (27, N'Analyst', 9)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (28, N'Analyst', 20)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (29, N'Algebraist', 21)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (30, N'Programmer', 22)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (31, N'Programmer', 21)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (32, N'Analyst', 21)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (33, N'Analyst', 21)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (34, N'Algebraist', 21)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (35, N'Analyst', 21)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (36, N'Programmer', 21)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (37, N'Programmer', 23)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (38, N'Algebraist', 24)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (39, N'Programmer', 25)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (40, N'Programmer', 26)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (41, N'Programmer', 27)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (42, N'Programmer', 28)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (43, N'Programmer', 29)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (78, N'Programmer', 21)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (79, N'Algebraist', 24)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (80, N'Algebraist', 30)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (81, N'Analyst', 31)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (82, N'Analyst', 32)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (83, N'Algebraist', 33)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (84, N'Algebraist', 34)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (85, N'Algebraist', 35)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (86, N'Programmer', 36)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (87, N'Programmer', 37)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (88, N'Analyst', 38)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (89, N'Programmer', 39)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (90, N'Programmer', 40)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (91, N'Programmer', 43)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (92, N'Analyst', 41)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (93, N'Analyst', 42)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (94, N'Analyst', 43)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (97, N'Algebraist', 45)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (98, N'Analyst', 7)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (99, N'Analyst', 7)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (100, N'Algebraist', 7)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (101, N'Analyst', 7)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (102, N'Algebraist', 7)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (103, N'Analyst', 46)
INSERT [dbo].[FavouriteCharacter] ([ID], [FavourtieClass], [PlayerID]) VALUES (104, N'Analyst', 7)
SET IDENTITY_INSERT [dbo].[FavouriteCharacter] OFF
SET IDENTITY_INSERT [dbo].[LoginHistory] ON 

INSERT [dbo].[LoginHistory] ([ID], [DateOfLogging], [UserID]) VALUES (24, CAST(N'2019-05-19T15:24:34.000' AS DateTime), 22)
INSERT [dbo].[LoginHistory] ([ID], [DateOfLogging], [UserID]) VALUES (25, CAST(N'2019-05-19T15:32:07.000' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([ID], [DateOfLogging], [UserID]) VALUES (26, CAST(N'2019-05-19T15:33:10.000' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([ID], [DateOfLogging], [UserID]) VALUES (30, CAST(N'2019-05-19T19:07:23.000' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([ID], [DateOfLogging], [UserID]) VALUES (31, CAST(N'2019-05-19T19:10:17.000' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([ID], [DateOfLogging], [UserID]) VALUES (117, CAST(N'2019-05-20T04:04:11.000' AS DateTime), 3)
INSERT [dbo].[LoginHistory] ([ID], [DateOfLogging], [UserID]) VALUES (118, CAST(N'2019-05-20T04:04:43.000' AS DateTime), 5)
INSERT [dbo].[LoginHistory] ([ID], [DateOfLogging], [UserID]) VALUES (119, CAST(N'2019-05-20T04:05:19.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[LoginHistory] OFF
SET IDENTITY_INSERT [dbo].[Score] ON 

INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (1, 72743, 1)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (2, 69502, 2)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (3, 9313, 3)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (4, 6372, 4)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (5, 4942, 3)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (6, 4286, 5)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (7, 3913, 6)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (8, 3890, 2)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (9, 3888, 7)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (10, 3848, 2)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (11, 3847, 8)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (12, 3413, 9)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (13, 3344, 10)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (14, 3056, 11)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (15, 3040, 12)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (16, 3009, 13)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (17, 2943, 3)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (18, 2915, 14)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (19, 2909, 15)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (20, 2854, 16)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (21, 2382, 17)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (22, 2081, 13)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (23, 1928, 18)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (24, 1888, 10)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (25, 1654, 19)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (26, 1297, 9)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (27, 627, 20)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (28, 542, 43)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (29, 163, 43)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (30, 138, 39)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (31, 137, 40)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (32, 125, 21)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (33, 123, 22)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (34, 110, 21)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (35, 110, 21)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (36, 107, 21)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (37, 105, 21)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (38, 103, 21)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (39, 91, 21)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (40, 73, 21)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (41, 63, 42)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (42, 59, 23)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (43, 58, 24)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (44, 56, 24)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (45, 55, 26)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (46, 47, 27)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (47, 47, 28)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (48, 36, 36)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (49, 35, 21)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (50, 33, 41)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (51, 30, 24)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (52, 28, 30)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (53, 25, 31)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (54, 24, 32)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (55, 22, 33)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (56, 22, 34)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (57, 20, 22)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (58, 19, 36)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (59, 16, 37)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (65, 70, 45)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (66, 91, 7)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (67, 23, 7)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (68, 28, 7)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (69, 46, 7)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (70, 26, 7)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (71, 56, 46)
INSERT [dbo].[Score] ([ID], [POINTS], [PlayerID]) VALUES (72, 27, 7)
SET IDENTITY_INSERT [dbo].[Score] OFF
ALTER TABLE [dbo].[CharacterSkins] ADD  DEFAULT ((0)) FOR [WastedPoints]
GO
ALTER TABLE [dbo].[CharacterSkins]  WITH CHECK ADD FOREIGN KEY([PlayerID])
REFERENCES [dbo].[AvailablePoints] ([ID])
GO
ALTER TABLE [dbo].[FavouriteCharacter]  WITH CHECK ADD  CONSTRAINT [FK__Favourite__Playe__5812160E] FOREIGN KEY([PlayerID])
REFERENCES [dbo].[AvailablePoints] ([ID])
GO
ALTER TABLE [dbo].[FavouriteCharacter] CHECK CONSTRAINT [FK__Favourite__Playe__5812160E]
GO
ALTER TABLE [dbo].[LoginHistory]  WITH CHECK ADD  CONSTRAINT [FK__LoginHist__UserI__3B75D760] FOREIGN KEY([UserID])
REFERENCES [dbo].[Accounts] ([ID])
GO
ALTER TABLE [dbo].[LoginHistory] CHECK CONSTRAINT [FK__LoginHist__UserI__3B75D760]
GO
ALTER TABLE [dbo].[Score]  WITH NOCHECK ADD FOREIGN KEY([PlayerID])
REFERENCES [dbo].[AvailablePoints] ([ID])
GO
USE [master]
GO
ALTER DATABASE [MedievalStudents] SET  READ_WRITE 
GO
