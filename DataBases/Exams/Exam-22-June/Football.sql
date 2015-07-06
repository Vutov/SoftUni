USE Football
GO
--All Teams
SELECT TeamName
FROM Teams
ORDER BY TeamName ASC

GO
--Biggest Countries by Population
SELECT TOP 50 CountryName, Population
FROM Countries
ORDER BY Population DESC, CountryName ASC

GO
--Countries and Currency (Eurzone)
SELECT 
	CountryName,
	CountryCode,
	CASE 
		WHEN CurrencyCode = 'EUR' THEN 'Inside' ELSE 'Outside' 
	END AS Eurozone
FROM Countries
ORDER BY CountryName ASC

GO
--Teams Holding Numbers
SELECT TeamName AS [Team Name], CountryCode AS [Country Code]
FROM Teams
WHERE TeamName LIKE '%[0-9]%'
ORDER BY CountryCode

GO
--International Matches
SELECT 
	hc.CountryName AS [Home Team], ac.CountryName AS [Away Team], i.MatchDate AS [Match Date]
FROM InternationalMatches i
JOIN Countries hc
ON i.HomeCountryCode = hc.CountryCode
JOIN Countries ac
ON i.AwayCountryCode = ac.CountryCode
ORDER BY [Match Date] DESC

GO
--Teams with their League and League Country
SELECT 
	TeamName AS [Team Name],
	l.LeagueName AS [League],
	ISNULL(c.CountryName, 'International') AS [League Country]
FROM Teams t
JOIN Leagues_Teams lt
ON t.Id = lt.TeamId
JOIN Leagues l
ON lt.LeagueId = l.Id
LEFT JOIN Countries c
ON l.CountryCode = c.CountryCode
ORDER BY [Team Name], League

GO
--Teams with more than One Match
BEGIN TRAN
CREATE TABLE #Temp1 ( Team nvarchar(100), [Matches Count] int )

INSERT INTO #Temp1 (Team, [Matches Count])
	SELECT TeamName, COUNT(TeamName)
	FROM Teams t 
	JOIN TeamMatches tm 
	ON tm.HomeTeamId = t.Id
	WHERE tm.MatchDate IS NOT NULL
	GROUP BY TeamName
	ORDER BY TeamName

INSERT INTO #Temp1 (Team, [Matches Count])
	SELECT TeamName, COUNT(TeamName)
	FROM Teams t 
	JOIN TeamMatches tm 
	ON tm.AwayTeamId = t.Id
	WHERE tm.MatchDate IS NOT NULL
	GROUP BY TeamName
	ORDER BY TeamName


SELECT Team, SUM([Matches Count]) AS [Matches Count]
FROM #Temp1
GROUP BY Team
HAVING SUM([Matches Count]) > 1
ORDER BY Team

ROLLBACK TRAN

GO
--Number of Teams and Matches in Leagues
BEGIN TRAN
CREATE TABLE #Temp2 ( [League Name] nvarchar(100), [Teams] int, [Matches] int, [Average Goals] int )

INSERT INTO #Temp2 SELECT LeagueName AS [League Name], 0 AS Teams, COUNT(tm.Id) AS Matches, AVG(tm.HomeGoals + tm.AwayGoals) AS [Average Goals] 
FROM Leagues l
LEFT JOIN TeamMatches tm
ON l.Id = tm.LeagueId
LEFT JOIN Teams t
ON tm.HomeTeamId = t.Id
GROUP BY LeagueName

UPDATE #Temp2 SET Teams = t.Teams
FROM (SELECT 
	l.LeagueName AS [League Name],
	COUNT(t.TeamName) AS [Teams]
FROM Leagues l
JOIN Leagues_Teams lt
ON lt.LeagueId = l.Id
JOIN Teams t
ON lt.TeamId = t.Id
GROUP BY l.LeagueName) t
WHERE #Temp2.[League Name] = t.[League Name]

SELECT [League Name], Teams, Matches, ISNULL([Average Goals], 0) AS [Average Goals]
FROM #Temp2
ORDER BY Teams DESC, Matches DESC

ROLLBACK TRAN

GO
--Total Goals per Team in all Matches
BEGIN TRAN

CREATE TABLE #Temp3 ( [TeamName] nvarchar(100), Goals int)

INSERT INTO #Temp3 SELECT TeamName, SUM(tm.HomeGoals)
FROM Teams t
LEFT JOIN TeamMatches tm
ON t.Id = tm.HomeTeamId
GROUP BY TeamName

INSERT INTO #Temp3 SELECT TeamName, SUM(tm.AwayGoals)
FROM Teams t
LEFT JOIN TeamMatches tm
ON t.Id = tm.AwayTeamId
GROUP BY TeamName

SELECT TeamName, ISNULL(SUM(Goals), 0) AS [Total Goals]
FROM #Temp3
GROUP BY TeamName
ORDER BY [Total Goals] DESC, TeamName ASC

ROLLBACK TRAN

GO
--Pairs of Matches on the Same Day
SELECT a.MatchDate AS [First Date], t.MatchDate AS [Second Date]
FROM TeamMatches t, TeamMatches a
WHERE a.MatchDate < t.MatchDate AND convert(varchar, t.MatchDate, 103) = convert(varchar, a.MatchDate, 103)
ORDER BY a.MatchDate DESC, t.MatchDate DESC

SELECT a.MatchDate AS [First Date], t.MatchDate AS [Second Date]
FROM TeamMatches t, TeamMatches a
WHERE t.MatchDate > a.MatchDate AND DATEDIFF(day, a.MatchDate, t.MatchDate) < 1
ORDER BY a.MatchDate DESC, t.MatchDate DESC

GO
--Mix of Team Names
SELECT LOWER(t1.TeamName + RIGHT(REVERSE(t2.TeamName), LEN(t2.TeamName) - 1)) AS Mix
FROM Teams t1, Teams t2
WHERE RIGHT(t1.TeamName, 1) = LEFT(REVERSE(t2.TeamName), 1)
ORDER BY Mix ASC

GO
--Countries with International and Team Matches
BEGIN TRAN
CREATE TABLE #Temp5 ( Country nvarchar(100), imatches int, tmatches int)

INSERT INTO #Temp5 SELECT c.CountryName, COUNT(i.Id), 0
FROM Countries c
LEFT JOIN InternationalMatches i
ON c.CountryCode = i.AwayCountryCode
GROUP BY c.CountryName

INSERT INTO #Temp5 SELECT c.CountryName, COUNT(i.Id), 0
FROM Countries c
LEFT JOIN InternationalMatches i
ON c.CountryCode = i.HomeCountryCode
GROUP BY c.CountryName

INSERT INTO #Temp5 
	SELECT ca.CountryName, 0, COUNT(ca.CountryName)
	FROM TeamMatches tm
	JOIN Teams t
	ON tm.HomeTeamId = t.Id
	JOIN Countries c
	ON t.CountryCode = c.CountryCode
	JOIN Teams ta
	ON tm.AwayTeamId = ta.Id
	JOIN Countries ca
	ON ta.CountryCode = ca.CountryCode
	WHERE  c.CountryName = ca.CountryName
	GROUP BY  ca.CountryName


SELECT 
	Country AS [Country Name], 
	SUM(imatches) AS [International Matches], 
	SUM(tmatches) AS [Team Matches] 
FROM #Temp5 
GROUP BY Country
HAVING SUM(imatches) >= 1 OR SUM(tmatches) >= 1
ORDER BY SUM(imatches) DESC, SUM(tmatches) DESC, Country ASC

ROLLBACK TRAN

GO
--Changes in the Database
BEGIN TRAN
CREATE TABLE FriendlyMatches(
	Id int PRIMARY KEY IDENTITY,
	HomeTeamId int,
	AwayTeamId int,
	MatchDate datetime,
	CONSTRAINT FK_FriendlyMatchesHomeTeam FOREIGN KEY (HomeTeamId)
	REFERENCES Teams(Id),
	CONSTRAINT FK_FriendlyMatchesAwayTeam FOREIGN KEY (AwayTeamId)
	REFERENCES Teams(Id),
) 

GO

INSERT INTO Teams(TeamName) VALUES
 ('US All Stars'),
 ('Formula 1 Drivers'),
 ('Actors'),
 ('FIFA Legends'),
 ('UEFA Legends'),
 ('Svetlio & The Legends')
GO

INSERT INTO FriendlyMatches(
  HomeTeamId, AwayTeamId, MatchDate) VALUES
  
((SELECT Id FROM Teams WHERE TeamName='US All Stars'), 
 (SELECT Id FROM Teams WHERE TeamName='Liverpool'),
 '30-Jun-2015 17:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Formula 1 Drivers'), 
 (SELECT Id FROM Teams WHERE TeamName='Porto'),
 '12-May-2015 10:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Actors'), 
 (SELECT Id FROM Teams WHERE TeamName='Manchester United'),
 '30-Jan-2015 17:00'),

((SELECT Id FROM Teams WHERE TeamName='FIFA Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='UEFA Legends'),
 '23-Dec-2015 18:00'),

((SELECT Id FROM Teams WHERE TeamName='Svetlio & The Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='Ludogorets'),
 '22-Jun-2015 21:00')

GO

CREATE TABLE #Temp6 ( [Home Team] nvarchar(100), [Away Team] nvarchar(100), [Match Date] datetime)

INSERT INTO #Temp6 SELECT th.TeamName, ta.TeamName, f.MatchDate 
FROM FriendlyMatches f
JOIN Teams th
ON f.HomeTeamId = th.Id
JOIN Teams ta
ON f.AwayTeamId = ta.Id

INSERT INTO #Temp6 SELECT th.TeamName, ta.TeamName, tm.MatchDate
FROM TeamMatches tm
JOIN Teams th
ON tm.HomeTeamId = th.Id
JOIN Teams ta
ON tm.AwayTeamId = ta.Id

SELECT * FROM #Temp6 ORDER BY [Match Date] DESC

GO
--Seasonal Matches
ALTER TABLE Leagues ADD IsSeasonal bit

SELECT * FROM TeamMatches

INSERT INTO TeamMatches (HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId) VALUES (
	(SELECT Id
	FROM Teams
	WHERE TeamName = 'Empoli'
	),
	(SELECT Id
	FROM Teams
	WHERE TeamName = 'Parma'
	),
	2,
	2,
	CAST('19-Apr-2015 16:00' AS datetime),
	(SELECT Id
	FROM Leagues
	WHERE LeagueName LIKE 'Italian%'
	)
)

INSERT INTO TeamMatches (HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId) VALUES (
	(SELECT Id
	FROM Teams
	WHERE TeamName = 'Internazionale'
	),
	(SELECT Id
	FROM Teams
	WHERE TeamName = 'AC Milan'
	),
	0,
	0,
	CAST('19-Apr-2015 21:45' AS datetime),
	(SELECT Id
	FROM Leagues
	WHERE LeagueName LIKE 'Italian%'
	)
)

UPDATE Leagues SET IsSeasonal = 0 WHERE IsSeasonal IS NULL

GO

SELECT * FROM Leagues

UPDATE Leagues SET IsSeasonal = 1
WHERE LeagueName IN (SELECT l.LeagueName
	FROM Leagues l
	LEFT JOIN TeamMatches tm
	ON l.Id = tm.LeagueId
	GROUP BY LeagueName
	HAVING COUNT(tm.Id) > 0)

GO

COMMIT TRAN

GO

SELECT
	th.TeamName AS [Home Team], 
	tm.HomeGoals AS [Home Goals],
	ta.TeamName AS [Away Team], 
	tm.AwayGoals AS [Away Goals],
	l.LeagueName AS [League Name]
FROM Leagues l
JOIN TeamMatches tm
ON l.Id = tm.LeagueId
JOIN Teams th
ON th.id = tm.HomeTeamId
JOIN Teams ta
ON ta.id = tm.AwayTeamId
WHERE l.IsSeasonal = 1 AND tm.MatchDate > CAST('10-Apr-2015 00:00' AS datetime)
ORDER BY l.LeagueName, [Home Goals] DESC, [Away Goals] DESC

GO

SELECT 
	t.TeamName,
	(SELECT TeamName
	FROM Teams
	WHERE Id = tm.HomeTeamId
	), 
	tm.HomeGoals,
	(SELECT TeamName
	FROM Teams
	WHERE Id = tm.AwayTeamId
	),
	tm.AwayGoals,
	CONVERT(nvarchar, tm.MatchDate, 103)
FROM Teams t 
LEFT JOIN TeamMatches tm
ON t.Id = tm.HomeTeamId OR t.Id = tm.AwayTeamId
WHERE t.CountryCode = 'BG'
ORDER BY t.TeamName, tm.MatchDate DESC