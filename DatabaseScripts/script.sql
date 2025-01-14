USE [master]
GO
/****** Object:  Database [BloodDonation]    Script Date: 17/08/2018 11:19:13 AM ******/
CREATE DATABASE [BloodDonation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BloodDonation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.HP\MSSQL\DATA\BloodDonation.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BloodDonation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.HP\MSSQL\DATA\BloodDonation_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BloodDonation] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BloodDonation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BloodDonation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BloodDonation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BloodDonation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BloodDonation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BloodDonation] SET ARITHABORT OFF 
GO
ALTER DATABASE [BloodDonation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BloodDonation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BloodDonation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BloodDonation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BloodDonation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BloodDonation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BloodDonation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BloodDonation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BloodDonation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BloodDonation] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BloodDonation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BloodDonation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BloodDonation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BloodDonation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BloodDonation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BloodDonation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BloodDonation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BloodDonation] SET RECOVERY FULL 
GO
ALTER DATABASE [BloodDonation] SET  MULTI_USER 
GO
ALTER DATABASE [BloodDonation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BloodDonation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BloodDonation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BloodDonation] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BloodDonation] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BloodDonation', N'ON'
GO
USE [BloodDonation]
GO
/****** Object:  Table [dbo].[AcceptorDetails]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcceptorDetails](
	[AcceptorId] [bigint] IDENTITY(1,1) NOT NULL,
	[DonatedTo] [bigint] NULL,
	[DonatedBy] [bigint] NULL,
	[BleedDate] [datetime] NOT NULL,
	[OnCreated] [datetime] NOT NULL CONSTRAINT [DF_AcceptorDetails_OnCreated]  DEFAULT (getdate()),
	[OnModified] [datetime] NOT NULL CONSTRAINT [DF_AcceptorDetails_OnModified]  DEFAULT (getdate()),
 CONSTRAINT [PK_AcceptorDetails] PRIMARY KEY CLUSTERED 
(
	[AcceptorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BloodGroup]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BloodGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_BloodGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[City]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CityArea]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CityArea](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](1024) NOT NULL,
	[CityId] [int] NOT NULL,
 CONSTRAINT [PK_CityArea] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ColonyArea]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColonyArea](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1024) NULL,
	[CityAreaId] [bigint] NOT NULL,
 CONSTRAINT [PK_ColonyArea] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonarRelationships]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonarRelationships](
	[PersonId] [bigint] NOT NULL,
	[RelatedPersonId] [bigint] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Donars]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donars](
	[DonarId] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](256) NOT NULL,
	[LastName] [nvarchar](256) NULL,
	[MobilePhone] [nvarchar](50) NOT NULL,
	[AlternateMobilePhone] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](256) NULL,
	[GenderId] [int] NULL,
	[MartialStatusId] [int] NULL,
	[BloodGroupId] [int] NOT NULL,
	[Weight] [float] NULL,
	[Longitude] [float] NULL,
	[Latitude] [float] NULL,
	[StreetAddress] [nvarchar](2048) NULL,
	[ColonyAreaId] [bigint] NOT NULL,
	[OnCreated] [datetime] NOT NULL CONSTRAINT [DF_Donars_OnCreated]  DEFAULT (getdate()),
	[OnModified] [datetime] NOT NULL CONSTRAINT [DF_Donars_OnModified]  DEFAULT (getdate()),
	[DateOfBirth] [datetime] NULL,
 CONSTRAINT [PK_Donars] PRIMARY KEY CLUSTERED 
(
	[DonarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gender]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MartialStatus]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MartialStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MartialStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Relationships]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relationships](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Relationships] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[ColonyAreaView]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ColonyAreaView]
AS
SELECT      dbo.ColonyArea.Id AS ColonyAreaId,dbo.ColonyArea.Name AS ColonyAreaName,
			dbo.CityArea.Id AS CityAreaId,dbo.CityArea.Name AS CityAreaName,
			dbo.City.Id AS CityId, dbo.City.Name AS CityName, 
			dbo.Country.Id AS CountryId, dbo.Country.Name AS CountryName
FROM          
			dbo.ColonyArea 
			INNER JOIN  dbo.CityArea 
				ON dbo.ColonyArea.CityAreaId = dbo.CityArea.Id 
			INNER JOIN dbo.City 
				ON dbo.CityArea.CityId = dbo.City.Id 
			INNER JOIN dbo.Country 
				ON dbo.City.CountryId = dbo.Country.Id

GO
/****** Object:  View [dbo].[DonarLastBleedView]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DonarLastBleedView]
AS
SELECT 
	DonatedBy,
	ThisYearBirthDay,
	BleedDate,
	Years,
	Months,
	Days,
	CAST( ( Years * 12 ) + Months + ( Days - ( Days % 15 ) ) * 0.25 / 15 as numeric(18,2) ) as AgeInMonths
FROM (SELECT 
	DonatedBy,
	ThisYearBirthDay,
	BleedDate,
	DATEDIFF(year, BleedDate, GETDATE()) - (CASE WHEN ThisYearBirthDay > GETDATE() THEN 1 ELSE 0 END) AS Years,
	MONTH(GETDATE() - ThisYearBirthDay) - 1 AS Months,
	DAY(GETDATE() - ThisYearBirthDay) - 1 AS Days
FROM (SELECT 
	DonatedBy,
	DATEADD(year, DATEDIFF(year, BleedDate, GETDATE()), BleedDate) as ThisYearBirthDay,
	BleedDate
FROM (SELECT DonatedBy,MAX(BleedDate) AS BleedDate 
FROM dbo.AcceptorDetails GROUP BY DonatedBy) LastBleeds) LastBleedsWithThisYear) CalculatedAgeOfLastBleed

GO
/****** Object:  View [dbo].[DonarDetailView]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[DonarDetailView]
AS
/****** Script for SelectTopNRows command from SSMS  ******/

SELECT [DonarId]
      ,[FirstName]
      ,[LastName]
      ,[MobilePhone]
      ,[AlternateMobilePhone]
      ,[EmailAddress]
      ,[GenderId]
	  ,dbo.Gender.Name as GenderName
      ,[MartialStatusId]
	  ,dbo.MartialStatus.Name as MartialStatusName
      ,[BloodGroupId]
	  ,dbo.BloodGroup.Name as BloodGroupName
      ,[Weight]
      ,[Longitude]
      ,[Latitude]
	  ,dbo.ColonyAreaView.ColonyAreaId 
	  ,dbo.ColonyAreaView.ColonyAreaName
      ,[StreetAddress]
      ,[OnCreated]
      ,[OnModified]
	  ,DateOfBirth
	  ,CAST(ROUND(DATEDIFF(DD,DateOfBirth,GETDATE())/365.25,1) AS NUMERIC(18,1)) AS Age
	  ,AgeInMonths AS LastBleddDate
  FROM 
		[dbo].[Donars] INNER JOIN dbo.Gender
			ON dbo.Donars.GenderId = dbo.Gender.Id
		INNER JOIN dbo.MartialStatus
			ON dbo.Donars.MartialStatusId = dbo.MartialStatus.Id
		INNER JOIN dbo.BloodGroup
			ON dbo.Donars.BloodGroupId = dbo.BloodGroup.Id
		INNER JOIN dbo.ColonyAreaView
			ON dbo.Donars.ColonyAreaId = dbo.ColonyAreaView.ColonyAreaId
		LEFT OUTER JOIN dbo.DonarLastBleedView
			ON dbo.Donars.DonarId = dbo.DonarLastBleedView.DonatedBy			



GO
/****** Object:  View [dbo].[DonarRelationshipView]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[DonarRelationshipView]
AS
SELECT        r.PersonId,r1.FirstName + ' ' + ISNULL(r1.LastName,'') as PersonName,r.RelatedPersonId,r2.FirstName + ' ' + ISNULL(r2.LastName,'') as RelatedPersonName
FROM            dbo.Donars r1 INNER JOIN dbo.DonarRelationships r
					ON r1.DonarId = r.PersonId
				INNER JOIN dbo.Donars r2 
                    ON r2.DonarId = r.RelatedPersonId


GO
/****** Object:  View [dbo].[DonarsHeirarchyView]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[DonarsHeirarchyView]
AS
WITH Hierarchy(ChildId, ChildName, ParentId, Childs)
AS
(
    SELECT RelatedPersonId, RelatedPersonName, PersonId, CAST('' AS VARCHAR(MAX))
        FROM dbo.DonarRelationshipView AS LastGeneration
        WHERE RelatedPersonId NOT IN (SELECT COALESCE(PersonId, 0) FROM dbo.DonarRelationshipView)     
    UNION ALL
    SELECT PrevGeneration.RelatedPersonId, PrevGeneration.RelatedPersonName, PrevGeneration.PersonId,
    CAST(CASE WHEN Child.Childs = ''
        THEN(CAST(Child.ChildId AS VARCHAR(MAX)))
        ELSE(Child.Childs + ',' + CAST(Child.ChildId AS VARCHAR(MAX)))
    END AS VARCHAR(MAX))
        FROM dbo.DonarRelationshipView AS PrevGeneration
        INNER JOIN Hierarchy AS Child ON PrevGeneration.RelatedPersonId = Child.ParentId  
		  
)
SELECT [ParentId],LEN(REPLACE(Childs, ',', ''))+1 as ChildrenCount
      ,cast([ParentId] as nvarchar(5)) + ',' + cast([ChildId] as nvarchar(5))+ (case when [Childs] = '' then '' else ',' end) +[Childs] as Childs
    FROM Hierarchy
	--order by parentId
--OPTION(MAXRECURSION 0)


GO
/****** Object:  View [dbo].[CityAreaView]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CityAreaView]
AS
SELECT        dbo.CityArea.Id AS CityAreaId,dbo.CityArea.Name AS CityAreaName,dbo.City.Id AS CityId, dbo.City.Name AS CityName, dbo.Country.Id AS CountryId, dbo.Country.Name AS CountryName
FROM          dbo.CityArea INNER JOIN dbo.City ON dbo.CityArea.CityId = dbo.City.Id INNER JOIN
                         dbo.Country ON dbo.City.CountryId = dbo.Country.Id


GO
/****** Object:  View [dbo].[CityView]    Script Date: 17/08/2018 11:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CityView]
AS
SELECT        dbo.City.Id AS CityId, dbo.City.Name AS CityName, dbo.Country.Id AS CountryId, dbo.Country.Name AS CountryName
FROM            dbo.City INNER JOIN
                         dbo.Country ON dbo.City.CountryId = dbo.Country.Id

GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_Country]
GO
ALTER TABLE [dbo].[CityArea]  WITH CHECK ADD  CONSTRAINT [FK_CityArea_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[CityArea] CHECK CONSTRAINT [FK_CityArea_City]
GO
ALTER TABLE [dbo].[ColonyArea]  WITH CHECK ADD  CONSTRAINT [FK_ColonyArea_CityArea] FOREIGN KEY([CityAreaId])
REFERENCES [dbo].[CityArea] ([Id])
GO
ALTER TABLE [dbo].[ColonyArea] CHECK CONSTRAINT [FK_ColonyArea_CityArea]
GO
ALTER TABLE [dbo].[DonarRelationships]  WITH CHECK ADD  CONSTRAINT [FK_DonarRelationships_Donars] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Donars] ([DonarId])
GO
ALTER TABLE [dbo].[DonarRelationships] CHECK CONSTRAINT [FK_DonarRelationships_Donars]
GO
ALTER TABLE [dbo].[DonarRelationships]  WITH CHECK ADD  CONSTRAINT [FK_DonarRelationships_RelatedDonars] FOREIGN KEY([RelatedPersonId])
REFERENCES [dbo].[Donars] ([DonarId])
GO
ALTER TABLE [dbo].[DonarRelationships] CHECK CONSTRAINT [FK_DonarRelationships_RelatedDonars]
GO
ALTER TABLE [dbo].[Donars]  WITH CHECK ADD  CONSTRAINT [FK_Donars_BloodGroup] FOREIGN KEY([BloodGroupId])
REFERENCES [dbo].[BloodGroup] ([Id])
GO
ALTER TABLE [dbo].[Donars] CHECK CONSTRAINT [FK_Donars_BloodGroup]
GO
ALTER TABLE [dbo].[Donars]  WITH CHECK ADD  CONSTRAINT [FK_Donars_ColonyArea] FOREIGN KEY([ColonyAreaId])
REFERENCES [dbo].[ColonyArea] ([Id])
GO
ALTER TABLE [dbo].[Donars] CHECK CONSTRAINT [FK_Donars_ColonyArea]
GO
ALTER TABLE [dbo].[Donars]  WITH CHECK ADD  CONSTRAINT [FK_Donars_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[Donars] CHECK CONSTRAINT [FK_Donars_Gender]
GO
ALTER TABLE [dbo].[Donars]  WITH CHECK ADD  CONSTRAINT [FK_Donars_MartialStatus] FOREIGN KEY([MartialStatusId])
REFERENCES [dbo].[MartialStatus] ([Id])
GO
ALTER TABLE [dbo].[Donars] CHECK CONSTRAINT [FK_Donars_MartialStatus]
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
         Begin Table = "City"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Country"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 416
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CityView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CityView'
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
         Begin Table = "DonarRelationships"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Donars"
            Begin Extent = 
               Top = 6
               Left = 250
               Bottom = 136
               Right = 458
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DonarRelationshipView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DonarRelationshipView'
GO
USE [master]
GO
ALTER DATABASE [BloodDonation] SET  READ_WRITE 
GO
