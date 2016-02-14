String.prototype.left = function(count) {
    return this.substring(0, count);
};

String.prototype.right = function (count) {
    var start = this.length - count;
    if (start < 0) {
        start = 0;
    }

    return this.substring(start, this.count);
};

String.prototype.padLeft = function (count, letter) {
    var padding = "";
    if (!letter) {
        letter = " ";
    }
    for (var i = 0; i < count; i++) {
        padding += letter;
    }

    return padding + this;
};

String.prototype.padRight = function (count, letter) {
    var padding = "";
    if (!letter) {
        letter = " ";
    }
    for (var i = 0; i < count; i++) {
        padding += letter;
    }

    return this + padding;
};

// ES6 already has .startsWith and .endsWith
var example = "This is an example string used only for demonstration purposes.";
console.log(example.startsWith("This"));
console.log(example.startsWith("this"));
console.log(example.startsWith("other"));	
	   
var example = "This is an example string used only for demonstration purposes.";
console.log(example.endsWith("poses."));
console.log(example.endsWith ("example"));
console.log(example.startsWith("something else"));	

var example = "This is an example string used only for demonstration purposes.";
console.log(example.left(9));
console.log(example.left(90));	

var example = "This is an example string used only for demonstration purposes.";
console.log(example.right(9));
console.log(example.right(90));	

 // Combinations must also work
var example = "abcdefgh";
console.log(example.left(5).right(2));	   
var hello = "hello";
console.log(hello.padLeft(5));
console.log(hello.padLeft(10));
console.log(hello.padLeft(5, "."));
console.log(hello.padLeft(10, "."));
console.log(hello.padLeft(2, "."));	

var hello = "hello";
console.log(hello.padRight(5));
console.log(hello.padRight(10));
console.log(hello.padRight(5, "."));
console.log(hello.padRight(10, "."));
console.log(hello.padRight(2, "."));

var character = "*";
console.log(character.repeat(5));
// Alternative syntax
console.log("~".repeat(3));
	   
// Another combination
console.log("*".repeat(5).padLeft(10, "-").padRight(15, "+"));