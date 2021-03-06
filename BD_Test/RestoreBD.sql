USE [master]
GO
/****** Object:  Database [BD_Test]    Script Date: 18/09/2021 03:49:28 ******/
CREATE DATABASE [BD_Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_Test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BD_Test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD_Test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BD_Test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BD_Test] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_Test] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BD_Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_Test] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BD_Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_Test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BD_Test] SET  MULTI_USER 
GO
ALTER DATABASE [BD_Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_Test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BD_Test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BD_Test] SET QUERY_STORE = OFF
GO
USE [BD_Test]
GO
/****** Object:  Table [dbo].[tb_Client]    Script Date: 18/09/2021 03:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Client](
	[ID_Client] [int] IDENTITY(1,1) NOT NULL,
	[T_ClientName] [varchar](50) NOT NULL,
	[D_Birthdate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Request_Loans]    Script Date: 18/09/2021 03:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Request_Loans](
	[ID_Request_Loans] [int] IDENTITY(1,1) NOT NULL,
	[ID_Client] [int] NOT NULL,
	[D_Date_Request] [date] NOT NULL,
	[N_Request_Amount] [decimal](9, 3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Request_Loans] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tb_Client] ON 

INSERT [dbo].[tb_Client] ([ID_Client], [T_ClientName], [D_Birthdate]) VALUES (1, N'Robert', CAST(N'1997-07-25' AS Date))
INSERT [dbo].[tb_Client] ([ID_Client], [T_ClientName], [D_Birthdate]) VALUES (2, N'Carlos', CAST(N'1991-09-28' AS Date))
INSERT [dbo].[tb_Client] ([ID_Client], [T_ClientName], [D_Birthdate]) VALUES (3, N'Gustavo', CAST(N'1990-09-15' AS Date))
INSERT [dbo].[tb_Client] ([ID_Client], [T_ClientName], [D_Birthdate]) VALUES (5, N'Jose', CAST(N'1992-09-24' AS Date))
INSERT [dbo].[tb_Client] ([ID_Client], [T_ClientName], [D_Birthdate]) VALUES (7, N'Marcos', CAST(N'1994-09-15' AS Date))
SET IDENTITY_INSERT [dbo].[tb_Client] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_Request_Loans] ON 

INSERT [dbo].[tb_Request_Loans] ([ID_Request_Loans], [ID_Client], [D_Date_Request], [N_Request_Amount]) VALUES (1, 3, CAST(N'2021-09-23' AS Date), CAST(500.000 AS Decimal(9, 3)))
INSERT [dbo].[tb_Request_Loans] ([ID_Request_Loans], [ID_Client], [D_Date_Request], [N_Request_Amount]) VALUES (2, 1, CAST(N'2021-09-16' AS Date), CAST(200000.000 AS Decimal(9, 3)))
INSERT [dbo].[tb_Request_Loans] ([ID_Request_Loans], [ID_Client], [D_Date_Request], [N_Request_Amount]) VALUES (4, 5, CAST(N'2021-09-15' AS Date), CAST(87364.000 AS Decimal(9, 3)))
INSERT [dbo].[tb_Request_Loans] ([ID_Request_Loans], [ID_Client], [D_Date_Request], [N_Request_Amount]) VALUES (6, 1, CAST(N'2021-09-15' AS Date), CAST(3000.000 AS Decimal(9, 3)))
INSERT [dbo].[tb_Request_Loans] ([ID_Request_Loans], [ID_Client], [D_Date_Request], [N_Request_Amount]) VALUES (8, 2, CAST(N'2021-09-18' AS Date), CAST(2345.126 AS Decimal(9, 3)))
SET IDENTITY_INSERT [dbo].[tb_Request_Loans] OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_TB_CLIENT_ADD_CLIENT]    Script Date: 18/09/2021 03:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_TB_CLIENT_ADD_CLIENT]
@T_ClientName varchar(50),
@D_Birthdate date
as
Insert into tb_Client
values(@T_ClientName,
	   @D_Birthdate		
)
GO
/****** Object:  StoredProcedure [dbo].[SP_TB_CLIENT_DELETE_CLIENT]    Script Date: 18/09/2021 03:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_TB_CLIENT_DELETE_CLIENT]
@ID_Client int
as
delete tb_Client
where ID_Client = @ID_Client
GO
/****** Object:  StoredProcedure [dbo].[SP_TB_CLIENT_EDIT_CLIENT]    Script Date: 18/09/2021 03:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_TB_CLIENT_EDIT_CLIENT]
@ID_Client int,
@T_ClientName varchar(50),
@D_Birthdate date
as
update tb_Client
set T_ClientName = @T_ClientName, D_Birthdate = @D_Birthdate
where ID_Client = @ID_Client
GO
/****** Object:  StoredProcedure [dbo].[SP_TB_CLIENT_LIST_CLIENT]    Script Date: 18/09/2021 03:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_TB_CLIENT_LIST_CLIENT]
as
select ID_Client, 
	   T_ClientName,
	   FORMAT (D_Birthdate, 'dd/MM/yyyy ') as D_Birthdate
from tb_Client
GO
/****** Object:  StoredProcedure [dbo].[SP_TB_CLIENT_LIST_CLIENT_X_NAME]    Script Date: 18/09/2021 03:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_TB_CLIENT_LIST_CLIENT_X_NAME]
@T_ClientName varchar(50)
as
select ID_Client, 
	   T_ClientName,
	   FORMAT (D_Birthdate, 'dd/MM/yyyy ') as D_Birthdate
from tb_Client
where T_ClientName like '%' + @T_ClientName + '%' or @T_ClientName = ''
GO
/****** Object:  StoredProcedure [dbo].[SP_TB_REQUEST_LOANS_ADD_LOANS]    Script Date: 18/09/2021 03:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_TB_REQUEST_LOANS_ADD_LOANS]
@ID_Client int,
@D_Date_Request date,
@N_Request_Amount decimal(9,3)
as
Insert into tb_Request_Loans
values(@ID_Client,
	   @D_Date_Request,
	   @N_Request_Amount
)
GO
/****** Object:  StoredProcedure [dbo].[SP_TB_REQUEST_LOANS_DELETE_LOANS]    Script Date: 18/09/2021 03:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_TB_REQUEST_LOANS_DELETE_LOANS]
@ID_Request_Loans int
as
delete tb_Request_Loans
where ID_Request_Loans = @ID_Request_Loans
GO
/****** Object:  StoredProcedure [dbo].[SP_TB_REQUEST_LOANS_EDIT_LOANS]    Script Date: 18/09/2021 03:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_TB_REQUEST_LOANS_EDIT_LOANS]
@ID_Request_Loans int,
@ID_Client int,
@D_Date_Request date,
@N_Request_Amount decimal(9,3)
as
update tb_Request_Loans
set ID_Client = @ID_Client, 
	D_Date_Request = @D_Date_Request, 
	N_Request_Amount = @N_Request_Amount
where ID_Request_Loans = @ID_Request_Loans
GO
/****** Object:  StoredProcedure [dbo].[SP_TB_REQUEST_LOANS_LIST_LOANS]    Script Date: 18/09/2021 03:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_TB_REQUEST_LOANS_LIST_LOANS]
as
select RL.ID_Request_Loans,
	   RL.ID_Client,
	   C.T_ClientName,
	   FORMAT (RL.D_Date_Request, 'dd/MM/yyyy ') as D_Date_Request,
	   RL.N_Request_Amount
from tb_Request_Loans RL
	 inner join tb_Client C
	 on RL.ID_Client = C.ID_Client
GO
/****** Object:  StoredProcedure [dbo].[SP_TB_REQUEST_LOANS_LIST_LOANS_X_ID]    Script Date: 18/09/2021 03:49:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_TB_REQUEST_LOANS_LIST_LOANS_X_ID]
@ID_Client varchar(50)
as
select RL.ID_Request_Loans,
	   RL.ID_Client,
	   C.T_ClientName,
	   FORMAT (RL.D_Date_Request, 'dd/MM/yyyy ') as D_Date_Request,
	   RL.N_Request_Amount
from tb_Request_Loans RL
	 inner join tb_Client C
	 on RL.ID_Client = C.ID_Client
where RL.ID_Client = @ID_Client
GO
USE [master]
GO
ALTER DATABASE [BD_Test] SET  READ_WRITE 
GO
