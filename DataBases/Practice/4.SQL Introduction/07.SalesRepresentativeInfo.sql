SELECT 
	e.FirstName, e.LastName, e.MiddleName, e.JobTitle,
	d.Name, m.FirstName + ' ' + m.LastName as [Manager],
	e.HireDate, e.Salary, a.AddressText, d.Name
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
JOIN Employees m
on e.ManagerID = m.EmployeeID
JOIN Addresses a
ON e.AddressID = a.AddressID 
WHERE e.JobTitle = 'Sales Representative'
ORDER BY FirstName