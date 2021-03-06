USE [master]
GO
/****** Object:  Database [ESL]    Script Date: 12/18/2018 10:52:16 PM ******/
CREATE DATABASE [ESL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ESL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ESL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ESL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ESL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ESL] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ESL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ESL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ESL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ESL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ESL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ESL] SET ARITHABORT OFF 
GO
ALTER DATABASE [ESL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ESL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ESL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ESL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ESL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ESL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ESL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ESL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ESL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ESL] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ESL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ESL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ESL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ESL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ESL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ESL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ESL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ESL] SET RECOVERY FULL 
GO
ALTER DATABASE [ESL] SET  MULTI_USER 
GO
ALTER DATABASE [ESL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ESL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ESL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ESL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ESL] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ESL', N'ON'
GO
ALTER DATABASE [ESL] SET QUERY_STORE = OFF
GO
USE [ESL]
GO
/****** Object:  Table [dbo].[Accommodation]    Script Date: 12/18/2018 10:52:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accommodation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Instruction] [varchar](1000) NULL,
	[Assignment] [varchar](1000) NULL,
	[Assessment] [varchar](1000) NULL,
	[StudentID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Advisor]    Script Date: 12/18/2018 10:52:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advisor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](25) NOT NULL,
	[FirstName] [varchar](25) NOT NULL,
	[Phone] [varchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 12/18/2018 10:52:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Counselor]    Script Date: 12/18/2018 10:52:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Counselor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](25) NOT NULL,
	[FirstName] [varchar](25) NOT NULL,
	[Phone] [varchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Domain]    Script Date: 12/18/2018 10:52:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Domain](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](12) NULL,
	[GradeID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Family]    Script Date: 12/18/2018 10:52:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Family](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](25) NOT NULL,
	[FirstName] [varchar](25) NOT NULL,
	[Relationship] [varchar](25) NOT NULL,
	[SameSchool] [varchar](10) NULL,
	[NeedInterpreter] [varchar](10) NOT NULL,
	[StudentID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grade]    Script Date: 12/18/2018 10:52:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](2) NOT NULL,
	[StudentID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LangProficiencyLevel]    Script Date: 12/18/2018 10:52:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LangProficiencyLevel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Level] [int] NOT NULL,
	[DomainID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 12/18/2018 10:52:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modification]    Script Date: 12/18/2018 10:52:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modification](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Instruction] [varchar](1000) NULL,
	[Assignment] [varchar](1000) NULL,
	[Assessment] [varchar](1000) NULL,
	[StudentID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OverallProficiencyScale]    Script Date: 12/18/2018 10:52:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OverallProficiencyScale](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Scale] [int] NOT NULL,
	[Description] [varchar](200) NULL,
	[StudentID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quarter]    Script Date: 12/18/2018 10:52:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quarter](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Quarter] [int] NOT NULL,
	[SchoolYearID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School]    Script Date: 12/18/2018 10:52:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[StreetOne] [varchar](100) NOT NULL,
	[StreetTwo] [varchar](100) NULL,
	[City] [varchar](25) NOT NULL,
	[State] [varchar](25) NOT NULL,
	[Zip] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchoolStudent]    Script Date: 12/18/2018 10:52:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolStudent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[CurrentSchool] [int] NOT NULL,
	[PreviousSchool1] [int] NULL,
	[PreviousSchool2] [int] NULL,
	[PreviousSchool3] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchoolYear]    Script Date: 12/18/2018 10:52:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolYear](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[StudentID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 12/18/2018 10:52:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](1000) NOT NULL,
	[Date] [datetime] NULL,
	[Observation] [varchar](1000) NULL,
	[Intervention] [varchar](1000) NULL,
	[Response] [varchar](1000) NULL,
	[LangProficiencyLevelID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 12/18/2018 10:52:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SchoolID] [int] NOT NULL,
	[SNumber] [int] NOT NULL,
	[LastName] [varchar](25) NOT NULL,
	[FirstName] [varchar](25) NOT NULL,
	[Phone] [varchar](12) NULL,
	[IEP] [varchar](10) NULL,
	[HomeLanguage] [varchar](25) NULL,
	[ELService] [varchar](1000) NULL,
	[AdditionalInfo] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAdvisor]    Script Date: 12/18/2018 10:52:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAdvisor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[AdvisorID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentClass]    Script Date: 12/18/2018 10:52:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentClass](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCounselor]    Script Date: 12/18/2018 10:52:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCounselor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[CounselorID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentLanguage]    Script Date: 12/18/2018 10:52:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentLanguage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[Language1] [int] NULL,
	[Language2] [int] NULL,
	[Language3] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentTeacher]    Script Date: 12/18/2018 10:52:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTeacher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[TeacherID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Summary]    Script Date: 12/18/2018 10:52:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Summary](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Note] [varchar](1000) NULL,
	[QuarterID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 12/18/2018 10:52:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](25) NOT NULL,
	[FirstName] [varchar](25) NOT NULL,
	[Phone] [varchar](12) NULL,
	[isELStaff] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherClass]    Script Date: 12/18/2018 10:52:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherClass](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[School] ON 

INSERT [dbo].[School] ([ID], [Name], [StreetOne], [StreetTwo], [City], [State], [Zip]) VALUES (1, N'Lakewood High School', N'18645 DETROIT AVE', NULL, N'LAKEWOOD', N'OH', N'44107')
SET IDENTITY_INSERT [dbo].[School] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([ID], [SchoolID], [SNumber], [LastName], [FirstName], [Phone], [IEP], [HomeLanguage], [ELService], [AdditionalInfo]) VALUES (1, 1, 100, N'Sudik', N'Steve', N'333-333-3334', N'No', N'Chinese', N'Meets every Wednesday morning', N'Good student')
SET IDENTITY_INSERT [dbo].[Student] OFF
ALTER TABLE [dbo].[Skill] ADD  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Accommodation]  WITH CHECK ADD  CONSTRAINT [StudentID_FK13] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[Accommodation] CHECK CONSTRAINT [StudentID_FK13]
GO
ALTER TABLE [dbo].[Domain]  WITH CHECK ADD  CONSTRAINT [GradeID_FK] FOREIGN KEY([GradeID])
REFERENCES [dbo].[Grade] ([ID])
GO
ALTER TABLE [dbo].[Domain] CHECK CONSTRAINT [GradeID_FK]
GO
ALTER TABLE [dbo].[Family]  WITH CHECK ADD  CONSTRAINT [StudentID_FK10] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[Family] CHECK CONSTRAINT [StudentID_FK10]
GO
ALTER TABLE [dbo].[Grade]  WITH CHECK ADD  CONSTRAINT [StudentID_FK6] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[Grade] CHECK CONSTRAINT [StudentID_FK6]
GO
ALTER TABLE [dbo].[LangProficiencyLevel]  WITH CHECK ADD  CONSTRAINT [DomainID_FK] FOREIGN KEY([DomainID])
REFERENCES [dbo].[Domain] ([ID])
GO
ALTER TABLE [dbo].[LangProficiencyLevel] CHECK CONSTRAINT [DomainID_FK]
GO
ALTER TABLE [dbo].[Modification]  WITH CHECK ADD  CONSTRAINT [StudentID_FK12] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[Modification] CHECK CONSTRAINT [StudentID_FK12]
GO
ALTER TABLE [dbo].[OverallProficiencyScale]  WITH CHECK ADD  CONSTRAINT [StudentID_FK11] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[OverallProficiencyScale] CHECK CONSTRAINT [StudentID_FK11]
GO
ALTER TABLE [dbo].[Quarter]  WITH CHECK ADD  CONSTRAINT [SchoolYearID_FK] FOREIGN KEY([SchoolYearID])
REFERENCES [dbo].[SchoolYear] ([ID])
GO
ALTER TABLE [dbo].[Quarter] CHECK CONSTRAINT [SchoolYearID_FK]
GO
ALTER TABLE [dbo].[SchoolStudent]  WITH CHECK ADD  CONSTRAINT [CurrentSchool_FK] FOREIGN KEY([CurrentSchool])
REFERENCES [dbo].[School] ([ID])
GO
ALTER TABLE [dbo].[SchoolStudent] CHECK CONSTRAINT [CurrentSchool_FK]
GO
ALTER TABLE [dbo].[SchoolStudent]  WITH CHECK ADD  CONSTRAINT [PreviousSchool1_FK] FOREIGN KEY([PreviousSchool1])
REFERENCES [dbo].[School] ([ID])
GO
ALTER TABLE [dbo].[SchoolStudent] CHECK CONSTRAINT [PreviousSchool1_FK]
GO
ALTER TABLE [dbo].[SchoolStudent]  WITH CHECK ADD  CONSTRAINT [PreviousSchool2_FK] FOREIGN KEY([PreviousSchool2])
REFERENCES [dbo].[School] ([ID])
GO
ALTER TABLE [dbo].[SchoolStudent] CHECK CONSTRAINT [PreviousSchool2_FK]
GO
ALTER TABLE [dbo].[SchoolStudent]  WITH CHECK ADD  CONSTRAINT [PreviousSchool3_FK] FOREIGN KEY([PreviousSchool3])
REFERENCES [dbo].[School] ([ID])
GO
ALTER TABLE [dbo].[SchoolStudent] CHECK CONSTRAINT [PreviousSchool3_FK]
GO
ALTER TABLE [dbo].[SchoolStudent]  WITH CHECK ADD  CONSTRAINT [StudentID_FK] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[SchoolStudent] CHECK CONSTRAINT [StudentID_FK]
GO
ALTER TABLE [dbo].[SchoolYear]  WITH CHECK ADD  CONSTRAINT [StudentID_FK14] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[SchoolYear] CHECK CONSTRAINT [StudentID_FK14]
GO
ALTER TABLE [dbo].[Skill]  WITH CHECK ADD  CONSTRAINT [LangProficiencyLevelID_FK] FOREIGN KEY([LangProficiencyLevelID])
REFERENCES [dbo].[LangProficiencyLevel] ([ID])
GO
ALTER TABLE [dbo].[Skill] CHECK CONSTRAINT [LangProficiencyLevelID_FK]
GO
ALTER TABLE [dbo].[StudentAdvisor]  WITH CHECK ADD  CONSTRAINT [AdvisorID_FK] FOREIGN KEY([AdvisorID])
REFERENCES [dbo].[Advisor] ([ID])
GO
ALTER TABLE [dbo].[StudentAdvisor] CHECK CONSTRAINT [AdvisorID_FK]
GO
ALTER TABLE [dbo].[StudentAdvisor]  WITH CHECK ADD  CONSTRAINT [StudentID_FK4] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StudentAdvisor] CHECK CONSTRAINT [StudentID_FK4]
GO
ALTER TABLE [dbo].[StudentClass]  WITH CHECK ADD  CONSTRAINT [ClassID_FK] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ID])
GO
ALTER TABLE [dbo].[StudentClass] CHECK CONSTRAINT [ClassID_FK]
GO
ALTER TABLE [dbo].[StudentClass]  WITH CHECK ADD  CONSTRAINT [StudentID_FK2] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StudentClass] CHECK CONSTRAINT [StudentID_FK2]
GO
ALTER TABLE [dbo].[StudentCounselor]  WITH CHECK ADD  CONSTRAINT [CounselorID_FK] FOREIGN KEY([CounselorID])
REFERENCES [dbo].[Counselor] ([ID])
GO
ALTER TABLE [dbo].[StudentCounselor] CHECK CONSTRAINT [CounselorID_FK]
GO
ALTER TABLE [dbo].[StudentCounselor]  WITH CHECK ADD  CONSTRAINT [StudentID_FK3] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StudentCounselor] CHECK CONSTRAINT [StudentID_FK3]
GO
ALTER TABLE [dbo].[StudentLanguage]  WITH CHECK ADD  CONSTRAINT [Language1_FK] FOREIGN KEY([Language1])
REFERENCES [dbo].[Language] ([ID])
GO
ALTER TABLE [dbo].[StudentLanguage] CHECK CONSTRAINT [Language1_FK]
GO
ALTER TABLE [dbo].[StudentLanguage]  WITH CHECK ADD  CONSTRAINT [Language2_FK] FOREIGN KEY([Language2])
REFERENCES [dbo].[Language] ([ID])
GO
ALTER TABLE [dbo].[StudentLanguage] CHECK CONSTRAINT [Language2_FK]
GO
ALTER TABLE [dbo].[StudentLanguage]  WITH CHECK ADD  CONSTRAINT [Language3_FK] FOREIGN KEY([Language3])
REFERENCES [dbo].[Language] ([ID])
GO
ALTER TABLE [dbo].[StudentLanguage] CHECK CONSTRAINT [Language3_FK]
GO
ALTER TABLE [dbo].[StudentLanguage]  WITH CHECK ADD  CONSTRAINT [StudentID_FK15] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StudentLanguage] CHECK CONSTRAINT [StudentID_FK15]
GO
ALTER TABLE [dbo].[StudentTeacher]  WITH CHECK ADD  CONSTRAINT [StudentID_FK1] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StudentTeacher] CHECK CONSTRAINT [StudentID_FK1]
GO
ALTER TABLE [dbo].[StudentTeacher]  WITH CHECK ADD  CONSTRAINT [TeacherID_FK] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([ID])
GO
ALTER TABLE [dbo].[StudentTeacher] CHECK CONSTRAINT [TeacherID_FK]
GO
ALTER TABLE [dbo].[Summary]  WITH CHECK ADD  CONSTRAINT [QuarterID_FK] FOREIGN KEY([QuarterID])
REFERENCES [dbo].[Quarter] ([ID])
GO
ALTER TABLE [dbo].[Summary] CHECK CONSTRAINT [QuarterID_FK]
GO
ALTER TABLE [dbo].[TeacherClass]  WITH CHECK ADD  CONSTRAINT [ClassID_FK1] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ID])
GO
ALTER TABLE [dbo].[TeacherClass] CHECK CONSTRAINT [ClassID_FK1]
GO
ALTER TABLE [dbo].[TeacherClass]  WITH CHECK ADD  CONSTRAINT [TeacherID_FK2] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([ID])
GO
ALTER TABLE [dbo].[TeacherClass] CHECK CONSTRAINT [TeacherID_FK2]
GO
USE [master]
GO
ALTER DATABASE [ESL] SET  READ_WRITE 
GO
