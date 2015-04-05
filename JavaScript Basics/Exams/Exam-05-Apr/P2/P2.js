function solve(arr) {
    var allowedJumps = Number(arr[0]);
    var len = Number(arr[1]);
    var field = [];
    for (var i = 2; i < arr.length; i++) {
        var data = arr[i].split(', ');
        var nick = data[0].slice(0, 1).toUpperCase();
        var dist = Number(data[1]);
        field.push({ name: data[0], dist: dist, currentPos: 0, nick: nick });
    }
    var ds = '';
    for (var k = 0; k < len; k++) {
        ds += '#';
    }
    var winner = false;
    var winFlea = 'NoFuckingOne';
    for (var j = 0; j < allowedJumps; j++) {
        if (!winner) {
            for (var flea in field) {
                //console.log(flea);
                //console.log(field[flea])
                var curFlea = field[flea];
                curFlea['currentPos'] += curFlea['dist'];
                if (curFlea['currentPos'] >= len - 1) {
                    //console.log(ds);
                    //console.log(ds);
                    //console.log('win ' + curFlea['name']);
                    winFlea = curFlea['name'];
                    winner = true;
                    break;
                }
            }
        }
    }
    //Print;
    console.log(ds);
    console.log(ds);
    var furthest = {maxRange: 0, name: ""};
    for (var flea in field) {
        //console.log(flea);
        //console.log(field[flea])
        var curFlea = field[flea];
        var line = '';
        //console.log(curFlea["currentPos"]);
        var dots = curFlea["currentPos"];
        if (curFlea["currentPos"] >= len) {
            dots = len - 1;
        }
        for (var l = 0; l < dots; l++) {
            line += '.';
        }
        line += curFlea["nick"];
        for (var l = line.length; l < len; l++) {
            line += '.';
        }
        if (furthest["maxRange"] <= curFlea["currentPos"] ) {
            furthest["maxRange"] = curFlea["currentPos"];
            furthest["name"] = curFlea["name"];
        }
        console.log(line);
    }
    console.log(ds);
    console.log(ds);
    if (winFlea === 'NoFuckingOne') {
        //console.log(furthest)
        winFlea = furthest["name"];
    }
    console.log('Winner: ' + winFlea);
    //console.log(field)
}

solve([
    '10',
    '19',
    'angel, 9',
    'Boris, 10',
    'Georgi, 3',
    'Dimitar, 7'
]);

//solve([
//    '3',
//    '5',
//    'cura, 1',
//    'Pepi, 1',
//    'Ult, 1',
//    'Boiko, 1'
//]);