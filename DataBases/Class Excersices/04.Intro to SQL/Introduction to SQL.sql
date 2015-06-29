CREATE DATABASE Excersice_Intro_To_Sql

GO

USE Excersice_Intro_To_Sql

GO

CREATE TABLE Players(
	Id int PRIMARY KEY IDENTITY,
	Username nvarchar(30) NOT NULL,
	Email nvarchar(50) NOT NULL,
	[Password] nvarchar(50) NOT NULL,
	Points int NOT NULL
)

CREATE TABLE Planets(
	Id int PRIMARY KEY IDENTITY,
	PlayerId int FOREIGN KEY REFERENCES Players(Id),
	X int NOT NULL,
	Y int NOT NULL,
	Z int NOT NULL,
	Crystal int NOT NULL,
	Metal int NOT NULL,
)

CREATE TABLE BuildingNames(
	Id int PRIMARY KEY IDENTITY,
	Name nvarchar(50) NOT NULL
)

CREATE TABLE Buildings(
	Id int PRIMARY KEY IDENTITY,
	BuildingNameId int FOREIGN KEY REFERENCES BuildingNames(Id),
	[Level] int NOT NULL,
	MetalCost int NOT NULL,
	CrystalCost int NOT NULL 
)

CREATE TABLE Planets_Buildings(
	PlanetId int NOT NULL REFERENCES Planets(Id),
	BuildingId int NOT NULL REFERENCES Buildings(Id),
	PRIMARY KEY (PlanetId, BuildingId) 
)

GO

INSERT INTO BuildingNames VALUES
	('metal mine'),
	('mineral  mine'),
	('fusion  reactor')

INSERT INTO Players VALUES
	('Me', 'Me@me', 'mememem', 0),
	('Bot', 'Bot@Bot', 'Bot', 0)

INSERT INTO Planets VALUES
	(1, 100,100,100, 1000,1000),
	(1, 101,101,101, 1000,1000),
	(2, 150,150,150, 1000,1000),
	(2, 151,151,151, 1000,1000)

INSERT INTO Buildings VALUES
	(1, 0, 1000, 500),
	(2, 0, 1000, 500),
	(3, 0, 1000, 500),
	(1, 0, 1000, 500),
	(2, 0, 1000, 500),
	(3, 0, 1000, 500),
	(1, 0, 1000, 500),
	(2, 0, 1000, 500),
	(3, 0, 1000, 500),
	(1, 0, 1000, 500),
	(2, 0, 1000, 500),
	(3, 0, 1000, 500)

INSERT INTO Planets_Buildings VALUES
	(1,1),(1,2),(1,3),
	(2,1),(2,2),(2,3),
	(3,1),(3,2),(3,3),
	(4,1),(4,2),(4,3)

GO

SELECT * From Planets_Buildings

GO

UPDATE Players SET Points = 2000 WHERE Id = 2

SELECT Id, Username, Points
FROM Players
ORDER BY Points DESC

GO

SELECT p.Username, pl.Metal, pl.Crystal
FROM Players p
JOIN Planets pl
ON p.Id = pl.PlayerId

GO

UPDATE Planets SET Metal = 11999 WHERE Id = 4

SELECT p.Username, SUM(pl.Metal) AS [AllMetal], SUM(pl.Crystal) AS [AllCrystal]
FROM Players p
JOIN Planets pl
ON p.Id = pl.PlayerId
GROUP BY p.Username
ORDER BY SUM(pl.Metal) + SUM(pl.Crystal) DESC

GO

SELECT p.Username, pl.Id AS [Planet Id], bn.Name AS [Building Name], b.[Level]
FROM Players p
JOIN Planets pl
ON p.Id = pl.PlayerId
JOIN Planets_Buildings pb
ON pl.Id = pb.PlanetId
JOIN Buildings b
ON pb.BuildingId = b.Id
JOIN BuildingNames bn
ON b.BuildingNameId = bn.Id