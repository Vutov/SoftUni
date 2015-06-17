SELECT FirstName + ' ' + LastName as [Name], Salary
FROM Employees
WHERE Salary >= 20000 AND Salary <= 30000
ORDER By Salary ASC