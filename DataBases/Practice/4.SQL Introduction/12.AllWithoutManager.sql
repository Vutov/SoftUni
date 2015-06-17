SELECT FirstName + ' ' + LastName as [Name], ManagerID
FROM Employees
WHERE ManagerID IS NULL