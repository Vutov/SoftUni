---Create a database with two tables
CREATE DATABASE TSQLHomework

GO

USE TSQLHomework

GO

CREATE TABLE Persons(
	Id int PRIMARY KEY IDENTITY,
	FirstName nvarchar(25) NOT NULL,
	LastName nvarchar(25) NOT NULL,
	SSN nvarchar(25) NULL
)

CREATE TABLE Accounts(
	Id int PRIMARY KEY IDENTITY,
	PersonId int FOREIGN KEY REFERENCES Persons(Id) NOT NULL,
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

CREATE PROC udp_get_full_names AS
	SELECT FirstName + ' ' + LastName AS [Full name]
	FROM Persons

GO

EXEC udp_get_full_names

GO
--Create a stored procedure
CREATE PROC udp_get_persons_with_money(@amount money) AS
	SELECT FirstName + ' ' + LastName AS [Full name], Balance
	FROM Persons p
	JOIN Accounts a
	ON p.Id = a.PersonId
	WHERE Balance > @amount

GO

EXEC udp_get_persons_with_money 1000

GO
--Create a function with parameters
CREATE FUNCTION udf_interest(@sum money, @interest float, @months int)
RETURNS money
AS
BEGIN
	DECLARE @newSum money;
	SET @newSum = @sum * (1 + @interest * @months / 12);
	RETURN @newSum;
END

GO

SELECT dbo.udf_interest(1000, 0.1, 12)

GO
--Create a stored procedure that uses the function from the previous example.
CREATE PROC udp_interest_accounts(@accountId int, @interest float) AS
UPDATE Accounts SET Balance = dbo.udf_interest(Balance, @interest, 1) WHERE Id = @accountId

GO

SELECT * FROM Accounts WHERE Id = 1

EXEC udp_interest_accounts 1, 0.1

SELECT * FROM Accounts WHERE Id = 1

GO
--Add two more stored procedures WithdrawMoney and DepositMoney.
CREATE PROC DepositMoney(@accountId int, @money money) AS
UPDATE Accounts SET Balance = Balance + @money WHERE Id = @accountId

GO

CREATE PROC WithdrawMoney(@accountId int, @money money) AS
DECLARE @balance money;
SET @balance = (SELECT Balance FROM Accounts WHERE Id=@accountId)
--No logic in it, just testing IF
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

GO
--Create table Logs.
CREATE TABLE Logs(
	Id int PRIMARY KEY IDENTITY,
	AccountID int NOT NULL,
	OldSum money NOT NULL,
	NewSum money NOT NULL,
)

GO

CREATE TRIGGER udt_sum_change 
ON Accounts
FOR UPDATE AS
INSERT INTO Logs 
	SELECT 
	d.Id,
	d.Balance,
	i.Balance
	FROM deleted d, inserted i

GO

EXEC DepositMoney 2, 100

EXEC WithdrawMoney 2, 200

SELECT * FROM Logs

GO
--Define function in the SoftUni database.
USE SoftUni

GO
CREATE FUNCTION ufn_ContainingLetters (@Word nvarchar(50), @Letters nvarchar(50))
RETURNS bit
AS
BEGIN
	DECLARE @WordLength int;
	DECLARE @Counter int;
	DECLARE @CurrentLetter nvarchar(1);

	SET @Counter = 1;
	SET @WordLength = LEN(@Word);

	-- Check Input
	IF @WordLength = 0 OR @Word IS NULL
		RETURN 0;
	WHILE @Counter <= @WordLength
		BEGIN
			SET @CurrentLetter = SUBSTRING(@Word, @Counter, 1);
			IF CHARINDEX(@CurrentLetter, @Letters) = 0
				BEGIN
					RETURN 0;
				END
			SET @Counter = @Counter + 1;
		END
	RETURN 1;
END
GO

CREATE FUNCTION ufn_FindEmployeesContainingLetters ( @Letters nvarchar(50) )
RETURNS TABLE
AS
RETURN
	SELECT emp.FirstName, emp.MiddleName, emp.LastName, Towns.Name
	FROM Employees AS emp
	JOIN Addresses AS adr
	ON emp.AddressID = adr.AddressID
	JOIN Towns
	ON adr.TownID = Towns.TownID
	WHERE 
		dbo.ufn_ContainingLetters(LOWER(Towns.Name), @Letters) = 1
		AND (
			dbo.ufn_ContainingLetters(LOWER(emp.FirstName), @Letters) = 1
			OR 
			dbo.ufn_ContainingLetters(LOWER(ISNULL(emp.MiddleName, '')), @Letters) = 1
			OR 
			dbo.ufn_ContainingLetters(LOWER(emp.LastName), @Letters) = 1
			)
GO

SELECT * FROM ufn_FindEmployeesContainingLetters('oistmiahf')

GO

--Using database cursor write a T-SQL
DECLARE Employees_Cursor CURSOR READ_ONLY FOR
 
SELECT fe.FirstName, fe.LastName, ft.Name AS [Town Name], se.FirstName, se.LastName
FROM Employees fe
JOIN Addresses fa
ON fe.AddressID = fa.AddressID
JOIN Towns ft
ON fa.TownID = ft.TownID
CROSS JOIN Employees se
JOIN Addresses sa
ON se.AddressID = sa.AddressID
JOIN Towns st
ON sa.TownID = st.TownID
WHERE ft.Name = st.Name AND fe.EmployeeID != se.EmployeeID
ORDER BY fe.FirstName, se.FirstName
 
OPEN Employees_Cursor
DECLARE @firstName1 NVARCHAR(50), @lastName1 NVARCHAR(50), @town NVARCHAR(50), 
	@firstName2 NVARCHAR(50), @lastName2 NVARCHAR(50)

FETCH NEXT FROM Employees_Cursor INTO 
	@firstName1, @lastName1, @town, @firstName2, @lastName2
 
WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT 
		@town + ': ' + 
		@firstName1 + ' ' + @lastName1 +
		', ' +
		@firstName2 + ' ' + @lastName2
	FETCH NEXT FROM Employees_Cursor INTO
		@firstName1, @lastName1, @town, @firstName2, @lastName2
END
 
CLOSE Employees_Cursor
DEALLOCATE Employees_Cursor