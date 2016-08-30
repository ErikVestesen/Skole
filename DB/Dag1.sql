drop table ansati
drop table person
drop table firma
drop table postnummer

go

create table postnummer
(
postnr char(4) primary key,
postdistrikt varchar(25)
)


create table person
(
cpr char(10) primary key,
navn varchar(25),
stilling varchar(25),
loen int not null check(loen > 0),
postnr char(4) foreign key references postnummer(postnr) not null
)

create table firma
(
firmanr int primary key,
firmanavn varchar(25),
postnr char(4) not null,
foreign key (postnr) references postnummer(postnr) 
)

create table ansati
(
cpr char(10) constraint cprforeign foreign key references person(cpr),
firmanr int constraint firmaforeign foreign key references firma(firmanr)
primary key(cpr,firmanr)
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

--------------------------------------------------------------------------------------------------------------------
---Kør som BATCH
--Opgave 1.4
--Opgave 1.4a
SELECT MAX(loen) FROM person;
--Opgave 1.4b
SELECT MIN(loen) FROM (SELECT TOP 2 loen FROM person GROUP BY loen ORDER BY loen DESC) as loen
--Opgave 1.4c
SELECT MIN(loen) FROM (SELECT TOP 3 loen FROM person GROUP BY loen ORDER BY loen DESC) as loen

--Could have done
declare @maxInt;
declare @name;
select top 3 @maxint = loen, @name = navn
from person order by loen desc

--Opgave 1.5
--create table  tbl_person (
--name varchar(25),
--age int
--);

--insert into tbl_person values ('Hans', 15)
--insert into tbl_person values ('Karl', 20)
--insert into tbl_person values ('Svend', 10)
--insert into tbl_person values ('Knud', 25)
--insert into tbl_person values ('Per', 11)
--insert into tbl_person values ('Per', 9)
--insert into tbl_person values ('Per', 31)
--insert into tbl_person values ('Per', 1)

SELECT CASE 
         WHEN age < 10 THEN '0-9' 
         WHEN age < 20 THEN '10-19' 
		 WHEN age < 30 THEN '20-29' 
		 WHEN age < 40 THEN '30-39' 
		 WHEN age < 50 THEN '40-49' 
         ELSE '50+' 
       END AS age, 
       COUNT(*) AS 'no. of persons'
FROM tbl_person
GROUP BY 
	   CASE 
         WHEN age < 10 THEN '0-9' 
         WHEN age < 20 THEN '10-19' 
		 WHEN age < 30 THEN '20-29' 
		 WHEN age < 40 THEN '30-39' 
		 WHEN age < 50 THEN '40-49' 
         ELSE '50+' 
       END

--Use while




