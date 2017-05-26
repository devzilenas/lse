CREATE TABLE [dbo].[TokenTypeConfiguration] (
    [TokenTypeConfigurationId]     INT IDENTITY (1, 1) NOT NULL,
    [TokenTypeId]                  INT NOT NULL,
    [Enabled]                      BIT DEFAULT ((0)) NOT NULL,
    [DefaultValidForDurationDimId] INT NULL,
    [DefaultValidForDuration]      INT NULL,
    PRIMARY KEY CLUSTERED ([TokenTypeConfigurationId] ASC)
);

