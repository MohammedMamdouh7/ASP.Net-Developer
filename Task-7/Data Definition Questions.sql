--   ============================== Data Definition Questions: (using SQL NOT GUI)  ===================
CREATE SCHEMA DF 

--1
CREATE TABLE DF.Employees
(
	id INT ,
	name VARCHAR(100),
	salary DECIMAL(10,2),
)


--2 
ALTER TABLE DF.Employees ADD Department VARCHAR(50)


--3
ALTER TABLE DF.Employees DROP COLUMN salary


--4 ==REF==> https://stackoverflow.com/questions/16296622/rename-column-sql-server-2008
EXEC sp_RENAME 'DF.Employees.Department' , 'DeptName', 'COLUMN'


--5
CREATE TABLE DF.Projects
(
	project_id INT ,
	project_name VARCHAR(100)
)


--6 ==REF==> ÇÓÊÚäÊ ÈÕÏíÞ
ALTER TABLE DF.Employees
ALTER COLUMN id INT NOT NULL

ALTER TABLE DF.Employees
ADD PRIMARY KEY(id)


--7 ==REF==>https://www.sqlservertutorial.net/sql-server-basics/sql-server-unique-constraint/
ALTER TABLE DF.Employees
ADD CONSTRAINT CN
UNIQUE(name);


--8
CREATE TABLE DF.Customers
(
	CustomerID INT ,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Email VARCHAR(100),
	Status VARCHAR(50),
)


--9
ALTER TABLE DF.Customers
ADD CONSTRAINT U_FName UNIQUE(FirstName)
ALTER TABLE DF.Customers
ADD CONSTRAINT U_LName UNIQUE(LastName)


--10
CREATE TABLE DF.Orders
(
	order_id  INT,
	customer_id INT,
	order_date DATETIME,
	total_amount DECIMAL(12,2)
)


--11 ==REF==>https://www.sqlservertutorial.net/sql-server-basics/sql-server-check-constraint/
ALTER TABLE DF.Orders
ADD CONSTRAINT CHECK_TA CHECK (total_amount > 0);


--12
CREATE SCHEMA Sales
ALTER SCHEMA Sales TRANSFER DF.Orders


--13
EXEC sp_rename 'Sales.Orders' , 'SalesOrders.'


