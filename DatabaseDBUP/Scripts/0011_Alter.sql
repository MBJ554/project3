ALTER TABLE [dbo].[ExerciseLine]  WITH CHECK ADD  CONSTRAINT [FK_ExerciseLine_Excercise] FOREIGN KEY([excerciseId])
REFERENCES [dbo].[Exercise] ([id])
GO

ALTER TABLE [dbo].[ExerciseLine] CHECK CONSTRAINT [FK_ExerciseLine_Excercise]
GO

ALTER TABLE [dbo].[ExerciseLine]  WITH CHECK ADD  CONSTRAINT [FK_ExerciseLine_RehabProgram] FOREIGN KEY([rehabProgramId])
REFERENCES [dbo].[RehabProgram] ([id]) ON DELETE CASCADE ON UPDATE CASCADE;
GO

ALTER TABLE [dbo].[ExerciseLine] CHECK CONSTRAINT [FK_ExerciseLine_RehabProgram]
GO

ALTER TABLE [dbo].[Clinic]  WITH CHECK ADD  CONSTRAINT [FK_Clinic_City] FOREIGN KEY([zipCode])
REFERENCES [dbo].[City] ([zipCode])
GO

ALTER TABLE [dbo].[Clinic] CHECK CONSTRAINT [FK_Clinic_City]
GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Customer_City] FOREIGN KEY([zipCode])
REFERENCES [dbo].[City] ([zipCode])
GO

ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Customer_City]
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
REFERENCES [dbo].[Person] ([id]) --ON DELETE SET NULL
GO

ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Practitioner_Customer]
GO

ALTER TABLE [dbo].[RehabProgram]  WITH CHECK ADD  CONSTRAINT [FK_RehabProgram_Customer] FOREIGN KEY([customerId])
REFERENCES [dbo].[Person] ([id]) ON DELETE CASCADE ON UPDATE CASCADE;
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

ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Customer] FOREIGN KEY([customerId])
REFERENCES [dbo].[Person] ([id]) --ON DELETE CASCADE;
GO

ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Customer]
GO

ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Practitioner] FOREIGN KEY([practitionerId])
REFERENCES [dbo].[Person] ([id]) --ON DELETE CASCADE;
GO

ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Practitioner]
GO

ALTER TABLE [dbo].[Appointment] ADD CONSTRAINT [Unique_Appointment] UNIQUE(practitionerId, startdate)
GO