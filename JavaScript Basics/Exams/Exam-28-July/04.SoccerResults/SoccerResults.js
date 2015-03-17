function solve(arr) {
    var json = {};
    arr.forEach(function (line) {
        var data = line.split(/[/:-]+/).map(function (x) { return x.trim() });
        var firstCountry = data[0];
        var secondCountry = data[1];
        var scoresFirst = Number(data[2]);
        var scoresSecond = Number(data[3]);
        
        fillJson(firstCountry, scoresFirst, scoresSecond, secondCountry);
        fillJson(secondCountry, scoresSecond, scoresFirst, firstCountry);
    });
    json = sortObj(json);
    
    function fillJson(country, scored, recieved, playedAgainst) {
        if (!json[country]) {
            json[country] = {};
        }
        if (!json[country]['goalsScored']) {
            json[country]['goalsScored'] = scored;
        } else {
            json[country]['goalsScored'] = json[country]['goalsScored'] + scored;
        }
        if (!json[country]['goalsConceded']) {
            json[country]['goalsConceded'] = recieved;
        } else {
            json[country]['goalsConceded'] = json[country]['goalsConceded'] + recieved;
        }
        if (!json[country]['matchesPlayedWith']) {
            json[country]['matchesPlayedWith'] = [playedAgainst];
        } else {
            if (json[country]['matchesPlayedWith'].indexOf(playedAgainst) === -1) {
                json[country]['matchesPlayedWith'].push(playedAgainst);
            }
                
        }
    }
    
    
    function sortObj(arr) {
        // Setup Arrays
        var sortedKeys = new Array();
        var sortedObj = {};
        
        // Separate keys and sort them
        for (var i in arr) {
            sortedKeys.push(i);
        
        }
        sortedKeys.sort();
        
        // Reconstruct sorted obj based on keys
        for (var i in sortedKeys) {
            sortedObj[sortedKeys[i]] = arr[sortedKeys[i]];
            
        }
        return sortedObj;
       
    }
    
    for (var team in json) {
        json[team]['matchesPlayedWith'].sort();
        //console.log(json[team]['matchesPlayedWith']);
    }
    
    //console.log(json);
    console.log(JSON.stringify(json));
}

//solve([
//    "Germany / Argentina: 1-0",
//    "Germany / Argentina: 0-3"
//]);