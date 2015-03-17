function printNumbers(number) {
    var validNums = [];
    var found = false;
    for (var i = 1; i <= number; i++) {
        if (i % 4 !== 0 && i % 5 !== 0) {
            validNums.push(i);
            found = true;
        }
    }
    if (found) {
        console.log(validNums.toString());
    } else {
        console.log("No");
    }
}

printNumbers(20);
printNumbers(-5);
printNumbers(13);
