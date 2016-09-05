drop table student
drop table grades

create table student
(
studentno int,
name varchar(30)
)
create table grades
(
studentno int,
grade int
)
insert into student values (1,'clever boy')
insert into student values (2,'fool')
insert into student values (3,'just over the limit boy')
insert into student values (4,'fool too')
--
insert into grades values (1,11)
insert into grades values (1,13)
insert into grades values (1,9)
insert into grades values (1,10)
insert into grades values (1,13)
insert into grades values (2,5)
insert into grades values (2,3)
insert into grades values (2,7)
insert into grades values (2,6)
insert into grades values (2,6)
insert into grades values (3,5)
insert into grades values (3,3)
insert into grades values (3,7)
insert into grades values (3,7)
insert into grades values (3,6)
insert into grades values (4,3)
insert into grades values (4,0)
insert into grades values (4,10)
insert into grades values (4,9)
insert into grades values (4,10)

go
drop function passedCheck
go

create function passedCheck (@studentno int)
returns Char(15)
as
BEGIN
	declare @avg decimal
	set @avg = (select AVG(grade * 1.0) from grades where studentno = @studentno)
	declare @twoLowSum decimal
	set @twoLowSum = (
			select SUM(grade) 
			from (
				select top 2 grade from grades where studentno = @studentno order by grade
			) as something
	)
	declare @res char(15)
	set @res = 'Passed'

	if @avg < 5.5
		set @res = 'Failed'

	if @res = 'Passed'
	begin
		if @avg + @twoLowSum < 13
			set @res = 'Failed'
	end

	RETURN @res    
END

go
select name Navn,dbo.passedCheck(studentno) Resultat
from student


--Opgave 1.8
--Exercise 1.8	

--Laver temp table
CREATE TABLE #Temp (
tableName varchar(255),
nrOfRecords int)
--cursor
declare t cursor
for select name from (select name from sysobjects where type = 'u' and category = 0) as myTables
declare @name varchar(255)
open t
fetch t into @name
while @@fetch_status != -1
begin
	if @name not like '%Temp%'
	begin
		execute ('
			declare @count int
			select @count = (select COUNT(*) FROM ' + @name + ')
			insert into #Temp values('''+@name+''', @count)
		')
	end

	fetch t into @name
end
close t
deallocate t
--selecter mit temp table med dataene
select * from #Temp
--sletter temp table
drop table #Temp
--slut