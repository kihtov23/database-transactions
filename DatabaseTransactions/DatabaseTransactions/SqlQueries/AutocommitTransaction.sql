Use FishingLog
Select @@version
set implicit_transactions off

select * from Accounts

update Accounts set [Name] = 'Test1234'
where Id = 1

select * from Accounts

update Accounts set [Name] = 'Test12345'
where Id = 2

select * from Accounts

rollback 

select * from Accounts