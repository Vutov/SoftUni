function solve(arr) {
    var biggestFan = [new Date(1973, 04, 25), false];
    var biggestHater = [new Date(1973, 04, 25), false];
    arr.forEach(function (x) {
        var data = x.split('.');
        var date = new Date(data[2], Number(data[1]) - 1, data[0]);
        //console.log(new Date())
        if (date > new Date(1900, 0, 1) && date < new Date(2015, 0, 1)) {
            //hater
            //console.log(date)
            //console.log(new Date(1973, 04, 25))
            if (date < new Date(1973, 04, 25)) {
                // console.log(date)
                if (date < biggestHater[0]) {
                    biggestHater[0] = date;
                    biggestHater[1] = true;
                }
            } else {
                //fans
                if (date > biggestFan[0]) {
                    biggestFan[0] = date;
                    biggestFan[1] = true;
                }
            }
        }
        
        
    });
    if (biggestFan[1]) {
        console.log('The biggest fan of ewoks was born on ' + biggestFan[0].toDateString());
    }
    if (biggestHater[1]) {
        console.log('The biggest hater of ewoks was born on ' + biggestHater[0].toDateString());
    }
    if (!biggestFan[0] && !biggestHater[0]) {
        console.log('No result');
    }

}

solve([
    '22.03.2014',
    '17.05.1933',
    '10.10.1954'
]);

//younges
//olders