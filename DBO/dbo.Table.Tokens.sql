CREATE TABLE [dbo].[Tokens] (
    [TokenId]               INT           IDENTITY (1, 1) NOT NULL,
    [TokenText]             VARCHAR (MAX) NULL,
    [TokenTypeId]           INT           NULL,
    [ValidForDurationDimId] INT           NULL,
    [ValidForDuration]      INT           NULL,
    [IsExpired]             BIT           NULL,
    PRIMARY KEY CLUSTERED ([TokenId] ASC)
);

