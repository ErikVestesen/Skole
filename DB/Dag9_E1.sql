use eksempeldb
set transaction isolation level read uncommitted
set transaction isolation level read committed
set transaction isolation level repeatable read 
set transaction isolation level serializable
-- the new isolation level in SQL Server 2005 
set transaction isolation level snapshot
-- with SQL Server 2005 you are able to change the way 
-- the isolation level read commtted works
-- if you run the following alter command
use big
go
alter database eksempeldb set read_committed_snapshot on
-- this will make the database use row versions instead of locks for the read committed iso level.
go
use eksempeldb

--
--this enables snapshot isolation level
use big
alter database eksempeldb set allow_snapshot_isolation on
use eksempeldb

select * from person
-- dirty read
--1
begin tran
insert into person values('19','hans kurt','systemudvikler',400000,'8210')
--3
rollback tran

-- unrepeatable read (lost update) 
-- 2
begin tran
update person set loen = loen*1.02 where cpr = '1212121212' 
commit tran

-- phantom 

-- 2
insert into person values('21','hans kurt','systemudvikler',4000000,'8210')

-- snapshot example
-- without read transaction
--1 
select loen from person where cpr='1212121212'
select loen from person where cpr='1313131313' 
--3
select loen from person where cpr='1414141414' 
select loen from person where cpr='1515151515'  
-- with read transaction
begin tran
select loen from person where cpr='1212121212'
select loen from person where cpr='1313131313' 
--3
select loen from person where cpr='1414141414' 
select loen from person where cpr='1515151515' 
commit tran

-- with snapshot isolation
--1
set transaction isolation level snapshot
begin tran
select loen from person where cpr='1212121212'
select loen from person where cpr='1313131313' 
--3
select loen from person where cpr='1414141414' 
select loen from person where cpr='1515151515' 
commit tran