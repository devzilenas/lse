SET IDENTITY_INSERT [dbo].[DurationDim] ON
INSERT INTO [dbo].[DurationDim] ([DurationDimId], [DurationDimName], [DurationDimSeconds], [DurationDimShortName]) VALUES (1, N'second', 1, N's')
INSERT INTO [dbo].[DurationDim] ([DurationDimId], [DurationDimName], [DurationDimSeconds], [DurationDimShortName]) VALUES (2, N'minute', 60, N'min')
INSERT INTO [dbo].[DurationDim] ([DurationDimId], [DurationDimName], [DurationDimSeconds], [DurationDimShortName]) VALUES (3, N'hour', 3600, N'h')
SET IDENTITY_INSERT [dbo].[DurationDim] OFF
