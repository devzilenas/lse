CREATE TABLE [dbo].[TokenTypes] (
    [TokenTypeId]   INT          IDENTITY (1, 1) NOT NULL,
    [TokenTypeText] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([TokenTypeId] ASC)
);

