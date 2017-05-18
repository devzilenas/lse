CREATE TABLE [dbo].[TokensUsage]
(
	[TokenID] INT NOT NULL PRIMARY KEY, 
    [Token] VARCHAR(MAX) NULL, 
    [UsedOn] DATETIME NULL
)
