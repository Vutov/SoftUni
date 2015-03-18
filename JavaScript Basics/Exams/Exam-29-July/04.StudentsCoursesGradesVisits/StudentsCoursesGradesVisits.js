function solve(arr) {
    var json = {};
    arr.forEach(function (line) {
        var data = line.split('|').map(function (x) { return x.trim() });
        //console.log(data);
        var name = data[0];
        var subject = data[1];
        var grade = data[2];
        var visits = data[3];
        
        if (!json[subject]) {
            json[subject] = { avgGrade: [], avgVisits: [], students: [] };
        }
        json[subject]["avgGrade"].push(grade);
        json[subject]["avgVisits"].push(visits);
        if (json[subject]["students"].indexOf(name) === -1) {
            json[subject]["students"].push(name);
        }
    });
    for (var subject in json) {
        var avrGrade = 0;
        var avgVisits = 0;
        json[subject]["avgGrade"].forEach(function (x) { avrGrade += Number(x) });
        json[subject]["avgGrade"] =  Math.round(Number(avrGrade / json[subject]["avgGrade"].length) * 100) / 100;
        json[subject]["avgVisits"].forEach(function (x) { avgVisits += Number(x) });
        json[subject]["avgVisits"] = Math.round(Number(avgVisits / json[subject]["avgVisits"].length) * 100) / 100;
        json[subject]["students"] = json[subject]["students"].sort();
        //console.log();
    }

    json = sortObj(json);
    console.log(JSON.stringify(json));
    

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
    "Peter Nikolov | PHP  | 5.50 |8",
    "Maria Ivanova | Java | 5.83 | 7",
    "Ivan Petrov | PHP | 3.00 | 2",
    "Ivan Petrov | C #   | 3.00 | 2",
    "Peter Nikolov | C #   | 5.50 | 8",
    "Maria Ivanova | C #   | 5.83 | 7",
    "Ivan Petrov | C #   | 4.12 | 5",
    "Ivan Petrov | PHP | 3.10 | 2",
    "Peter Nikolov | Java | 6.00 | 9"
]);