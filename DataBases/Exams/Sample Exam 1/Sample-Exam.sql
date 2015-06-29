USE Ads

GO
--All Ad Titles
SELECT Title
FROM Ads
ORDER BY Title ASC

GO
--Ads in Date Range
SELECT Title, [Date]
FROM Ads
WHERE [Date] BETWEEN '2014-12-26 00:00:00' AND '2015-01-01 23:59:59'
ORDER BY [Date] ASC

GO
--Ads with "Yes/No" Images
SELECT 
	Title,
	[Date],
	CASE
		WHEN a.ImageDataURL IS NULL THEN ISNULL(a.ImageDataURL, 'no') 
		WHEN a.ImageDataURL IS NOT NULL THEN 'yes' 
	END 
	AS [Has Image]
FROM Ads a
ORDER BY Id

GO
--Ads without Town, Category or Image
SELECT *
FROM Ads
WHERE ImageDataURL IS NULL OR TownId IS NULL OR CategoryId IS NULL
ORDER BY Id

GO
--Ads with Their Town
SELECT a.Title, t.Name AS [Town]
FROM Ads a
LEFT JOIN Towns t
ON a.TownId = t.Id
ORDER BY a.Id

GO
--Ads with Their Category, Town and Status
SELECT a.Title, c.Name AS [CategoryName], t.Name AS [TownName], astat.[Status]
FROM Ads a
LEFT JOIN Towns t
ON a.TownId = t.Id
LEFT JOIN Categories c
ON a.CategoryId = c.Id
LEFT JOIN AdStatuses astat
ON a.StatusId = astat.Id
ORDER BY a.Id

GO
--Filtered Ads with Category, Town and Status
SELECT a.Title, c.Name AS [CategoryName], t.Name AS [TownName], astat.[Status]
FROM Ads a
JOIN Towns t
ON a.TownId = t.Id
JOIN Categories c
ON a.CategoryId = c.Id
JOIN AdStatuses astat
ON a.StatusId = astat.Id
WHERE  astat.[Status] = 'Published' AND
	t.Name IN ('Sofia', 'Blagoevgrad', 'Stara Zagora')
ORDER BY a.Title

GO
--Earliest and Latest Ads
SELECT MIN([Date]) AS [MinDate], MAX([Date]) AS [MaxDate]
FROM Ads

GO
--Latest 10 Ads
SELECT TOP 10 a.Title, a.[Date], astat.[Status]
FROM Ads a
JOIN AdStatuses astat
ON a.StatusId = astat.Id
ORDER BY a.[Date] DESC

GO
--Not Published Ads from the First Month
SELECT a.Id, a.Title, a.[Date], astat.[Status]
FROM Ads a
JOIN AdStatuses astat
ON a.StatusId = astat.Id
WHERE astat.[Status] != 'Published' AND RIGHT(convert(varchar, a.[Date], 106), 8) = (
	SELECT MIN(RIGHT(convert(varchar, [Date], 106), 8))
	FROM Ads
)
ORDER BY a.Id

SELECT convert(varchar, [Date], 102)
FROM Ads

GO
--Ads by Status
SELECT astat.[Status], COUNT(astat.[Status]) AS [Count]
FROM Ads a
JOIN AdStatuses astat
ON a.StatusId = astat.Id
GROUP BY astat.[Status]
ORDER BY astat.[Status]

GO
--Ads by Town and Status
SELECT t.Name AS [Town Name], astat.[Status], COUNT(astat.[Status]) AS [Count]
FROM Ads a
JOIN AdStatuses astat
ON a.StatusId = astat.Id
JOIN Towns t
ON a.TownId = t.Id
GROUP BY astat.[Status], t.Name
HAVING COUNT(astat.[Status]) > 0
ORDER BY t.Name

GO
--Ads by Users
SELECT 
  MIN(u.UserName) as UserName, 
  COUNT(a.Id) as AdsCount,
  (CASE WHEN admins.UserName IS NULL THEN 'no' ELSE 'yes' END) AS IsAdministrator
FROM 
  AspNetUsers u
  LEFT JOIN Ads a ON u.Id = a.OwnerId
  LEFT JOIN (
    SELECT DISTINCT u.UserName
	FROM AspNetUsers u
	  LEFT JOIN AspNetUserRoles ur ON ur.UserId = u.Id
	  LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id
	WHERE r.Name = 'Administrator'
  ) AS admins ON u.UserName = admins.UserName
GROUP BY OwnerId, u.UserName, admins.UserName
ORDER BY u.UserName

GO
--Ads by Town
SELECT COUNT(a.Id) AS [AdsCount], ISNULL(t.Name, '(no town)') AS Town
FROM Ads a
LEFT JOIN Towns t
ON a.TownId = t.Id
GROUP BY t.Name
HAVING COUNT(a.Id) BETWEEN 2 AND 3
ORDER BY t.Name

GO
--Pairs of Dates within 12 Hours
SELECT fa.[Date] AS FirstDate, sa.[Date] AS SecondDate
FROM Ads fa
CROSS JOIN Ads sa
WHERE DATEDIFF(HOUR, fa.[Date], sa.[Date]) BETWEEN 1 AND 11
ORDER BY fa.[Date], sa.[Date] ASC