function solve(arr) {
    var lines = arr.split("\n");
    //console.log(lines);
    lines.forEach(function(line) {
        if (line.trim().slice(0, 3) === "<a ") {
            var newLine = line.replace("<a ", "[URL ").replace(">", "]").replace("</a>", "[/URL]");
            console.log(newLine);
        } else {
            console.log(line);
        }
    });
}

solve('<ul>\n <li>\n  <a href=http://softuni.bg>SoftUni</a>\n </li>\n</ul>');