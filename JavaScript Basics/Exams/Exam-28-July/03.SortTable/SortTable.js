function solve(arr) {
    var regexPrice = /<td>(\d+\.?\d*)<\/td>/;

    var sortedTd = [];
    for (var i = 2; i < arr.length - 1; i++) {
        var line = arr[i];
        var match = regexPrice.exec(line);
        //console.log(match[1]);
        sortedTd.push({ price: match[1], line: line });
    }
    sortedTd.sort(function(x, y) {
        if (x.price !== y.price) {
            return x.price - y.price;
        } else {
            return x.line > y.line;
        }
    });
    var result = [];
    result.push(arr[0]);
    result.push(arr[1]);
    for (var info in sortedTd) {
        result.push(sortedTd[info].line);
    }
    result.push(arr[arr.length - 1]);
    console.log(result.join("\n"));

   

}


solve(["<table>",
"<tr><th>Product</th><th>Price</th><th>Votes</th></tr>",
"<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>",
"<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>",
"<tr><td>Laptop HP 250 G2</td><td>629</td><td>+1</td></tr>",
"<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>",
"<tr><td>Ariana Grapefruit 1.5 l</td><td>1.85</td><td>+7</td></tr>",
"<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>",
"</table>"]);
