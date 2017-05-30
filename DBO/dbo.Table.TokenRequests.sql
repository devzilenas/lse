CREATE TABLE [dbo].[TokenRequests] (
    [TokenRequestId] INT           IDENTITY (1, 1) NOT NULL,
    [RequestedOn]    DATETIME      NOT NULL,
    [TokenId]        INT           NULL,
    [LinkId]         INT           NULL,
    [TokenTypeId]    INT           NULL,
    [LinkHref]       VARCHAR (MAX) NULL,
    [TokenTypeText]  VARCHAR (50)  NULL,
    [SingleUse] BIT NULL, 
    PRIMARY KEY CLUSTERED ([TokenRequestId] ASC)
);

