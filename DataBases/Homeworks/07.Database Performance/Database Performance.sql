--Well I got the patience only for 3000000 rows so the data is for that.
CREATE DATABASE Performance
ALTER DATABASE Performance MODIFY FILE
( NAME = N'Performance' , SIZE = 1GB , MAXSIZE = UNLIMITED, FILEGROWTH = 1000MB ) 
GO

USE Performance
GO

CREATE TABLE SimpleTable(
	Id int PRIMARY KEY IDENTITY,
	SomeText nvarchar(50) NOT NULL,
	SomeDate date NOT NULL
)
GO

DECLARE @currIndex int = 0;

WHILE @currIndex < 10000000
  BEGIN
    INSERT INTO SimpleTable VALUES('SampleText' + CAST(@currIndex AS nvarchar(50)), CAST('1900-1-1' AS datetime) + @currIndex)
	SET @currIndex = @currIndex + 1 
  END

CLOSE empCursor
DEALLOCATE empCursor

 GO

 --clear cache
CHECKPOINT; 
GO 
DBCC DROPCLEANBUFFERS; 
GO

SELECT SomeDate
FROM SimpleTable
WHERE SomeDate LIKE '20%'

GO
CREATE INDEX index_date
ON SimpleTable (SomeDate)

GO
SELECT SomeDate
FROM SimpleTable
WHERE SomeDate LIKE '20%'