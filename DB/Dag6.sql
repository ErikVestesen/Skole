
create view total as
select p.cpr, navn, po.postdistrikt, firmanavn, po2.postdistrikt as firmapost
 from person p join postnummer po on po.postnr = p.postnr
			   join ansati  a on p.cpr = a.cpr
			   join firma f on a.firmanr = f.firmanr
			   join postnummer po2 on a.postnr = po2.postnr

Select navn, firmanavn from total


-- create clustered index test on person(navn)
-- select * from person where navn like 'a%' ==> seek, !scan (CTRL + L)

-- reduction factor = hvor mange % data opfylder betingelsen
--Interessant begreb ved nonclustered index
--Bruger kun nonclustered index, hvis reduction factor < ca 1%