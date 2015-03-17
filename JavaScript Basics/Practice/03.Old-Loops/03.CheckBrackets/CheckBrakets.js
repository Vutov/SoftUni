function checkBrackets(str) {
    var letters = str.split(/[^()]+/g);
    letters = letters.filter(function(x) {
        return x;
    });
    var incorect = false;
    var opening = 0;
    //console.log(letters);
    letters.forEach(function (x) {
        
        if (x === '(') {
            opening++;
        }
        else if (x === ')') {
            opening--;
            if (opening < 0) {
                incorect = true;
                return;
            }
        }
    });
    if (incorect || opening !== 0) {
        console.log("incorrect");
    } else {
        console.log("correct");
    }
}

checkBrackets('( ( a + b ) / 5 – d )');
checkBrackets(') ( a + b ) )');
checkBrackets('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )');