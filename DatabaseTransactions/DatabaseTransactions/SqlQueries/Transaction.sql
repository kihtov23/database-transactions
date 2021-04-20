USE [FishingLog]
GO


Begin transaction test1;

update Accounts set [Name] = 'Ivan123' where Id = 2;
Select * from Accounts 
--update Accounts set [Name] = 'Ivan' where Id = 3;

rollback transaction test1;


--update Accounts set [Name] = 'Ivan123' where Id = 2;