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
declare @res char(15)
declare @gradeSum int
set @gradeSum = 0.0
declare @lowestFirst int
declare @lowesttwo int
set @lowestFirst = 13
set @lowesttwo = 13
declare p cursor
for select grade from grades where studentno = @studentno
declare @grade int
open p 
fetch p into @grade
while @@FETCH_STATUS != -1
	begin
		if(@grade < @lowestFirst)
		set @lowestFirst = @grade
		else if(@grade < @lowesttwo AND @lowestFirst <= @lowesttwo)
		set @lowesttwo = @grade

		set @gradeSum = @gradeSum + @grade
		fetch p into @grade
	end
close p
deallocate p
if((@gradeSum*1.0)/5 > 5.5 and (@lowestFirst+@lowesttwo+(((@gradeSum*1.0-@lowesttwo-@lowestFirst)*1.0) / 3.0)) >= 13)
set @res = 'passed'
else 
set @res = 'failed'
RETURN @res    
END 
go
select name,dbo.passedCheck(studentno)
from student  

--Actual avg
Select avg(grade*1.0) Gennemsnit,name from student s join grades g on g.studentno = s.studentno group by name
