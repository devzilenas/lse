--Resets database
USE LinkShareEasy

GO

/* No tokens. */
DELETE FROM Tokens;
/* Links should go to since "no tokens".*/
DELETE FROM Links;
/* No link requests. */
DELETE FROM LinkRequests;
/* No token requests. */
DELETE FROM TokenRequests;

DELETE FROM TokenUsage;

UPDATE NumericTokens SET Used = 0;
UPDATE EnglishWordTokens SET Used = 0;

-- Reduce size.
DELETE FROM  NumericTokens 
       WHERE NumericTokenN > 100000;

--DELETE FROM UnicodeTokens;

--DELETE FROM Numbers65535;