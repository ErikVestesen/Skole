
-- security

-- create new SQL Server logins
use master
exec sp_addlogin 'programmer','1234'
exec sp_addlogin 'normaluser','1234'
exec sp_addlogin 'superuser','1234'
-- exec sp_droplogin 'dan'

-- give the login access to a database (here the bigdb db)
use SecTest
exec sp_grantdbaccess 'programmer'
exec sp_grantdbaccess 'normaluser'
exec sp_grantdbaccess 'superuser'

-- make new userdefined roles
exec sp_addrole 'normalusers'
exec sp_addrole 'programmers'
-- exec sp_droprole 'developers'

---------------------------
--ddl = create/drop objects
--security = Må give adgang til andre
--datawrite og dataread
---------------------------

-- add members to the roles
--exec sp_addrolemember 'role','person'
exec sp_addrolemember 'normalusers','normaluser'
exec sp_addrolemember 'programmers','programmer'

-- add users or roles to fixed roles
--exec sp_addrolemember 'fixed roles','role'
exec sp_addrolemember 'db_datareader','programmers'
exec sp_addrolemember 'db_securityadmin','programmers'
exec sp_addrolemember 'db_ddladmin','programmers'
exec sp_addrolemember 'db_datawriter','programmers'

-- statement permission
grant create view,create table to killerdan
grant create procedure to developers

-- remove permissions again
revoke create view from killerdan  

-- objects permission
grant select,insert on big to [susan]
revoke insert on big from [susan] 
deny delete on big to [susan]

-- Schema example
use bigdb
go
create schema myschema
go
alter user peter with default_schema = myschema  -- table creator
go
exec sp_addrolemember 'db_datareader','killerdan'
go
alter user killerdan with default_schema = myschema  -- ordinary user