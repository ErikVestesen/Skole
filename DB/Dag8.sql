--use tempdb
--exec sp_addtype cprtype,'char(10)'
--go
--create table testperson
--(
--cpr cprtype,
--name varchar(25)
--)
--drop rule cprrule
--go
--create rule cprrule
--as isdate(substring(@x,5,2)+substring(@x,3,2)+substring(@x,1,2))=1 AND
--(substring(@x,1,1)*4 +
--substring(@x,2,1)*3 +
--substring(@x,3,1)*2 +
--substring(@x,4,1)*7 +
--substring(@x,5,1)*6 +
--substring(@x,6,1)*5 +
--substring(@x,7,1)*4 +
--substring(@x,8,1)*3 +
--substring(@x,9,1)*2 +
--substring(@x,10,1)*1)%11 = 0
--go

--sp_bindrule cprrule,'testperson.cpr'

-- 2 4 1 2 0 0 3 3 3 3
-- 4 3 2 7 6 5 4 3 2 1

-- legit cpr nr ^  

sp_bindrule cprrule,cprtype
insert into testperson values('2212603611 ','OK') -- OK with date and modulus 11
insert into testperson values('1002893211','OK too') -- OK with date and modulus 11
insert into testperson values('1002895211','not OK') -- OK date wrong modulus 11
insert into testperson values('3002893217','wrong date') -- wrong date
go
sp_unbindrule cprtype 
go