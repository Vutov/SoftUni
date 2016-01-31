function solve(arr) {
    var regex = /mine\s+[^-]*-\s+(gold|silver|diamonds)\s*:\s+(\d+)/;
    var result = { "silver": 0, "gold": 0, "diamonds": 0 };
    arr.forEach(function (row) {
        row = row.toLowerCase();
        var matches = row.match(regex);
        if (matches) {
            result[matches[1]] += parseInt(matches[2]);
        }
        
    });

    console.log('*Silver: ' + result["silver"]);
    console.log('*Gold: ' + result["gold"]);
    console.log('*Diamonds: ' + result["diamonds"]);
}

solve([
    'mine bobovDol - gold: 10"',
    'mine medenRudnik - silver: 22"',
    'mine chernoMore - shrimps : 24"',
    'gold: 50'
]);