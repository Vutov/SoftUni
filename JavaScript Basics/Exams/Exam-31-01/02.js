function solve(arr) {
    // This exam problem is bullshit - JS IS NOT C#!
    var numOfSame = parseInt(arr[arr.length - 1].trim());
    arr.splice(arr.length - 1, 1);
    var result = [];
    arr.forEach(function (row) {
        var rowArr = row.split(' ');
        result.push(rowArr);
    });

    var foundSimilar = 0;
    var lastSeen = result[0][0];
    for (var i = 0; i < result.length; i++) {
        for (var j = 0; j < result[i].length; j++) {
            if (result[i][j] === lastSeen) {
                foundSimilar++;
            } else {
                foundSimilar = 1;
                lastSeen = result[i][j];
            }

            if (foundSimilar === numOfSame) {
                foundSimilar = 0;
                var goBackRow = i;
                var goBackCol = j;
                for (var k = 0; k < numOfSame; k++) {
                    result[goBackRow][goBackCol] = "";
                    if (numOfSame - 1 === k) {
                        continue;
                    }
                    if (goBackCol > 0) {
                        goBackCol--;
                    } else {
                        goBackRow--;
                        goBackCol = result[goBackRow].length - 1;
                    }
                }
            }
        }
    }

    for (var h = 0; h < result.length; h++) {
        var rowString = "";
        for (var o = 0; o < result[h].length; o++) {
            rowString += result[h][o] + " ";
        }
        var printString = rowString.trim();
        if (printString === "") {
            console.log("(empty)");
        } else {
            printString = printString.replace(/\s+/g, " ");
            console.log(printString);
        }
    }
}

//solve([
//        "1 2 3 3",
//        "3 5 7 8",
//        "3 2 2 1",
//        "3",
//]);

//solve([
//    "1 2 3 3 2 1",
//    "5 2 2 1 1 0",
//    "3 3 1 3 3",
//    "2",
//]);

solve([
    "3 3 3 2 5 9 9 9 9 1 2",
    "1 1 1 1 1 2 5 8 1 1 7 7",
    "7 1 2 3 5 7 4 4 1 2",
    "2",
]);