USE [master]
GO
/****** Object:  Database [HauntedBuilding]    Script Date: 04/10/2015 14:05:44 ******/
CREATE DATABASE [HauntedBuilding] ON  PRIMARY 
( NAME = N'HauntedBuilding', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\HauntedBuilding.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HauntedBuilding_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\HauntedBuilding_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HauntedBuilding] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HauntedBuilding].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HauntedBuilding] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [HauntedBuilding] SET ANSI_NULLS OFF
GO
ALTER DATABASE [HauntedBuilding] SET ANSI_PADDING OFF
GO
ALTER DATABASE [HauntedBuilding] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [HauntedBuilding] SET ARITHABORT OFF
GO
ALTER DATABASE [HauntedBuilding] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [HauntedBuilding] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [HauntedBuilding] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [HauntedBuilding] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [HauntedBuilding] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [HauntedBuilding] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [HauntedBuilding] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [HauntedBuilding] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [HauntedBuilding] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [HauntedBuilding] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [HauntedBuilding] SET  DISABLE_BROKER
GO
ALTER DATABASE [HauntedBuilding] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [HauntedBuilding] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [HauntedBuilding] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [HauntedBuilding] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [HauntedBuilding] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [HauntedBuilding] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [HauntedBuilding] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [HauntedBuilding] SET  READ_WRITE
GO
ALTER DATABASE [HauntedBuilding] SET RECOVERY FULL
GO
ALTER DATABASE [HauntedBuilding] SET  MULTI_USER
GO
ALTER DATABASE [HauntedBuilding] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [HauntedBuilding] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'HauntedBuilding', N'ON'
GO
USE [HauntedBuilding]
GO
/****** Object:  User [nooshin]    Script Date: 04/10/2015 14:05:44 ******/
CREATE USER [nooshin] FOR LOGIN [nooshin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[PlayerHistory]    Script Date: 04/10/2015 14:05:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerHistory](
	[UserName] [nvarchar](50) NOT NULL,
	[FloorNo] [int] NULL,
	[FloorX] [int] NULL,
	[FloorY] [int] NULL,
	[FirstDgtPass] [int] NULL,
	[SecDgtPass] [int] NULL,
	[ThirdDgtPass] [int] NULL,
	[CaseStatus] [int] NULL,
	[HaveCase] [int] NULL,
	[Note] [int] NULL,
	[Phone] [int] NULL,
	[Audio] [int] NULL,
	[Difficulty] [int] NULL,
	[TimeRemain] [int] NULL,
	[CaseHint] [nvarchar](50) NULL,
	[ScareMeter] [int] NULL,
 CONSTRAINT [PK_PlayerH] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginAuthority]    Script Date: 04/10/2015 14:05:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginAuthority](
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LoginAuthority] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserScores]    Script Date: 04/10/2015 14:05:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserScores](
	[User_Name] [nvarchar](50) NOT NULL,
	[DatePlayed] [nvarchar](50) NULL,
	[Difficulty] [nvarchar](10) NULL,
	[TimePlayed] [int] NULL,
	[Score] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spSelScores]    Script Date: 04/10/2015 14:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spSelScores]
                 @UserName nvarchar(50)
as 
select DatePlayed,Difficulty,TimePlayed,Score from UserScores where User_Name=@UserName

--exec spSelScores
GO
/****** Object:  StoredProcedure [dbo].[spSaveScore]    Script Date: 04/10/2015 14:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spSaveScore]
                 @UserName nvarchar(50),
                 @DatePlayed nvarchar(10),
                 @Difficulty nvarchar(10),
                 @TimePlayed int,
                 @Score nvarchar(50)
as
insert into UserScores values (@UserName,@DatePlayed,@Difficulty,@TimePlayed,@Score)
GO
/****** Object:  StoredProcedure [dbo].[spSaveGame]    Script Date: 04/10/2015 14:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spSaveGame]
					@UserName nvarchar(50),
					@FloorNo  int,
					@FloorX int,
					@FloorY  int,
					@FirstDgtPass int,
					@SecDgtPass int,
					@ThirdDgtPass int,
					@CaseStatus int,
					@HaveCase int,
					@Note    int,
					@Phone  int,
					@Audio    int,
					@Difficulty int,
					@TimeRemain int,
					@CaseHint nvarchar(50),
					@ScareMeter int
					
as

if exists (select UserName from PlayerHistory where UserName=@UserName)
update PlayerHistory
	set FloorNo=@FloorNo,
    FloorX=@FloorX,
    FloorY=@FloorY,
    FirstDgtPass=@FirstDgtPass,
    SecDgtPass=@SecDgtPass,
    ThirdDgtPass=@ThirdDgtPass,
    CaseStatus=@CaseStatus,
    HaveCase=@HaveCase,
    Note=@Note,
    Phone=@Phone,
    Audio=@Audio,
    Difficulty=@Difficulty,
    TimeRemain=@TimeRemain,
    CaseHint=@CaseHint,
    ScareMeter=@ScareMeter
    
    
    
where UserName=@UserName 

if not exists (select UserName from PlayerHistory where UserName=@UserName)
insert into PlayerHistory values(@UserName,@FloorNo,@FloorX,@FloorY,@FirstDgtPass,@SecDgtPass,@ThirdDgtPass,@CaseStatus,@HaveCase,@Note,@Phone,@Audio,@Difficulty,@TimeRemain,@CaseHint,@ScareMeter)
   

--exec spSaveGame 'babak',7,3,1,2,4,1,0,0,0,1,0

--select * from PlayerHistory
GO
/****** Object:  StoredProcedure [dbo].[spLogin]    Script Date: 04/10/2015 14:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spLogin]
					@Username nvarchar(50),
					@Password nvarchar(50)
					--@Status nvarchar(5)output
as
select * from LoginAuthority where UserName=@Username and Password=@Password
GO
/****** Object:  StoredProcedure [dbo].[spGetPlayerData]    Script Date: 04/10/2015 14:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spGetPlayerData]
					@UserName nvarchar(50),
					@FloorNo  int output,
					@FloorX int output,
					@FloorY  int output,
					@FirstDgtPass int output,
					@SecDgtPass int output,
					@ThirdDgtPass int output,
					@CaseStatus int output,
					@HaveCase int output,
					@Note    int output,
					@Phone  int output,
					@Audio    int output,
					@Difficulty int output,
					@TimeRemain int output,
					@CaseHint nvarchar(50) output,
					@ScareMeter int output 
as

if exists (select UserName from PlayerHistory where UserName=@UserName)
begin
set @FloorNo=(select FloorNo from PlayerHistory where UserName=@UserName )
set @FloorX=(select FloorX from PlayerHistory where UserName=@UserName )
set @FloorY=(select FloorY from PlayerHistory where UserName=@UserName )
set @FirstDgtPass=(select FirstDgtPass from PlayerHistory where UserName=@UserName )
set @SecDgtPass=(select SecDgtPass from PlayerHistory where UserName=@UserName )
set @ThirdDgtPass=(select ThirdDgtPass from PlayerHistory where UserName=@UserName )
set @CaseStatus=(select CaseStatus from PlayerHistory where UserName=@UserName )
set @HaveCase=(select HaveCase from PlayerHistory where UserName=@UserName )
set @Note=(select Note from PlayerHistory where UserName=@UserName )
set @Phone=(select Phone from PlayerHistory where UserName=@UserName )
set @Audio=(select Audio from PlayerHistory where UserName=@UserName )
set @Difficulty=(select Difficulty from PlayerHistory where UserName=@UserName )
set @TimeRemain=(select TimeRemain from PlayerHistory where UserName=@UserName )
set @CaseHint=(select CaseHint from PlayerHistory where UserName=@UserName )
set @ScareMeter=(select ScareMeter from PlayerHistory where UserName=@UserName )
end

else
raiserror ('You dont have any saved game',16,1)	


--declare @fNo int, @fx int, @fy int, @dgt1 int, @dgt2 int, @dgt3 int, @cs int, @hc int, @nt int, @ph int, @au int, @diff int, @time int, @hint nvarchar(50), @scare int	
--exec spGetPlayerData 'nooshin',@fNo output, @fx output, @fy output, @dgt1 output, @dgt2 output, @dgt3 output, @cs output, @hc output, @nt output, @ph output, @au output, @diff output, @time output, @hint output, @scare output	
--print @fNo 
--print @fx 
--print @fy 
--print @dgt1 
--print @dgt2 
--print @dgt3 
--print @cs 
--print @hc 
--print @nt 
--print @ph 
--print @au 
--print @diff 
--print @time
--print @hint
--print @scare
GO
/****** Object:  StoredProcedure [dbo].[spDefineAcc]    Script Date: 04/10/2015 14:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spDefineAcc]
                 @UserName nvarchar(50),
                 @Password nvarchar(50)
as
if not exists (select UserName from LoginAuthority where UserName=@UserName)
insert into LoginAuthority values (@UserName, @Password)

else 
raiserror ('This UserName has already taken',16,1)
GO
