--1
create table fun (
dato datetime,
id int
);

--2
Backup database Dag13 to mindbdevice 


--3
insert into fun values (GETDATE(),1);
insert into fun values (GETDATE(),2);
insert into fun values (GETDATE(),3);
insert into fun values (GETDATE(),4);
insert into fun values (GETDATE(),5);
Backup database Dag13 to mindbdevice with differential

--4
insert into fun values (GETDATE(),6);
insert into fun values (GETDATE(),7);


insert into fun values (GETDATE(),8);
insert into fun values (GETDATE(),9);

--5
begin tran tran1 with mark 'Meaningless'
	insert into fun values (GETDATE(),10);
commit tran tran1

--6
insert into fun values (GETDATE(),11);
insert into fun values (GETDATE(),12);

--7
backup log Dag13 to minlogdevice

--8
delete from fun

--9 
use master
RESTORE DATABASE Dag13 FROM mindbdevice WITH FILE = 1, NORECOVERY, REPLACE

--10
use master
RESTORE DATABASE Dag13 FROM mindbdevice WITH FILE = 2, NORECOVERY

--11
use master
RESTORE LOG Dag13 FROM minlogdevice WITH FILE = 1, RECOVERY, STOPAT = '2016-10-25 09:08'
use Dag13
select * from fun

--12 
use Dag13
select * from fun

---13 (stopatmark for tran)
--13.8
delete from fun
--13.9
RESTORE DATABASE Dag13 FROM mindbdevice WITH FILE = 1, NORECOVERY, REPLACE
RESTORE LOG Dag13 FROM minlogdevice WITH FILE = 1, RECOVERY, STOPATMARK = 'Meaningless'
--13.10
RESTORE DATABASE Dag13 FROM mindbdevice WITH FILE = 1, NORECOVERY, REPLACE 
RESTORE DATABASE Dag13 FROM mindbdevice WITH FILE = 2, NORECOVERY
RESTORE LOG Dag13 FROM minlogdevice WITH FILE = 1, RECOVERY, STOPATMARK = 'Meaningless'

select * from fun


/*

RESTORE DATABASE Dag13 FROM mindbdevice WITH FILE = 1, NORECOVERY, REPLACE
RESTORE DATABASE Dag13 FROM mindbdevice WITH FILE = 2, NORECOVERY
RESTORE LOG Dag13 FROM minlogdevice WITH FILE = 1, RECOVERY

*/