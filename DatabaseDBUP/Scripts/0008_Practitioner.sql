USE [project3]
GO

/****** Object:  Table [dbo].[Practitioner]    Script Date: 02-11-2020 17:12:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Practitioner](
	[id] [int] NOT NULL,
	[typeId] [int] NOT NULL,
	[clinicId] [int] NOT NULL,
 CONSTRAINT [PK_Practitioners] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Practitioner]  WITH CHECK ADD  CONSTRAINT [FK_Practitioner_Clinic] FOREIGN KEY([clinicId])
REFERENCES [dbo].[Clinic] ([id])
GO

ALTER TABLE [dbo].[Practitioner] CHECK CONSTRAINT [FK_Practitioner_Clinic]
GO

ALTER TABLE [dbo].[Practitioner]  WITH CHECK ADD  CONSTRAINT [FK_Practitioner_Person] FOREIGN KEY([id])
REFERENCES [dbo].[Person] ([id])
GO

ALTER TABLE [dbo].[Practitioner] CHECK CONSTRAINT [FK_Practitioner_Person]
GO

ALTER TABLE [dbo].[Practitioner]  WITH CHECK ADD  CONSTRAINT [FK_Practitioner_Type] FOREIGN KEY([typeId])
REFERENCES [dbo].[Type] ([id])
GO

ALTER TABLE [dbo].[Practitioner] CHECK CONSTRAINT [FK_Practitioner_Type]
GO


