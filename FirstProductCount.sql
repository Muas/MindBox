select ProductId, Count(*) from
(
select 
	ProductId, 
	(select top 1 ProductId from Sales ss where ss.CustomerId = Sales.CustomerId order by DateCreated) as FirstProductId 
from 
	Sales
) s
where s.FirstProductId = s.ProductId
group by
	ProductId