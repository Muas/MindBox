-- Не совсем очевидна структура таблицы. Можно предположить, что все записи для одного покупателя в одно время - это один заказ. 
-- Но в этом случае можно получить расхождения во времени из-за реализации записи в таблице 
-- (неизвестно исходя из чего запиывается время в каждом продукте и нет гарантии, что оно одновременно проставилось) 
-- и часть заказа может не попасть в выборку.
-- Либо Id - не PK, а FK на сам заказ. И тогда для заказа поле Id будет иметь одно и то же значение.
-- Запрос построен исходя из того, что для одного заказа дата одна и та же
 
select ProductId, Count(*) as Count from
(
	select 
		ProductId
		, DateCreated
		, (select top 1 DateCreated from Sales ss where ss.CustomerId = Sales.CustomerId order by DateCreated) as FirstOrderDate 
	from 
	Sales
) s
where 
	s.FirstOrderDate = s.DateCreated
group by
	ProductId