USE FishingLog;

SET IMPLICIT_TRANSACTIONS ON;

UPDATE Accounts
  SET 
      [Name] = 'Test123'
WHERE Id = 1;

UPDATE Accounts
  SET 
      [Name] = 'Test456'
WHERE Id = 2;

ROLLBACK;



SELECT TOP (1000) [Id]
      ,[Name]
      ,[Balance]
  FROM [FishingLog].[dbo].[Accounts]