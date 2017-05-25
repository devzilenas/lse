CREATE TABLE [dbo].[DurationDim] (
    [DurationDimId]        INT          IDENTITY (1, 1) NOT NULL,
    [DurationDimName]      VARCHAR (50) NOT NULL,
    [DurationDimSeconds]   INT          NOT NULL,
    [DurationDimShortName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([DurationDimId] ASC)
);

