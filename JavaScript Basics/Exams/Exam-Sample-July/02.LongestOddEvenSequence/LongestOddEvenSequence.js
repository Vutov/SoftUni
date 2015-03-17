function solve(arr) {
    var data = arr[0].split(/\D+/g);
    var nums = [];
    for (var j = 0; j < data.length; j++) {
        if (data[j] !== "") {
            nums.push(data[j]);
        }
    }
    
    //console.log(nums);
    var maxLength = 0;
    var currLength = 0;
    var oddRule = nums[0] % 2 != 0;
    for (var i = 0; i < nums.length; i++) {
        var isOdd = nums[i] % 2 != 0;
        if (isOdd == oddRule || nums[i] == 0) {
            currLength++;
        } else {
            oddRule = isOdd;
            currLength = 1;
        }
        oddRule = !oddRule;
        if (currLength > maxLength) {
            maxLength = currLength;
        }
    }
    console.log(maxLength);
}

//solve(["(3) (22) (-18) (55) (44) (3) (21)"]);
//solve(["(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)"]);
//solve([" (2)(33)(1)(4)(-1)"]);
//solve(["(102)(103)(0)(105)(107)(1)"]);