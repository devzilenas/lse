CREATE TABLE [dbo].[Links] (
    [LinkID]   INT            NOT NULL IDENTITY,
    [LinkHref] NVARCHAR (MAX) NULL,
    [TokenID]  INT            NULL,
    PRIMARY KEY CLUSTERED ([LinkID] ASC)
);

