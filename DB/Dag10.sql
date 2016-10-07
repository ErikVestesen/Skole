drop table ansati
drop table person
drop table firma
drop table postnummer

go

create table postnummer
(
postnr char(4),
postdistrikt varchar(25)
)


create table person
(
cpr char(10),
navn varchar(25),
stilling varchar(25),
loen int not null check(loen > 0),
postnr char(4) not null
)

create table firma
(
firmanr int,
firmanavn varchar(25),
postnr char(4) not null,
)

create table ansati
(
cpr char(10),
firmanr int
)


go

insert into postnummer values('8000','Århus C')
insert into postnummer values('8200','Århus N')
insert into postnummer values('8210','Århus V')
insert into postnummer values('8220','Brabrand')
insert into postnummer values('8240','Risskov')
insert into postnummer values('8310','Tranbjerg J')
insert into postnummer values('8270','Højbjerg')
insert into postnummer values('8250','Egå')
insert into person values('1212121212','Ib Hansen','systemudvikler',250000,'8000')
insert into person values('1313131313','Poul Ibsen','projektleder',500000,'8310')
insert into person values('1414141414','Anna Poulsen','IT-chef',870000,'8250')
insert into person values('1515151515','Jette Olsen','systemudvikler',200000,'8000')
insert into person values('1616161616','Roy Hurtigkoder','programmør',500000,'8210')
insert into firma values(1,'Danske Data','8220')
insert into firma values(2,'Kommunedata','8000')
insert into firma values(3,'LEC','8240')
insert into firma values(4,'Dansk Supermarked','8270')
insert into ansati values('1212121212',2)
insert into ansati values('1313131313',4)
insert into ansati values('1414141414',4)
insert into ansati values('1616161616',2)


Select * from person where cpr = '1212121212'