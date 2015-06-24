--01.Write a SQL query to find all information about all departments (use "SoftUni" database).
USE SoftUni

SELECT * 
FROM Departments

GO
--02.Write a SQL query to find all department names.

SELECT Name 
FROM Departments

GO
--03.Write a SQL query to find the salary of each employee.
--04.Write a SQL to find the full name of each employee.  
SELECT FirstName + ' ' + LastName AS [Name], Salary
FROM Employees

GO
--05.Write a SQL query to find the email addresses of each employee.
SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Addresses]
FROM Employees

GO
--06.Write a SQL query to find all different employee salaries. 
SELECT DISTINCT Salary 
FROM Employees

GO
--07.Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
SELECT * 
FROM Employees
WHERE JobTitle = 'Sales Representative'

GO
--08.Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE FirstName LIKE 'SA%'

GO
--09.Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE LastName LIKE '%ei%'

GO
--10.Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000
ORDER BY Salary ASC

GO
--11.Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary IN (25000,14000,12500,23600)
ORDER BY Salary ASC

GO
--12.Write a SQL query to find all employees that do not have manager.
SELECT *
FROM Employees
WHERE ManagerID IS NULL

GO
--13.Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

GO
--14.Write a SQL query to find the top 5 best paid employees.
SELECT TOP 5 FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
ORDER BY Salary DESC

GO
--15.Write a SQL query to find all employees along with their address.
SELECT e.FirstName, e.LastName, a.AddressText
FROM Employees e
INNER JOIN Addresses a
ON e.AddressID = a.AddressID

GO
--16.Write a SQL query to find all employees and their address.
SELECT e.FirstName, e.LastName, a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

GO
--17.Write a SQL query to find all employees along with their manager.
--18.Write a SQL query to find all employees, along with their manager and their address.
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name],
	ea.AddressText AS [Employee Address],
	m.FirstName + ' ' + m.LastName AS [Manager Name],
	ma.AddressText AS [Manager Address]
FROM Employees e
INNER JOIN Employees m
ON e.ManagerID = m.EmployeeID
INNER JOIN Addresses ma
ON m.AddressID = ma.AddressID
INNER JOIN Addresses ea
ON e.AddressID = ea.AddressID

GO
--19.Write a SQL query to find all departments and all town names as a single list.
SELECT d.Name
FROM Departments d
UNION
SELECT t.Name
FROM Towns t

GO
--20.Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. 
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name],
	m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM Employees e
LEFT JOIN Employees m
ON e.ManagerID = m.EmployeeID

GO
--21.Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name],
	e.HireDate,
	d.Name
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name IN ('Sales', 'Finance') AND e.HireDate BETWEEN '1995-1-1' AND '2005-12-31'
ORDER BY e.HireDate ASC