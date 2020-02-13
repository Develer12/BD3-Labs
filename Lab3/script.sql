use WHiring;
exec sp_configure 'clr_enabled', 1
exec sp_configure 'clr_strict_security', 0
reconfigure

alter assembly GetCount
	from 'D:\Subject\BD3\Lab\Lab3\Lab3\bin\Debug\Lab3.dll'
	with permission_set = safe;

go
create procedure GetCountbyAge (@min int, @max int)
as external name GetCountbyAge.StoredProcedures.GetCountbyAge

declare @num int
exec @num = GetCountbyAge '20', '50'
print @num
