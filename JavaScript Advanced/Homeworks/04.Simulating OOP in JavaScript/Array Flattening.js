Array.prototype.flatten = function() {
    var flatten = function(items) {
        var flattened = [];
        items.forEach(function(item) {
            if (typeof item === "object") {
                flatten(item).forEach(function (i) {
                    flattened.push(i);
                });
            } else {
                flattened.push(item);
            }
        });

        return flattened;
    }

    return flatten(this);
};

var array = [1, 2, 3, 4];
console.log(array.flatten());

array = [1, 2, [3, 4], [5, 6]];
console.log(array.flatten());
console.log(array); // Not changed	[1, 2, 3, 4, 5, 6]

array = [0, ["string", "values"], 5.5, [[1, 2, true], [3, 4, false]], 10];
console.log(array.flatten());
