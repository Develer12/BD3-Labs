go
use WHiring;

create table MAP
(
	Id int identity(1,1) constraint TOWN_ID_PK PRIMARY KEY,
	Point geometry
);

insert into MAP(Point) 
	values (geometry::STGeomFromText('Point(1 1)', 0)),
			(geometry::STGeomFromText('Point(10 21)', 0));

go
alter table VACANCY
	add Office_Addr int constraint VOFFICE_ID_FK foreign key references MAP(Id);

go
alter table CANDIDATE
	add Place int constraint COFFICE_ID_FK foreign key references MAP(Id);

go
alter table WORKER
	add Place int constraint WOFFICE_ID_FK foreign key references MAP(Id);
