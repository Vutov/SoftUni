function getRoots(a, b, c) {
    a = parseInt(a);
    b = parseInt(b);
    c = parseInt(c);
    var firstRoot = (-b - Math.sqrt(Math.pow(b, 2) - 4 * a * c)) / (2 * a);
    var secondRoot = (-b + Math.sqrt(Math.pow(b, 2) - 4 * a * c)) / (2 * a);
    if (!firstRoot || !secondRoot) {
        console.log("no real roots");
    }
    else {
        if (firstRoot === secondRoot) {
            console.log("x = " + firstRoot);
        }
        else {
            console.log("x1 = " + firstRoot + " x2 = " + secondRoot);
        }
    }
}

getRoots(2, 5, -3);
getRoots(2, -4, 2);
getRoots(4, 2, 1);