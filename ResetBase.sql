--Resets database
USE LinkShareEasy

GO

DELETE FROM Tokens;
DELETE FROM Links;
DELETE FROM LinkRequests;
DELETE FROM TokenRequests;
DELETE FROM TokenUsage;

UPDATE NumericTokens SET Used=0;
UPDATE     EnglishWordTokens 
       SET   Used       = 0
           , WordLength = LEN(EnglishWordTokenText);

--DELETE FROM UnicodeTokens;

--DELETE FROM Numbers65535;

--DELETE FROM EnglishWordTokens;