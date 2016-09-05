drop table customer;

create table customer (
	id int,
	name varchar(15),
	debt int,
	guarantor varchar(30),
	created date
);

insert into customer values(0,'Allan', 100, null, '1990-01-01');
insert into customer values(1,'Ballan', 110, 'Allan', '1991-01-01');
insert into customer values(2,'Callan', 120, 'Allan', '1992-01-01');
insert into customer values(3,'Dallan', 130, 'Callan', '1993-01-01');
insert into customer values(4,'John Hitler', 140, 'Callan', '1994-01-01');

-- 2.1B
delete from customer where created in (select top 20 percent created from customer order by created)
select * from customer

-- 2.1C
Select * from customer
update customer
set debt *= 1.1
output deleted.name, deleted.debt,inserted.name, inserted.debt 

-- 2.1D
  go
  with customerCTE(guarantor)
  as
  (
  select name
  from customer
  where guarantor = 'Allan'
  union all
  select c.name
  from customer as c
  join customerCTE as cc
  on c.guarantor = cc.guarantor
  )
  select guarantor from customerCTE  

 -- 2.2