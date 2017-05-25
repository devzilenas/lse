CREATE TABLE [dbo].[LinkRequests] (
    [LinkRequestID] INT           IDENTITY (1, 1) NOT NULL,
    [RequestedOn]   DATETIME      NOT NULL,
    [Token]         VARCHAR (MAX) NOT NULL,
    [Processed]     BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([LinkRequestID] ASC)
);

