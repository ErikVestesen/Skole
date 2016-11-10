---Opgave 1



--Opgave 2
--Giv alle de destinationer og uger hvor mindst x% af boliger er udlejet og x% af flysæder er optaget
Drop procedure KravD1
go
CREATE PROCEDURE KravD1
@x int
as
select d.navn, fu.ugenr, sum(case ledig when 1 then 0 when 0 then 1 end)*100/count(fu.ledig) as ProcentBooked, (aa.solgtepladser*100 / aa.antalpladser) as ledigeFlyPladserProcent into NyTabel
from ferieuge fu
	join feriebolig fb on fb.id = fu.feriebolig
	join destination d on d.id = fb.destination
	join antalSæder aa on aa.destination = d.id and aa.ugenr = fu.ugenr
group by fu.ugenr, d.navn, aa.solgtepladser, aa.antalpladser

select * from NyTabel where ProcentBooked >= @x OR ledigeFlyPladserProcent >= @x
drop table NyTabel

go

exec KravD1 0;


---Opgave 3
Drop procedure KravD2
go
Create procedure KravD2
as
select fb.navn, sum(case ledig when 1 then 800 when 0 then fu.pris*0.6 end) as penge
from feriebolig fb, ferieuge fu
where  fb.id = fu.feriebolig
group by fb.navn
go
exec KravD2


---Opgave 4
--Opgave 4.1
--View der returnerer meget data, og hvis en bolig ikke er udlejet, så skal den stå som værende ledig og antal personer = 0
drop view KravD3
go
create view KravD3
as
select d.navn as destination,d.id as did,fb.id as id,fb.navn, fu.ugenr as ugenr, (case ledig when 1 then 'LEDIG' when 0 then k.navn end) as navnet, (case ledig when 1 then 0 when 0 then b.antalpersoner end) as antalpersoner
from feriebolig fb
	 join destination d on d.id = fb.destination
	 join ferieuge fu on fu.feriebolig = fb.id
	 left join booking b on b.feriebolig = fb.id  and b.ugenr = fu.ugenr
	 left join kunde k on k.kundeid = b.kundenr
go

select * from KravD3

--Opgave 4.2
--Update instead of trigger på kravd3
drop trigger changePersons
go
create trigger changePersons
on KravD3
instead of update
as 
begin
	UPDATE booking
	SET antalpersoner = INSERTED.antalpersoner
	FROM INSERTED,feriebolig fb
	WHERE INSERTED.antalpersoner <= booking.antalpersoner AND INSERTED.ugenr = booking.ugenr AND INSERTED.id = fb.id

	update antalsæder
	set solgtepladser -= inserted.antalpersoner
	from inserted
	where inserted.antalpersoner <= antalsæder.solgtepladser AND inserted.ugenr = antalsæder.ugenr and inserted.did = antalsæder.destination
end
