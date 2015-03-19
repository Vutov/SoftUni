function sortLetters(str, order) {
    var letters = str.split("").sort(function (x, y) {
        if (order) {
            return x.toLowerCase() > y.toLowerCase();
        } else {
            return x.toLowerCase() < y.toLowerCase();
        }
        
    });
    console.log(letters.join(""));
}


sortLetters('HelloWorld', true);// 'deHllloorW'
sortLetters('HelloWorld', false);// 'WroolllHed'
