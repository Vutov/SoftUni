function Person(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = Number(age);
}

function groupBy(criteria) {
    var json = {};
    if (criteria === 'firstName') {
        //console.log(people);
        people.forEach(function (x) {
            if (!json["Group " + x.firstName]) {
                json["Group " + x.firstName] = [];
            }
            json["Group " + x.firstName].push(x.firstName + " " + x.lastName + "(" + x.age + ")");
        });
        
    }
    else if (criteria === 'lastName') {
        people.forEach(function (x) {
            if (!json["Group " + x.lastName]) {
                json["Group " + x.lastName] = [];
            }
            json["Group " + x.lastName].push(x.firstName + " " + x.lastName + "(" + x.age + ")");
        });
    }
    else if (criteria === 'age') {
        people.forEach(function (x) {
            if (!json["Group " + x.age]) {
                json["Group " + x.age] = [];
            }
            json["Group " + x.age].push(x.firstName + " " + x.lastName + "(" + x.age + ")");
        });
        json = sortObj(json);
    }
    
    console.log(json);
}

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

var people = [
    new Person("Scott", "Guthrie", 38),
    new Person("Scott", "Johns", 36),
    new Person("Scott", "Hanselman", 39),
    new Person("Jesse", "Liberty", 57),
    new Person("Jon", "Skeet", 38)
];

groupBy('lastName');