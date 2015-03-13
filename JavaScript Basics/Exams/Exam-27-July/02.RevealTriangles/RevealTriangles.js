function solve(arr) {
    var lines = arr.length;
    //Check every possible little triangle;
    for (var i = 0; i < lines - 1; i++) {
        for (var row = 1; row < arr[i].length; row++) {
            var upper = arr[i].charAt(row);
            var lower = arr[i + 1].substring(row - 1, row + 2);
            if (areSame(upper, lower)) {
                //Mark found combinations;
                arr[i] = replaceAt(arr[i], row, upper.toUpperCase());
                arr[i + 1] = replaceAt(arr[i + 1], row - 1, upper.toUpperCase());
                arr[i + 1] = replaceAt(arr[i + 1], row, upper.toUpperCase());
                arr[i + 1] = replaceAt(arr[i + 1], row + 1, upper.toUpperCase());
            }
        }
        //console.log(arr[i]);
    }
    //console.log(arr[arr.length - 1]);

    //Replace with * and print;
    for (var i = 0; i < arr.length; i++) {
        arr[i] = replaceUpper(arr[i]);
         console.log(arr[i]);
    }
    
    function replaceAt(line, index, character) {
        return line.substr(0, index) + character + line.substr(index + character.length);
    }
    
    function areSame(sample, line) {
        sample = sample.toLowerCase();
        line = line.toString().toLowerCase();
        if (sample.charAt(0) === line.charAt(0) && sample.charAt(0) === line.charAt(1) && sample.charAt(0) === line.charAt(2)) {
            return true;
        } else {
            return false;
        }
    }
    
    function replaceUpper(line, ch) {
        for (var j = 0; j < line.length; j++) {
            var ch = line.charAt(j);
            if (ch >= 'A' && ch <= 'Z') {
                line = replaceAt(line, j, '*');
            }
        }
        return line;
    }

}

//solve(['abcdexgh', 'bbbdxxxh', 'abcxxxxx']);
//solve([
//    'aa',
//    'aaa',
//    'aaaa ',
//    'aaaaa ',
//]);