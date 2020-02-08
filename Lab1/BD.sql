go
create database WHiring;

go
use WHiring;

create table VACANCY
(
	Id int identity(1,1) constraint VACANCY_ID_PK PRIMARY KEY,
	Company nvarchar(50),
	Position nvarchar(50),
	Level nvarchar(15),
    Exp int check(Exp >= 0 and Exp <= 116),
	MinSalary int,
	MaxSalary int,
)

create table WORKER
(
	Id int identity(1,1) constraint WORKER_ID_PK PRIMARY KEY,
	FName nvarchar(50),
	SName nvarchar(50),
	Position nvarchar(50),
	Level nvarchar(15),
	Sex nchar(1) check(Sex = 'M' or Sex = 'F'), 
    Age int check(Age >= 14 and Age <= 120),
    Exp int check(Exp >= 0 and Exp <= 116),
	Salary int,
    Job int constraint JOB_ID_FK foreign key references VACANCY(Id)
)

create table CANDIDATE
(
	Id int identity(1,1) constraint CANDIDATE_ID_PK PRIMARY KEY,
	FName nvarchar(50),
	SName nvarchar(50),
	Position nvarchar(50),
	Level nvarchar(15),
	Sex nchar(1) check(Sex = 'M' or Sex = 'F'), 
    Age int check(Age >= 14 and Age <= 120),
    Exp int check(Exp >= 0 and Exp <= 116),
	Salary int,
	Job int constraint VACANCY_ID_FK foreign key references VACANCY(Id)
)