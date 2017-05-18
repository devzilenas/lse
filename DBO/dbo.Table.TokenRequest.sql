CREATE TABLE [dbo].[TokenRequest]
(
	[TokenRequestId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RequestedOn] DATETIME NOT NULL, 
    [LinkHref] VARCHAR(MAX) NOT NULL, 
    [TokenId] INT NULL
)
