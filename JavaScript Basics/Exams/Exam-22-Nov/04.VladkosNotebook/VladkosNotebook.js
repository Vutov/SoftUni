function solve(arr) {
    var data = {};
    arr.forEach(function (x) {
        var line = x.split('|');
        var color = line[0];
        var sec = line[1];
        var third = line[2];
        //console.log(line);
        if (!data[color]) {
            data[color] = { age: -1, name: "", opponents: [], rank: [0, 0] };
        }
        if (sec === 'age') {
            data[color]['age'] = third;
        } 
        else if (sec === 'name') {
            data[color]['name'] = third;
        } else {
            data[color]['opponents'].push(third);
            if (sec === 'win') {
                data[color]['rank'][0] += 1;
            } else {
                data[color]['rank'][1] += 1;
            }
        }

    });
    for (var color in data) {
        data[color]['opponents'].sort();
        data[color]['rank'] = ((data[color]['rank'][0] + 1) / (data[color]['rank'][1] + 1)).toFixed(2);
        if (data[color]['name'] === '' || data[color]['age'] === -1) {
            delete data[color];
        }
    }
    data = sortObj(data);
    console.log(JSON.stringify(data));
    
    
    function sortObj(arr) {
        // Setup Arrays
        var sortedKeys = new Array();
        var sortedObj = {};
        
        // Separate keys and sort them
        for (var i in arr) {
            sortedKeys.push(i);
        
        }
        sortedKeys.sort();
        
        // Reconstruct sorted obj based on keys
        for (var i in sortedKeys) {
            sortedObj[sortedKeys[i]] = arr[sortedKeys[i]];
            
        }
        return sortedObj;
       
    }
}

solve([
    "purple|age|99",
    "red|age|44",
    "blue|win|pesho",
    "blue|win|mariya",
    "purple|loss|Kiko",
    "purple|loss|Kiko",
    "purple|loss|Kiko",
    "purple|loss|Yana",
    "purple|loss|Yana",
    "purple|loss|Manov",
    "purple|loss|Manov",
    "red|name|gosho",
    "blue|win|Vladko",
    "purple|loss|Yana",
    "purple|name|VladoKaramfilov",
    "blue|age|21",
    "blue|loss|Pesho"
]);

// { color: {age : int, name :str, opp:[], rank: [win,lose]} }