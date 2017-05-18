CREATE TABLE [dbo].[LinkRequests]
(
	[LinkRequestID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LinkHref] VARCHAR(MAX) NOT NULL, 
    [RequestedOn] DATETIME NOT NULL
)
