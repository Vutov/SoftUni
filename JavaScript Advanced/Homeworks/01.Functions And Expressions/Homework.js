function Homework() {
    var printArgsInfo = function () {
        for (var i = 0; i < arguments.length; i++) {
            console.log(arguments[i] + " (" + typeof (arguments[i]) + ")");
        }
    },
    playWithCall = function () {
        this.printArgsInfo.call(this);
        this.printArgsInfo.call(this, 'Calling with something');
        this.printArgsInfo.apply(this);
        this.printArgsInfo.apply(this, ['Applying with something', 1, 2, 3]);
    }

    return {
        printArgsInfo: printArgsInfo,
        playWithCall: playWithCall
    }
}

var homework = new Homework();

homework.printArgsInfo(2, 3, 2.5, -110.5564, false);
//homework.printArgsInfo(null, undefined, "", 0, [], {});
//homework.printArgsInfo([1, 2], ["string", "array"], ["single value"]);
//homework.printArgsInfo("some string", [1, 2], ["string", "array"], ["mixed", 2, false, "array"], { name: "Peter", age: 20 });
//homework.printArgsInfo([[1, [2, [3, [4, 5]]]], ["string", "array"]]);
homework.playWithCall();

function testContext() {
    return this;
}

// Global scope, this is Document
console.log(testContext());

// Inside an other function, this is still Document, can be called with .call or .bind in order to get the current this in there.
function test() {
    console.log(testContext());
}

test();

// This is not constructor - pointless.
console.log(new testContext());

function traverse(identificator) {
    // For class, same can be done for id.
    if (identificator.indexOf('.') === 0) {
        identificator = identificator.replace('.', '');
        var root = document.getElementsByClassName(identificator);
        console.log(root);
        var html = root[0].innerHTML;
        var regex = /(\s*)<(\w+\s*)(.*class=".+")?/g;
        var result = "";
        var match = regex.exec(html);
        while (match != null) {
            result += match[1];
            if (match[2]) {
                result += match[2].trim() + ": ";
            }

            if (match[3]) {
                result += match[3];
            }

            match = regex.exec(html);
        }
        
        console.log(result);
    }
}

var selector = ".birds";
traverse(selector);