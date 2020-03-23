go
use WHiring
go


--TASK1
create table Report (
id INTEGER primary key identity(1,1),
xml_column XML
);

--TASK2	
go
create procedure generateXML
as
declare @x XML
set @x = (Select vac.Id [Id], Company [Company], can.Position [Position],
				FName[FName], SName[LName], Age, Sex, Salary,GETDATE() [Date] 
from VACANCY vac join CANDIDATE can on vac.Id = can.Job
FOR XML AUTO);
SELECT @x
go

execute generateXML;

--TASK3
go
create procedure InsertInReport
as
DECLARE  @s XML  
SET @s = (Select vac.Id [Id], Company [Company], can.Position [Position],
				FName[FName], SName[LName], Age, Sex, Salary,GETDATE() [Date] 
from VACANCY vac join CANDIDATE can on vac.Id = can.Job
for xml raw);
insert into Report values(@s);
go
  
  execute InsertInReport
  select * from Report;

--task4
create primary xml index My_XML_Index on Report(xml_column)

create xml index Second_XML_Index on Report(xml_column)
using xml index My_XML_Index for path

--task5
go
create procedure SelectData
as
select xml_column.query('/row') as[xml_column] from Report for xml auto, type;
go

execute SelectData

select xml_column.value('(/row/@Date)[1]', 'nvarchar(max)') as[xml_column] from Report for xml auto, type;

select r.Id,
	m.c.value('@Date', 'nvarchar(max)') as [date]
from Report as r
	outer apply r.xml_column.nodes('/row') as m(c)

select xml_column.query('/row') as [xml_column] from Report for xml auto, type;
