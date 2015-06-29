USE Softuni

GO
--Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
SELECT FirstName, LastName, Salary
FROM Employees
ORDER BY Salary ASC

GO
--Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary > (
	SELECT MIN(Salary)
	FROM Employees
) AND Salary < (
	SELECT MIN(Salary) * 1.1
	FROM Employees
) 

GO
--Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
SELECT e.FirstName, e.LastName, d.Name, e.Salary
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = (
	SELECT MIN(Salary)
	FROM Employees
	WHERE e.DepartmentID = DepartmentID
)
GROUP BY e.FirstName, e.LastName, d.Name, e.Salary
ORDER BY d.Name

GO
--Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) AS [Average Salary]
FROM Employees
WHERE DepartmentID = 1

GO
--Write a SQL query to find the average salary in the "Sales" department
SELECT AVG(e.Salary) AS [Average Salary for Sales Department]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

GO
--Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(e.EmployeeID) AS [Sales Employees Count]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

GO
--Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(e.ManagerID) AS [Employees with manager]
FROM Employees e

GO
--Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(e.EmployeeID) AS [Employees without manager]
FROM Employees e
WHERE e.ManagerID IS NULL

GO
--Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name, AVG(e.Salary)
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

GO
--Write a SQL query to find the count of all employees in each department and for each town.
SELECT t.Name, d.Name, Count(e.EmployeeID)
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t
ON a.TownID = t.TownID
GROUP BY t.Name, d.Name

GO
--Write a SQL query to find all managers that have exactly 5 employees.
SELECT m.FirstName, m.LastName, COUNT(m.FirstName + m.LastName) AS [Employees count]
FROM Employees e
JOIN Employees m
ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(m.FirstName + m.LastName) = 5

GO
--Write a SQL query to find all employees along with their managers.
SELECT
	e.FirstName + ' ' + e.LastName AS [Employee],
	ISNULL(m.FirstName + ' ' + m.LastName, 'No manager') AS [Manager]
FROM Employees e
LEFT JOIN Employees m
ON e.ManagerID = m.EmployeeID

GO
--Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
SELECT FirstName, LastName
FROM Employees e
WHERE LEN(FirstName) = 5 OR LEN(LastName) = 5

GO
--Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". 
SELECT CONVERT(varchar, GETDATE(), 104) + ' ' + RIGHT(CONVERT(varchar, GETDATE(), 113), 12)

GO
--Write a SQL statement to create a table Users.
CREATE TABLE Users(
	id int PRIMARY KEY IDENTITY,
	Username nvarchar(30) UNIQUE NOT NULL,
	[Password] nvarchar(30) NOT NULL CHECK (LEN([Password]) > 5),
	FullName nvarchar(50) NULL,
	LastLogin DateTime NOT NULL,
)

INSERT INTO Users VALUES 
	('test', '123456', 'test', GETDATE()),
	('test5', '123456', 'test', GETDATE()),
	('test1', '123123', 'test1', GETDATE()),
	('test2', '123456', 'test2', GETDATE()),
	('test3', '1234567', 'test2', CONVERT(varchar, '2014-01-20', 113));

GO
--Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
CREATE VIEW UV_UsersLoggedToday AS
	SELECT Username, LastLogin 
	FROM Users
	WHERE CONVERT (date, LastLogin) = CONVERT (date, GETDATE())

GO

SELECT * 
FROM dbo.UV_UsersLoggedToday

GO
--Write a SQL statement to create a table Groups. 
CREATE TABLE Groups(
	Id int PRIMARY KEY IDENTITY,
	Name nvarchar(25) UNIQUE	
)

GO
--Write a SQL statement to add a column GroupID to the table Users.
ALTER TABLE Users 
	ADD GroupId int FOREIGN KEY REFERENCES Groups(Id)

GO

INSERT INTO Groups VALUES
	('Some'),
	('Some1'),
	('Some2'),
	('Some3')

GO
--Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Users VALUES('test34', '123456', 'test', GETDATE(), 1);
INSERT INTO Users VALUES('test35', '123456', 'test', GETDATE(), 1);
INSERT INTO Users VALUES('test36', '123456', 'test', GETDATE(), 1);
INSERT INTO Groups VALUES('test34');
INSERT INTO Groups VALUES('test35');

GO
--Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users SET Username = 'updated' WHERE Id = 1
UPDATE Users SET Username = 'updated1' WHERE Id = 2
UPDATE Users SET Username = 'updated2' WHERE Id = 3
UPDATE Users SET GroupId = '1' WHERE GroupId IS NULL
UPDATE Groups SET Name = 'updated' WHERE Id = 1

--Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users WHERE Id < 4

--Write SQL statements to insert in the Users table the names of all employees from the Employees table.
INSERT INTO Users (Username, [Password], FullName, LastLogin, GroupId)
	SELECT
	LEFT(FirstName, 1) + '' + LOWER(LastName) + CAST(EmployeeID AS nvarchar(25)),
	LEFT(FirstName, 1) + '' + LOWER(LastName) + '000',
	FirstName + ' ' + LastName,
	GETDATE(),
	NULL
FROM Employees

GO
--Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users
SET LastLogin = CONVERT (date, '2010-01-30')
WHERE Id < 10

GO

ALTER Table Users ALTER COLUMN [Password] nvarchar(30) NULL

GO

UPDATE Users 
SET [Password] = NULL 
WHERE CONVERT (date, LastLogin) < CONVERT (date, '2010-03-10')

GO
--Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users WHERE [Password] IS NULL

GO
--Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name, e.JobTitle, AVG(e.Salary)
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

GO
--Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
SELECT d.Name, e.JobTitle, MIN(e.FirstName), MIN(e.Salary)
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY d.Name

GO
--Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name, COUNT(e.EmployeeID)
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t
ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(e.EmployeeID) DESC

GO
--Write a SQL query to display the number of managers from each town.
SELECT
	t.Name, COUNT(DISTINCT m.EmployeeID)
FROM Employees e
JOIN Employees m 
ON e.ManagerID = m.EmployeeID
JOIN Addresses a
ON m.AddressID = a.AddressID
JOIN Towns t
ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY t.Name

GO
--Write a SQL to create table WorkHours to store work reports for each employee.
CREATE TABLE WorkHours(
	Id int PRIMARY KEY IDENTITY,
	[Date] date NOT NULL,
	Task nvarchar(30) NOT NULL,
	[Hours] int NOT NULL,
	Comments nvarchar(150),
	EmployeeId int UNIQUE FOREIGN KEY REFERENCES Employees(EmployeeID)
)


--Issue few SQL statements to insert, update and delete of some data in the table.
INSERT INTO WorkHours VALUES(GETDATE(), 'Worker', 5, NULL, 1)
INSERT INTO WorkHours VALUES(GETDATE(), 'Worker', 15, NULL, 4)
INSERT INTO WorkHours VALUES(GETDATE(), 'Worker', 2, NULL, 2)
INSERT INTO WorkHours VALUES(GETDATE(), 'Worker', 8, NULL, 13)
UPDATE WorkHours SET Task = 'Not Worker' WHERE Id = 1
UPDATE WorkHours SET Task = 'Not Worker' WHERE Id = 2
UPDATE WorkHours SET Comments = 'Some comment' WHERE Comments IS NULL
DELETE FROM WorkHours WHERE Task = 'Worker'

SELECT * 
FROM WorkHours

GO

--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
CREATE TABLE WorkHoursLogs(
	Id int PRIMARY KEY IDENTITY,
	[Old Date] date NULL,
	[New Date] date NULL,
	[Old Task] nvarchar(30) NULL,
	[New Task] nvarchar(30) NULL,
	[Old Hours] int NULL,
	[New Hours] int NULL,
	[Old Comments] nvarchar(150) NULL,
	[New Comments] nvarchar(150) NULL,
	[Command type] nvarchar(25) NULL,
	EmployeeId int FOREIGN KEY REFERENCES Employees(EmployeeID)
)

GO

CREATE TRIGGER track_updates_in_WorkHours
ON WorkHours
FOR UPDATE AS
	INSERT INTO WorkHoursLogs 
	SELECT 
	d.[Date],
	i.[Date],
	d.Task,
	i.Task,
	d.[Hours],
	i.[Hours],
	d.Comments,
	i.Comments,
	'UPDATE',
	d.EmployeeId
	FROM deleted d, inserted i

GO

CREATE TRIGGER track_deletes_in_WorkHours
ON WorkHours
FOR DELETE AS
	INSERT INTO WorkHoursLogs 
	SELECT 
	d.[Date],
	NULL,
	d.Task,
	NULL,
	d.[Hours],
	NULL,
	d.Comments,
	NULL,
	'DELETE',
	d.EmployeeId
	FROM deleted d

GO

CREATE TRIGGER track_insert_in_WorkHours
ON WorkHours
FOR INSERT AS
	INSERT INTO WorkHoursLogs 
	SELECT 
	NULL,
	i.[Date],
	NULL,
	i.Task,
	NULL,
	i.[Hours],
	NULL,
	i.Comments,
	'INSERT',
	i.EmployeeId
	FROM inserted i

GO

UPDATE WorkHours SET Task = 'Not! Worker' WHERE Id = 6
DELETE FROM WorkHours WHERE Id = 6
INSERT INTO WorkHours VALUES(GETDATE(), 'Worker', 5, NULL, 22)

SELECT * FROM WorkHoursLogs
SELECT * FROM WorkHours

GO
--Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables. At the end rollback the transaction.
BEGIN TRAN

ALTER TABLE Employees
DROP CONSTRAINT FK_Employees_Addresses
ALTER TABLE Employees
DROP CONSTRAINT FK_Employees_Departments
ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees

DELETE FROM Employees WHERE DepartmentID = (
	SELECT DepartmentID
	FROM Departments 
	WHERE Name = 'Sales')

SELECT * 
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

ROLLBACK TRAN

GO
--Start a database transaction and drop the table EmployeesProjects.
BEGIN TRAN

DROP TABLE EmployeesProjects

ROLLBACK TRAN

GO
--Find how to use temporary tables in SQL Server.
BEGIN TRAN

CREATE TABLE #Temp1 ( [EmployeeID] int, [ProjectID] int )

INSERT INTO #Temp1 ([EmployeeID], [ProjectID])
	SELECT EmployeeID, [ProjectID] FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects ( [EmployeeID] int, [ProjectID] int )

INSERT INTO EmployeesProjects ([EmployeeID], [ProjectID])
	SELECT EmployeeID, [ProjectID] FROM #Temp1

DROP TABLE #Temp1

SELECT * FROM EmployeesProjects

--Just to not mess with the database much. It is working without the transaction.
ROLLBACK TRAN