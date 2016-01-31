function solve(arr) {
    var regexUser = /#([a-zA-Z][a-zA-Z0-9\-_]*[a-zA-Z0-9])[\s!,.:?]/;
    var regexCode = /<code>[\s\S]*?<\/code>/g;

    var bannedUsers = (arr[arr.length - 1]).split(' ');
    arr.splice(arr.length - 1, 1);
    var result = "";
    arr.forEach(function (row) {
        result += "\n" + row;
    });

    result += " ";

    var codes = result.match(regexCode);
    if (codes) {
        var codeIndex = 0;
        codes.forEach(function (code) {
            result = result.replace(code, "<code>" + codeIndex + "</code>");
            codeIndex++;
        });
    }


    var foundUser = result.match(regexUser);
    while (foundUser) {
        var user = foundUser[1];
        if (user.length >= 3) {
            if (bannedUsers.indexOf(user) === -1) {
                var anchor = '<a href="/users/profile/show/' + user + '">' + user + '</a>';
                result = result.replace("#" + user, anchor);
            } else {
                var reduct = "";
                for (var i = 0; i < user.length; i++) {
                    reduct += '*';
                }

                result = result.replace("#" + user, reduct);
            }
        }

        foundUser = result.match(regexUser);
    }

    if (codes) {
        codeIndex = 0;
        codes.forEach(function (code) {
            result = result.replace("<code>" + codeIndex + "</code>", code);
            codeIndex++;
        });
    }

    console.log(result);
}

solve([
    "#RoYaLinio: I'm not sure what you mean,",
    "#RoYaL: I'm not sure what you mean,",
    "#RoYaL: I'm not sure what you mean,",
    "#RoYaLinio: I'm not sure what you mean,",
    "but I am confident that I've written",
    "everything correctly. Ask #iordan_93",
    "and #pesho if you don't believe me",

    "#123, or #Asd_golemiq_ ",
    "pesho gosho",
]);