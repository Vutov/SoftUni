USE master

GO

CREATE DATABASE School

GO

USE School

GO

CREATE TABLE Classes(
	Id int PRIMARY KEY IDENTITY,
	Name nvarchar(25) NOT NULL,
	MaxStudents int NOT NULL,
)

GO

CREATE TABLE Students(
	Id int PRIMARY KEY IDENTITY,
	Name nvarchar(25) NOT NULL,
	Age int NULL,
	PhoneNumber nvarchar(25) NULL,
	ClassId int FOREIGN KEY REFERENCES Classes(Id)
)

GO

INSERT INTO Classes VALUES('Math', 102)
INSERT INTO Classes VALUES('AT', 120)
INSERT INTO Classes VALUES('MS', 2200)
INSERT INTO Classes VALUES('TG', 50)
INSERT INTO Students VALUES('Pesho', 20, '08888888', 1)
INSERT INTO Students VALUES('Ivan', 30, NULL, 2)
INSERT INTO Students VALUES('Mitko', 40, NULL, 4)
INSERT INTO Students VALUES('Mariq', 50, NULL, 1)
INSERT INTO Students VALUES('Gogo', 55, '0142323424', 2)

GO

SELECT s.Name, s.Age, s.PhoneNumber, c.Name, c.MaxStudents AS [Max students in class]
FROM Students s
JOIN Classes c
ON s.ClassId = c.Id

GO

USE master

DROP DATABASE School