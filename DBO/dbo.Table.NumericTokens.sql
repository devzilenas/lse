CREATE TABLE [dbo].[NumericTokens] (
    [NumericTokenID] INT IDENTITY (1, 1) NOT NULL,
    [NumericTokenN]  INT NOT NULL,
    [Used]           BIT DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([NumericTokenID] ASC)
);

