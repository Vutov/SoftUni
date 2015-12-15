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
