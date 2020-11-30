USE [project3]
GO

/****** Object:  Table [dbo].[RehabProgram]    Script Date: 03-11-2020 12:14:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RehabProgram](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customerId] [int] NOT NULL,
	[description] [varchar](1000) NULL,
	[startDate] [datetime] NULL,
	[endDate] [datetime] NULL,
 CONSTRAINT [PK_RehabProgram] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[RehabProgram]  WITH CHECK ADD  CONSTRAINT [FK_RehabProgram_Customer] FOREIGN KEY([customerId])
--REFERENCES [dbo].[Person] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
--GO


