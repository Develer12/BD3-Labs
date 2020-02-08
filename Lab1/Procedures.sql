go
use WHiring;


--Watch all Vacancy
go
Create Procedure SVACANCY
	@end int,
	@start int
AS
Begin
	WITH num_row AS
	(
		SELECT row_number() OVER (ORDER BY Id) as nom , 		
		Id, Company, Position, Level, Exp, MinSalary, MaxSalary FROM VACANCY
	) 
	SELECT * FROM num_row
	WHERE nom BETWEEN @start AND @end;
End;

--Watch all Vacancy
go
Create Procedure SCANDIDATE
	@end int,
	@start int
AS
Begin
	WITH num_row AS
	(
		SELECT row_number() OVER (ORDER BY p.Id) as nom , 		
		p.Id, p.FName, p.SName, p.Position, p.Level, p.Sex, p.Age, p.Exp, p.Salary, Job FROM CANDIDATE p
		LEFT OUTER JOIN
		VACANCY t ON t.Id = p.Job
	) 
	SELECT * FROM num_row
	WHERE nom BETWEEN @start AND @end;
End;

--Watch all Vacancy
go
Create Procedure SWORKER
	@end int,
	@start int
AS
Begin
	WITH num_row AS
	(
		SELECT row_number() OVER (ORDER BY p.Id) as nom , 		
		p.Id, p.FName, p.SName, p.Position, p.Level, p.Sex, p.Age, p.Exp, p.Salary, Job FROM WORKER p
		LEFT OUTER JOIN
		VACANCY t ON t.Id = p.Job
	) 
	SELECT * FROM num_row
	WHERE nom BETWEEN @start AND @end;
End;