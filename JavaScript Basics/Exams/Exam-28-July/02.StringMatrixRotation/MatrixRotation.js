function solve(arr) {
    var rotation = arr[0].split(/\D+/g).filter(function (x) { return x });
    rotation = rotation[0];
    rotation = (rotation / 90) % 4;
    //console.log(rotation);
    
    var words = [];
    var longestWord = 0;
    for (var i = 1; i < arr.length; i++) {
        words[i - 1] = arr[i].split("");
        longestWord = Math.max(words[i - 1].length, longestWord);
    }
    //console.log(longestWord);
    
    if (rotation / 90 === 0) {
        for (var l = 0; l < words.length; l++) {
            console.log(words[l].join(""));
        }
    }
    else if (rotation === 1) {
        for (var j = 0; j < longestWord; j++) {
            var line = "";
            for (var k = words.length - 1; k >= 0; k--) {
                if (words[k][j]) {
                    line += words[k][j];
                } else {
                    line += " ";
                }
            }
            console.log(line);
        }
    }
    else if (rotation === 2) {
        for (var k = words.length - 1; k >= 0; k--) {
            var line = "";
            for (var j = longestWord - 1; j >= 0; j--) {
                if (words[k][j]) {
                    line += words[k][j];
                } else {
                    line += " ";
                }
            }
            console.log(line);
        }
    } 
    else if (rotation === 3) {
        for (var j = longestWord - 1; j >= 0; j--) {
            var line = "";
            for (var k = 0; k < words.length; k++) {
                if (words[k][j]) {
                    line += words[k][j];
                } else {
                    line += " ";
                }
            }
            console.log(line);
        }
    }
}




//solve(["Rotate(90)", "hello", "softuni", "exam"]);
//solve(["Rotate(180)", "hello", "softuni", "exam"]);
solve(["Rotate(270)", "hello", "softuni", "exam"]);
//solve(["Rotate(360)", "hello", "softuni", "exam"]);