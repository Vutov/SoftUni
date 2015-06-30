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

GO
--Changes in the Database
BEGIN TRAN
CREATE TABLE Countries(
	Id int PRIMARY KEY IDENTITY,
	Name nvarchar(50) NOT NULL,
)

GO

ALTER TABLE Towns ADD CountryId int FOREIGN KEY REFERENCES Towns(Id) NULL

GO

INSERT INTO Countries(Name) VALUES ('Bulgaria'), ('Germany'), ('France')
UPDATE Towns SET CountryId = (SELECT Id FROM Countries WHERE Name='Bulgaria')
INSERT INTO Towns VALUES
('Munich', (SELECT Id FROM Countries WHERE Name='Germany')),
('Frankfurt', (SELECT Id FROM Countries WHERE Name='Germany')),
('Berlin', (SELECT Id FROM Countries WHERE Name='Germany')),
('Hamburg', (SELECT Id FROM Countries WHERE Name='Germany')),
('Paris', (SELECT Id FROM Countries WHERE Name='France')),
('Lyon', (SELECT Id FROM Countries WHERE Name='France')),
('Nantes', (SELECT Id FROM Countries WHERE Name='France'))

GO

UPDATE Ads SET TownId = (
	SELECT t.Id
	FROM Towns t
	WHERE t.Name = 'Paris'
	)
WHERE Id IN (
	SELECT a.Id
	FROM Ads a
	WHERE DATENAME(weekday, [Date]) = 'Friday'
	)

UPDATE Ads SET TownId = (
	SELECT t.Id
	FROM Towns t
	WHERE t.Name = 'Hamburg'
	)
WHERE Id IN (
	SELECT a.Id
	FROM Ads a
	WHERE DATENAME(weekday, [Date]) = 'Thursday'
	)

GO

DELETE Ads WHERE Id IN (
	SELECT a.Id
	FROM Ads a
	JOIN AspNetUsers u
	ON a.OwnerId = u.Id
	JOIN AspNetUserRoles ar
	ON u.Id = ar.UserId
	JOIN AspNetRoles ro
	ON ar.RoleId = ro.Id
	WHERE ro.Name = 'Partner'
)

GO

INSERT INTO Ads (Title, [Text], [Date], OwnerId, StatusId) VALUES (
'Free Book',
'Free C# Book',
GETDATE(),
(SELECT Id AS OwnerId
FROM AspNetUsers
WHERE Name = 'Nakov'),
(SELECT Id AS StatusId
FROM AdStatuses
WHERE [Status] = 'Waiting Approval')
)

GO

SELECT 
	t.Name AS [Town], c.Name AS [Country], COUNT(a.Id) AS [AdsCount]
FROM Ads a
FULL JOIN Towns t
ON a.TownId = t.Id
FULL JOIN Countries c
ON t.CountryId = c.Id
GROUP BY t.Name, c.Name
ORDER BY t.Name, c.Name

ROLLBACK TRAN

GO
--Stored Procedures
BEGIN TRAN

GO

CREATE VIEW AllAds AS
	SELECT a.Id, a.Title, u.UserName AS [Author], a.[Date], t.Name AS [Town],
		c.Name AS [Category], s.[Status]
	FROM Ads a
	FULL JOIN AspNetUsers u
	ON a.OwnerId = u.Id
	LEFT JOIN Towns t
	ON a.TownId = t.Id
	LEFT JOIN Categories c
	ON a.CategoryId = c.Id
	LEFT JOIN AdStatuses s
	ON a.StatusId = s.Id

GO

COMMIT TRAN

GO

BEGIN TRAN

GO

CREATE FUNCTION fn_ListUsersAds()
RETURNS @UsersAndDates TABLE
   (
    UserName nvarchar(50),
    AdDates nvarchar(Max)
   )
AS
BEGIN
	DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT Author, [Date] FROM AllAds ORDER BY Author DESC, [Date] ASC

	OPEN empCursor
	DECLARE @currAuthor nvarchar(50), @lastAuthor nvarchar(50),
		@currDate date, @dates nvarchar(Max)
	SET @dates = NULL
	FETCH NEXT FROM empCursor INTO @currAuthor, @currDate
	SET @lastAuthor = @currAuthor

	WHILE @@FETCH_STATUS = 0
	  BEGIN
		IF @currAuthor = @lastAuthor
			BEGIN
				IF @dates IS NULL
					BEGIN
						IF @currDate IS NULL
							BEGIN
								SET @dates = @currDate
							END
						ELSE
							BEGIN
								SET @dates = convert(varchar, @currDate, 112)
							END
					END
				ELSE
					BEGIN
						SET @dates = @dates+ '; ' + convert(varchar, @currDate, 112)
					END
			END
		ELSE
			BEGIN
				INSERT @UsersAndDates VALUES (@lastAuthor, ISNULL(@dates, 'NULL'))

				SET @lastAuthor = @currAuthor
				SET @dates = convert(varchar, @currDate, 112)
			END

		FETCH NEXT FROM empCursor INTO @currAuthor, @currDate
	  END

	INSERT @UsersAndDates VALUES (@lastAuthor, ISNULL(@dates, 'NULL'))

	CLOSE empCursor
	DEALLOCATE empCursor

	RETURN
END

GO

--ROLLBACK TRAN
COMMIT TRAN

GO

SELECT * FROM fn_ListUsersAds()

--SELECT Author,[Date] FROM AllAds GROUP BY Author,[Date] ORDER BY Author DESC, [Date] ASC
