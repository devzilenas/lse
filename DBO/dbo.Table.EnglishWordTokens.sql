CREATE TABLE [dbo].[EnglishWordTokens] (
    [EnglishWordTokenText] VARCHAR (50) NOT NULL,
    [EnglishWordTokenId]   INT          IDENTITY (1, 1) NOT NULL,
    [Used]                 BIT          NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_EnglishWordTokens_Column]
    ON [dbo].[EnglishWordTokens]([EnglishWordTokenText] ASC);


GO
