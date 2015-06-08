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

DROP VIEW view_users_logged_today

GO

DROP TABLE Users