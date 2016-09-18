drop table matches
drop table teams


go
create table teams
(
Id char(3) primary key,
name varchar(40),
nomatches int,
owngoals int,
othergoals int,
points int
)
create table matches
(
id int identity(1,1),
homeid char(3) foreign key references teams(id),
outid char(3) foreign key references teams(id),
homegoal int,
outgoal int,
matchdate date
)
go
insert into teams values('agf','AGF',0,0,0,0)
insert into teams values('vib','Viborg',0,0,0,0)
insert into teams values('fck','FC København',0,0,0,0)
insert into teams values('rfc','Randers FC',0,0,0,0)
insert into teams values('hac','Horsens',0,0,0,0)
insert into teams values('søn','SønderjyskE',0,0,0,0)
insert into teams values('ob','OB',0,0,0,0)
insert into teams values('fcm','FC Midtjylland',0,0,0,0)
insert into teams values('efb','Esbjerg fB',0,0,0,0)
insert into teams values('bif','Brøndby IF',0,0,0,0)
insert into teams values('fcn','FC Nordsjælland',0,0,0,0)
insert into teams values('aab','AaB',0,0,0,0)
insert into teams values('lyn','Lyngby',0,0,0,0)
insert into teams values('sil','Silkeborg',0,0,0,0)
go
-- Her indsættes trigger/triggere 
--Exercise A trigger
create trigger aTrigger
on matches 
for insert, update
as 
declare @homegoal int = (select homegoal from inserted)
declare @outgoal int = (select outgoal from inserted)
declare @homeid char(3) = (select homeid from inserted)
declare @outid char(3) = (select outid from inserted)

	if(@homegoal > @outgoal)
		update teams set points += 3 where Id = @homeid
	if (@homegoal < @outgoal) 
		update teams set points += 3 where Id = @outid
	if(@homegoal = @outgoal)
		begin
		update teams set points += 1 where Id = @homeid
		update teams set points += 1 where Id = @outid
		end
	update teams set nomatches += 1, owngoals += @homegoal, othergoals += @outgoal  where Id = @homeid
	update teams set nomatches += 1, owngoals += @outgoal, othergoals += @homegoal  where Id = @outid
		
go

--Exercise B trigger
create trigger bTrigger
on matches 
for delete, update
as 
declare @homegoal int = (select homegoal from deleted)
declare @outgoal int = (select outgoal from deleted)
declare @homeid char(3) = (select homeid from deleted)
declare @outid char(3) = (select outid from deleted)

	if(@homegoal > @outgoal)
		update teams set points -= 3 where Id = @homeid
	if (@homegoal < @outgoal) 
		update teams set points -= 3 where Id = @outid
	if(@homegoal = @outgoal)
		begin
		update teams set points -= 1 where Id = @homeid
		update teams set points -= 1 where Id = @outid
		end
	update teams set nomatches -= 1, owngoals -= @homegoal, othergoals -= @outgoal  where Id = @homeid
	update teams set nomatches -= 1, owngoals -= @outgoal, othergoals -= @homegoal  where Id = @outid
		
go     


go
insert into matches values('vib','fcn',0,4,'2016-07-15')
insert into matches values('ob','sil',0,0,'2016-07-15')
insert into matches values('fck','lyn',3,0,'2016-07-16')
insert into matches values('søn','agf',1,2,'2016-07-17')
insert into matches values('aab','hac',1,1,'2016-07-17')
insert into matches values('bif','efb',4,0,'2016-07-17')
insert into matches values('fcm','rfc',2,2,'2016-07-18')
--
insert into matches values('agf','vib',2,1,'2016-07-22')
insert into matches values('efb','fck',0,4,'2016-07-23')
insert into matches values('hac','søn',1,1,'2016-07-24')
insert into matches values('lyn','ob',2,2,'2016-07-24')
insert into matches values('sil','bif',0,2,'2016-07-24')
insert into matches values('fcn','fcm',0,4,'2016-07-24')
insert into matches values('rfc','aab',0,1,'2016-07-24')
--
insert into matches values('vib','efb',2,1,'2016-07-29')
insert into matches values('fck','fcn',4,0,'2016-07-30')
insert into matches values('søn','lyn',0,1,'2016-07-31')
insert into matches values('fcm','sil',3,0,'2016-07-31')
insert into matches values('bif','hac',2,2,'2016-07-31')
insert into matches values('agf','rfc',1,2,'2016-07-31')
insert into matches values('aab','ob',2,2,'2016-08-01')
--
insert into matches values('rfc','hac',1,0,'2016-08-05')
insert into matches values('sil','lyn',0,4,'2016-08-05')
insert into matches values('ob','vib',0,0,'2016-08-06')
insert into matches values('fcn','aab',1,2,'2016-08-07')
insert into matches values('søn','fck',1,1,'2016-08-07')
insert into matches values('fcm','bif',3,3,'2016-08-07')
insert into matches values('efb','agf',2,2,'2016-08-08')
--
insert into matches values('vib','rfc',0,1,'2016-08-12')
insert into matches values('lyn','agf',0,0,'2016-08-12')
insert into matches values('hac','sil',3,3,'2016-08-13')
insert into matches values('fck','fcm',3,1,'2016-08-13')
insert into matches values('ob','fcn',3,1,'2016-08-14')
insert into matches values('bif','søn',4,0,'2016-08-14')
insert into matches values('aab','efb',2,1,'2016-08-15')
----
insert into matches values('fcn','rfc',1,1,'2016-08-19')
insert into matches values('hac','lyn',2,1,'2016-08-19')
insert into matches values('fck','aab',1,1,'2016-08-20')
insert into matches values('sil','vib',1,5,'2016-08-21')
insert into matches values('agf','bif',0,7,'2016-08-21')
insert into matches values('fcm','søn',2,2,'2016-08-21')
insert into matches values('efb','ob',3,2,'2016-08-22')
--
insert into matches values('rfc','sil',1,0,'2016-08-26')
insert into matches values('lyn','fcn',0,1,'2016-08-26')
insert into matches values('søn','efb',1,1,'2016-08-28')
insert into matches values('ob','hac',0,1,'2016-08-28')
insert into matches values('bif','fck',1,1,'2016-08-28')
insert into matches values('aab','agf',2,1,'2016-08-28')
insert into matches values('vib','fcm',0,0,'2016-08-28')
--
--Exercise A Results
select name Hold, nomatches Kampe, owngoals Mål, othergoals 'Mål scoret på dem', points Point from teams order by points desc

--Exercise C
go
Create Procedure SP_OpgaveC(@dato date)
As
Begin
Select * FROM matches WHERE matchdate = @dato
End

declare @d date;
set @d = '2015-08-08'
execute SP_OpgaveC @d
--Exercise D
