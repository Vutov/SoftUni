function findCardFrequency(str) {
    var nums = str.split(/[^0-9JAKQ]+/g);
    nums = nums.filter(function (x) { return x });
    var freq = {};
    nums.forEach(function(x) {
        if (freq[x]) {
            freq[x] = freq[x] + 1;
        } else {
            freq[x] = 1;
        }
    });
    //console.log(freq)
    for (var key in freq) {
        console.log(key + " -> " + ((freq[key]/ nums.length) * 100).toFixed(2) + "%");
    }
}

findCardFrequency('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦');
console.log("-------------");
findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠');
console.log("-------------");
findCardFrequency('10♣ 10♥');