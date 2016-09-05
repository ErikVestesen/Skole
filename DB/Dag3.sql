drop table customer;

create table customer (
	id int,
	name varchar(15),
	debt int,
	guarantor sysname,
	created date
);

insert into customer values(0,'Allan', 100, null, '1990-01-01');
insert into customer values(1,'Ballan', 100, null, '1990-01-01');
insert into customer values(2,'Callan', 100, null, '1990-01-01');
insert into customer values(3,'Dallan', 100, null, '1990-01-01');
insert into customer values(4,'John Hitler', 100, null, '1990-01-01');

-- 2.1B
--delete from customer where created in (select top 20 percent created from customer order by created)
-- 2.1C
--update customer c
--set c.debt *= 1.1
--output 
-- 2.1D
