SELECT d.Name, d.ManagerID, e.FirstName + ' ' + e.LastName as [Manager name]
FROM Departments d
JOIN Employees e
ON d.DepartmentID = e.EmployeeID