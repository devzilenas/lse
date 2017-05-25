CREATE TABLE [dbo].[Banners] (
    [BannerId]      INT           IDENTITY (1, 1) NOT NULL,
    [AlternateText] VARCHAR (MAX) NOT NULL,
    [ImageUrl]      VARCHAR (MAX) NOT NULL,
    [NavigateUrl]   VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([BannerId] ASC)
);

