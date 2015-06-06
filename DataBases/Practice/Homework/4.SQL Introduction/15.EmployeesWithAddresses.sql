SELECT e.FirstName + ' ' + e.LastName as [Name], a.AddressText as [Address]
FROM Employees e
JOIN Addresses a
ON e.AddressID = a.AddressID
ORDER BY [Name] ASC