function clone(obj) {
    var temp = {};
    for (var key in obj) {
        temp[key] = obj[key];
    }
    //console.log(temp)
    return temp;
}

function compareObjects(a, b) {
    console.log(a === b);
}

var a = { name: 'Pesho', age: 21 }
var b = clone(a); // a deep copy 
compareObjects(a, b); //a == b-- > false
var a = { name: 'Pesho', age: 21 };
var b = a; // not a deep copy
compareObjects(a, b); //a == b-- > true
