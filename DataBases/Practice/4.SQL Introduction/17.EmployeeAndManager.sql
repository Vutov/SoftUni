SELECT 
	e.FirstName + ' ' + e.LastName as [Employee Name],
	m.FirstName + ' ' + m.LastName as [Manager Name]
FROM Employees e
JOIN Employees m
ON e.ManagerID = m.EmployeeID