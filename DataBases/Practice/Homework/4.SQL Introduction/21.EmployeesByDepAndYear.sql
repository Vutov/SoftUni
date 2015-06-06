SELECT e.FirstName + ' ' + e.LastName as [Name], e.HireDate, d.Name
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE
	(d.Name = 'Sales' OR d.Name = 'Finance') AND 
	(HireDate > '1995-01-01' AND HireDate < '2005-01-01')
ORDER BY e.HireDate