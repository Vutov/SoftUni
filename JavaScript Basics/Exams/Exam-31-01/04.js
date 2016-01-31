function solve(arr) {
    // Get lodash for JUDGE, this is pointless
    var regex = /\s*([^&]+?)\s*&\s*([^&]+?)\s*&\s*([^&]+?)\s*&\s*([^&]+?)\s*&\s*(.+)\s*/;
    var result = {};
    var resultToDisplay = {};
    arr.forEach(function (row) {
        var matches = row.match(regex);
        var name = matches[1];
        var type = matches[2];
        var taskNumber = "Task " + matches[3];
        var score = parseInt(matches[4]);
        var linesOfCode = parseInt(matches[5]);
        if (!result.hasOwnProperty(taskNumber)) {
            result[taskNumber] = { "tasks": [] };
            resultToDisplay[taskNumber] = { "tasks": [] };
        }
        var taskToDisplay = { "name": name, "type": type };
        var task = { "name": name, "type": type, "score": score, "lines": linesOfCode };
        result[taskNumber].tasks.push(task);
        resultToDisplay[taskNumber].tasks.push(taskToDisplay);
    });

    for (var property in result) {
        var tasks = result[property].tasks;
        var totalScore = 0;
        var totalLines = 0;
        tasks.forEach(function (task) {
            totalScore += task.score;
            totalLines += task.lines;
        });

        var averageScore = totalScore / tasks.length;
        resultToDisplay[property].average = Number(averageScore.toFixed(2));
        resultToDisplay[property].lines = totalLines;
    }

    var keysSorted = Object.keys(resultToDisplay).sort(function (a, b) {
        if (resultToDisplay[a].average !== resultToDisplay[b].average) {
            return resultToDisplay[b].average - resultToDisplay[a].average;
        }

        return resultToDisplay[a].lines - resultToDisplay[b].lines;
    });

    var sortedResult = {};
    keysSorted.forEach(function (key) {
        sortedResult[key] = resultToDisplay[key];
    });

    for (var prop in sortedResult) {
        sortedResult[prop].tasks.sort(function (a, b) {
            return a.name.localeCompare(b.name);
        });
    }

    console.log(JSON.stringify(sortedResult));
}

solve([
    "Array Matcher & strings & 4 & 100 & 38",
    "Magic Wand & draw & 3 & 100 & 15",
    "Dream Item & loops & 2 & 88 & 80",
    "Knight Path & bits & 5 & 100 & 65",
    "Basket Battle & conditionals & 2 & 100 & 120",
    "Torrent Pirate & calculations & 1 & 100 & 20",
    "Encrypted Matrix & nested loops & 4 & 90 & 52",
    "Game of bits & bits & 5 &  100 & 18",
    "Fit box in box & conditionals & 1 & 100 & 95",
    "Disk & draw & 3 & 90 & 15",
    "Poker Straight & nested loops & 4 & 40 & 57",
    "Friend Bits & bits & 5 & 100 & 81",
]);


//solve([
//    "Array Matcher & strings & 4 & 100 & 38",
//    "Dream Item & loops & 4 & 88 & 80",
//    "Basket Battle & conditionals & 4 & 100 & 120",
//    "Encrypted Matrix & nested loops & 4 & 90 & 52",
//]);