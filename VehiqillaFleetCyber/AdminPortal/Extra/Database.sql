USE [dbVehiqillaFleetCyberAdmin]
GO
/****** Object:  Table [dbo].[AppBreaches]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppBreaches](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[NewsSource] [nvarchar](250) NULL,
	[VulnerabilityExploited] [nvarchar](250) NULL,
	[Date] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[ECUApp_ID] [int] NULL,
 CONSTRAINT [PK_dbo.AppBreaches] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppVulnerabilities]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppVulnerabilities](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Name] [nvarchar](max) NULL,
	[HackType] [nvarchar](250) NULL,
	[Access] [nvarchar](250) NULL,
	[Range] [nvarchar](250) NULL,
	[AttackVector] [nvarchar](250) NULL,
	[AttackMethod] [nvarchar](250) NULL,
	[Impact] [nvarchar](250) NULL,
	[ResearchName] [nvarchar](250) NULL,
	[Reference] [nvarchar](250) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[ECUApp_ID] [int] NULL,
	[OemImpacted] [nvarchar](250) NULL,
	[Link] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.AppVulnerabilities] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Company_ID] [int] NULL,
	[Code] [nvarchar](max) NULL,
	[DateCreated] [datetime] NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CaseAttachments]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaseAttachments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AbsolutePath] [nvarchar](4000) NULL,
	[Address] [nvarchar](500) NULL,
	[FileName] [nvarchar](500) NULL,
	[Type] [nvarchar](250) NULL,
	[UploadedBy] [nvarchar](250) NULL,
	[TypeID] [int] NULL,
 CONSTRAINT [PK_Attachments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CaseResponses]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaseResponses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CaseID] [int] NULL,
	[Message] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[MessageFrom] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.CaseNotitifications] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cases]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cases](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](250) NULL,
	[Details] [text] NULL,
	[Summary] [nvarchar](250) NULL,
	[Status] [nvarchar](250) NULL,
	[Category] [nvarchar](250) NULL,
	[AssignedTo] [nvarchar](250) NULL,
	[Source] [nvarchar](250) NULL,
	[Requestedby] [nvarchar](250) NULL,
	[Priority] [nvarchar](250) NULL,
	[DateCreated] [datetime] NULL,
	[ResolutionDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Cases] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Abbreviation] [nvarchar](250) NULL,
	[DisplayName] [nvarchar](250) NULL,
	[logo] [nvarchar](max) NULL,
	[Address] [nvarchar](250) NULL,
	[Country] [nvarchar](250) NULL,
	[Email] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[Url] [nvarchar](max) NULL,
	[Vehicles] [int] NULL,
	[License] [int] NULL,
	[Fleets] [int] NULL,
 CONSTRAINT [PK_dbo.Companies] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contents]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](250) NULL,
	[Heading] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Text] [nvarchar](max) NULL,
	[File] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Designation] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Contents] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CyberRiskTypes]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CyberRiskTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
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
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ECUApps]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ECUApps](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[VehicleModel] [nvarchar](250) NULL,
	[YearManufactured] [nvarchar](250) NULL,
	[Breaches] [nvarchar](250) NULL,
	[Vulnerabilities] [nvarchar](250) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[Category_ID] [int] NULL,
	[Supplier_ID] [int] NULL,
	[FilePath] [nvarchar](4000) NULL,
 CONSTRAINT [PK_dbo.ECUApps] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KnowledgeCenters]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KnowledgeCenters](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Heading] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[AbsolutePath] [nvarchar](max) NULL,
	[FilePath] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.KnowledgeCenters] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Heading] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Read] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[User_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Notifications] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oems]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Brand] [nvarchar](250) NULL,
	[Model] [nvarchar](250) NULL,
	[YearManufactured] [int] NOT NULL,
	[Country] [nvarchar](250) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.Oems] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[ContactPerson] [nvarchar](250) NULL,
	[ContactDetail] [nvarchar](250) NULL,
	[Headoffice] [nvarchar](250) NULL,
	[Country] [nvarchar](250) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[Logo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Suppliers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehiAssureAssessmentCustomFields]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiAssureAssessmentCustomFields](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AssessmentDate] [datetime] NOT NULL,
	[Token] [nvarchar](250) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[EcuAppID] [int] NOT NULL,
	[FieldID] [int] NOT NULL,
	[Value] [nvarchar](250) NOT NULL,
	[UUID] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.VehiAssureAssessmentCustomFields] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehiAssureAssessments]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiAssureAssessments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UUID] [nvarchar](250) NULL,
	[AssessmentDate] [datetime] NOT NULL,
	[Token] [nvarchar](250) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[EcuAppID] [int] NOT NULL,
	[QuestionaireID] [int] NOT NULL,
	[QuestionID] [int] NOT NULL,
	[OptionID] [int] NOT NULL,
	[Remarks] [nvarchar](250) NULL,
	[Approved] [bit] NOT NULL,
	[Reviewed] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.VehiAssureAssessments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehiAssureInvites]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiAssureInvites](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InviteStatus] [nvarchar](max) NULL,
	[Token] [nvarchar](max) NULL,
	[DateRequested] [datetime] NOT NULL,
	[RemindedOn] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[ECUApp_ID] [int] NULL,
	[Supplier_ID] [int] NULL,
 CONSTRAINT [PK_dbo.VehiAssureInvites] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehiAssureQuestionaireCustomFields]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiAssureQuestionaireCustomFields](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehiAssureQuestionaireID] [int] NOT NULL,
	[Field] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.VehiAssureQuestionaireCustomFields] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehiAssureQuestionaires]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiAssureQuestionaires](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Instructions] [nvarchar](max) NOT NULL,
	[DueInDays] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](250) NOT NULL,
	[DateModified] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.VehiAssureQuestionaires] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehiAssureQuestionGroups]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiAssureQuestionGroups](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[MaxScore] [int] NOT NULL,
	[Threshold] [int] NOT NULL,
	[VehiAssureQuestionaireID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.VehiAssureQuestionGroups] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehiAssureQuestionOptions]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiAssureQuestionOptions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Score] [int] NOT NULL,
	[VehiAssureQuestionID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.VehiAssureQuestionOptions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehiAssureQuestions]    Script Date: 9/7/2023 8:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiAssureQuestions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Score] [int] NOT NULL,
	[VehiAssureQuestionGroupID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.VehiAssureQuestions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f00cfc23-5221-499b-8622-86e31d7bc373', N'Admin')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [Company_ID], [Code], [DateCreated], [Phone], [Active], [Address]) VALUES (N'443a370e-584a-43ca-9ecc-abad62960756', N'mabdullahjavaid93+user1@gmail.com', 1, N'AC/cLFavYzKNZhEXWphNZRz5fkP4/662PUj5K+wDK8a2jhRTaAuWxkX6E5ipwvuptw==', N'9f0424e7-0738-4535-9030-f2abc5539cbc', NULL, 0, 0, NULL, 1, 0, N'mabdullahjavaid93+user1@gmail.com', N'Muhammad Abdullah bin Javaid', 3, NULL, CAST(N'2023-09-05T17:51:07.480' AS DateTime), N'+923400018231', 1, N'Islamabad')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [Company_ID], [Code], [DateCreated], [Phone], [Active], [Address]) VALUES (N'f2d14967-211d-471b-92cf-892161c88e19', N'admin@gmail.com', 1, N'ABMRldDh/ubYd+YtOTFvQC9d7YCEYiYv8fRSjrI0wOo2Izu7LcdFHPPbhigmJGq4AQ==', N'32820263-e8d0-4ab2-9786-9284c8141cd4', NULL, 0, 0, NULL, 0, 0, N'admin@gmail.com', N'Admin', NULL, NULL, CAST(N'2021-01-01T00:00:00.000' AS DateTime), NULL, 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([ID], [Name], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified], [Discriminator]) VALUES (3, N'Cat 1', 1, 0, N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T22:52:32.060' AS DateTime), N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T22:52:32.060' AS DateTime), N'')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 
GO
INSERT [dbo].[Companies] ([ID], [Name], [Abbreviation], [DisplayName], [logo], [Address], [Country], [Email], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified], [Url], [Vehicles], [License], [Fleets]) VALUES (3, N'Company 1', NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T22:44:27.850' AS DateTime), N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T22:44:27.850' AS DateTime), N'http://localhost:4568/', 100, 2, 1)
GO
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[Contents] ON 
GO
INSERT [dbo].[Contents] ([ID], [Type], [Heading], [Image], [Text], [File], [Url], [Name], [Designation], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified]) VALUES (1, N'About', NULL, NULL, N'sd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  asdasdas dadsas dasas da dsa dssd sdfs dfsd fas das da sdasdsad as dasdadsasd  as', NULL, NULL, NULL, NULL, 1, 0, N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-06-17T20:46:34.503' AS DateTime), N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-06-17T20:46:34.503' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Contents] OFF
GO
SET IDENTITY_INSERT [dbo].[CyberRiskTypes] ON 
GO
INSERT [dbo].[CyberRiskTypes] ([ID], [Name], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified], [Discriminator]) VALUES (8, N'Cat 1', 1, 0, N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T22:52:38.650' AS DateTime), N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T22:52:38.650' AS DateTime), N'')
GO
SET IDENTITY_INSERT [dbo].[CyberRiskTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[ECUApps] ON 
GO
INSERT [dbo].[ECUApps] ([ID], [Name], [Description], [VehicleModel], [YearManufactured], [Breaches], [Vulnerabilities], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified], [Category_ID], [Supplier_ID], [FilePath]) VALUES (6, N'App 1', N'des', NULL, NULL, NULL, NULL, 1, 0, N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T23:07:28.863' AS DateTime), N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T23:07:28.863' AS DateTime), 3, 2, N'http://localhost:4567/App_Data/Uploads/AppLogos/e6cbb6db-66c2-4907-a425-550500ae14d7_OverallRiskScore.png')
GO
INSERT [dbo].[ECUApps] ([ID], [Name], [Description], [VehicleModel], [YearManufactured], [Breaches], [Vulnerabilities], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified], [Category_ID], [Supplier_ID], [FilePath]) VALUES (7, N'a2', N'asdasdasd', NULL, NULL, NULL, NULL, 1, 0, N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T23:46:19.247' AS DateTime), N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T23:46:19.247' AS DateTime), 3, 3, N'http://localhost:4567/App_Data/Uploads/AppLogos/5e2ec961-543c-4dcc-9c40-ae68c939a536_OverallRiskScore.png')
GO
SET IDENTITY_INSERT [dbo].[ECUApps] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 
GO
INSERT [dbo].[Suppliers] ([ID], [Name], [ContactPerson], [ContactDetail], [Headoffice], [Country], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified], [Discriminator], [Logo]) VALUES (2, N'Supplier 1', N'Supplier 1 Contact Person', N'mabdullahjavaid93+sup1@gmail.com', N'Supplier 1', N'Albania', 1, 0, N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T22:53:07.340' AS DateTime), N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T22:53:07.340' AS DateTime), N'', NULL)
GO
INSERT [dbo].[Suppliers] ([ID], [Name], [ContactPerson], [ContactDetail], [Headoffice], [Country], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified], [Discriminator], [Logo]) VALUES (3, N's2', N's2', N's2@email.com', N's2', N'Bangladesh', 1, 0, N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T23:46:05.240' AS DateTime), N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T23:46:05.240' AS DateTime), N'', NULL)
GO
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
SET IDENTITY_INSERT [dbo].[VehiAssureAssessmentCustomFields] ON 
GO
INSERT [dbo].[VehiAssureAssessmentCustomFields] ([ID], [AssessmentDate], [Token], [SupplierID], [EcuAppID], [FieldID], [Value], [UUID]) VALUES (1, CAST(N'2023-09-05T18:27:25.807' AS DateTime), N'521af137f21f47cf8e6f6012930c02b8', 2, 6, 1, N'asdasda', N'00841f306062457e80b04c5d23a74d14')
GO
SET IDENTITY_INSERT [dbo].[VehiAssureAssessmentCustomFields] OFF
GO
SET IDENTITY_INSERT [dbo].[VehiAssureAssessments] ON 
GO
INSERT [dbo].[VehiAssureAssessments] ([ID], [UUID], [AssessmentDate], [Token], [SupplierID], [EcuAppID], [QuestionaireID], [QuestionID], [OptionID], [Remarks], [Approved], [Reviewed]) VALUES (1, N'00841f306062457e80b04c5d23a74d14', CAST(N'2023-09-05T18:27:25.807' AS DateTime), N'521af137f21f47cf8e6f6012930c02b8', 2, 6, 1, 1, 1, N'asdadsadsasd', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[VehiAssureAssessments] OFF
GO
SET IDENTITY_INSERT [dbo].[VehiAssureInvites] ON 
GO
INSERT [dbo].[VehiAssureInvites] ([ID], [InviteStatus], [Token], [DateRequested], [RemindedOn], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified], [ECUApp_ID], [Supplier_ID]) VALUES (1, N'Completed', N'521af137f21f47cf8e6f6012930c02b8', CAST(N'2023-08-05T18:10:33.767' AS DateTime), CAST(N'2023-09-05T18:21:50.860' AS DateTime), 1, 0, N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-08-05T18:16:35.557' AS DateTime), N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T18:10:33.767' AS DateTime), 6, 2)
GO
INSERT [dbo].[VehiAssureInvites] ([ID], [InviteStatus], [Token], [DateRequested], [RemindedOn], [IsActive], [IsDeleted], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified], [ECUApp_ID], [Supplier_ID]) VALUES (2, N'Pending', N'309da97d22d84f899c2b76bc20f59bb5', CAST(N'2023-08-05T18:16:35.557' AS DateTime), NULL, 1, 0, N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-08-05T18:16:35.557' AS DateTime), N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T18:16:35.557' AS DateTime), 6, 2)
GO
SET IDENTITY_INSERT [dbo].[VehiAssureInvites] OFF
GO
SET IDENTITY_INSERT [dbo].[VehiAssureQuestionaireCustomFields] ON 
GO
INSERT [dbo].[VehiAssureQuestionaireCustomFields] ([ID], [VehiAssureQuestionaireID], [Field]) VALUES (1, 1, N'Some Name field')
GO
SET IDENTITY_INSERT [dbo].[VehiAssureQuestionaireCustomFields] OFF
GO
SET IDENTITY_INSERT [dbo].[VehiAssureQuestionaires] ON 
GO
INSERT [dbo].[VehiAssureQuestionaires] ([ID], [Name], [Instructions], [DueInDays], [Status], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified]) VALUES (1, N'Q 1', N'q1', 14, 1, N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T17:54:03.000' AS DateTime), N'f2d14967-211d-471b-92cf-892161c88e19', CAST(N'2023-09-05T17:54:03.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[VehiAssureQuestionaires] OFF
GO
SET IDENTITY_INSERT [dbo].[VehiAssureQuestionGroups] ON 
GO
INSERT [dbo].[VehiAssureQuestionGroups] ([ID], [Name], [MaxScore], [Threshold], [VehiAssureQuestionaireID]) VALUES (1, N'g1', 100, 50, 1)
GO
SET IDENTITY_INSERT [dbo].[VehiAssureQuestionGroups] OFF
GO
SET IDENTITY_INSERT [dbo].[VehiAssureQuestionOptions] ON 
GO
INSERT [dbo].[VehiAssureQuestionOptions] ([ID], [Name], [Score], [VehiAssureQuestionID]) VALUES (1, N'Yes', 100, 1)
GO
INSERT [dbo].[VehiAssureQuestionOptions] ([ID], [Name], [Score], [VehiAssureQuestionID]) VALUES (2, N'No', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[VehiAssureQuestionOptions] OFF
GO
SET IDENTITY_INSERT [dbo].[VehiAssureQuestions] ON 
GO
INSERT [dbo].[VehiAssureQuestions] ([ID], [Type], [Name], [Score], [VehiAssureQuestionGroupID]) VALUES (1, N'Yes/No', N'q1', 100, 1)
GO
SET IDENTITY_INSERT [dbo].[VehiAssureQuestions] OFF
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [DateCreated]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT ('') FOR [Discriminator]
GO
ALTER TABLE [dbo].[CyberRiskTypes] ADD  CONSTRAINT [DF_Findings_Discriminator]  DEFAULT ('') FOR [Discriminator]
GO
ALTER TABLE [dbo].[Oems] ADD  DEFAULT ('') FOR [Discriminator]
GO
ALTER TABLE [dbo].[Suppliers] ADD  DEFAULT ('') FOR [Discriminator]
GO
ALTER TABLE [dbo].[VehiAssureQuestionGroups] ADD  DEFAULT ((0)) FOR [VehiAssureQuestionaireID]
GO
ALTER TABLE [dbo].[VehiAssureQuestionOptions] ADD  DEFAULT ((0)) FOR [VehiAssureQuestionID]
GO
ALTER TABLE [dbo].[VehiAssureQuestions] ADD  DEFAULT ((0)) FOR [VehiAssureQuestionGroupID]
GO
ALTER TABLE [dbo].[AppBreaches]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AppBreaches_dbo.ECUApps_ECUApp_ID] FOREIGN KEY([ECUApp_ID])
REFERENCES [dbo].[ECUApps] ([ID])
GO
ALTER TABLE [dbo].[AppBreaches] CHECK CONSTRAINT [FK_dbo.AppBreaches_dbo.ECUApps_ECUApp_ID]
GO
ALTER TABLE [dbo].[AppVulnerabilities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AppVulnerabilities_dbo.ECUApps_ECUApp_ID] FOREIGN KEY([ECUApp_ID])
REFERENCES [dbo].[ECUApps] ([ID])
GO
ALTER TABLE [dbo].[AppVulnerabilities] CHECK CONSTRAINT [FK_dbo.AppVulnerabilities_dbo.ECUApps_ECUApp_ID]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUsers_dbo.Companies_Company_ID] FOREIGN KEY([Company_ID])
REFERENCES [dbo].[Companies] ([ID])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_dbo.AspNetUsers_dbo.Companies_Company_ID]
GO
ALTER TABLE [dbo].[ECUApps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ECUApps_dbo.Categories_Category_ID] FOREIGN KEY([Category_ID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[ECUApps] CHECK CONSTRAINT [FK_dbo.ECUApps_dbo.Categories_Category_ID]
GO
ALTER TABLE [dbo].[ECUApps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ECUApps_dbo.Suppliers_Supplier_ID] FOREIGN KEY([Supplier_ID])
REFERENCES [dbo].[Suppliers] ([ID])
GO
ALTER TABLE [dbo].[ECUApps] CHECK CONSTRAINT [FK_dbo.ECUApps_dbo.Suppliers_Supplier_ID]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Notifications_dbo.AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_dbo.Notifications_dbo.AspNetUsers_User_Id]
GO
ALTER TABLE [dbo].[VehiAssureInvites]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VehiAssureInvites_dbo.ECUApps_ECUApp_ID] FOREIGN KEY([ECUApp_ID])
REFERENCES [dbo].[ECUApps] ([ID])
GO
ALTER TABLE [dbo].[VehiAssureInvites] CHECK CONSTRAINT [FK_dbo.VehiAssureInvites_dbo.ECUApps_ECUApp_ID]
GO
ALTER TABLE [dbo].[VehiAssureInvites]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VehiAssureInvites_dbo.Suppliers_Supplier_ID] FOREIGN KEY([Supplier_ID])
REFERENCES [dbo].[Suppliers] ([ID])
GO
ALTER TABLE [dbo].[VehiAssureInvites] CHECK CONSTRAINT [FK_dbo.VehiAssureInvites_dbo.Suppliers_Supplier_ID]
GO
/****** Object:  StoredProcedure [dbo].[_CREATE_ADMIN]    Script Date: 9/7/2023 8:21:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_CREATE_ADMIN]

AS


INSERT [dbo].[AspNetUsers] ( [Id]
      ,[Email]
      ,[EmailConfirmed]
      ,[PasswordHash]
      ,[SecurityStamp]
      ,[PhoneNumber]
      ,[PhoneNumberConfirmed]
      ,[TwoFactorEnabled]
      ,[LockoutEndDateUtc]
      ,[LockoutEnabled]
      ,[AccessFailedCount]
      ,[UserName]
      ,[Name]
      ,[Company_ID]) 
VALUES (N'f2d14967-211d-471b-92cf-892161c88e19', --[Id]
N'admin@gmail.com', --[Email]
1, -- [EmailConfirmed]
 N'AFc8L+ae5NSETKk3WwWiGSd+8l6R3FuJV/4zBtizxTqNEcZYHxWmaA7Trdb7CLag7g==', --[PasswordHash]
N'4b08788d-2c94-4e30-9f76-61cd544da493', --[SecurityStamp]
NULL,--[PhoneNumber]
0,--[PhoneNumberConfirmed]
0,--[TwoFactorEnabled]
NULL,--[LockoutEndDateUtc]
0,--[LockoutEnabled]
0,--[AccessFailedCount]
N'admin@gmail.com',--[UserName]
N'Admin',--[Name]
NULL--[Company_ID]

)
GO
/****** Object:  StoredProcedure [dbo].[_MODEL_CREATOR]    Script Date: 9/7/2023 8:21:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[_MODEL_CREATOR]

AS

DECLARE @TableName sysname = 'CaseAttachments'
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
/****** Object:  StoredProcedure [dbo].[_X_X_X_X_X_X_X_X_X_X_X_X_X_CLEAR_DATA]    Script Date: 9/7/2023 8:21:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_X_X_X_X_X_X_X_X_X_X_X_X_X_CLEAR_DATA]
@AreYouSureYouWantToDeleteAllData as nvarchar =''
AS 

 DELETE FROM AppBreaches;
 DELETE FROM AppVulnerabilities;
 DELETE FROM AspNetUsers WHERE Email!='admin@gmail.com';
 DELETE FROM CaseAttachments;
 DELETE FROM CaseResponses;
 DELETE FROM CyberRiskTypes;
 DELETE FROM Cases;
 DELETE FROM Categories;
 DELETE FROM Companies;
 DELETE FROM Contents where type!='About';
 DELETE FROM ECUApps;
 DELETE FROM KnowledgeCenters;
 DELETE FROM Notifications;
 DELETE FROM OEMs;
 DELETE FROM Suppliers;
 DELETE FROM VehiAssureAssessmentCustomFields;
 DELETE FROM VehiAssureAssessments;
 DELETE FROM VehiAssureInvites;
 DELETE FROM VehiAssureQuestionaireCustomFields;
 DELETE FROM VehiAssureQuestionaires;
 DELETE FROM VehiAssureQuestionGroups;
 DELETE FROM VehiAssureQuestionOptions;
 DELETE FROM VehiAssureQuestions;
GO
/****** Object:  StoredProcedure [dbo].[GetAppAssessment]    Script Date: 9/7/2023 8:21:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAppAssessment]
@AppID as int = 2
As

SELECT Categories.Name CategoryName,Suppliers.Name SupplierName, Suppliers.Logo as Logo,

E.Name as Name,
E.ID as ID,
E.Description as Description,
E.FilePath as FilePath,

E.DateCreated as DateCreated,
Max(VehiAssureAssessments.AssessmentDate) as AssessmentDate,

sum(VehiAssureQuestionOptions.Score) AS Score,
(SELECT COUNT(*) FROM AppBreaches where AppBreaches.ECUApp_ID=E.ID) Breaches,
(SELECT COUNT(*) FROM AppVulnerabilities where AppVulnerabilities.ECUApp_ID=E.ID) Vulnerabilities

FROM ECUApps AS E

INNER JOIN Categories ON Categories.ID = E.Category_ID
INNER JOIN Suppliers ON Suppliers.ID = E.Supplier_ID
INNER JOIN VehiAssureAssessments ON VehiAssureAssessments.EcuAppID = E.ID
INNER JOIN VehiAssureQuestionOptions ON VehiAssureAssessments.OptionID = VehiAssureQuestionOptions.ID

WHERE E.IsDeleted=0  AND VehiAssureAssessments.AssessmentDate = (Select MAX(AssessmentDate) FROM  VehiAssureAssessments WHERE EcuAppID = E.ID )
AND E.ID = @AppID AND VehiAssureAssessments.Approved = 1
GROUP BY Categories.Name,Suppliers.Name,Suppliers.Logo,E.Name,E.ID,E.DateCreated,E.Description,E.FilePath 

--SELECT * FROM VehiAssureAssessments
--SELECT * FROM VehiAssureQuestionOptions

--SELECT * FROM EcuApps



GO
/****** Object:  StoredProcedure [dbo].[GetAppDetailsAssessmentReview]    Script Date: 9/7/2023 8:21:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAppDetailsAssessmentReview]
@UUID as VARCHAR(255) = 'd4619c1abee04ec9b26187416de5dd98'
As
SELECT Categories.Name CategoryName,Suppliers.Name SupplierName, Suppliers.Logo as Logo,
E.Name as Name,
E.ID as ID,
E.FilePath as FilePath,
sum(VehiAssureQuestionOptions.Score) AS Score
FROM ECUApps AS E

INNER JOIN Categories ON Categories.ID = E.Category_ID
INNER JOIN Suppliers ON Suppliers.ID = E.Supplier_ID
INNER JOIN VehiAssureAssessments ON VehiAssureAssessments.EcuAppID = E.ID
INNER JOIN VehiAssureQuestionOptions ON VehiAssureAssessments.OptionID = VehiAssureQuestionOptions.ID

WHERE E.IsDeleted=0 AND VehiAssureAssessments.UUID = @UUID
GROUP BY Categories.Name,Suppliers.Name,Suppliers.Logo,E.Name,E.ID,e.FilePath

--SELECT * FROM VehiAssureAssessments
--SELECT * FROM VehiAssureQuestionOptions

--SELECT * FROM EcuApps



GO
/****** Object:  StoredProcedure [dbo].[GetAssessmentChart]    Script Date: 9/7/2023 8:21:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAssessmentChart]
@AppID as int = 2
As
SELECT 
VehiAssureAssessments.AssessmentDate as AssessmentDate,

sum(VehiAssureQuestionOptions.Score) AS Score
FROM ECUApps AS E

INNER JOIN Categories ON Categories.ID = E.Category_ID
INNER JOIN Suppliers ON Suppliers.ID = E.Supplier_ID
INNER JOIN VehiAssureAssessments ON VehiAssureAssessments.EcuAppID = E.ID
INNER JOIN VehiAssureQuestionOptions ON VehiAssureAssessments.OptionID = VehiAssureQuestionOptions.ID

WHERE E.IsDeleted=0 
AND E.ID = @AppID AND VehiAssureAssessments.Approved = 1
GROUP BY Categories.Name,Suppliers.Name,Suppliers.Logo,E.Name,E.ID,E.DateCreated,E.Description,VehiAssureAssessments.AssessmentDate


GO
/****** Object:  StoredProcedure [dbo].[GetAssessmentsOverallResult]    Script Date: 9/7/2023 8:21:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAssessmentsOverallResult]
@CatID as int = -1
As

SELECT Categories.Name CategoryName,Suppliers.Name SupplierName, Suppliers.Logo as Logo,

E.Name as Name,
E.ID as ID,
E.FilePath as FilePath,
E.Description as Description,
sum(VehiAssureQuestionOptions.Score) AS Score,
(SELECT COUNT(*) FROM AppBreaches where AppBreaches.ECUApp_ID=E.ID) Breaches,
(SELECT COUNT(*) FROM AppVulnerabilities where AppVulnerabilities.ECUApp_ID=E.ID) Vulnerabilities
FROM ECUApps AS E

INNER JOIN Categories ON Categories.ID = E.Category_ID
INNER JOIN Suppliers ON Suppliers.ID = E.Supplier_ID
INNER JOIN VehiAssureAssessments ON VehiAssureAssessments.EcuAppID = E.ID
INNER JOIN VehiAssureQuestionOptions ON VehiAssureAssessments.OptionID = VehiAssureQuestionOptions.ID

WHERE E.IsDeleted=0 AND VehiAssureAssessments.AssessmentDate = (Select MAX(AssessmentDate) FROM  VehiAssureAssessments WHERE EcuAppID = E.ID )
AND (Categories.ID = @CatID OR @CatID=-1) AND VehiAssureAssessments.Approved = 1
GROUP BY Categories.Name,Suppliers.Name,Suppliers.Logo,E.Name,E.ID,E.FilePath ,
E.Description 

--SELECT * FROM VehiAssureAssessments
--SELECT * FROM VehiAssureQuestionOptions

--SELECT * FROM EcuApps



GO
/****** Object:  StoredProcedure [dbo].[GetSelectedOptions]    Script Date: 9/7/2023 8:21:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  PROCEDURE [dbo].[GetSelectedOptions]
@AppID as int = -1,
@GroupID as int = -1

As
SELECT VehiAssureAssessments.*

FROM VehiAssureAssessments
INNER JOIN VehiAssureQuestions ON VehiAssureQuestions.ID = VehiAssureAssessments.QuestionID
INNER JOIN VehiAssureQuestionGroups ON VehiAssureQuestions.VehiAssureQuestionGroupID = VehiAssureQuestionGroups.ID

WHERE  VehiAssureAssessments.AssessmentDate = (Select MAX(AssessmentDate) FROM  VehiAssureAssessments WHERE EcuAppID = @AppID )
AND VehiAssureQuestionGroups.ID = @GroupID
GO
/****** Object:  StoredProcedure [dbo].[GetSelectedOptionsByUUID]    Script Date: 9/7/2023 8:21:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create  PROCEDURE [dbo].[GetSelectedOptionsByUUID]
@UUID as NVARCHAR (255) = 'd4619c1abee04ec9b26187416de5dd98',
@GroupID as int = -1

As
SELECT VehiAssureAssessments.*

FROM VehiAssureAssessments
INNER JOIN VehiAssureQuestions ON VehiAssureQuestions.ID = VehiAssureAssessments.QuestionID
INNER JOIN VehiAssureQuestionGroups ON VehiAssureQuestions.VehiAssureQuestionGroupID = VehiAssureQuestionGroups.ID

WHERE  VehiAssureAssessments.UUID = @UUID AND VehiAssureQuestionGroups.ID = @GroupID


--SELECT * FROM VehiAssureAssessments
--SELECT * FROM VehiAssureQuestionOptions

--SELECT * FROM EcuApps



GO
/****** Object:  StoredProcedure [dbo].[Rpt_MegaReport]    Script Date: 9/7/2023 8:21:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rpt_MegaReport]
AS 


WITH Score AS (
SELECT EcuAppID,SUM(VehiAssureQuestionOptions.Score) AS Score FROM VehiAssureAssessments X
INNER JOIN VehiAssureQuestionOptions ON VehiAssureQuestionOptions.ID=X.OptionID
WHERE  X.AssessmentDate = (Select MAX(AssessmentDate) FROM  VehiAssureAssessments WHERE EcuAppID = X.EcuAppID )
GROUP BY EcuAppID 
)

SELECT 
'' Fleet,
'' Vehicle,
'' Brand,
'' Model,
'' YearManufactured,
Categories.Name as CategoryName,
ECUApps.Name,
Suppliers.Name as SupplierName,
ECUApps.ID as  ID,
(SELECT CAST(COUNT(*) AS nvarchar) 
FROM AppVulnerabilities 
WHERE AppVulnerabilities.ECUApp_ID=ECUApps.ID) AS [Vulnerabilities],
(SELECT CAST(COUNT(*) AS nvarchar) 
FROM AppBreaches 
WHERE AppBreaches.ECUApp_ID=ECUApps.ID) AS [Breaches],
Score.Score

FROM ECUApps

INNER JOIN Categories ON Categories.ID = ECUApps.Category_ID
INNER JOIN Suppliers ON ECUApps.Supplier_ID = Suppliers.ID
inner join Score on Score.EcuAppID= ECUApps.ID

WHERE ECUApps.IsDeleted=0 


--oup by Fleets.Name,Vehicles.Name,Vehicles.Brand,Vehicles.Model,Vehicles.YearManufactured,Categories.Name,ECUApps.Name,Suppliers.Name,ECUApps.ID,OEMs.Name,Score
ORDER BY Name;
GO
