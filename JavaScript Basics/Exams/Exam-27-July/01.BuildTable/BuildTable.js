function Solve(arr) {
    var start = Number(arr[0]);
    var end = Number(arr[1]);

    function isFib(val) {
        var prev = 0;
        var curr = 1;
        while (prev <= val) {
            if (prev === val) {
                return "yes";
            }
            curr = prev + curr;
            prev = curr - prev;
        }

        return "no";
    }

    var result = "<table>\n<tr><th>Num</th><th>Square</th><th>Fib</th></tr>\n";
    for (var i = start; i <= end; i++) {
        result += "<tr><td>" + i + "</td><td>" + Math.pow(i, 2) + "</td><td>" + isFib(i) + "</td></tr>\n";

    }
    result += "</table>";
    //console.log(result);
    return result;
}

//Solve([2, 6]);
//Solve([55, 56]);

//http://justindavis.co/2014/10/30/determine-if-a-number-is-in-the-fibonacci-series-using-javascript/
