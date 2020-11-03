USE [project3]
GO

/****** Object:  Table [dbo].[Injury]    Script Date: 03-11-2020 12:28:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Injury](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customerId] [int] NOT NULL,
	[injuryTypeId] [int] NOT NULL,
	[description] [varchar](500) NOT NULL,
	[severity] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Injury] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Injury]  WITH CHECK ADD  CONSTRAINT [FK_Injury_Customer] FOREIGN KEY([customerId])
REFERENCES [dbo].[Person] ([id])
GO

ALTER TABLE [dbo].[Injury] CHECK CONSTRAINT [FK_Injury_Customer]
GO

ALTER TABLE [dbo].[Injury]  WITH CHECK ADD  CONSTRAINT [FK_Injury_InjuryType] FOREIGN KEY([injuryTypeId])
REFERENCES [dbo].[InjuryType] ([id])
GO

ALTER TABLE [dbo].[Injury] CHECK CONSTRAINT [FK_Injury_InjuryType]
GO


