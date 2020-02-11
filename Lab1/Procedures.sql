go
use WHiring;


--Watch all Vacancy
go
Create Procedure SVACANCY
AS
Begin
	SELECT Id, Status, Company, Position, Level, Exp, MinSalary, MaxSalary FROM VACANCY;
End;

--Watch all Candidate
go
Create Procedure SCANDIDATE
AS
Begin
	SELECT p.Id, p.FName, p.SName, p.Position, p.Level, p.Sex, p.Age, p.Exp, p.Salary, Job FROM CANDIDATE p
	LEFT OUTER JOIN
	VACANCY t ON t.Id = p.Job;
End;

--Watch all Worker
go
Create Procedure SWORKER
AS
Begin
	SELECT p.Id, p.FName, p.SName, p.Position, p.Level, p.Sex, p.Age, p.Exp, p.Salary, Job FROM WORKER p
	LEFT OUTER JOIN
	VACANCY t ON t.Id = p.Job;
End;