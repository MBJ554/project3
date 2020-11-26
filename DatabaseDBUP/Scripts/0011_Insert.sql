USE [project3]
GO
INSERT [dbo].[Exercise] ([name], [description]) VALUES (N'Løb', N'Man løber')
GO
INSERT [dbo].[Exercise] ([name], [description]) VALUES (N'Gå', N'Man går')
GO
INSERT [dbo].[RehabProgram] ([description], [startDate], [endDate]) VALUES (N'Følger programmet 3 gange om ugen', CAST(N'2020-11-09T18:16:02.567' AS DateTime), CAST(N'2020-11-09T18:16:02.567' AS DateTime))
GO
INSERT [dbo].[RehabProgram] ([description], [startDate], [endDate]) VALUES (N'følg programmet 2 gange om ugen', CAST(N'2020-11-09T18:28:01.190' AS DateTime), CAST(N'2020-11-09T18:28:01.190' AS DateTime))
GO
INSERT [dbo].[ExerciseLine] ([rehabProgramId], [excerciseId], [sets], [reps]) VALUES (1, 1, 0, 0)
GO
INSERT [dbo].[ExerciseLine] ([rehabProgramId], [excerciseId], [sets], [reps]) VALUES (2, 2, 0, 0)
GO
INSERT [dbo].[City] ([zipCode], [cityName]) VALUES (N'7470', N'Karup J')
GO
INSERT [dbo].[City] ([zipCode], [cityName]) VALUES (N'8800', N'Viborg')
GO
INSERT [dbo].[City] ([zipCode], [cityName]) VALUES (N'9000', N'Aalborg')
GO
INSERT [dbo].[Clinic] ([name], [address], [zipCode], [phoneNo], [description]) VALUES (N'Klinikken', N'Klinikvej 2', N'7470', N'12345678', N'Den er god')
GO
SET IDENTITY_INSERT [dbo].[PersonType] ON 
GO
INSERT [dbo].[PersonType] ([id], [type]) VALUES (1, N'Customer')
GO
INSERT [dbo].[PersonType] ([id], [type]) VALUES (2, N'Practitioner')
GO
SET IDENTITY_INSERT [dbo].[PersonType] OFF
GO
INSERT [dbo].[Person] ([personTypeId], [clinicId], [practitionerId], [rehabProgramId], [firstName], [lastName], [phoneNo], [email], [password], [address], [zipCode]) VALUES (2, 1, NULL, NULL, N'Doctor', N'Who', N'69696969', N'Tardis@Gallifrey.dk', N'whodaman', NULL, NULL)
GO
INSERT [dbo].[Person] ([personTypeId], [clinicId], [practitionerId], [rehabProgramId], [firstName], [lastName], [phoneNo], [email], [password], [address], [zipCode]) VALUES (1, 1, 1, NULL, N'Jens', N'Bobsen', N'12345678', N'bob@gmail.com', N'Bob1234', N'Bobvej 2', N'8800')
GO
INSERT [dbo].[Person] ([personTypeId], [clinicId], [practitionerId], [rehabProgramId], [firstName], [lastName], [phoneNo], [email], [password], [address], [zipCode]) VALUES (1, 1, 1, 1, N'Magnus', N'Munk', N'50718449', N'æggehoved', N'123', N'vej 2', N'7470')
GO
INSERT [dbo].[Person] ([personTypeId], [clinicId], [practitionerId], [rehabProgramId], [firstName], [lastName], [phoneNo], [email], [password], [address], [zipCode]) VALUES (1, 1, 1, 2, N'Mikkel', N'Brøgger', N'23404540', N'mikkelbrgger@gmail.com', N'210997', N'Godsbanen 63, 1, 9', N'9000')
GO