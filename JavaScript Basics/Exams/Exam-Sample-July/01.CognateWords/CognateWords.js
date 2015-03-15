function solve(arr) {
    var words = arr[0].split(/[^a-zA-Z]+/g);
    //for (var i = 0; i < words.length; i++) {
    //    console.log(words[i]);
    //}
    var found = false;
    var foundWords = {};
    var len = words.length;
    for (var w1 = 0; w1 < len; w1++) {
        for (var w2 = 0; w2 < len; w2++) {
            for (var w3 = 0; w3 < len; w3++) {
                if (w1 !== w2 && w1 !== w3 && w2 !== w3) {
                    if (words[w1] + words[w2] === words[w3] && words[w1] !== "" && words[w2] !== "" && words[w3] !== "") {
                        var word = words[w1] + "|" + words[w2] + "=" + words[w3];
                        foundWords[word] = word;
                    }
                }
            }
        }
    }
    for (var match in foundWords) {
        console.log(foundWords[match]);
        found = true;
    }
    if (!found) {
        console.log("No");
    }
}

//solve(["java..?|basics/*-+=javabasics"]);
//solve(["Hi, Hi, Hihi"]);
//solve(["Uni(lo,.ve=I love SoftUni (Soft)"]);
//solve(["a a aa a"]);