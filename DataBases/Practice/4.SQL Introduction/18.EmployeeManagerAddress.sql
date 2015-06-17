SELECT 
	e.FirstName + ' ' + e.LastName as [Employee Name],
	ea.AddressText as [Employee Address],
	m.FirstName + ' ' + m.LastName as [Manager Name],
	ma.AddressText as [Manager Address]
FROM Employees e
JOIN Employees m
ON e.ManagerID = m.EmployeeID
JOIN Addresses ea
ON e.AddressID = ea.AddressID
JOIN Addresses ma
ON m.AddressID = ma.AddressID