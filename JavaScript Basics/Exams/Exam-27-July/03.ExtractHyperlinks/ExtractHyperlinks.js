function solve(arr) {
    var data = arr.join("\n");
    var regex = /<a\s+(?:[^>]*)href[\s=]+(?:"([^"]*)"|'([^']*)'|([^\s>]*))[^>]*>/g;
    //var match = regex.exec(data);
    var match;
    while (match = regex.exec(data)) {
        var href = match[1];
        if (href === undefined) {
            var href = match[2];
        }
        if (href === undefined) {
            var href = match[3];
        }
        console.log(href);
    }
    //console.log(match[1]);

}

//solve(['<a href="http://softuni.bg" class="new"></a>']);
//solve(['<p>This text has no links</p>']);
//solve(['<!DOCTYPE html>','<html>','<head>','<title>Hyperlinks</title>','<link href="theme.css" rel="stylesheet" />','</head>','<body>','<ul><li><a   href="/"  id="home">Home</a></li><li><a','class="selected" href=/courses>Courses</a>','</li><li><a href = ','\'/forum\' >Forum</a></li><li><a class="href"','onclick="go()" href= "#">Forum</a></li>','<li><a id="js" href =','"javascript:alert(\'hi yo\')" class="new">click</a></li>','<li><a id=\'nakov\' href =','http://www.nakov.com class=\'new\'>nak</a></li></ul>','<a href="#empty"></a>','<a id="href">href=\'fake\'<img src=\'http://abv.bg/i.gif\' ','alt=\'abv\'/></a><a href="#">&lt;a href=\'hello\'&gt;</a>','<!-- This code is commented:','<a href="#commented">commentex hyperlink</a> -->','</body>']);