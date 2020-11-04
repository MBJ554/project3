USE [project3]
GO

/****** Object:  Table [dbo].[Person]    Script Date: 03-11-2020 12:27:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[personTypeId] [int] NOT NULL,
	[clinicId] [int] NOT NULL,
	[practitionerId] [int] NULL,
	[rehabProgramId] [int] NULL,
	[firstName] [varchar](50) NOT NULL,
	[lastName] [varchar](50) NOT NULL,
	[phoneNo] [varchar](11) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[address] [varchar](70) NULL,
	[zipCode] [varchar](4) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Customer_City] FOREIGN KEY([zipCode])
REFERENCES [dbo].[City] ([zipCode])
GO

ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Customer_City]
GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Customer_RehabProgram] FOREIGN KEY([rehabProgramId])
REFERENCES [dbo].[RehabProgram] ([id])
GO

ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Customer_RehabProgram]
GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Clinic] FOREIGN KEY([clinicId])
REFERENCES [dbo].[Clinic] ([id])
GO

ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Clinic]
GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_PersonType] FOREIGN KEY([personTypeId])
REFERENCES [dbo].[PersonType] ([id])
GO

ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_PersonType]
GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Practitioner_Customer] FOREIGN KEY([practitionerId])
REFERENCES [dbo].[Person] ([id])
GO

ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Practitioner_Customer]
GO


