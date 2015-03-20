function solve(arr) {
    var json = {};
    arr.forEach(function (line) {
        var data = line.split(" ").filter(function (x) { return x });
        var type = data[1];
        var name = data[0];
        var size = Number(data[2].replace("MB", "")); 
        
        if (!json[type]) {
            json[type] = { files: [], memory : []};
        }
        json[type]["files"].push(name);
        json[type]["memory"].push(size);
    });
    json = sortObj(json);
    for (var type in json) {
        json[type]["files"].sort();
        var totalMb = 0;
        json[type]["memory"].forEach(function(x) { totalMb += x });
        json[type]["memory"] = totalMb.toFixed(2);
    }

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
    "sentinel .exe 15MB",
    "zoomIt .msi 3MB",
    "skype .exe 45MB",
    "trojanStopper .bat 23MB",
    "kindleInstaller .exe 120MB",
    "setup .msi 33.4MB",
    "winBlock .bat 1MB"
]);