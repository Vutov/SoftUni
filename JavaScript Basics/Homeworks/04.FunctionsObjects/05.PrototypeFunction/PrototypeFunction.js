Array.prototype.removeItem = function (element) {
    //console.log(element);
    //console.log(this.indexOf(element));
    while (this.indexOf(element) !== -1) {
        this.splice(this.indexOf(element), 1);
    }
};

var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
console.log("Before:", arr);
arr.removeItem(1);
console.log("After:", arr);
var arr = ['hi', 'bye', 'hello'];
console.log("Before:", arr);
arr.removeItem('bye');
console.log("After:", arr);