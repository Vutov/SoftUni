function solve(arr) {
    var longest = 0;
    var result = [];
    arr = arr.map(function (line) {
        result.push(line.split(''));
        if (line.length > longest) {
            longest = line.length;
        }
        return line.toLowerCase();
    });
    for (var l = 0; l < arr.length - 2; l++) {
        for (var r = 1; r < longest; r++) {
            if (arr[l][r] === arr[l + 1][r] &&
                arr[l][r] === arr[l + 1][r + 1] &&
                arr[l][r] === arr[l + 1][r - 1] &&
                arr[l][r] === arr[l + 2][r]
                ) {
                result[l][r] = '';
                result[l + 1][r] = '';
                result[l + 1][r + 1] = '';
                result[l + 1][r - 1] = '';
                result[l + 2][r] = '';
            }
        }
    }
    result.forEach(function(line) {
        console.log(line.join(''));
    });
}