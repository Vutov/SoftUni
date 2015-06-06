SELECT 
	e.FirstName + ' ' + e.LastName as [Manager Name],
	m.FirstName + ' ' + m.LastName as [Employee Name]
FROM Employees m
LEFT OUTER JOIN Employees e
ON m.ManagerID = e.EmployeeID


SELECT 
	e.FirstName + ' ' + e.LastName as [Employee Name],
	m.FirstName + ' ' + m.LastName as [Manager Name]
FROM Employees e
LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID