function extractObjects(array) {
    var objects = [];

array.forEach(function(x) {
        if (typeof x === "object" && !Array.isArray(x)) {
            objects.push(x);
        }
    });
    console.log(objects);
}

var data = [
    "Pesho",
    4,
    4.21,
    true,
    { name: 'Valyo', age: 16 },
    { type: 'fish', model: 'zlatna ribka' },
    [1, 2, 3],
    "Gosho",
    { name: 'Penka', height: 1.65 }
];

extractObjects(data);