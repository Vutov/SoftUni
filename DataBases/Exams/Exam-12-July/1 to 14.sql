use Diablo

GO

--1
SELECT Name 
FROM Characters
ORDER BY Name ASC

GO

--2
SELECT TOP 50 Name AS [Game], left(convert(varchar, Start, 120), 10) AS Start
FROM Games
where YEAR(Start) = 2011 or year(Start) = 2012
order by Start, Name

--3
SELECT Username, RIGHT(Email,LEN(Email)-CHARINDEX('@',Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider] asc, Username asc

SELECT * FROM Users
where Username = 'Pesho'	

--4
SELECT Username, IpAddress as [IP Address]
FROM Users
where IpAddress like '[0-9][0-9][0-9].1%.%.[0-9][0-9][0-9]'
order by Username asc

--5
SELECT Name As Game,
	case 
		when DATEPART(Hour,Start) >= 0 AND DATEPART(Hour,Start) < 12 then 'Morning'
		when DATEPART(Hour,Start) >= 12 and DATEPART(Hour,Start) < 18 then 'Afternoon'
		when DATEPART(Hour,Start) >= 18 and DATEPART(Hour,Start) < 24 then 'Evening'
	end AS [Part of the Day],
	case
		when Duration <= 3 then 'Extra Short'
		when Duration between 4 and 6 then 'Short'
		when Duration > 6 then 'Long'
		when Duration is null then 'Extra Long'
	end AS [Duration]
FROM Games
order by Game asc, [Duration],[Part of the Day]

select * from Games

--6
select RIGHT(Email,LEN(Email)-CHARINDEX('@',Email)) AS [Email Provider], COUNT(RIGHT(Email,LEN(Email)-CHARINDEX('@',Email))) AS [Number Of Users] 
from Users
group by RIGHT(Email,LEN(Email)-CHARINDEX('@',Email))
order by COUNT(RIGHT(Email,LEN(Email)-CHARINDEX('@',Email))) desc , [Email Provider]

--7
select g.Name AS [Game], gt.Name AS [Game Type], u.Username, ug.Level, ug.Cash, c.Name as Character
from Users u
LEFT join UsersGames ug
on u.Id = ug.UserId
LEFT join Games g
on ug.GameId = g.Id
LEFT join GameTypes gt
on g.GameTypeId = gt.Id
left join Characters c
on ug.CharacterId = c.Id
order by Level desc, u.Username ASC, [Game] asc

--8
select u.Username, g.Name as Game, COUNT(i.Id) AS [Items Count], SUM(i.Price) as [Items Price]
from Users u
join UsersGames ug
on u.id = ug.UserId
join Games g
on ug.GameId = g.Id
join UserGameItems ui
on ui.UserGameId = ug.Id
join Items i
on ui.ItemId = i.Id
group by u.Username, g.Name
having COUNT(i.Id) >= 10
order by COUNT(i.Id) desc, SUM(i.Price) desc, u.Username asc

-- 10
select i.Name, i.Price, i.MinLevel, s.Strength, s.Defence, s.Speed, s.Luck, s.Mind 
from Items i 
join [Statistics] s 
on i.StatisticId = s.Id
where s.Mind > 9 and s.Luck > 9 and s.Speed > 9
order by i.Name

--11
select i.Name as Item, i.Price, i.MinLevel, gt.Name as [Forbidden Game Type]
from Items i
join GameTypeForbiddenItems forb
on forb.ItemId = i.Id
join GameTypes gt
on forb.GameTypeId = gt.Id
order by [Forbidden Game Type] desc, i.Name asc

select i.Name as Item, i.Price, i.MinLevel, gt.Name as [Forbidden Game Type]
from Items i
left join GameTypeForbiddenItems forb
on forb.ItemId = i.Id
left join GameTypes gt
on forb.GameTypeId = gt.Id
group by i.Name, i.Price, i.MinLevel, gt.Name
order by [Forbidden Game Type] desc, i.Name asc

select * from Items i join GameTypeForbiddenItems forb on forb.ItemId = i.Id

select * from GameTypeForbiddenItems

--12
GO
BEGIN TRAN

select * from Users
WHERe Username = 'Alex'

select u.Username, g.Name, ug.Cash, i.Name as [Item Name]
from Users u
join UsersGames ug
on ug.UserId = u.Id
join Games g
on ug.GameId = g.Id
join UserGameItems ui
on ug.Id = ui.UserGameId
join Items i
on i.Id = ui.ItemId
where g.Name = 'Edinburgh'
order by i.Name

rollback
select * 
from Games g 
join UsersGames ug
on ug.GameId = g.Id
join UserGameItems ui
on ug.Id = ui.UserGameId
where g.Name = 'Edinburgh'

select Id from Items
where Name = 'Blackguard' or Name = 'Bottomless Potion of Amplification' or
Name = 'Eye of Etlich (Diablo III)' or Name = 'Gem of Efficacious Toxin' or
Name = 'Golden Gorget of Leoric' or Name = 'Hellfire Amulet'

--2957.00
begin tran
update UsersGames set Cash = Cash - 2957 where Id = 235

select u.Username, ug.Id, ug.Cash
from Users u
join UsersGames ug
on ug.UserId = u.Id
join Games g
on ug.GameId = g.Id
where g.Name = 'Edinburgh'

select * from UserGameItems

insert into UserGameItems VALUES (51, 235),
(71, 235),
(157, 235),
(184, 235),
(197, 235),
(223, 235)
--alex 235

select *
from Users u
join UsersGames ug
on ug.UserId = u.Id
join Games g
on ug.GameId = g.Id
join UserGameItems ui
on ug.Id = ui.UserGameId
join Items i
on i.Id = ui.ItemId
where g.Name = 'Edinburgh'
order by i.Name

rollback

--13
select * from Users
WHERe Username = 'Stamat'

select i.Name as [Item Name]
from Users u
join UsersGames ug
on ug.UserId = u.Id
join Games g
on ug.GameId = g.Id
join UserGameItems ui
on ug.Id = ui.UserGameId
join Items i
on i.Id = ui.ItemId
where g.Name = 'Safflower'
order by i.Name

--gold
select SUM(Price) from Items
where MinLevel = 19 or MinLevel = 20 or MinLevel = 21

select Id from Items
where MinLevel = 11 or MinLevel = 12


--11 and 12 = 4777.00 gold
order by MinLevel

--110
begin tran
update UsersGames set Cash = Cash - 4777 where Id = 110

insert into UserGameItems VALUES 
(16, 110),
(45, 110),
(108, 110),
(111, 110),
(176, 110),
(184, 110),
(191, 110),
(194, 110),
(195, 110),
(247, 110),
(280, 110),
(475, 110),
(500, 110),
(552, 110)

select u.Username, ug.Id, ug.Cash
from Users u
join UsersGames ug
on ug.UserId = u.Id
join Games g
on ug.GameId = g.Id
where g.Name = 'Safflower'

select *
from Users u
join UsersGames ug
on ug.UserId = u.Id
join Games g
on ug.GameId = g.Id
where g.Name = 'Safflower'

rollback

--14
IF OBJECT_ID ('fn_CashInUsersGames') IS NOT NULL
    DROP FUNCTION dbo.fn_CashInUsersGames;
GO
CREATE FUNCTION fn_CashInUsersGames(@gameName nvarchar(50))
RETURNS float 
AS 
BEGIN
    DECLARE empCursor CURSOR READ_ONLY FOR
	select Cash from Games g join UsersGames ug on ug.GameId = g.Id
	where g.Name like @gameName
	ORDER by Cash desc

	OPEN empCursor
	DECLARE @sum float = 0, @currentSum float, @currentRow int = 1
	FETCH NEXT FROM empCursor INTO @currentSum

	WHILE @@FETCH_STATUS = 0
	  BEGIN
		if @currentRow % 2 = 1
		BEGIN
			SET @sum = @sum + @currentSum
		END

		SET @currentRow = @currentRow + 1
		FETCH NEXT FROM empCursor INTO @currentSum
	  END
	CLOSE empCursor
	DEALLOCATE empCursor

    RETURN @sum
END
GO

select dbo.fn_CashInUsersGames('Bali') as SumCash
union
select dbo.fn_CashInUsersGames('Lily Stargazer')as SumCash
union
select dbo.fn_CashInUsersGames('Love in a mist')as SumCash
union
select dbo.fn_CashInUsersGames('Mimosa')as SumCash
union
select dbo.fn_CashInUsersGames('Ming fern')as SumCash




select * 
from Games g
join UsersGames ug
on ug.GameId = g.Id
where g.Name like 'Bali'
ORDER by Cash desc

select Cash from Games g join UsersGames ug on ug.GameId = g.Id
	where g.Name like 'Bali'
	ORDER by Cash desc

	
select Cash from Games g join UsersGames ug on ug.GameId = g.Id
	where g.Name like 'Lily Stargazer'
	ORDER by Cash desc

select Cash from Games g join UsersGames ug on ug.GameId = g.Id
	where g.Name like 'Love in a mist'
	ORDER by Cash desc

select Cash from Games g join UsersGames ug on ug.GameId = g.Id
	where g.Name like 'Mimosa'
	ORDER by Cash desc

select Cash from Games g join UsersGames ug on ug.GameId = g.Id
	where g.Name like 'Ming fern'
	ORDER by Cash desc

rollback

--15. NOT WORKING
go
create trigger high_level_items
on UserGameItems
INSTEAD OF Insert AS
IF (SELECT it.MinLevel
	FROM inserted i
	join Items it
	on i.ItemId = it.Id
) < (
	SELECT ug.Level
	FROM inserted i
	join UsersGames ug
	on i.UserGameId = ug.Id)
BEGIN
	INSERT INTO UserGameItems values ((SELECT i.ItemId
FROM inserted i), (SELECT i.UserGameId
FROM inserted i))

	UPDATE UsersGames set Cash = Cash - (
	SELECT it.Price
	FROM inserted i
	join Items it
	on i.ItemId = it.Id) where Id =  (
	SELECT ug.UserId
	FROM inserted i
	join UsersGames ug
	on i.UserGameId = ug.Id)
END
go
