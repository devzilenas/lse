CREATE TABLE [dbo].[TokenUsage] (
    [TokenId]      INT           NOT NULL,
    [Token]        VARCHAR (MAX) NULL,
    [UsedOn]       DATETIME      NULL,
    [TokenUsageId] INT           IDENTITY (1, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([TokenUsageId] ASC)
);

