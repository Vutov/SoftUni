function solve(arr) {
    var result = [];
    
    arr = arr.map(function (line) {
        result.push(line.split(''));
        return line.toLowerCase().split('');
    });
    
    for (var row = 0; row < arr.length - 2; row++) {
        for (var col = 0; col < arr[row].length; col++) {
            var sample = arr[row][col];
            if (
                arr[row][col] === arr[row][col + 2] &&
                arr[row][col] === arr[row + 1][col + 1] &&
                arr[row][col] === arr[row + 2][col] &&
                arr[row][col] === arr[row + 2][col + 2]
               ) {
                result[row][col] = '';
                result[row][col + 2] = '';
                result[row + 1][col + 1] = '';
                result[row + 2][col] = '';
                result[row + 2][col + 2] = '';
            }
        }
    }
    
    result.forEach(function (line) {
        console.log(line.filter(function (x) {return x}).join(''));
    });
}

solve([
    "abnbjs",
    "xoBab",
    "Abmbh",
    "aabab",
    "ababvvvv"
]);