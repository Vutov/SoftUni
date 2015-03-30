function solve(arr) {
    var match;
    var regex = /<p>(.+?)<\/p>/g;
    var decripted = "";
    while (match = regex.exec(arr[0])) {
        decripted += match[1];
    }
    decripted = decripted.replace(/[^a-z0-9\\s]+/g, ' ').replace(/\\s+/g);
    decripted = decripted.split('');
    decripted = decripted.map(function(char) {
        var charNum = char.charCodeAt(0);
        //console.log(charNum)
        if (charNum >= 97 && charNum < 110) {
            return String.fromCharCode(charNum + 13);
        }
        else if (charNum >= 110 && charNum <= 122) {
            return String.fromCharCode(charNum - 13);
        } else {
            return char;
        }
    });
    console.log(decripted.join(''));
}

solve(["<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>"]);
solve(["<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>"]);