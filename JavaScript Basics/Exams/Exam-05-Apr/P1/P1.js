function solve(arr) {
    var totalCoins = 0;
    arr.forEach(function(line) {
        var data = line.split(' ');
        if ((data[0].toLowerCase()=== 'coin' ||
            data[0].toLowerCase() === 'coins' &&
            !isNaN(data[1]))) {
            if (Number((data[1]) * 10) % 10 === 0 && Number(data[1] >= 0)) {
                totalCoins += Number(data[1]);
            }
        }
    });
    //console.log(totalCoins);
    var gold = Math.floor(totalCoins / 100);
    var silver = Math.floor((totalCoins - gold * 100) / 10);
    var bronze = totalCoins - (gold * 100) - (silver * 10);
    console.log("gold : " +gold);
    console.log("silver : " +silver);
    console.log("bronze : " +bronze);
}

//coin , coins

solve([
    'coins 1',
    'Coin 2.00',
    'coin 5',
    'coin 10',
    'coin 20',
    'coin 50',
    'coin 100',
    'coin 200',
    'coin 500',
    'coin -500',
    'cigars 1'
]);

solve([
    'coins 1',
    'coin two',
    'coin 5',
    'coin 10.50',
    'coin 20',
    'coin 50',
    'coin hundred',
    'cigaras 1'
]);