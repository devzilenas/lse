CREATE TABLE [dbo].[LinkShareEasyConfig] (
    [LinkShareEasyConfigId]      INT IDENTITY (1, 1) NOT NULL,
    [TransferAfterDuration]      INT NOT NULL,
    [TransferAfterDurationDimId] INT NOT NULL,
    [DefaultDurationDimId]       INT NULL,
    [DefaultDuration]            INT NULL,
    PRIMARY KEY CLUSTERED ([LinkShareEasyConfigId] ASC)
);

