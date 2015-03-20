function solve(arr) {
    var nums = arr[0].split(/\D/g).filter(function (x) { return x }).map(function(x) {
        var hex = Number(x).toString(16).toUpperCase();
        while (hex.length < 4) {
            hex = "0" + hex;
        }
        return "0x" + hex;
    });
    console.log(nums.join("-"));

}

//solve(["5tffwj(//*7837xzc2---34rlxXP%$”."]);
solve(["482vMWo(*&^%$213;k!@41341((()&^>><///]42344p;e312"]);