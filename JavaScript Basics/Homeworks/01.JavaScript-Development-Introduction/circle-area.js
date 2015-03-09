//r=7, r=1.5 and r=20

function calcCircleArea(r) {
    var pi = Math.PI;
    return pi * Math.pow(r, 2);
}

document.writeln(calcCircleArea(7) + "<br>");
document.writeln(calcCircleArea(1.5) + "<br>");
document.writeln(calcCircleArea(20) + "<br>");
