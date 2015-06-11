--Problem 1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = (
	SELECT MIN(Salary)
	FROM Employees
	)

--Problem 2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary BETWEEN (
	SELECT MIN(Salary)
	FROM Employees
	) AND (
	SELECT MIN(Salary) * 1.1
	FROM Employees
	) 

--Problem 3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
SELECT
	e.FirstName + ' ' + e.LastName as [Full Name],
	e.Salary,
	d.Name as [Departmant Name]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE Salary = (
	SELECT MIN(Salary)
	FROM Employees
	WHERE DepartmentID = e.DepartmentID
	)

--Problem 4. Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) as [Average Salary for first Department]
FROM Employees
WHERE DepartmentID = 1

--Problem 5. Write a SQL query to find the average salary in the "Sales" department.
SELECT AVG(e.Salary) as [Average Salary for Sales Department]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--Problem 6. Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(e.FirstName) as [Sales Employees Count]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--Problem 7. Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(e.FirstName) as [Employees with manager]
FROM Employees e
WHERE e.ManagerID IS NOT NULL

--Problem 8. Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(e.FirstName) as [Employees with manager]
FROM Employees e
WHERE e.ManagerID IS NULL

--Problem 9. Write a SQL query to find all departments and the average salary for each of them.
SELECT
	d.Name as [Department],
	AVG(Salary) as [Average Salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

--Problem 10. Write a SQL query to find the count of all employees in each department and for each town.
SELECT t.Name AS Towns, d.Name AS Department, Count(e.EmployeeID) AS [Employees count]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t
ON a.TownID = t.TownID
GROUP BY d.Name, t.Name
ORDER BY d.Name

--Problem 11. Write a SQL query to find all managers that have exactly 5 employees.
SELECT m.FirstName, m.LastName, COUNT(m.FirstName + ' ' + m.LastName)
FROM Employees e
JOIN Employees m
ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(m.FirstName + ' ' + m.LastName) = 5

--Problem 12. Write a SQL query to find all employees along with their managers.
SELECT 
	e.FirstName + ' ' + e.LastName AS [Employee],
	ISNULL(m.FirstName + ' ' + m.LastName, 'No manager') AS [Manager]
FROM Employees e
LEFT JOIN Employees m
ON e.ManagerID = m.EmployeeID

--Problem 13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '_____'

--Problem 14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
SELECT CONVERT(varchar, GETDATE(), 104) + ' ' + RIGHT(CONVERT(varchar, GETDATE(), 113), 12)

--Problem 15. Write a SQL statement to create a table Users.
CREATE TABLE Users(
	Id int PRIMARY KEY IDENTITY,
	Username nvarchar(25) UNIQUE,
	[Password] nvarchar(25) CHECK (LEN([Password]) > 5),
	FullName nvarchar(50),
	LastLogin date
	)

GO

INSERT INTO Users VALUES ('test', '123456', 'test', GETDATE());
INSERT INTO Users VALUES ('test', '123456', 'test', GETDATE());
INSERT INTO Users VALUES ('test1', '123', 'test1', GETDATE());
INSERT INTO Users VALUES ('test2', '123456', 'test2', GETDATE());
INSERT INTO Users VALUES ('test3', '1234567', 'test2', CONVERT(varchar, '2014-01-20', 113));

GO

--Problem 16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
CREATE VIEW view_users_logged_today AS
SELECT *
FROM Users
WHERE CONVERT (date, LastLogin) = CONVERT (date, GETDATE())

GO

--Problem 17. Write a SQL statement to create a table Groups. 
CREATE TABLE Groups(
	Id int PRIMARY KEY IDENTITY,
	Name nvarchar(25) UNIQUE
)

GO

--Problem 18. Write a SQL statement to add a column GroupID to the table Users.
INSERT INTO Groups VALUES ('Name');
INSERT INTO Groups VALUES ('Name');

GO

ALTER TABLE Users
ADD GroupId int FOREIGN KEY REFERENCES Groups(Id)

GO

--Problem 19. Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Users VALUES('test34', '123456', 'test', GETDATE(), 1);
INSERT INTO Users VALUES('test35', '123456', 'test', GETDATE(), 1);
INSERT INTO Users VALUES('test36', '123456', 'test', GETDATE(), 1);
INSERT INTO Groups VALUES('test34');
INSERT INTO Groups VALUES('test35');

--Problem 20. Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users SET Username = 'updated' WHERE Id = 1
UPDATE Users SET Username = 'updated1' WHERE Id = 2
UPDATE Users SET Username = 'updated2' WHERE Id = 3
UPDATE Users SET GroupId = '1' WHERE GroupId IS NULL
UPDATE Groups SET Name = 'updated' WHERE Id = 1

GO

--Problem 21. Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE Id = 1
DELETE FROM Users
WHERE Id = 2
DELETE FROM Groups
WHERE Id = 3

GO

--Problem 22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.
INSERT INTO Users
	SELECT
	LEFT(FirstName, 1) + '' + LOWER(LastName) + CAST(EmployeeID AS nvarchar(25)) AS [Username],
	LEFT(FirstName, 1) + '' + LOWER(LastName) + '---' AS [Password],
	FirstName + ' ' + LastName,
	GETDATE(),
	1
FROM Employees

GO
--Problem 23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users
SET LastLogin = CONVERT (date, '2010-01-30')
WHERE Id < 10

GO

UPDATE Users 
SET [Password] = NULL 
WHERE CONVERT (date, LastLogin) < CONVERT (date, '2010-03-10')

GO

--Problem 24. Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users
WHERE [Password] IS NULL

GO

--Problem 25. Write a SQL query to display the average employee salary by department and job title.
SELECT
	d.Name AS Department,
	e.JobTitle AS [Job Title],
	AVG(Salary) AS [Avarage Salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

GO

--Problem 26. Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
SELECT
	d.Name AS Department,
	e.JobTitle AS [Job Title],
	MIN(e.FirstName) as [First Name],
	MIN(Salary) AS [Avarage Salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY d.Name, [Avarage Salary]

GO

--Problem 27. Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 
	t.Name, COUNT(t.Name) AS [Number of employees]
FROM Employees e
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t
ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY [Number of employees] DESC

--Problem 28. Write a SQL query to display the number of managers from each town.
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

--Problem 29. Write a SQL to create table WorkHours to store work reports for each employee.
CREATE TABLE WorkHours(
	Id int PRIMARY KEY IDENTITY,
	[Date] date NOT NULL,
	Task nvarchar(30) NOT NULL,
	[Hours] int NOT NULL,
	Comments nvarchar(150),
	EmployeeId int UNIQUE FOREIGN KEY REFERENCES Employees(EmployeeID)
)


--Problem 30. Issue few SQL statements to insert, update and delete of some data in the table.
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

--Problem 31. Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
CREATE TABLE WorkHoursLogs(
	Id int PRIMARY KEY IDENTITY,
	[Old Date] date NOT NULL,
	[New Date] date NOT NULL,
	[Old Task] nvarchar(30) NOT NULL,
	[New Task] nvarchar(30) NOT NULL,
	[Old Hours] int NOT NULL,
	[New Hours] int NOT NULL,
	[Old Comments] nvarchar(150),
	[New Comments] nvarchar(150),
	[Command type] nvarchar(25) NOT NULL,
	EmployeeId int UNIQUE FOREIGN KEY REFERENCES Employees(EmployeeID)
)

GO

CREATE TRIGGER track_changes_in_WorkHours
ON WorkHours
FOR UPDATE AS
--??

GO

--Problem 32. Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables. At the end rollback the transaction.
BEGIN TRAN
DELETE FROM Employees WHERE DepartmentID = (
	SELECT DepartmentID
	FROM Departments 
	WHERE Name = 'Sales')
ROLLBACK TRAN

SELECT * FROM Employees

