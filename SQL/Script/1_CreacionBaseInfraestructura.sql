USE [master]
GO

/****** Object:  Database [Infraestructura]    Script Date: 19/5/2022 17:16:08 ******/
CREATE DATABASE [Infraestructura]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Infraestructura', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Infraestructura.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Infraestructura_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Infraestructura_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Infraestructura].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Infraestructura] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Infraestructura] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Infraestructura] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Infraestructura] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Infraestructura] SET ARITHABORT OFF 
GO

ALTER DATABASE [Infraestructura] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Infraestructura] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Infraestructura] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Infraestructura] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Infraestructura] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Infraestructura] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Infraestructura] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Infraestructura] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Infraestructura] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Infraestructura] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Infraestructura] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Infraestructura] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Infraestructura] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Infraestructura] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Infraestructura] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Infraestructura] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Infraestructura] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Infraestructura] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Infraestructura] SET  MULTI_USER 
GO

ALTER DATABASE [Infraestructura] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Infraestructura] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Infraestructura] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Infraestructura] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Infraestructura] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Infraestructura] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Infraestructura] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Infraestructura] SET  READ_WRITE 
GO

