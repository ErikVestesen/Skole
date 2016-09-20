-- the following script is made to show, how history can be implemented
-- error-handling is NOT implemented

-- no history
create table item
(
itemno int identity(1,1) primary key,
itemname varchar(25),
price decimal(7,2)
)
drop table histprice
drop table item

-- with history
create table item
(
itemno int identity(1,1) primary key,
itemname varchar(25)
)
create table histprice
(
itemno int foreign key references item,
price decimal(7,2),
fromdate datetime,
--todate datetime
)
insert into item values
	('pommes frites'),
	('chickens')
insert into histprice values
     (1,'13.50','2016-01-01','2016-01-10'),
     (1,'16.50','2016-01-10',null)
insert into histprice values
     (2,'35.00','2016-01-01','2016-02-01'),
     (2,'40.00','2016-02-01',null)
--    
select itemno,price,fromdate,todate from histprice  


-- find the price for all items on a given date using a stored procedure
drop proc spfindprice
go
create proc spfindprice
@day datetime
as
	select itemname,price
	from item i,histprice h
	where i.itemno = h.itemno and fromdate in
	(select max(fromdate) from histprice where fromdate <= @day and i.itemno = itemno)
go
exec spfindprice '2016-01-19'
go
-- find the price for one item on a given day using a function
drop function fufindprice
go
create function fufindprice (@day datetime,@itemno int)
returns decimal(7,2)
as
BEGIN
return (select price
from histprice 
where itemno = @itemno and
(fromdate <= @day))
END     
go
select dbo.fufindprice('2016.01.26',2)
drop proc spupdateprice
go    
create proc spupdateprice
-- assumes itemno already exists 
@itemno int,
@newprice decimal(7,2),
@fromdate datetime
as
update histprice set fromdate = @fromdate where itemno =@itemno and @fromdate > fromdate
insert into histprice values(@itemno,@newprice,@fromdate)
go
exec spupdateprice 1,'32.00','2016.2.29'


select dbo.fufindprice('2016.02.29',1)