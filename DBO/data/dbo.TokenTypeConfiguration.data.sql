SET IDENTITY_INSERT [dbo].[TokenTypeConfiguration] ON
INSERT INTO [dbo].[TokenTypeConfiguration] ([TokenTypeConfigurationId], [TokenTypeId], [Enabled], [DefaultValidForDurationDimId], [DefaultValidForDuration]) VALUES (1, 1, 1, 2, 10)
INSERT INTO [dbo].[TokenTypeConfiguration] ([TokenTypeConfigurationId], [TokenTypeId], [Enabled], [DefaultValidForDurationDimId], [DefaultValidForDuration]) VALUES (2, 2, 0, 2, 10)
INSERT INTO [dbo].[TokenTypeConfiguration] ([TokenTypeConfigurationId], [TokenTypeId], [Enabled], [DefaultValidForDurationDimId], [DefaultValidForDuration]) VALUES (3, 3, 1, 2, 10)
SET IDENTITY_INSERT [dbo].[TokenTypeConfiguration] OFF
