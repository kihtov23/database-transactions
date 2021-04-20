USE FishingLog;

SET IMPLICIT_TRANSACTIONS OFF;

UPDATE Accounts
  SET 
      [Name] = 'Test1234'
WHERE Id = 1;

UPDATE Accounts
  SET 
      [Name] = 'Test12345'
WHERE Id = 2;

ROLLBACK;