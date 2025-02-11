USE [BloodDonation]
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Id], [Name]) VALUES (1, N'Pakistan')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [Name], [CountryId]) VALUES (1, N'Lahore', 1)
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[CityArea] ON 

INSERT [dbo].[CityArea] ([Id], [Name], [CityId]) VALUES (1, N'Walton', 1)
SET IDENTITY_INSERT [dbo].[CityArea] OFF
SET IDENTITY_INSERT [dbo].[ColonyArea] ON 

INSERT [dbo].[ColonyArea] ([Id], [Name], [CityAreaId]) VALUES (2, N'Main Street Mian Park', 1)
INSERT [dbo].[ColonyArea] ([Id], [Name], [CityAreaId]) VALUES (3, N'Street 1 Mian Park', 1)
INSERT [dbo].[ColonyArea] ([Id], [Name], [CityAreaId]) VALUES (4, N'Street 2 Mian Park', 1)
INSERT [dbo].[ColonyArea] ([Id], [Name], [CityAreaId]) VALUES (5, N'Street 3 Mian Park', 1)
INSERT [dbo].[ColonyArea] ([Id], [Name], [CityAreaId]) VALUES (6, N'Street 4 Mian Park', 1)
SET IDENTITY_INSERT [dbo].[ColonyArea] OFF
SET IDENTITY_INSERT [dbo].[BloodGroup] ON 

INSERT [dbo].[BloodGroup] ([Id], [Name]) VALUES (1, N'A+')
INSERT [dbo].[BloodGroup] ([Id], [Name]) VALUES (2, N'A-')
INSERT [dbo].[BloodGroup] ([Id], [Name]) VALUES (3, N'B+')
INSERT [dbo].[BloodGroup] ([Id], [Name]) VALUES (4, N'B-')
INSERT [dbo].[BloodGroup] ([Id], [Name]) VALUES (5, N'O+')
INSERT [dbo].[BloodGroup] ([Id], [Name]) VALUES (6, N'O-')
INSERT [dbo].[BloodGroup] ([Id], [Name]) VALUES (7, N'AB+')
INSERT [dbo].[BloodGroup] ([Id], [Name]) VALUES (8, N'AB-')
SET IDENTITY_INSERT [dbo].[BloodGroup] OFF
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([Id], [Name]) VALUES (1, N'Male')
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (2, N'Female')
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (3, N'Other')
SET IDENTITY_INSERT [dbo].[Gender] OFF
SET IDENTITY_INSERT [dbo].[MartialStatus] ON 

INSERT [dbo].[MartialStatus] ([Id], [Name]) VALUES (1, N'Single')
INSERT [dbo].[MartialStatus] ([Id], [Name]) VALUES (2, N'Married')
INSERT [dbo].[MartialStatus] ([Id], [Name]) VALUES (3, N'Unknown')
SET IDENTITY_INSERT [dbo].[MartialStatus] OFF
