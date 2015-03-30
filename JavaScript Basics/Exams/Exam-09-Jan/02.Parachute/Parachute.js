function solve(arr) {
    var pos = 0;
    //arr.forEach(function(x) { console.log(x) });
    var parRow = 0;
    for (var l = 0; l < arr.length; l++) {
        var firstLine = arr[l].split('');
        for (var k = 0; k < firstLine.length; k++) {
            if (firstLine[k] === 'o') {
                pos = k;
                parRow = l;
            }
        }
    }
    
    for (var j = parRow +1; j < arr.length; j++) {
        var moveLeft = 0;
        var moveRight = 0;
        var ch = arr[j].split('');
        for (var i = 0; i < ch.length; i++) {
            if (ch[i] === '<') {
                moveLeft++;
            } else if (ch[i] === '>') {
                moveRight++;
            }
        }
        pos += (moveRight - moveLeft);
        //console.log(pos);
        if (ch[pos] === '_') {
            //console.log(ch[pos]);
            console.log('Landed on the ground like a boss!');
            console.log(j + ' ' + pos);
            break;
        } 
        else if (ch[pos] === '~') {
            //console.log(ch[pos]);
            console.log('Drowned in the water like a cat!');
            console.log(j + ' ' + pos);
            break;
        } 
        else if (
            ch[pos] === '/' || 
            ch[pos] === '\\' || 
            ch[pos] === '|'
            ) {
            //console.log(ch[pos]);
            console.log('Got smacked on the rock like a dog!');
            console.log(j + ' ' + pos);
            break;
        }
    }

}


//solve([
//    '-------------o-<<--------',
//    '-------->>>>>------------',
//    '---------------->-<---<--',
//    '------<<<<<-------/\\--<--',
//    '--------------<--/-<\\----',
//    '>>--------/\\----/<-<-\\---',
//    '---------/<-\\--/------\\--',
//    '<-------/----\\/--------\\-',
//    '\------/--------------<-\\',
//    '-\___~/------<-----------'
//]);

solve([
    '--o----------------------',
    '>------------------------',
    '>------------------------',
    '>-----------------/\\-----',
    '-----------------/--\\----',
    '>---------/\\----/----\\---',
    '---------/--\\--/------\\--',
    '<-------/----\\/--------\\-',
    '\\------/----------------\\',
    '-\\____/------------------'
]);