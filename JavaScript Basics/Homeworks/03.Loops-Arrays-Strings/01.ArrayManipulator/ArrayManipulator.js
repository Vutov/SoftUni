function solve(arr) {
    var nums = arr.filter(function(x) {
        return !isNaN(x);
    });

    nums.sort(function(x, y) {
        return x < y;
    });
    var min = Math.min.apply(null, nums),
        max = Math.max.apply(null, nums);

    var count = 1;
    var num;
    var maxCount = 0;
    nums.forEach(function(x, y) {
        if (x === y) {
            count++;
            if (count > maxCount) {
                num = x;
                maxCount = count;
            }
        } else {
            count = 1;
        }
    });
    console.log("Min number: " + min + "\n" + "Max number: " + max + "\n" + "Most frequent number: " + num);
    console.log(nums);
}

solve(["Pesho", 2, "Gosho", 12, 2, "true", 9, undefined, 0, "Penka", { bunniesCount: 10 }, [10, 20, 30, 40]]);