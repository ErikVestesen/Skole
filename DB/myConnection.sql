drop table account;
drop table workplace;
drop table person;
drop table company;
drop table zipcode;

create table zipcode
(
zip char(4) primary key,
postaldistrict varchar(25)
);


create table person
(
cpr char(10) primary key,
name varchar(25),
job varchar(25),
salary int,
zip char(4) not null,
foreign key (zip) references zipcode(zip)
);

create table company
(
companynr int primary key,
companyname varchar(25),
zip char(4) not null,
foreign key (zip) references zipcode(zip)
);

create table workplace
(
cpr char(10),
constraint cprforeign foreign key(cpr) references person(cpr),
companynr int,
constraint companyforeign foreign key (companynr) references company(companynr),
primary key(cpr,companynr)
);

create table account
(
accountno int primary key,
belongsto char(10),
balance int
);


-- Opgave 9
create or replace trigger delaccount
AFTER DELETE
ON SYSTEM.ACCOUNT
FOR EACH ROW
declare
  exst number;
  
BEGIN
DBMS_OUTPUT.put_line('STARTED');
  
  if :OLD.balance <> 0 THEN
    DBMS_OUTPUT.PUT_LINE('FORBUDT FOR FANDEN');
    raise_application_error(-20101,'Account could not de deleted');
    rollback;
  END IF;
end;
------------------



--Opgave 13
drop table studentWithGradeList;
DROP TYPE GradeList;
CREATE TYPE GradeList IS VARRAY(5) OF INT;

create table studentWithGradeList (
studentno int,
name varchar(30),
karaktere GradeList
);

insert into studentWithGradeList values(1,'clever boy',GradeList(11,13,9,10,13));
insert into studentWithGradeList values(2,'fool',GradeList(5,3,7,6,6));

create or replace procedure findStudent(nr in int)
as
  gSum int := 0;
  gr GradeList;
  counter int;
begin
  select karaktere into gr from studentWithGradeList where studentno = nr;
  for counter in gr.first..gr.last loop
  gSum := gSum + gr(counter);
  end loop;
  dbms_output.put_line('Karaktersum for student ' || nr || ' er ' || gSum);
end;

begin
  findStudent(1);
  findStudent(2);
end;

------------------


--Opgave 15
select name 
from person
where rownum <= 3
order by salary desc;
------------------

insert into zipcode values('8000','Århus C');
insert into zipcode values('8200','Århus N');
insert into zipcode values('8210','Århus V');
insert into zipcode values('8220','Brabrand');
insert into zipcode values('8240','Risskov');
insert into zipcode values('8310','Tranbjerg J');
insert into zipcode values('8270','Højbjerg');
insert into zipcode values('8250','Egå');
insert into person values('1212121212','Ib Hansen','systemdeveloper',250000,'8000');
insert into person values('1313131313','Poul Ibsen','project manager',500000,'8310');
insert into person values('1414141414','Anna Poulsen','IT-manager',870000,'8250');
insert into person values('1515151515','Jette Olsen','systemdeveloper',200000,'8000');
insert into person values('1616161616','Roy Hurtigkoder','programmer',500000,'8210');
insert into company values(1,'Danske Data','8220');
insert into company values(2,'Kommunedata','8000');
insert into company values(3,'LEC','8240');
insert into company values(4,'Dansk Supermarked','8270');
insert into workplace values('1212121212',2);
insert into workplace values('1313131313',4);
insert into workplace values('1414141414',4);
insert into workplace values('1616161616',2);
insert into account values(1,'1212121212',1000);
insert into account values(2,'1414141414',100);
insert into account values(3,'1414141414',10000);
insert into account values(4,'1414141414',10);
insert into account values(5,'1414141414',0);

select * from zipcode;
select * from ACCOUNT;
select * from WORKPLACE;
select * from person;

delete from account where accountno = 2;
delete from account where accountno = 5;
show errors