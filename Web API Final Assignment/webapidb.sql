USE [master]
GO
/****** Object:  Database [HotelManagment]    Script Date: 1/12/2021 1:43:09 AM ******/
CREATE DATABASE [HotelManagment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelManagment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLINSTANCE\MSSQL\DATA\HotelManagment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelManagment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLINSTANCE\MSSQL\DATA\HotelManagment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HotelManagment] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelManagment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelManagment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelManagment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelManagment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelManagment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelManagment] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelManagment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotelManagment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelManagment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelManagment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelManagment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelManagment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelManagment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelManagment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelManagment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelManagment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HotelManagment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelManagment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelManagment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelManagment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelManagment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelManagment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelManagment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelManagment] SET RECOVERY FULL 
GO
ALTER DATABASE [HotelManagment] SET  MULTI_USER 
GO
ALTER DATABASE [HotelManagment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelManagment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelManagment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelManagment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelManagment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelManagment] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HotelManagment', N'ON'
GO
ALTER DATABASE [HotelManagment] SET QUERY_STORE = OFF
GO
USE [HotelManagment]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 1/12/2021 1:43:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Booking_Date] [date] NOT NULL,
	[Room_Id] [int] NOT NULL,
	[Status] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 1/12/2021 1:43:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[PinCode] [varchar](50) NOT NULL,
	[Contact_Number] [decimal](10, 0) NOT NULL,
	[Contact_Person] [varchar](100) NOT NULL,
	[Website] [nvarchar](500) NULL,
	[Facebook] [nvarchar](100) NULL,
	[Twitter] [nvarchar](100) NULL,
	[IsActive] [bit] NOT NULL,
	[Created_Date] [date] NOT NULL,
	[Created_By] [varchar](100) NOT NULL,
	[Updated_By] [varchar](100) NULL,
	[Updated_Date] [date] NULL,
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 1/12/2021 1:43:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Email] [nvarchar](128) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Is_Active] [bit] NOT NULL,
	[Created_Date] [date] NOT NULL,
	[Updated_Date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 1/12/2021 1:43:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Category] [varchar](100) NOT NULL,
	[Price] [money] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Created_Date] [date] NOT NULL,
	[Created_By] [varchar](100) NOT NULL,
	[Updated_Date] [date] NULL,
	[Updated_By] [varchar](100) NULL,
	[Hotel_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD FOREIGN KEY([Room_Id])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD FOREIGN KEY([Hotel_Id])
REFERENCES [dbo].[Hotels] ([Id])
GO
USE [master]
GO
ALTER DATABASE [HotelManagment] SET  READ_WRITE 
GO
