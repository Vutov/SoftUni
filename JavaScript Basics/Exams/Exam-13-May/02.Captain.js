function solve(arr) {
    var wordRegex = /\b[a-zA-Z]+\b/g;
    var words = arr[0].toLowerCase().match(wordRegex);
    var resultSet = {};
    words.forEach(function (word) {
        if (resultSet[word]) {
            resultSet[word]++;
        } else {
            resultSet[word] = 1;
        }
    });

    var neededWords = [];
    for (var word in resultSet) {
        if (resultSet[word] >= 3) {
            neededWords.push(word);
        }
    }

    if (neededWords.length === 0) {
        console.log('No words');
        return;
    }
    var sentances = arr[1].match(/\s*(.+?(?:\.|!|\?))\s*/g);
    var printedSentances = 0;
    sentances.forEach(function (sentace) {
        var foundWords = 0;
        neededWords.forEach(function (word) {
            var sentaceWords = sentace.toLowerCase().match(wordRegex);
            if (sentaceWords.indexOf(word) !== -1) {
                foundWords++;
            }
        });

        if (foundWords >= 2) {
            console.log(sentace);
            printedSentances++;
        }
    });

    if (printedSentances === 0) {
        console.log('No sentences');
    }
}

solve([
    "The words: the and are, are repeated more than three thimes. Look in the second text are there sentences with those words",
    "Yup there are no such sentences."
]);