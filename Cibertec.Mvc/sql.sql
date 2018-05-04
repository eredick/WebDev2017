
create proc CustomerPagedList
	@startRow int,
	@endRow int
as
begin
	with CustomerResult as
	(
		select CustomerID, CompanyName, ContactName, City, Country, Phone, ROW_NUMBER() over (order by customerid) as RowNum
		from Customers
	)

	select CustomerID, CompanyName, ContactName, City, Country, Phone, RowNum
	from CustomerResult
	where RowNum between @startRow and @endRow
end