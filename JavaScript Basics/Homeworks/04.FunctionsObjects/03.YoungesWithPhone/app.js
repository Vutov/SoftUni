function findYoungestPerson(arr) {
    var younges = Number.POSITIVE_INFINITY;
    var name = "";
    arr.forEach(function (x) {
        if (x["hasSmartphone"] && x["age"] < younges) {
            younges = x["age"];
            name = x["firstname"] + " " + x["lastname"];
        }
        //console.log(x["hasSmartphone"]);
    });
    console.log("The youngest person is " + name);
}

var people = [
    { firstname: 'George', lastname: 'Kolev', age: 32, hasSmartphone: false },
    { firstname: 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true },
    { firstname: 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true },
    { firstname: 'Baba', lastname: 'Ginka', age: 40, hasSmartphone: false }
];

findYoungestPerson(people);
