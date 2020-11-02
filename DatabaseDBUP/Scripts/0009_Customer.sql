USE [project3]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 02-11-2020 17:13:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[id] [int] NOT NULL,
	[zipCode] [varchar](4) NOT NULL,
	[address] [varchar](70) NULL,
	[practitionerId] [int] NOT NULL,
	[rehabProgramId] [int] NOT NULL,
	[clinicId] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_City] FOREIGN KEY([zipCode])
REFERENCES [dbo].[City] ([zipCode])
GO

ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_City]
GO

ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Clinic] FOREIGN KEY([clinicId])
REFERENCES [dbo].[Clinic] ([id])
GO

ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Clinic]
GO

ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Person] FOREIGN KEY([id])
REFERENCES [dbo].[Person] ([id])
GO

ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Person]
GO

ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Practitioner] FOREIGN KEY([practitionerId])
REFERENCES [dbo].[Practitioner] ([id])
GO

ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Practitioner]
GO

ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_RehabProgram] FOREIGN KEY([rehabProgramId])
REFERENCES [dbo].[RehabProgram] ([id])
GO

ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_RehabProgram]
GO


