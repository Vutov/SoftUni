function replaceSpaces(str) {
    var letters = str.split(" ");
    letters = letters.filter(function(x) {
        return x;
    });
    console.log(letters.join(""));
}

replaceSpaces('But you were living in another world tryin\' to get your message through');