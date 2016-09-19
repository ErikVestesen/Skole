drop table sale
drop table invoice
drop table customer
drop table product
drop table supplier
drop table country
go
create table country
(
countryid int identity primary key,
countryname varchar(50) not null
)
create table supplier
(
supplierid int identity primary key,
suppliername varchar(50) not null,
countryid int foreign key references country(countryid),
)

create table product
(
productid int identity primary key,
productname varchar(25) not null,
supplierid int foreign key references supplier(supplierid) not null
)

create table customer
(
customerid int identity primary key,
custname varchar(25) not null,
)
create table invoice
(
invoiceid int identity primary key,
customerid int foreign key references customer(customerid) not null,
)
create table sale
(
productid int foreign key references product(productid),
invoiceid int foreign key references invoice(invoiceid),
primary key(productid,invoiceid)

)
insert into country values('Danmark')
insert into country values('Panama')
insert into country values('Italien')
insert into supplier values('B&O',1)
insert into supplier values('Tax Cheating',2)
insert into supplier values('very dirty',NULL)
insert into supplier values('Italian food service',3)
insert into supplier values('Spaghetti A/S',3)
insert into product values('pommes frites',1)
insert into product values('sugar',2)
insert into product values('milk',2)
insert into product values('lasagne',5)
insert into customer values('Hans Hansen')
insert into customer values('Ib Ibsen')
insert into customer values('Per Persen')
insert into customer values('Mikkel Mikkelsen')
insert into customer values('Bent Bentsen')
insert into invoice values(1),(1),(2),(3),(4),(4)
insert into sale values(1,2)
insert into sale values(2,3)
insert into sale values(2,4)
insert into sale values(3,2)
insert into sale values(3,3)
insert into sale values(3,4)
insert into sale values(4,4)
insert into sale values(4,3)
insert into sale values(4,1)

 