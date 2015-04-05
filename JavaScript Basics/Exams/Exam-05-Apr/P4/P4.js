function solve(arr) {
    var data = [];
    var regex = /(\w+)\s+(\w+)\s*vs\.\s*(\w+)\s+(\w+)\s*:\s*/g;
    arr.forEach(function (x) {
        var match;
        var firstPlayer = "";
        var secondPlayer = "";
        while (match = regex.exec(x)) {
            firstPlayer = match[1] + " " + match[2];
            secondPlayer = match[3] + " " + match[4];
        }
        var score = x.replace(regex, "");
        //console.log(score)
        var sets = score.split(/\s+/g);
        //console.log(sets)
        var setsWon = 0;
        var setsLost = 0;
        var gamesWon = 0;
        var gamesLost = 0;
        sets.forEach(function (curSet) {
            curSet = curSet.split('-');
            gamesWon += Number(curSet[0]);
            gamesLost += Number(curSet[1]);
            
            if (Number(curSet[0]) > Number(curSet[1])) {
                setsWon++;
            } else {
                setsLost++;
            }
        });
        //console.log(setsWon);
        //console.log(setsLost);
        //console.log(gamesWon)
        //console.log(gamesLost)
        var matchesWon = 0;
        var matchesLost = 0;
        if (setsWon > setsLost) {
            matchesWon = 1;
        } else {
            matchesLost = 1;
        }
        //console.log(won)
        //console.log(firstPlayer);
        //console.log(secondPlayer);
        //console.log(temp);
        
        //PlayerOne;
        var found = false;
        for (var i in data) {
            var player = data[i];
            if (player['name'] === firstPlayer) {
                player['matchesWon'] += matchesWon;
                player['matchesLost'] += matchesLost;
                player['setsWon'] += setsWon;
                player['setsLost'] += setsLost;
                player['gamesWon'] += gamesWon;
                player['gamesLost'] += gamesLost;
                found = true;
            }
        }
        if (!found) {
            var player = { name: firstPlayer , matchesWon: matchesWon, matchesLost: matchesLost , setsWon: setsWon , setsLost: setsLost , gamesWon: gamesWon , gamesLost: gamesLost };
            data.push(player);
        }
        //PlayerTwo;
        found = false;
        for (var i in data) {
            var player = data[i];
            if (player['name'] === secondPlayer) {
                player['matchesWon'] += matchesLost;
                player['matchesLost'] += matchesWon;
                player['setsWon'] += setsLost;
                player['setsLost'] += setsWon;
                player['gamesWon'] += gamesLost;
                player['gamesLost'] += gamesWon;
                found = true;
            }
        }
        if (!found) {
            var player = { name: secondPlayer , matchesWon: matchesLost, matchesLost: matchesWon , setsWon: setsLost , setsLost: setsWon , gamesWon: gamesLost , gamesLost: gamesWon };
            data.push(player);
        }


    });
    
    data.sort(function (x, y) {
        if (Number(x["matchesWon"]) !== Number(y["matchesWon"])) {
            return Number(y["matchesWon"]) - Number(x["matchesWon"]);
        } else {
            if (Number(x["setsWon"]) !== Number(y["setsWon"])) {
                return Number(y["setsWon"]) - Number(x["setsWon"]);
            } else {
                if (Number(x["gamesWon"]) !== Number(y["gamesWon"])) {
                    return Number(y["gamesWon"]) - Number(x["gamesWon"]);
                }
                else {
                    return x["name"].localeCompare(y['name']);
                }
            }
        }
    });

    console.log(JSON.stringify(data));
}

//[] trim names, check for whitespace
//{Name: , matchesWon: , matchesLost: , setsWon: , setsLost: , gamesWon: , gamesLost: }

solve([
    'Novak Djokovic vs. Roger Federer : 6-3 6-3',
    'Roger    Federer    vs.        Novak Djokovic    :         6-2 6-3',
    'Rafael Nadal vs. Andy Murray : 4-6 6-2 5-7',
    'Andy Murray vs. David Ferrer : 6-4 7-6',
    'Tomas Bedrych vs. Kei Nishikori : 4-6 6-4 6-3 4-6 5-7',
    'Grigor Dimitrov vs. Milos Raonic : 6-3 4-6 7-6 6-2',
    'Pete Sampras vs. Andre Agassi : 2-1',
    'Boris Beckervs.Andre        			Agassi:2-1'
]);

//solve([
//    'Novak Djokovic vs. Roger Federer : 1-2 1-2 0-1',
//    'Novak D    vs.        Aak   Djo    :    1-2 1-2 0-1'
//]);