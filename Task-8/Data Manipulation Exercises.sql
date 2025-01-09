CREATE DATABASE CompanyDB;
CREATE SCHEMA Sales



CREATE TABLE Sales.employees (
    employee_id INT NOT NULL,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    salary DECIMAL(10, 2),
    CONSTRAINT pk_employee PRIMARY KEY (employee_id)  
)




CREATE SEQUENCE Sales.employee_seq 
START WITH 1
INCREMENT BY 1



ALTER TABLE Sales.employees
ADD hire_date DATE  




--1
SELECT * FROM Sales.employees 


--2
SELECT first_name,last_name FROM Sales.employees   

--3
SELECT first_name +' '+ last_name as full_name FROM Sales.employees 


--4
SELECT avg(salary) as average_salary  FROM Sales.employees 


--5
SELECT * FROM Sales.employees where salary > 50000    

--6
SELECT * FROM Sales.employees where year (hire_date) =2020 

--7
SELECT * FROM Sales.employees where last_name LIKE 'S%' 

--8
SELECT TOP 10 *FROM Sales.employees ORDER BY salary DESC 


--9
SELECT * FROM Sales.employees where salary between 40000 and 60000 ORDER BY salary DESC 

--10
SELECT * FROM Sales.employees where first_name LIKE '%man%' OR last_name LIKE '%man%' 


--11

SELECT * FROM Sales.employees where hire_date is null 
 

 --12
 SELECT * FROM Sales.employees where salary= 40000 OR salary= 45000 OR salary= 50000 
 


--13
SELECT * FROM Sales.employees where hire_date BETWEEN '2020-01-01' AND '2021-01-01' ORDER BY hire_date ASC

--14
SELECT * FROM Sales.employees ORDER BY salary DESC


--15
SELECT TOP 5 *FROM Sales.employees ORDER BY last_name ASC

--16
SELECT * FROM Sales.employees where salary > 55000 and  year (hire_date)= 2020


--17
SELECT * FROM Sales.employees where first_name LIKE 'John' OR first_name LIKE 'Jane'

--18
SELECT * FROM Sales.employees where salary <= 55000 and  hire_date > '2022-01-01' 




--19 =========> Helped by AI tools   
SELECT e.*
FROM Sales.employees e
JOIN (SELECT AVG(salary) AS AvgSalary FROM Sales.employees) AS AvgResult
ON e.salary > AvgResult.AvgSalary;



--   ÇáØÑíÞÉ ÇáËÇäíÉ åí ÇáÊí ßäÊ ÓÃÍá ÈåÇ, ÊÚØí äÝÓ ÇáäÇÊÌ áÇßä áÇ ÇÏÑí åá ÊÚÊÈÑ ÕÍíÍÉ Çã Çäå ãä ÇáÇÝÖá ÇáÏãÌ¿
-- ÇáÑÌÇÁ ÇáÑÏ Úáì ÇáÓÄÇá
SELECT AVG(salary) AS AvgSalary FROM Sales.employees -- äÃÎÐ ÇáãÊæÓØ ãä åäÇ æãä Ëã äÖÚå Ýí ÇáßæíÑí ÇáÊÇáíÉ ßËÇÈÊ  

SELECT * FROM Sales.employees where salary > 31985.769000 --<<<-----





--20 =========> Helped by AI tools   
SELECT *FROM (
    SELECT TOP 7 *FROM Sales.employees ORDER BY salary DESC
) AS Top7
ORDER BY salary ASC
OFFSET 2 ROWS



--21
SELECT * FROM Sales.employees where hire_date > '2021-01-01'  ORDER BY first_name ASC


--22
SELECT * FROM Sales.employees where salary > 50000 and last_name NOT LIKE 'A%'


--23
SELECT * FROM Sales.employees where salary is not null 




--24 =========> Helped by AI tools   
SELECT * FROM Sales.employees where
(first_name LIKE '%e%' OR last_name LIKE '%e%' OR first_name LIKE '%i%' OR last_name LIKE '%i%')
AND salary > 45000


