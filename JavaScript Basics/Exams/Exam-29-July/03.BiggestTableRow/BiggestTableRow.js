function solve(arr) {
    var maxSum = -50000000000000000000000000;
    var maxEq = "";
    for (var row = 2; row < arr.length - 1; row++) {
        var line = arr[row].replace(/<tr>/g, '').replace(/<\/tr>/g, '').replace(/<td>/g, '').replace(/<\/td>/g, '|').split("|").filter(function (x) { return !isNaN(x) }).filter(function (x) { return x });
        //console.log(line);
        //console.log(line.length);
        var sum = 0;
        if (line.length > 0) {
            line.forEach(function(x) { sum += Number(x) });
        }
        //console.log(typeof sum);
        //console.log(typeof  maxSum);
        var equation = line.join(" + ");
        if (sum > maxSum) {
            maxSum = sum;
            maxEq = equation;
            //console.log("t");
        }
        //console.log(sum);
        //console.log(equation);
    }
    if (equation === "") {
        console.log("no data");
    } else {
        console.log(maxSum + " = " + maxEq);
    }
}

//solve([
//    "<table>",
//    "<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>",
//    "<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>",
//    "<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>",
//    "<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>",
//    "<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>",
//    "</table>"
//]);

//solve([
//    "<table>",
//    "<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>",
//    "<tr><td>Sofia</td><td>-26.2</td><td>-8.20</td><td>-</td></tr>",
//    "<tr><td>Varna</td><td>-8.20</td><td>-26.2</td><td>-</td></tr>",
//    "</table>"
//]);

solve(["<table>",
"<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>",
"<tr><td>Sofia</td><td>-</td><td>-</td><td>-</td></tr>",
"</table>]"]);