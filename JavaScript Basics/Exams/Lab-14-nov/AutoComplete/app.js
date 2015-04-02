function solve(arr) {
    var text = arr[0].split(' ');
    arr.shift(0);
    arr.forEach(function (x) {
        var matchingWords = [];
        text.forEach(function (word) {
            //console.log(word.slice(0, x.length));
            if (word.toLowerCase().slice(0, x.length) === x.toLowerCase()) {
                matchingWords.push(word);
            }
        });
        matchingWords.sort(function(x, y) {
            if (x.length === y.length) {
                //console.log("1");
                return x.toLowerCase().localeCompare(y.toLowerCase());
            } else {
                return x.length - y.length;
            }
        });
        if (matchingWords.length !== 0) {
            console.log(matchingWords[0]);
        } else {
            console.log('-');
        }
        //console.log(matchingWords);
        //console.log('--');
    });
}

solve([
    'word screammm screech speech wolf',
    'bas',
    'wo',
    'scr',
    's'
]);