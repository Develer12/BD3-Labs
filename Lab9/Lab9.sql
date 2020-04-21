USE WHiring;

--1
SELECT count(*) FROM CANDIDATE
	WHERE Age BETWEEN 20 AND 40;
---------------------------------------
SELECT Id, Age, Salary
	,sum(Salary) OVER()
	,(100.00*Salary / (sum(Salary) OVER()))/100.00 AS "Percent"  
FROM CANDIDATE   
	WHERE Age BETWEEN 20 AND 40
group by Id, Salary, Age;

---------------------------------------
SELECT VACANCY.Id
	, CANDIDATE.Job
	,count(CANDIDATE.Job) OVER()
	, count(VACANCY.Id)
	,count(VACANCY.Id) OVER()
	,(100.00 / (count(VACANCY.Id)))/100.00 AS "Percent"  
FROM CANDIDATE
	join VACANCY ON CANDIDATE.Job = VACANCY.Id
GROUP BY CANDIDATE.Job, VACANCY.Id;

--3
SELECT * , ROW_NUMBER() OVER(PARTITION BY Id ORDER BY Id) AS rownum
FROM CANDIDATE;

--4. ROW_NUMBER() delete dublicates
SELECT count(*) FROM CANDIDATE;

delete x from 
(
  select *, rn=row_number() over (partition by Id order by Id)
  from CANDIDATE 
) x
where rn > 1;


--5
SELECT CANDIDATE.Job, count(CANDIDATE.Job) as count,
  RANK() OVER(ORDER BY SUM(CANDIDATE.Job) DESC) AS rank
FROM CANDIDATE
  JOIN VACANCY ON CANDIDATE.Job = VACANCY.Id
GROUP BY CANDIDATE.Job;
