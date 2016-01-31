function solve(arr) {
    var regex = /\s*([^\s]+)\s*([^\s]+)\s*([^\s]+)\s*([^\s]+)\s*/;
    var lastRow = arr[arr.length - 1].trim();
    arr.splice(arr.length - 1, 1);
    var result = [];
    arr.forEach(function (row) {
        var matches = row.match(regex);
        var examPoints = parseInt(matches[3]);
        var failed = false;
        if (examPoints < 100) {
            failed = true;
        }
        var coursePoints = parseInt(matches[3]) * 0.2 + parseInt(matches[4]);
        var grade = ((coursePoints / 80) * 4) + 2;
        if (grade > 6) {
            grade = 6;
        }
        var student = {
            "name": matches[1],
            "exam": matches[2],
            "examPoints": examPoints,
            "points": Number(coursePoints.toFixed(2)),
            "grade": grade.toFixed(2),
            "failed": failed
        };
        result.push(student);
    });

    var totalForCourse = 0;
    var numberOfStudents = 0;
    result.forEach(function (student) {
        if (student.exam === lastRow) {
            totalForCourse += student.examPoints;
            numberOfStudents++;
        }
    });

    var averagePoints = Number((totalForCourse / numberOfStudents).toFixed(2));
    result.forEach(function (student) {
        if (student.failed) {
            console.log(student.name + ' failed at "' + student.exam + '"');
        } else {
            console.log(student.name + ': Exam - "' + student.exam + '"; Points - ' + student.points +
                '; Grade - ' + student.grade);
        }
    });
    console.log('"' + lastRow + '" average points -> ' + averagePoints);
}

solve([
    "Pesho C#-Advanced 100 3",
    "Gosho Java-Basics 157 3",
    "Tosho HTML&CSS 317 12",
    "Minka C#-Advanced 57 15",
    "Stanka C#-Advanced 157 15",
    "Kircho C#-Advanced 300 0",
    "Niki C#-Advanced 400 10",
    "C#-Advanced",
]);