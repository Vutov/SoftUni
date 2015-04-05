function solve(arr) {
    var regex = /(?:{(&)})|(?:{(\*)})|(?:{(\#)})|(?:{(!)})/g;
    var found = [0, 0, 0, 0];
    
    function eat(row) {
        var match;
        while (match = regex.exec(row)) {
            //console.log(match)
            if (match[1]) {
                found[0]++;
            }
            if (match[2]) {
                found[1]++;
            }
            if (match[3]) {
                found[2]++;
            }
            if (match[4]) {
                found[3]++;
            }
        }
    }
    
    var directions = arr[0].split(/\W+/g);
    var currPosRow = 0;
    var currPosCol = 0;
    var matrix = [];
    for (var row = 1; row < arr.length; row++) {
        var currRow = arr[row].split(', ');
        //console.log(currRow[0]);
        matrix.push(currRow);
    }
    var wall = 0;
    var visitedCells = [];
    directions.forEach(function (dir) {
        if (dir === 'up') {
            if (currPosRow > 0) {
                currPosRow--;
                eat(matrix[currPosRow][currPosCol]);
                //console.log(currPosRow)
                //console.log(currPosCol)
                //console.log(matrix[currPosRow][currPosCol])
                matrix[currPosRow][currPosCol] = matrix[currPosRow][currPosCol].replace(regex, '@');
                visitedCells.push(matrix[currPosRow][currPosCol]);
            } else {
                wall++;
            }
        }
        if (dir === 'down') {
            //console.log(matrix.length)
            if (currPosRow < matrix.length - 1) {
                currPosRow++;
                eat(matrix[currPosRow][currPosCol]);
                //console.log(currPosRow)
                //console.log(currPosCol)
               // console.log(matrix[currPosRow][currPosCol])
                matrix[currPosRow][currPosCol] = matrix[currPosRow][currPosCol].replace(regex, '@');
                visitedCells.push(matrix[currPosRow][currPosCol]);
            } else {
                wall++;
            }
        }
        if (dir === 'left') {
            if (currPosCol > 0) {
                currPosCol--;
                eat(matrix[currPosRow][currPosCol]);
                //console.log(currPosRow)
                //console.log(currPosCol)
                //console.log(matrix[currPosRow][currPosCol])
                matrix[currPosRow][currPosCol] = matrix[currPosRow][currPosCol].replace(regex, '@');
                visitedCells.push(matrix[currPosRow][currPosCol]);
            } else {
                wall++;
            }
        }
        if (dir === 'right') {
            if (currPosCol < matrix[currPosRow].length - 1) {
                currPosCol++;
                eat(matrix[currPosRow][currPosCol]);
                //console.log(currPosRow)
                //console.log(currPosCol)
                //console.log(matrix[currPosRow][currPosCol])
                matrix[currPosRow][currPosCol] = matrix[currPosRow][currPosCol].replace(regex, '@');
                visitedCells.push(matrix[currPosRow][currPosCol]);
            } else {
                wall++;
            }
        }

    });
    //console.log(matrix)
    console.log("{\"&\":" + found[0] + "," + "\"*\":" + found[1] + "," + "\"#\":" + found[2] + "," + "\"!\":" + found[3] + "," + "\"wall hits\":" + wall + "}");
    //console.log(found)
    //console.log(wall)
    if (visitedCells.length !== 0) {
        console.log(visitedCells.join("|"));
    } else {
        console.log("no");
    }
    
}

solve(['up, right, left, down', 'as{!}xnk']);
//solve(['right, up, up, down', 'asdf, as{#}aj{g}dasd, kjldk{}fdffd, jdflk{#}jdfj', 'tr{X}yrty, zxx{*}zxc, mncvnvcn, popipoip', 'poiopipo, nmf{X}d{X}ei, mzoijwq, omcxzne']);