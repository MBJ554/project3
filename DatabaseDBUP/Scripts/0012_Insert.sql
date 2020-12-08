USE [project3]
GO
--INSERT [dbo].[Exercise] ([name], [description]) VALUES (N'Løb', N'Man løber')
--GO
--INSERT [dbo].[Exercise] ([name], [description]) VALUES (N'Gå', N'Man går')
--GO
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
INSERT [dbo].[Person] ([id], [personTypeId], [clinicId], [practitionerId], [firstName], [lastName], [phoneNo], [email], [passwordHash], [salt], [address], [zipCode]) VALUES (2, 1, 1, 9, N'Magnus', N'Munk', N'50718449', N'mail@mail.com', N'vagRJq/iNcLUIVJol234+TK+MJR6QJ4rlbDqJpn/C2J5BZuPq3jIyHUqSqDG/FUGQWdS0pvVDwnnhYMXcl/1uQ==', N'nTND6yHWnzccqIQImUeh2DCFlaiC9wto7e6LaTZXnHtlwI3s1kMv9thGTDvn9WKqRFECGRG9zBjkqypVbTt4kmX3CiG75UgVoDWcFdQCw9iNsyPgBo4HrdMw3T3KEpjq+uTamHxsv6WFKIbQkYaC/pGRGSDbgkTbbtLsuBRMeYvOqh3nQZiXr4mbBv+w0zFU/PzTXFN9h9BztX3EUg6iefoTExiQ+4y9X7TWgR7a633mcmi7yGqCQVlc5bNYMrjwXt7hZhEooO4R1ddNLEgwTHnZZm1K+FtOIFOxF+nGYytK+/YTn89cBIvb43g8yG5/nBbviznoKdoxrVi7FDUvUQ==', N'vejen 2', N'7470')
GO
INSERT [dbo].[Person] ([id], [personTypeId], [clinicId], [practitionerId], [firstName], [lastName], [phoneNo], [email], [passwordHash], [salt], [address], [zipCode]) VALUES (9, 2, 1, NULL, N'admin', N'admin', N'12345678', N'admin@admin.dk', N'f3m8fDJnwal5W7NCBsr4NYocMbN1VMSNWFOY83c65XDTvE+W4pXHxPi1fdGZqLYRpha+susiJnBIP9IFpZjP0A==', N'/An022H2TvPjUr4+IqbWON9VVwy8xEd8wI/UHMmRptHCOF+n/QOK0tmqMn/m/xFXKdp5ucMEKoky/7iqjv/JzygLCESVaDRC3GZyqpuO8V80/sY+aXd8w26wNN+RtBJmDOVIU3lhuixJpzzHG0zIUOe21DEvMtjBkjych3ajd0wkkdRaZaXVuXrYhYKI9kxAX/qQPhJGxxQ6/VzFpZmujA+a5pKaM0H3avCEkX5yNL2vmcK72LAH9YI3D/gw4DZk4KuAEtS1yTorh+7O0QkyUmYC2oSyKkeICytitKa1+VGVi8z0iJctqKxetKXGBvVcgmW9TwG4wlrhdl5J94EVMw==', NULL, NULL)
GO
--INSERT [dbo].[Person] ([personTypeId], [clinicId], [practitionerId], [firstName], [lastName], [phoneNo], [email], [password], [address], [zipCode]) VALUES (2, 1, NULL, N'Doctor', N'Who', N'69696969', N'Tardis@Gallifrey.dk', N'whodaman', NULL, NULL)
--GO
--INSERT [dbo].[Person] ([personTypeId], [clinicId], [practitionerId], [firstName], [lastName], [phoneNo], [email], [password], [address], [zipCode]) VALUES (1, 1, 1, N'Jens', N'Bobsen', N'12345678', N'bob@gmail.com', N'Bob1234', N'Bobvej 2', N'8800')
--GO
--INSERT [dbo].[Person] ([personTypeId], [clinicId], [practitionerId], [firstName], [lastName], [phoneNo], [email], [password], [address], [zipCode]) VALUES (1, 1, 1, N'Magnus', N'Munk', N'50718449', N'æggehoved', N'123', N'vej 2', N'7470')
--GO
--INSERT [dbo].[Person] ([personTypeId], [clinicId], [practitionerId], [firstName], [lastName], [phoneNo], [email], [password], [address], [zipCode]) VALUES (1, 1, 1, N'Mikkel', N'Brøgger', N'23404540', N'mikkelbrgger@gmail.com', N'210997', N'Godsbanen 63, 1, 9', N'9000')
--GO
--INSERT [dbo].[RehabProgram] ([customerID], [description], [startDate], [endDate]) VALUES (3, N'Følger programmet 3 gange om ugen', CAST(N'2020-11-09T18:16:02.567' AS DateTime), CAST(N'2020-11-09T18:16:02.567' AS DateTime))
--GO
--INSERT [dbo].[RehabProgram] ([customerID], [description], [startDate], [endDate]) VALUES (4, N'følg programmet 2 gange om ugen', CAST(N'2020-11-09T18:28:01.190' AS DateTime), CAST(N'2020-11-09T18:28:01.190' AS DateTime))
--GO
--INSERT [dbo].[ExerciseLine] ([rehabProgramId], [excerciseId], [sets], [reps]) VALUES (1, 1, 0, 0)
--GO
--INSERT [dbo].[ExerciseLine] ([rehabProgramId], [excerciseId], [sets], [reps]) VALUES (2, 2, 0, 0)
--GO