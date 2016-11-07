drop table booking
drop table kunde
drop table ferieuge
drop table feriebolig
drop table antalsæder
drop table destination

create table destination
(
id int identity primary key,
navn varchar(50),
skiftedag char(7) check(skiftedag in ('fredag','lørdag','søndag')),
flypris int,
)
create table antalsæder
(
destination int not null foreign key references destination,
ugenr int,
antalpladser int,
solgtepladser int,  -- redundans
primary key (destination,ugenr), 
check (solgtepladser <= antalpladser),
) 
create table feriebolig
(
id int identity primary key,
destination int not null foreign key references destination,
navn varchar(50),
beskrivelse varchar(500),
maxpersoner int,
afstandstrand int,
afstandindkoeb int
)
create table ferieuge
(
feriebolig int foreign key references feriebolig,
ugenr int,
ledig bit,
pris int,
primary key(feriebolig,ugenr)
)
create table kunde
(
kundeid int primary key identity,
navn varchar(50),
adresse varchar(100),
) 
create table booking
(
id int primary key identity,
feriebolig int not null,
ugenr int not null,
antalpersoner int not null,
kundenr int not null foreign key references kunde,
constraint ugecheck foreign key (feriebolig,ugenr) references ferieuge
)
go
insert into destination values ('Nice','fredag',3000),('Costa del Sol','lørdag',4000),('Malta','lørdag',3500)

insert into antalsæder values (1,28,10,3),(1,29,15,4),(1,30,15,0)
insert into antalsæder values (2,28,10,0),(2,29,15,4),(2,30,15,0)
insert into antalsæder values (3,28,10,0),(3,29,15,0),(3,30,15,2)

insert into feriebolig values (1,'strandkig','bla bla',5,100,500),
(1,'smugkro','bla bla',4,200,500),(1,'søblik','bla bla',3,500,1000),
(2,'søbar','bla bla',4,100,500),(2,'labyrinten','bla bla',4,100,500),
(3,'udsigten','bla bla',5,100,500),(3,'strandkig2','bla bla',2,100,500)

insert into ferieuge values (1,28,0,6000),(1,29,0,7500),(1,30,1,7500)
insert into ferieuge values (2,28,1,9000),(2,29,1,10500),(2,30,1,7500)
insert into ferieuge values (3,28,1,6000),(3,29,1,7500),(3,30,1,7500)
insert into ferieuge values (4,28,1,6000),(4,29,1,7500),(4,30,1,7500)
insert into ferieuge values (5,28,1,8000),(5,29,0,7500),(5,30,1,7500)
insert into ferieuge values (6,28,1,6000)
insert into ferieuge values (7,28,1,6000),(7,30,0,7500)

insert into kunde values('hansen','nyvej 3 Svebølle')
insert into kunde values('jensen','nyvej 5 Svebølle')
insert into kunde values('olsen','nyvej 7 Svebølle')
insert into kunde values('andersen','nyvej 9 Svebølle')

insert into booking values(1,28,3,1),(1,29,4,2),(5,29,4,1),(7,30,2,4)