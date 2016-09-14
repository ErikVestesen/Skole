--5.2
--create view total as
--select p.cpr, navn, po.postdistrikt, firmanavn, po2.postdistrikt as firmapost
-- from person p join postnummer po on po.postnr = p.postnr
--			   join ansati  a on p.cpr = a.cpr
--			   join firma f on a.firmanr = f.firmanr
--			   join postnummer po2 on a.postnr = po2.postnr

--Select navn, firmanavn from total


-- create clustered index test on person(navn)
-- select * from person where navn like 'a%' ==> seek, !scan (CTRL + L)

-- reduction factor = hvor mange % data opfylder betingelsen
--Interessant begreb ved nonclustered index
--Bruger kun nonclustered index, hvis reduction factor < ca 1%

--6.2 Hvilke skal have index?
drop table fakturalinie
drop table faktura
drop table kunde
drop table vare
drop table varegruppe
go
create table varegruppe
(
varegruppeid int identity primary key,
varegruppenavn varchar(40)
)
create table vare
(
vareid int identity primary key,
EANnr char(13),
varenavn varchar(40),
varegruppeid int foreign key references varegruppe, 
varebeskrivelse varchar(600),
pris decimal(8,2)
)
create table kunde
(
kundeid int identity primary key,
kundetype char(3),
kundenavn varchar(60),
kundetlf char(8),
kundeadresse varchar(100),
kundepostnr char(4)
)
create table faktura
(
fakturaid int identity primary key,
kundenr int foreign key references kunde,
fakturadato date,
betalt bit
)
create table fakturalinie
(
fakturalinieid int identity primary key,
fakturanid int foreign key references faktura,
vareid int foreign key references vare,
antal int
)
-- alternativ 
create table fakturalinie2
(
fakturaid int foreign key references faktura,
vareid int foreign key references vare,
antal int, 
primary key (fakturaid,vareid)
)