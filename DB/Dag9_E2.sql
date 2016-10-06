use eksempeldb 
-- the traditonal ANSI isolation levels
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
alter database eksempeldb set read_committed_snapshot off
-- this will make the database use row versions instead of locks 
use eksempeldb

--this enables snapshot isolation level
alter database eksempeldb set allow_snapshot_isolation on

-- dirty read
-- 2
select * from person

-- unrepeatable read (lost update i dette tilfælde) 
-- 1
begin tran 
select loen from person where cpr = '1212121212'
-- wants to give him a raise in salary on 10000
-- 3
update person set loen = 260000 where cpr = '1212121212'     
commit tran
select * from person where cpr = '1212121212'

-- phantom
--1
begin tran
select stilling,sum(loen) from person group by stilling
-- 3
select postnr,sum(loen) from person group by postnr
commit tran

-- example for snapshot isolation
-- good for read-write conflicts 
-- (conflicts between a transaction, which only reads
-- and a transaction, which makes insert, update or delete)

--2
begin tran
update person set loen = loen - 50000 
where cpr = '1212121212'
update person set loen = loen + 50000 
where cpr = '1414141414'
commit tran  

select * from person

set transaction isolation level snapshot