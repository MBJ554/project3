USE [project3]
GO

/****** Object:  Table [dbo].[Appointment]    Script Date: 03-11-2020 12:28:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Appointment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[startdate] [datetime] NOT NULL,
	[enddate] [datetime] NOT NULL,
	[customerId] [int] NOT NULL,
	[practitionerId] [int] NOT NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Customer] FOREIGN KEY([customerId])
--REFERENCES [dbo].[Person] ([id]) ON DELETE SET NULL
--GO

--ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Customer]
--GO

--ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Practitioner] FOREIGN KEY([practitionerId])
--REFERENCES [dbo].[Person] ([id]) ON DELETE SET NULL
--GO

--ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Practitioner]
--GO

--ALTER TABLE [dbo].[Appointment] ADD CONSTRAINT [Unique_Appointment] UNIQUE(practitionerId, startdate)
--GO


