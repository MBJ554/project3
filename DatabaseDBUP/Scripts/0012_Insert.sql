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
SET IDENTITY_INSERT [dbo].[Person] ON 
GO
INSERT [dbo].[Person] ([id], [personTypeId], [clinicId], [practitionerId], [firstName], [lastName], [phoneNo], [email], [passwordHash], [salt], [address], [zipCode]) VALUES (1, 2, 1, NULL, N'Admin', N'Jensen', N'11111111', N'admin@admin.desktop', N'e5IejFFR+GlG1eBn+pGC3gt5gzs2fZoVWHAOaebs+jJv2mjSN53UwOtpmpA+queRV+nxWx6/u8683ON8Qc4QEQ==', N'yLSScf5LLxfmYXVBlKNVLG97iu/hFcTa2mivf9XxZB9p5i2E/Ta4XRX6LsYsdlp7UeERN6MFjyYzIlPL10nn5rWQw2671PYh2MLj/QNSRK1QKqZn9vf9brqpOCrmvq9CuRBLpBWAEgQven6dAS1Ebn3cZlTgahz2mio95Hk/KFzbFC8YtjQ9z34NdwRxaEndUp4s/JZDtSfYSqXx9clIKuVuzstyJoYRan2q1k6pSvtKL4R0ejSCJyonZ1+6dgbx+k/eZYHCBeEaRXe/CVWrssU+qGILY4mgkZg4EfaVs6pSrRRawWUZv2p3Y2mdx9fD0AnxtC2s8EXLxSpoBVvWIA==', NULL, NULL)
GO
INSERT [dbo].[Person] ([id], [personTypeId], [clinicId], [practitionerId], [firstName], [lastName], [phoneNo], [email], [passwordHash], [salt], [address], [zipCode]) VALUES (2, 1, 1, 1, N'Customer', N'Jensen', N'22222222', N'admin@admin.web', N'OhlwPqQpOzZaUl4FbH4k9kVIa6wh9AKDTh8k1WXt0TjROQH2VxHUwDHqARIJVOojPCYz0sH+b/zO74m1DlBqBg==', N'gcNsRCAYmZqcvJajWQO4Dil+0DZ8OaqsikpME//PEx3DKfzg0KEtIQKgNOykWVaaBHHuRkFrNMHIXfMsH3BZEMB414isI43RshPsi+yyvFgrSzvnxFAlBxiwwXNhVPCh5cboP6ITrHZoGP2BVx31CODuMg1O6H6fZo6QhVr+x+1nHcn5bGnAJSIPbuQu6LIZwvZAZNAL137IBKJf39p7z2J60zC5roKbcv5H7scoxHBwEYOWSC9AE91ax1+efp4MSOXSw0omU4v88T4HtqvKbgTZKZQOrWlzyKr/1wxDytN1/AGu7jUHXNMrgZR/VNZyGZ5Z1wKCS/3boW0pE8DEvw==', N'adminvej 3', N'9000')
GO
SET IDENTITY_INSERT [dbo].[Person] OFF 
GO