function solve(arr) {
    arr.forEach(function (x) {
        var line = x.replace(/%20/g, ' ').replace(/\+/g, ' ').replace(/\?/g, '&');
        //console.log(line);
        var data = {};
        var regex = /([^&]+)=([^&]+)/g;
        var match;
        while (match = regex.exec(line)) {
            match[1] = match[1].replace(/\s+/g, ' ');
            match[2] = match[2].replace(/\s+/g, ' ');
            var field = match[1].trim();
            var value = match[2].trim();
            if (!data[field]) {
                data[field] = [];
            }
            data[field].push(value);
            //console.log("key: " + match[1].trim());
            //console.log("val: " + match[2].trim());
        }
        //console.log(data);
        line = "";
        for (var field in data) {
            line += field + "=" + "[" + data[field].join(', ') + "]";
        }
        console.log(line);
    });
}

solve([
    "foo=%20foo&value=+val&foo+=5+%20+203",
    "foo=poo%20&value=valley&dog=wow+",
    "url = https://softuni.bg/trainings/coursesinstances/details/1070",
    "https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php"
]);
solve(["login=student&password=student"]);
solve([
    "field=value1&field=value2&field=value3",
    "http://example.com/over/there?name=ferret"
]);

//replace &20 and + ? for &