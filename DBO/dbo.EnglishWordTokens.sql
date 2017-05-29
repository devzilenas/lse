CREATE TABLE [dbo].[EnglishWordTokens] (
    [EnglishWordTokenText] VARCHAR (50) NOT NULL,
    [EnglishWordTokenId]   INT           IDENTITY (1, 1) NOT NULL,
    [Used]                 BIT           NULL
);


GO

CREATE INDEX [IX_EnglishWordTokens_Column] ON [dbo].[EnglishWordTokens] ([EnglishWordTokenText])
