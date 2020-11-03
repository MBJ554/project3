USE [project3]
GO

/****** Object:  Table [dbo].[ExerciseLine]    Script Date: 03-11-2020 12:15:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ExerciseLine](
	[rehabProgramId] [int] NOT NULL,
	[excerciseId] [int] NOT NULL,
	[sets] [int] NULL,
	[reps] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ExerciseLine]  WITH CHECK ADD  CONSTRAINT [FK_ExerciseLine_Excercise] FOREIGN KEY([excerciseId])
REFERENCES [dbo].[Exercise] ([id])
GO

ALTER TABLE [dbo].[ExerciseLine] CHECK CONSTRAINT [FK_ExerciseLine_Excercise]
GO

ALTER TABLE [dbo].[ExerciseLine]  WITH CHECK ADD  CONSTRAINT [FK_ExerciseLine_RehabProgram] FOREIGN KEY([rehabProgramId])
REFERENCES [dbo].[RehabProgram] ([id])
GO

ALTER TABLE [dbo].[ExerciseLine] CHECK CONSTRAINT [FK_ExerciseLine_RehabProgram]
GO


