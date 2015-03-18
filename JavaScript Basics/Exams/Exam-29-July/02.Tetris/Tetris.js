function solve(arr) {
    var field = arr.map(function (x) { return x.split("") });
    //console.log(field);
    
    var iS = 0;
    var lS = 0;
    var jS = 0;
    var oS = 0;
    var zS = 0;
    var sS = 0;
    var tS = 0;
    for (var row = 0; row < field.length - 3; row++) {
        for (var col = 0; col < field[row].length; col++) {
            //console.log(field[row][col]);
            if (field[row][col] === 'o' &&
                field[row][col] === field[row + 1][col] &&
                field[row][col] === field[row + 2][col] &&
                field[row][col] === field[row + 3][col]) {
                iS++;
            }
        }
    }
    //console.log(iS);
    for (var row = 0; row < field.length - 2; row++) {
        for (var col = 0; col < field[row].length - 1; col++) {
            //console.log(field[row][col]);
            if (field[row][col] === 'o' &&
                field[row][col] === field[row + 1][col] &&
                field[row][col] === field[row + 2][col] &&
                field[row][col] === field[row + 2][col + 1]) {
                lS++;
            }
        }
    }
    //console.log(lS);
    for (var row = 0; row < field.length - 2; row++) {
        for (var col = 1; col < field[row].length; col++) {
            //console.log(field[row][col]);
            if (field[row][col] === 'o' &&
                field[row][col] === field[row + 1][col] &&
                field[row][col] === field[row + 2][col] &&
                field[row][col] === field[row + 2][col - 1]) {
                jS++;
            }
        }
    }
    //console.log(jS);
    for (var row = 0; row < field.length - 1; row++) {
        for (var col = 0; col < field[row].length - 1; col++) {
            //console.log(field[row][col]);
            if (field[row][col] === 'o' &&
                field[row][col] === field[row][col + 1] &&
                field[row][col] === field[row + 1][col] &&
                field[row][col] === field[row + 1][col + 1]) {
                oS++;
            }
        }
    }
    //console.log(oS);
    for (var row = 0; row < field.length - 1; row++) {
        for (var col = 0; col < field[row].length - 2; col++) {
            //console.log(field[row][col]);
            if (field[row][col] === 'o' &&
                field[row][col] === field[row][col + 1] &&
                field[row][col] === field[row + 1][col + 1] &&
                field[row][col] === field[row + 1][col + 2]) {
                zS++;
            }
            if (field[row][col + 1] === 'o' &&
                field[row][col + 1] === field[row][col + 2] &&
                field[row][col + 1] === field[row + 1][col] &&
                field[row][col + 1] === field[row + 1][col + 1]) {
                sS++;
            }
            if (field[row][col] === 'o' &&
                field[row][col] === field[row][col + 1] &&
                field[row][col] === field[row][col + 2] &&
                field[row][col] === field[row + 1][col + 1]) {
                tS++;
            }
        }
    }
    //console.log(zS);
    //console.log(sS);
    //console.log(tS);
    var json = {
        I: iS,
        L: lS,
        J: jS,
        O: oS,
        Z: zS,
        S: sS,
        T: tS
    };
    console.log(JSON.stringify(json));
}



solve([
    "--o--o-",
    "--oo-oo",
    "ooo-oo-",
    "-ooooo-",
    "---oo--"
]);