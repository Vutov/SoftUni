function solve(arr) {
    var json = {};
    for (var i = 0; i < arr.length - 1; i++) {
        var data = arr[i].split(/\.*\*\.*/g);
        //console.log(data);
        var name = data[0];
        var lugName = data[1];
        var isFood = data[2];
        var isDrink = data[3];
        var isFragile = data[4];
        var weight = Number(data[5]);
        var transferWith = data[6];
        var type = 'other';
        if (isFood === 'true') {
            type = 'food';
        }
        if (isDrink === 'true') {
            type = 'drink';
        }
        if (isFragile === 'true') {
            isFragile = true;
        } else {
            isFragile = false;
        }
        if (!json[name]) {
            json[name] = {};
        }
        if (!json[name][lugName]) {
            json[name][lugName] = { kg: weight, fragile: isFragile, type: type, transferredWith: transferWith };
        }
        json[name][lugName] = { kg : weight, fragile: isFragile, type : type, transferredWith: transferWith };
    }
    var sortType = arr[arr.length - 1];
    if (sortType === 'strict') {
        console.log(JSON.stringify(json));
    }
    else if (sortType === 'luggage name') {
        for (var name in json) {
            json[name] = sortObj(json[name]);
        }
        console.log(JSON.stringify(json));
    }
    else { //Weight
        for (var name in json) {
                json[name]= sortObjByWeight(json[name]);
        }
        console.log(JSON.stringify(json));
    }
    
    //console.log(json);
    
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
    
    function sortObjByWeight(arr) {
        // Setup Arrays
        var sortedKeys = new Array();
        var sortedObj = {};
        // Separate obj in array and sort them
        for (var i in arr) {
            arr[i]['key'] = i;
            sortedKeys.push(arr[i]);
        }
        sortedKeys.sort(function (x, y) {
            return x['kg'] - y['kg'];
        });
        
        // Reconstruct sorted obj based on keys
        for (var i in sortedKeys) {
            sortedObj[sortedKeys[i]['key']] = sortedKeys[i];
            delete sortedKeys[i]['key'];
        }
        return sortedObj;
       
    }
}

//solve([
//    'Kiko.*.socks.*.false.*.false.*.false.*.0.2.*.backpack',
//    'Kiko.*.banana.*.true.*.false.*.false.*.3.2.*.backpack',
//    'Kiko.*.sticks.*.false.*.false.*.false.*.1.6.*.ATV',
//    'Kiko.*.glasses.*.false.*.false.*.true.*.3.*.ATV',
//    'weight'
//]);