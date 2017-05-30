CREATE TABLE [dbo].[EnglishWordTokens] (
    [EnglishWordTokenText] VARCHAR (50) NOT NULL,
    [EnglishWordTokenId]   INT          IDENTITY (1, 1) NOT NULL,
    [Used]                 BIT          NULL, 
    [WordLength] INT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_EnglishWordTokens_Column]
    ON [dbo].[EnglishWordTokens]([EnglishWordTokenText] ASC);


GO

CREATE INDEX [IX_EnglishWordTokens_Column_1] ON [dbo].[EnglishWordTokens] ([WordLength])
