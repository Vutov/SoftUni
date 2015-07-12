--09 NOT WORKING

begin tran
CREATE TABLE #Temp6 ( [Username] nvarchar(100), [Game] nvarchar(100), [Character] nvarchar(100),
	[Strength] int, [Defence] int, [Speed] int, [Mind] int, [Luck] int)

insert into #Temp6 ([Username], [Game], [Character], [Strength],[Defence],[Speed],[Mind],[Luck])
select u.Username, g.Name, max(c.Name), max(s.Strength), max(s.Defence),max(s.Speed), max(s.Mind), max(s.Luck)
from Users u left join UsersGames ug on u.Id = ug.UserId left join Games g on g.Id = ug.GameId
left join Characters c on c.Id = ug.CharacterId left join [Statistics] s on s.Id = c.StatisticId
group by u.Username, g.Name

insert into #Temp6 ([Username], [Game], [Character], [Strength],[Defence],[Speed],[Mind],[Luck]) 
select u.Username, g.Name, max(c.Name), max(s.Strength), max(s.Defence),max(s.Speed), max(s.Mind), max(s.Luck)
from Users u join UsersGames ug on u.Id = ug.UserId join Games g on g.Id = ug.GameId join Characters c on c.Id = ug.CharacterId
join GameTypes gt on gt.Id = g.GameTypeId join [Statistics] s on gt.BonusStatsId = s.Id
group by u.Username, g.Name

insert into #Temp6 ([Username], [Game], [Character], [Strength],[Defence],[Speed],[Mind],[Luck]) 
select u.Username, g.Name, max(c.Name), sum(s.Strength), sum(s.Defence),sum(s.Speed), sum(s.Mind), sum(s.Luck)
from Users u join UsersGames ug on u.Id = ug.UserId join Games g on g.Id = ug.GameId join Characters c on c.Id = ug.CharacterId
join UserGameItems gi on gi.UserGameId = ug.Id join items i on i.Id = gi.ItemId join [Statistics] s on i.StatisticId = s.Id
group by u.Username, g.Name

select Username, Game, MAX(Character) as [Character], sum(Strength) as Strength , sum(Defence) as Defence, sum(Speed) as Speed, sum(Mind) as Mind, sum(Luck) as Luck
from #Temp6
group by Username, Game
order by sum(Strength) desc, sum(Defence) desc, sum(Speed) desc,  sum(Mind) desc, sum(Luck)

rollback