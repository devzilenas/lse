
--Generate numeric tokens.

DECLARE @first AS INT
SET @first = 10001
DECLARE @step AS INT
SET @step = 1
DECLARE @last AS INT
SET @last = 99999

BEGIN TRANSACTION
WHILE(@first <= @last) BEGIN INSERT INTO NumericTokens(NumericTokenN) VALUES(@first) SET @first += @step END COMMIT TRANSACTION