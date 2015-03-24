function solve(arr) {
    var validNum = arr.filter(function (x) {
        return Number(x) > 10;
    }).map(function (x) {
        return Math.floor(Number(x));
    });
    console.log("<table border=\"1\">");
    console.log("<thead>");
    console.log("<tr><th colspan=\"3\">Blades</th></tr>");
    console.log("<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>");
    console.log("</thead>");
    console.log("<tbody>");
    validNum.forEach(function (x) {
        var type = "";
        var len = x % 5;
        switch (len) {
            case 1:
                type = "blade";
                break;
            case 2:
                type = "quite a blade";
                break;
            case 3:
                type = "pants-scraper";
                break;
            case 4:
                type = "frog-butcher";
                break;
            case 0:
                type = "*rap-poker";
                break;
        }
        if (x > 40) {
            console.log("<tr><td>" + x + "</td><td>sword</td><td>" + type + "</td></tr>");
        } else {
            console.log("<tr><td>" + x + "</td><td>dagger</td><td>" + type + "</td></tr>");
        }
    });
    console.log("</tbody>");
    console.log("</table>");
    //console.log(validNum);
}

solve([
    "17.8",
    "19.4",
    "13",
    "55.8",
    "126.96541651",
    "3"
]);