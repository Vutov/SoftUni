function solve(arr) {
    var regex = /\s*(.+?)\s*-\s*(.+?)\s*:\s*(\d+)/;
    var result = {};
    arr.forEach(function (student) {
        var data = student.match(regex);
        var name = data[1];
        var exam = data[2];
        var grade = parseInt(data[3]);
        if (grade >= 0 && grade <= 400) {
            if (!result[exam]) {
                result[exam] = [];
            }

            var retaker = false;
            result[exam].forEach(function (s) {
                if (s.name === name) {
                    if (s.result < grade) {
                        s.result = grade;
                    }

                    s.makeUpExams++;
                    retaker = true;
                }
            });

            if (!retaker) {
                var studentRow = { "name": name, "result": grade, makeUpExams: 0 };
                result[exam].push(studentRow);
            }
        }
    });

    for (var disceplin in result) {
        result[disceplin].sort(function (a, b) {
            if (a.result === b.result) {
                if (a.makeUpExams === b.makeUpExams) {
                    return a.name.localeCompare(b.name);
                }

                return a.makeUpExams - b.makeUpExams;
            }

            return b.result - a.result;
        });
    }

    console.log(JSON.stringify(result));
}

solve([
    "Simon Cowell - PHP : 100",
    "Simon Cowell-PHP: 500",
    "Peter Jackson - PHP: 350",
    "Simon Cowell - PHP : 400",
]);