drop table item
drop table itemnew
drop table histprice

-- old no history table
create table item
(
itemno int identity(1,1) primary key,
itemname varchar(25),
price decimal(7,2)
)
insert into item values('pommes frites',17),('small burger',25),('checken nuggets',28),('hot wings',27)

--
--
-- new system with history
create table itemnew
(
itemno int identity(1,1) primary key,
itemname varchar(25)
)
create table histprice
(
itemno int foreign key references itemnew,
price decimal(7,2),
fromdate datetime,
todate datetime
)
--
--
-- queries used by the old system
select price from item where itemno = 2
insert into item(itemname,price) values ('big burger',45)
update item set price = 50 where itemno = 4
delete from item where itemno = 3  

---
set identity_insert itemnew on
insert into itemnew (itemno, itemname) select itemno, itemname from item
set identity_insert itemnew off
insert into histprice (itemno, price) select itemno, price from item 
delete from item



---- TRIGGERS
--drop trigger itemDelete
--drop trigger itemInsert
--go
--create trigger itemDelete
--on item
--instead of delete
--as
--  delete from itemnew where itemno in (select itemno from deleted)
--  delete from histprice where itemno in (select itemno from deleted)
--go
--create trigger itemInsert
--on item
--instead of insert
--as
--  insert into itemnew(itemno, itemname) select itemno,itemname from inserted
--  insert into histprice(itemno, price) select itemno,price from inserted
--go
