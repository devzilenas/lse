
--Generate numeric tokens.

DECLARE @first AS INT
SET @first = 100000
DECLARE @step AS INT
SET @step = 1
DECLARE @last AS INT
SET @last = 999999

BEGIN TRANSACTION
WHILE(@first <= @last) BEGIN INSERT INTO NumericTokens(NumericTokenN) VALUES(@first) SET @first += @step END COMMIT TRANSACTION