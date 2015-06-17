--Create a database with two tables
CREATE DATABASE TSQL
GO

USE TSQL

CREATE TABLE Persons(
	Id int PRIMARY KEY IDENTITY,
	FirstName nvarchar(25) NOT NULL,
	LastName nvarchar(25) NOT NULL,
	SSN text NULL
)

CREATE TABLE Accounts(
	Id int PRIMARY KEY IDENTITY,
	PersonId int FOREIGN KEY REFERENCES Persons(Id),
	Balance money NOT NULL
)

GO

INSERT INTO Persons VALUES('test', 'test', '123')
INSERT INTO Persons VALUES('test2', 'test2', '123')
INSERT INTO Persons VALUES('test3', 'test3', '123')
INSERT INTO Persons VALUES('test4', 'test4', '123')
INSERT INTO Accounts VALUES(1, 132)
INSERT INTO Accounts VALUES(2, 1322)
INSERT INTO Accounts VALUES(3, 13442)

GO 

CREATE PROC get_names AS
SELECT FirstName
FROM Persons

GO

EXEC get_names

GO

--Create a stored procedure
CREATE PROC get_persons_with_less_money(@money money) AS
SELECT p.FirstName + ' ' + p.LastName AS [Name], Balance
FROM Accounts a
JOIN Persons p
ON a.PersonId = p.Id
WHERE a.Balance <= @money

GO

EXEC get_persons_with_less_money 1000

GO

--Create a function with parameters
CREATE FUNCTION udf_interest_calc(@sum money, @interestRate float, @months int)
RETURNS money
AS
BEGIN
	DECLARE @newSum money;
	SET @newSum = @sum * (1 + @interestRate * @months / 12);
	RETURN @newSum;
END

GO

--Create a stored procedure that uses the function from the previous example.
CREATE PROC out_of_names(@accountId int, @interest float) AS
SELECT 
	p.FirstName + ' ' + p.LastName AS [Name],
	a.Balance AS [Old Balance],
	dbo.udf_interest_calc(a.Balance, @interest, 1) AS [New Balance]
FROM Persons p
JOIN Accounts a
ON p.Id = a.PersonId
WHERE a.Id = @accountId

GO

EXEC out_of_names 1, 0.08

GO

--Add two more stored procedures WithdrawMoney and DepositMoney.
CREATE PROC DepositMoney(@accountId int, @money money) AS
UPDATE Accounts SET Balance = Balance + @money WHERE Id=@accountId

GO

CREATE PROC WithdrawMoney(@accountId int, @money money) AS
DECLARE @balance money;
SET @balance = (SELECT Balance FROM Accounts WHERE Id=@accountId)
IF @balance - @money < 0
	BEGIN
		UPDATE Accounts SET Balance = 0 WHERE Id=@accountId
	END
ELSE
	BEGIN
		UPDATE Accounts SET Balance = Balance - @money WHERE Id=@accountId
	END

GO

SELECT * FROM Accounts WHERE Id=1

EXEC DepositMoney 1, 100

EXEC WithdrawMoney 1, 200