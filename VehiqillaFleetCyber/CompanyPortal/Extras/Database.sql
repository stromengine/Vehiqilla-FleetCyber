USE [dbCompany1]
GO
/****** Object:  Table [dbo].[AccessLists]    Script Date: 9/7/2023 8:21:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessLists](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](250) NULL,
	[ItemID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.AccessLists] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppVehicleMaps]    Script Date: 9/7/2023 8:21:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppVehicleMaps](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[App_ID] [int] NULL,
	[Vehicle_ID] [int] NULL,
 CONSTRAINT [PK_AppVehicleMap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Findings]    Script Date: 9/7/2023 8:21:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Findings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[FleetID] [int] NOT NULL,
	[VehicleID] [int] NOT NULL,
	[Details] [text] NOT NULL,
	[CyberRiskTypeID] [int] NOT NULL,
	[RiskImpact] [nvarchar](250) NOT NULL,
	[RiskLikelyhood] [nvarchar](250) NOT NULL,
	[FindingRiskScore] [nvarchar](250) NOT NULL,
	[Recomendations] [text] NOT NULL,
	[Owner] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Findings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fleets]    Script Date: 9/7/2023 8:21:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fleets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[CompanyID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Fleets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 9/7/2023 8:21:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleIdentifier] [nvarchar](250) NULL,
	[Name] [nvarchar](250) NULL,
	[Brand] [nvarchar](250) NULL,
	[Model] [nvarchar](250) NULL,
	[YearManufactured] [nvarchar](250) NULL,
	[Fleet_ID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Vehicles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccessLists] ON 
GO
INSERT [dbo].[AccessLists] ([ID], [Type], [ItemID], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified]) VALUES (30, N'Supplier', 3, 1, 0, N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T23:46:33.353' AS DateTime), N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T23:46:33.353' AS DateTime))
GO
INSERT [dbo].[AccessLists] ([ID], [Type], [ItemID], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified]) VALUES (31, N'Supplier', 2, 1, 0, N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T23:46:40.427' AS DateTime), N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T23:46:40.427' AS DateTime))
GO
INSERT [dbo].[AccessLists] ([ID], [Type], [ItemID], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified]) VALUES (32, N'App', 7, 1, 0, N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T23:46:53.317' AS DateTime), N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T23:46:53.317' AS DateTime))
GO
INSERT [dbo].[AccessLists] ([ID], [Type], [ItemID], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified]) VALUES (33, N'App', 6, 1, 0, N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T23:46:53.777' AS DateTime), N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T23:46:53.777' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[AccessLists] OFF
GO
SET IDENTITY_INSERT [dbo].[AppVehicleMaps] ON 
GO
INSERT [dbo].[AppVehicleMaps] ([ID], [App_ID], [Vehicle_ID]) VALUES (15, 6, 111)
GO
INSERT [dbo].[AppVehicleMaps] ([ID], [App_ID], [Vehicle_ID]) VALUES (16, 7, 110)
GO
SET IDENTITY_INSERT [dbo].[AppVehicleMaps] OFF
GO
SET IDENTITY_INSERT [dbo].[Fleets] ON 
GO
INSERT [dbo].[Fleets] ([ID], [Name], [CompanyID], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified]) VALUES (7, N'f1', 0, 1, 0, N'443a370e-584a-43ca-9ecc-abad62960756', CAST(N'2023-09-05T23:39:21.627' AS DateTime), N'443a370e-584a-43ca-9ecc-abad62960756', CAST(N'2023-09-05T23:39:21.627' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Fleets] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicles] ON 
GO
INSERT [dbo].[Vehicles] ([ID], [VehicleIdentifier], [Name], [Brand], [Model], [YearManufactured], [Fleet_ID], [CompanyID], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified]) VALUES (110, N'v1', N'asda', N'asd', N'asd', N'2222', 7, 0, 1, 0, N'443a370e-584a-43ca-9ecc-abad62960756', CAST(N'2023-09-05T23:39:34.797' AS DateTime), N'443a370e-584a-43ca-9ecc-abad62960756', CAST(N'2023-09-05T23:39:34.797' AS DateTime))
GO
INSERT [dbo].[Vehicles] ([ID], [VehicleIdentifier], [Name], [Brand], [Model], [YearManufactured], [Fleet_ID], [CompanyID], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified]) VALUES (111, N'v2', N'v2', N'v2', N'v2', N'2222', 7, 0, 1, 0, N'443a370e-584a-43ca-9ecc-abad62960756', CAST(N'2023-09-06T00:00:57.417' AS DateTime), N'443a370e-584a-43ca-9ecc-abad62960756', CAST(N'2023-09-06T00:00:57.417' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Vehicles] OFF
GO
ALTER TABLE [dbo].[Findings] ADD  CONSTRAINT [DF_Findings_Discriminator]  DEFAULT ('') FOR [Discriminator]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_Fleets] FOREIGN KEY([Fleet_ID])
REFERENCES [dbo].[Fleets] ([ID])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_Fleets]
GO
/****** Object:  StoredProcedure [dbo].[_MODEL_CREATOR]    Script Date: 9/7/2023 8:21:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE  [dbo].[_MODEL_CREATOR]

AS

DECLARE @TableName sysname = 'Findings'
DECLARE @Result varchar(max) = 'public class ' + @TableName + ' {'
SELECT
  @Result = @Result + ' public ' + ColumnType + NullableSign + ' ' + ColumnName + ' { get; set; } '
FROM (SELECT
  REPLACE(col.name, ' ', '') ColumnName,
  column_id ColumnId,
  CASE typ.name
    WHEN 'bigint' THEN 'long'
    WHEN 'binary' THEN 'byte[]'
    WHEN 'bit' THEN 'bool'
    WHEN 'char' THEN 'string'
    WHEN 'date' THEN 'DateTime'
    WHEN 'datetime' THEN 'DateTime'
    WHEN 'datetime2' THEN 'DateTime'
    WHEN 'datetimeoffset' THEN 'DateTimeOffset'
    WHEN 'decimal' THEN 'decimal'
    WHEN 'float' THEN 'double'
    WHEN 'image' THEN 'byte[]'
    WHEN 'int' THEN 'int'
    WHEN 'money' THEN 'decimal'
    WHEN 'nchar' THEN 'string'
    WHEN 'ntext' THEN 'string'
    WHEN 'numeric' THEN 'decimal'
    WHEN 'nvarchar' THEN 'string'
    WHEN 'real' THEN 'double'
    WHEN 'smalldatetime' THEN 'DateTime'
    WHEN 'smallint' THEN 'short'
    WHEN 'smallmoney' THEN 'decimal'
    WHEN 'text' THEN 'string'
    WHEN 'time' THEN 'TimeSpan'
    WHEN 'timestamp' THEN 'DateTime'
    WHEN 'tinyint' THEN 'byte'
    WHEN 'uniqueidentifier' THEN 'Guid'
    WHEN 'varbinary' THEN 'byte[]'
    WHEN 'varchar' THEN 'string'
    ELSE 'UNKNOWN' + typ.name
  END ColumnType,
  CASE
    WHEN col.is_nullable = 1 AND
      typ.name IN ('bigint', 'bit', 'date', 'datetime', 'datetime2', 'datetimeoffset', 'decimal', 'float', 'int', 'money', 'numeric', 'real', 'smalldatetime', 'smallint', 'smallmoney', 'time', 'tinyint', 'uniqueidentifier') THEN '?'
    ELSE ''
  END NullableSign
FROM sys.columns col
JOIN sys.types typ
  ON col.system_type_id = typ.system_type_id
  AND col.user_type_id = typ.user_type_id
WHERE object_id = OBJECT_ID(@TableName)) t
ORDER BY ColumnId
SET @Result = @Result + ' }'
PRINT @Result
GO
/****** Object:  StoredProcedure [dbo].[_x_x_x_x_x_CLEAR_DATA]    Script Date: 9/7/2023 8:21:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_x_x_x_x_x_CLEAR_DATA] AS

DELETE FROM AccessLists
DELETE FROM AppVehicleMaps
DELETE FROM Findings
DELETE FROM Fleets
DELETE FROM Vehicles
GO
/****** Object:  StoredProcedure [dbo].[GetFindings]    Script Date: 9/7/2023 8:21:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetFindings]

as 

SELECT 
Findings.ID, 
'FND-'+RIGHT('0000'+CAST(Findings.ID AS VARCHAR(4)),4) FindingNo,
Findings.Name,
Findings.FleetID,
COALESCE((CASE WHEN Findings.FleetID =0 THEN 'All Fleets' ELSE Fleets.Name  END),'N/A') AS Fleet,
Findings.VehicleID,
COALESCE((CASE WHEN Findings.VehicleID =0 THEN 'All Vehicles' ELSE Vehicles.Name  END),'N/A') AS Vehicle,
Findings.Details,
Findings.CyberRiskTypeID,
Findings.RiskImpact,
Findings.RiskLikelyhood,
Findings.FindingRiskScore,
Findings.Recomendations,
Findings.Owner, 
Findings.IsActive,
Findings.IsDeleted,
Findings.CreatedBy,
Findings.DateCreated,
Findings.ModifiedBy,
Findings.DateModified,
Findings.Discriminator
FROM     Findings 
LEFT JOIN Fleets ON Findings.FleetID = Fleets.ID 
LEFT JOIN Vehicles ON Findings.VehicleID = Vehicles.ID
GO
