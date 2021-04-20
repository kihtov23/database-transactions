USE FishingLog;

SET IMPLICIT_TRANSACTIONS ON;

UPDATE Accounts
  SET 
      [Name] = 'qwerty'
WHERE Id = 1;

UPDATE Accounts
  SET 
      [Name] = '54321'
WHERE Id = 2;

ROLLBACK;