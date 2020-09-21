USE [master]
GO
/****** Object:  Database [CoilStore]    Script Date: 4/6/2014 8:18:51 AM ******/
CREATE DATABASE [CoilStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CoilStore', FILENAME = N'C:\SqlData\CoilStore.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CoilStore_log', FILENAME = N'C:\SqlData\CoilStore_log.ldf' , SIZE = 5184KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CoilStore] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CoilStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CoilStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CoilStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CoilStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CoilStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CoilStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [CoilStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CoilStore] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CoilStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CoilStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CoilStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CoilStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CoilStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CoilStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CoilStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CoilStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CoilStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CoilStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CoilStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CoilStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CoilStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CoilStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CoilStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CoilStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CoilStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CoilStore] SET  MULTI_USER 
GO
ALTER DATABASE [CoilStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CoilStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CoilStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CoilStore] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CoilStore]
GO
/****** Object:  Table [dbo].[CoilReadings]    Script Date: 4/6/2014 8:18:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoilReadings](
	[CoilReadingId] [bigint] NOT NULL,
	[CoilId] [bigint] NOT NULL,
	[ReadingNumber] [int] NOT NULL,
	[Value] [decimal](18, 6) NOT NULL,
 CONSTRAINT [PK_CoilReadings] PRIMARY KEY CLUSTERED 
(
	[CoilReadingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Coils]    Script Date: 4/6/2014 8:18:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Coils](
	[CoilId] [bigint] NOT NULL,
	[CoilNumber] [varchar](10) NOT NULL,
	[ProducedTime] [datetimeoffset](7) NULL,
	[GageInUse] [int] NULL,
	[NumberOfReadings] [int] NULL,
	[OrderValue] [decimal](18, 6) NULL,
	[PositiveTolerance] [decimal](18, 6) NULL,
	[NegativeTolerance] [decimal](18, 6) NULL,
	[CreationTimeUTC] [datetime] NULL,
	[Readings] [varchar](max) NULL,
	[DataType] [varchar](10) NULL,
 CONSTRAINT [PK_Coils] PRIMARY KEY CLUSTERED 
(
	[CoilId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[vCoilReadings]    Script Date: 4/6/2014 8:18:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vCoilReadings]
AS
SELECT        dbo.CoilReadings.*
FROM            dbo.CoilReadings

GO
/****** Object:  View [dbo].[vCoils]    Script Date: 4/6/2014 8:18:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vCoils]
AS
SELECT        dbo.Coils.*
FROM            dbo.Coils

GO
ALTER TABLE [dbo].[CoilReadings]  WITH CHECK ADD  CONSTRAINT [FK_CoilReadings_Coils] FOREIGN KEY([CoilId])
REFERENCES [dbo].[Coils] ([CoilId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CoilReadings] CHECK CONSTRAINT [FK_CoilReadings_Coils]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CoilReadings"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 214
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCoilReadings'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCoilReadings'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Coils"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 245
               Right = 298
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCoils'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCoils'
GO
USE [master]
GO
ALTER DATABASE [CoilStore] SET  READ_WRITE 
GO
