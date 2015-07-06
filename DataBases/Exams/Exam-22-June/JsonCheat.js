var data = [
    ["Beroe", "Litex", "1", "Beroe", "1", "11/04/2015"],
    ["Beroe", "Beroe", "1", "Lokomotiv (Sofia)", "4", "05/04/2015"],
    ["Beroe", "CSKA", "0", "Beroe", "0", "21/03/2015"],
    ["Botev (Plovdiv)", "CSKA", "0", "Botev (Plovdiv)", "0", "10/04/2015"],
    ["Botev (Plovdiv)", "Botev (Plovdiv)", "0", "Litex", "1", "05/04/2015"],
    ["Botev (Plovdiv)", "Ludogorets", "0", "Botev (Plovdiv)", "0", "22/03/2015"],
    ["Cherno More", "NULL", "NULL", "NULL", "NULL", "NULL"],
    ["CSKA", "CSKA", "0", "Botev (Plovdiv)", "0", "10/04/2015"],
    ["CSKA", "Ludogorets", "4", "CSKA", "0", "04/04/2015"],
    ["CSKA", "CSKA", "0", "Beroe", "0", "21/03/2015"],
    ["Haskovo", "NULL", "NULL", "NULL", "NULL", "NULL"],
    ["Levski", "NULL", "NULL", "NULL", "NULL", "NULL"],
    ["Litex", "Litex", "1", "Beroe", "1", "11/04/2015"],
    ["Litex", "Botev (Plovdiv)", "0", "Litex", "1", "05/04/2015"],
    ["Litex", "Lokomotiv (Sofia)", "0", "Litex", "0", "22/03/2015"],
    ["Lokomotiv (Plovdiv)", "NULL", "NULL", "NULL", "NULL", "NULL"],
    ["Lokomotiv (Sofia)", "Ludogorets", "0", "Lokomotiv (Sofia)", "0", "11/04/2015"],
    ["Lokomotiv (Sofia)", "Beroe", "1", "Lokomotiv (Sofia)", "4", "05/04/2015"],
    ["Lokomotiv (Sofia)", "Lokomotiv (Sofia)", "0", "Litex", "0", "22/03/2015"],
    ["Ludogorets", "Ludogorets", "0", "Lokomotiv (Sofia)", "0", "11/04/2015"],
    ["Ludogorets", "Ludogorets", "4", "CSKA", "0", "04/04/2015"],
    ["Ludogorets", "Ludogorets", "0", "Botev (Plovdiv)", "0", "22/03/2015"],
    ["Marek", "NULL", "NULL", "NULL", "NULL", "NULL"],
    ["Slavia", "NULL", "NULL", "NULL", "NULL", "NULL"],
];

var json = { "teams": [] };

data.forEach(function (r) {
    var teamName = r[0].trim();
    var firstTeam = r[1].trim();
    var firstScore = parseInt(r[2].trim());
    var secondTeam = r[3].trim();
    var secondScore = parseInt(r[4].trim());
    var date = r[5].replace(/\s+/g, "");
    
    var found = false;
    json.teams.forEach(function (t) {
        if (t.name === teamName) {
            found = true;
            if (firstTeam.toLowerCase() !== "null") {
                var matchInfo = {};
                matchInfo[firstTeam] = firstScore;
                matchInfo[secondTeam] = secondScore;
                matchInfo["date"] = date;
                t.matches.push(matchInfo);
            }
        }
    });
    
    if (!found) {
        var innerJson = {
            "name": teamName,
            "matches": []
        };

        if (firstTeam.toLowerCase() !== "null") {
            var matchInfo = {};
            matchInfo[firstTeam] = firstScore;
            matchInfo[secondTeam] = secondScore;
            matchInfo["date"] = date;
            innerJson.matches.push(matchInfo);
        }

        json.teams.push(innerJson);
    }
});

var json = JSON.stringify(json);
var newjson = json.replace(/"(\d+\/\d+\/\d+)"/g, "$1");

var fs = require('fs');
fs.writeFile("/result.txt", newjson, function (err) {
    if (err) {
        return console.log(err);
    }
    
    console.log("The file was saved!");
}); 