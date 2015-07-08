USE Forum
GO

--01.
SELECT Title
FROM Questions
ORDER BY Title ASC

--02.
SELECT Content, CreatedOn
FROM Answers
WHERE CreatedOn BETWEEN CAST('15-June-2012 00:00:00' AS datetime) AND 
	CAST('21-Mar-2013 23:59:59' AS datetime)
ORDER BY CreatedOn

--03.
SELECT Username, LastName,
	CASE 
		WHEN PhoneNumber IS NOT NULL THEN '1' ELSE '0'
	END AS [Has Phone]
FROM Users
ORDER BY LastName, Id

--04.
SELECT q.Title AS [Question Title], u.Username AS [Author]
FROM Questions q
JOIN Users u
ON q.UserId = u.Id
ORDER BY q.Title ASC

--05.
SELECT TOP 50 
	a.Content [Answer Content],
	a.CreatedOn, 
	u.Username AS [Answer Author],
	q.Title AS [Question Title],
	c.Name AS [Category Name]
FROM Answers a
JOIN Questions q
ON a.QuestionId = q.Id
JOIN Users u
ON a.UserId = u.Id
JOIN Categories c
ON q.CategoryId = c.Id
ORDER BY c.Name, u.Username, a.CreatedOn

--06.
SELECT c.Name AS [Category], q.Title AS [Question], q.CreatedOn
FROM Categories c
LEFT JOIN Questions q
ON c.Id = q.CategoryId
ORDER BY c.Name, q.Title

--07.
SELECT u.Id, u.Username, u.FirstName, u.PhoneNumber, u.RegistrationDate, u.Email
FROM Users u
LEFT JOIN Questions q
ON u.Id = q.UserId
WHERE u.PhoneNumber IS NULL AND q.Id IS NULL
ORDER BY RegistrationDate

--08.
SELECT (SELECT MIN(CreatedOn)
FROM Answers
WHERE YEAR(CreatedOn) = '2012') AS [MinDate], (SELECT MAX(CreatedOn)
FROM Answers
WHERE YEAR(CreatedOn) = '2014') AS [MaxDate]

--09.
SELECT TOP 10 Content AS Answer, CreatedOn, u.Username
FROM Answers a
JOIN Users u
ON a.UserId = u.Id
ORDER BY CreatedOn DESC

--10.
DECLARE @lastYear nvarchar(20) = (SELECT YEAR(MAX(CreatedOn)) FROM Answers)

SELECT a.Content AS [Answer Content], q.Title AS [Question], c.Name AS [Category]
FROM Answers a
JOIN Questions q
ON a.QuestionId = q.Id
JOIN Categories c
ON c.Id = q.CategoryId
WHERE YEAR(a.CreatedOn) = @lastYear AND
	(MONTH(a.CreatedOn) = (SELECT MONTH(MIN(CreatedOn)) FROM Answers WHERE YEAR(CreatedOn) = @lastYear) OR
	MONTH(a.CreatedOn) = (SELECT MONTH(MAX(CreatedOn)) FROM Answers WHERE YEAR(CreatedOn) = @lastYear) ) AND
	a.IsHidden = 1
ORDER BY c.Name

--11.
SELECT c.Name AS [Category], COUNT(a.Id) AS [Answers Count] 
FROM Answers a
JOIN Questions q
ON a.QuestionId = q.Id
RIGHT JOIN Categories c
ON q.CategoryId = c.Id
GROUP BY c.Name
ORDER BY COUNT(a.Id) DESC

--12.
SELECT c.Name AS [Category], u.Username, u.PhoneNumber, COUNT(a.Id) AS [Answers Count]
FROM Answers a
JOIN Questions q
ON a.QuestionId = q.Id
RIGHT JOIN Categories c
ON q.CategoryId = c.Id
JOIN Users u
ON a.UserId = u.Id
GROUP BY c.Name, u.Username, u.PhoneNumber
HAVING COUNT(a.Id) > 0 AND u.PhoneNumber IS NOT NULL
ORDER BY COUNT(a.Id) DESC, u.Username

--13.
GO

BEGIN TRAN
CREATE TABLE Towns(
	Id int PRIMARY KEY IDENTITY,
	Name nvarchar(100),
)

ALTER TABLE Users ADD TownId int NULL FOREIGN KEY REFERENCES Towns(Id)

GO

INSERT INTO Towns(Name) VALUES ('Sofia'), ('Berlin'), ('Lyon')
UPDATE Users SET TownId = (SELECT Id FROM Towns WHERE Name='Sofia')
INSERT INTO Towns VALUES
('Munich'), ('Frankfurt'), ('Varna'), ('Hamburg'), ('Paris'), ('Lom'), ('Nantes')

GO

UPDATE Users SET TownId = (SELECT Id FROM Towns WHERE Name = 'Paris') WHERE DATENAME(weekday, RegistrationDate) = 'Friday'

UPDATE Questions SET Title = 'Java += operator' WHERE Id = (SELECT Id FROM Questions WHERE (DATENAME(WEEKDAY, CreatedOn) = 'Monday' OR DATENAME(WEEKDAY, CreatedOn) = 'Sunday') AND MONTH(CreatedOn) = 2)

GO 
SELECT * FROM Answers

ALTER TABLE Votes DROP CONSTRAINT FK_Votes_Answers


GO
DELETE FROM Answers WHERE Id IN (SELECT a.Id
FROM Answers a
JOIN Votes v
ON a.Id = v.AnswerId
GROUP BY a.Id
HAVING SUM(v.Value) < 0)

--ALTER TABLE Votes ADD CONSTRAINT FK_Votes_Answers FOREIGN KEY REFERENCES Answers(Id) 

INSERT INTO Questions (Title, Content, CreatedOn, UserId, CategoryId)VALUES(
	'Fetch NULL values in PDO query',
	'When I run the snippet, NULL values are converted to empty strings. How can fetch NULL values?',
	GETDATE(),
	(SELECT Id
	FROM Users
	WHERE Username = 'darkcat'),
	(SELECT Id
	FROM Categories
	WHERE Name = 'Databases')
)

SELECT t.Name AS [Town], u.Username, COUNT(a.Id) AS [AnswersCount]
FROM Towns t
LEFT JOIN Users u
ON t.Id = u.TownId
LEFT JOIN Answers a
ON u.Id = a.UserId
GROUP BY t.Name, u.Username
ORDER BY COUNT(a.Id) DESC, u.Username


ROLLBACK

--14.
GO
CREATE VIEW AllQuestions
AS 
SELECT u.Id AS [UId], u.Username, u.FirstName, u.Email, u.PhoneNumber, u.RegistrationDate, 
	q.Id AS [QId], q.Title, q.Content, q.CategoryId, q.UserId, q.CreatedOn
FROM Questions q
RIGHT JOIN Users u
ON q.UserId = u.Id

GO
SELECT * FROM AllQuestions

GO
IF OBJECT_ID('fn_ListUsersQuestions') IS NOT NULL
  DROP FUNCTION fn_ListUsersQuestions
GO
CREATE FUNCTION fn_ListUsersQuestions() 
RETURNS  @result TABLE
   (
    UserName nvarchar(150),
	Questions nvarchar(max)
   )
AS
BEGIN
DECLARE empCursor CURSOR READ_ONLY FOR
  SELECT Username, Title
  FROM AllQuestions
  ORDER BY Username ASC, Title DESC 

OPEN empCursor
DECLARE @userName nvarchar(50),@lastUserName nvarchar(50), @question nvarchar(max), @allQuestions nvarchar(max) = ''
FETCH NEXT FROM empCursor INTO @userName, @question
SET @lastUserName = @userName

WHILE @@FETCH_STATUS = 0
  BEGIN
    IF @userName = @lastUserName
		BEGIN
			IF @allQuestions = ''
				SET @allQuestions = @question
			ELSE
				SET @allQuestions = @allQuestions + ', ' + @question
		END
	ELSE
		BEGIN
			INSERT @result VALUES (@lastUserName, @allQuestions)

			--Reset
			SET @allQuestions = @question
			SET @lastUserName = @userName
		END

	FETCH NEXT FROM empCursor INTO @userName, @question
  END

INSERT @result VALUES (@lastUserName, @allQuestions)

CLOSE empCursor
DEALLOCATE empCursor
RETURN
END

GO
SELECT * FROM fn_ListUsersQuestions()