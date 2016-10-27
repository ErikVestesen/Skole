drop table t1;
drop table t2;
drop view t1view;


create table t1(
salary int
);

create table t2(
test varchar(15)
);

go
create view t1view 
as
SELECT *
FROM t1
WHERE salary < 500000
go


GRANT SELECT,INSERT, UPDATE, DELETE ON t1 to superuser
GRANT SELECT,INSERT, UPDATE, DELETE ON t2 to superuser
REVOKE DELETE ON t2 to superuser

GRANT SELECT ON t2 to normaluser
GRANT SELECT ON t1view to normaluser 

