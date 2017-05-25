CREATE TABLE [dbo].[TokenTypesConfiguration] (
    [TokensTypesConfigurationId] INT IDENTITY (1, 1) NOT NULL,
    [TokenTypeId]                INT NOT NULL,
    [Enabled]                    BIT DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([TokensTypesConfigurationId] ASC)
);

