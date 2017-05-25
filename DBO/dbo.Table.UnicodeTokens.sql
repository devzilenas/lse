DROP TABLE Numbers65535
DECLARE @RunDate datetime
SET @RunDate=GETDATE()
CREATE TABLE Numbers65535 (Number  int  not null)  
;WITH
  Pass0 as (select 1 as C union all select 1), --2 rows
  Pass1 as (select 1 as C from Pass0 as A, Pass0 as B),--4 rows
  Pass2 as (select 1 as C from Pass1 as A, Pass1 as B),--16 rows
  Pass3 as (select 1 as C from Pass2 as A, Pass2 as B),--256 rows
  Pass4 as (select 1 as C from Pass3 as A, Pass3 as B),--65536 rows
  --I removed Pass5, since I'm only populating the Numbers table to 10,000
  Tally as (select row_number() over(order by C) as Number from Pass4)
INSERT Numbers65535
        (Number)
    SELECT Number
        FROM Tally
ALTER TABLE Numbers65535 ADD CONSTRAINT PK_Numbers65535 PRIMARY KEY CLUSTERED (Number)

DROP TABLE UnicodeTokens;
CREATE TABLE [dbo].[UnicodeTokens] (
    [UnicodeSymbolId]   INT           IDENTITY (1, 1) NOT NULL,
    [UnicodeSymbolText] NVARCHAR (50) NOT NULL,
    [UnicodeSymbolCode] INT           NULL,
    [Used] BIT NOT NULL DEFAULT 0, 
    PRIMARY KEY CLUSTERED ([UnicodeSymbolId] ASC)
);

--reset sequence
DBCC CHECKIDENT ('[UnicodeTokens]', RESEED, 0);

INSERT INTO UnicodeTokens (UnicodeSymbolCode, UnicodeSymbolText) SELECT Number, ISNULL(NChar(Number),'') FROM Numbers65535