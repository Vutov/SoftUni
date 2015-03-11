function calcKnots(km) {
    var knots = km / 1.852;
    knots = Math.round(knots * 100) / 100;
    console.log(knots.toFixed(2));
}

calcKnots(20);
calcKnots(112);
calcKnots(400);