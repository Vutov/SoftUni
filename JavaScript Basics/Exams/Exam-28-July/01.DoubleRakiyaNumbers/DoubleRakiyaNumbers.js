function solve(arr) {
    var startNum = Number(arr[0]);
    var endNum = Number(arr[1]);
    //console.log(startNum);
    console.log("<ul>");
    for (var i = startNum; i <= endNum; i++) {
        var num = i.toString();
        var rakiaNum = false;
        for (var j = 0; j < num.length; j++) {
            //console.log(num.slice(j, j + 2));
            var firstRakiaPart = num.slice(j, j + 2);
            for (var k = j + 2; k < num.length; k++) {
                //console.log(num.slice(k, k + 2));
                var secondRakiaPart = num.slice(k, k + 2);
                if (firstRakiaPart === secondRakiaPart) {
                    //console.log(i);
                    rakiaNum = true;
                }
            }
            //console.log(";;;;;");
        }
        if (rakiaNum) {
            console.log("<li><span class='rakiya'>" + i + "</span><a href=\"view.php?id=" + i + ">View</a></li>");
        } else {
            console.log("<li><span class='num'>" + i + "</span></li>");
        }
    }
    console.log("</ul>");
}

//solve(["5", "8"]);
//solve(["11210", "11215"]);
//solve(["55555", "55560"]);