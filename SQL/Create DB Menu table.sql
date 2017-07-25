USE [Dan]
GO

/****** Object:  Table [dbo].[Menu]    Script Date: 7/25/2017 2:45:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[UrlLink] [nvarchar](100) NULL,
	[MenuOrder] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO


INSERT Menu (Text, UrlLink, MenuOrder, IsActive)
VALUES ('Edit Menu', 'menueditor.aspx', 1, 1),
		('Survey Lookup', 'MetrixStuff/MissingSurveySessionLookup.aspx', 2, 1),
		('Bullhorn Lookup', 'MetrixStuff/BullhornLookup.aspx', 3, 1),
		('Employee Lookup', 'MetrixStuff/EmployeeLookup.aspx', 4, 1)