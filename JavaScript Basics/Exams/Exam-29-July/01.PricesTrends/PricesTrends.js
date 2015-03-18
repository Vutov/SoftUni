function solve(arr) {
    console.log("<table>");
    console.log("<tr><th>Price</th><th>Trend</th></tr>");
    console.log("<tr><td>" + Number(arr[0]).toFixed(2) + "</td><td><img src=\"fixed.png\"/></td></td>");
    for (var i = 1; i < arr.length; i++) {
        var prevNum = Number(arr[i - 1]).toFixed(2);
        var currentNum = Number(arr[i]).toFixed(2);
        prevNum = Number(prevNum);
        currentNum = Number(currentNum);
        //console.log(typeof Number(prevNum));
        var sufix = 'fixed';
        if (prevNum < currentNum) {
            sufix = 'up';
        }
        else if (prevNum > currentNum) {
            sufix = 'down';
        }
        console.log("<tr><td>" + currentNum.toFixed(2) + "</td><td><img src=\"" + sufix + ".png\"/></td></td>");
    }
    console.log("</table>");
}

solve([
    "36.333",
    "36.5",
    "37.019",
    "35.4",
    "35",
    "35.001",
    "36.225"
]);