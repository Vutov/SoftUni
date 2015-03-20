function solve(arr) {
    var bill = arr[0];
    var mood = arr[1];
    var tip = 0;
    switch (mood) {
        case "happy":
            tip = Math.round(Number(bill) * 10) / 100;
            break;
        case "married":
            tip = Math.round(Number(bill) * 5) / 10000;
            break;
        case "drunk":
            tip = 0.15 * bill;
            tip = Math.pow(tip, tip.toString().charAt(0));
            break;
        default:
            tip = Math.round(Number(bill) * 5) / 100;
            break;
    }
    console.log(Number(tip).toFixed(2));
}

solve(["1234", "drunk"]);