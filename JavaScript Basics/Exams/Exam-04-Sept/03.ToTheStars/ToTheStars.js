function solve(arr) {
    var stars = {};
    for (var i = 0; i < 3; i++) {
        var data = arr[i].split(" ").filter(function (x) { return x });
        //console.log(data)
        stars[data[0].toLowerCase()] = [Number(data[1]), Number(data[2])];
    }
    var coords = arr[3].split(" ").filter(function (x) { return x }).map(function (x){ return Number(x) });
    //console.log(coords)
    var turns = Number(arr[4]);
    for (var j = 0; j < turns + 1; j++) {
        var place = "space";
        for (var star in stars) {
            var starCoords = stars[star];
            if (coords[0]>= starCoords[0] - 1 && coords[0] <= starCoords[0] + 1 &&
                coords[1] >= starCoords[1] - 1 && coords[1] <= starCoords[1] + 1) {
                place = star;
            }
            //console.log(starCoords)
        }
        console.log(place);
        coords[1] += 1;
    }

}

//solve([
//    "Sirius 3 7",
//    "Alpha-Centauri 7 5",
//    "Gamma-Cygni 10 10",
//    "8 1",
//    "6"
//]);
solve([
    "Terra-Nova 16 2",
    "Perseus 2.6 4.8",
    "Virgo 1.6 7",
    "2 5",
    "4"
]);