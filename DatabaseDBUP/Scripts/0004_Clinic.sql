USE [project3]
GO

/****** Object:  Table [dbo].[Clinic]    Script Date: 03-11-2020 12:17:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clinic](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](60) NOT NULL,
	[address] [varchar](70) NOT NULL,
	[zipCode] [varchar](4) NOT NULL,
	[phoneNo] [varchar](11) NOT NULL,
	[description] [varchar](500) NULL,
 CONSTRAINT [PK_Clinic] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[Clinic]  WITH CHECK ADD  CONSTRAINT [FK_Clinic_City] FOREIGN KEY([zipCode])
--REFERENCES [dbo].[City] ([zipCode])
--GO

--ALTER TABLE [dbo].[Clinic] CHECK CONSTRAINT [FK_Clinic_City]
--GO


