CREATE TABLE [dbo].[Links] (
    [LinkId]   INT            IDENTITY (1, 1) NOT NULL,
    [LinkHref] NVARCHAR (MAX) NULL,
    [TokenId]  INT            NULL,
    PRIMARY KEY CLUSTERED ([LinkId] ASC)
);

