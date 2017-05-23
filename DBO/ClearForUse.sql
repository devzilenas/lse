DELETE FROM LinkRequests;
DELETE FROM TokenRequests;
DELETE FROM Links;
DELETE FROM Tokens;
DELETE FROM TokenUsage;
UPDATE NumericTokens SET Used = 0