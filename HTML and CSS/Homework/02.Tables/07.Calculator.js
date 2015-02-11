var equation = new String;

function EvaluateInfo(info) {
    if (info == '=') {
        equation = eval(equation)
        document.getElementById("display").innerHTML = equation;
    }
    else if (info == 'C') {
        equation = 0;
        document.getElementById("display").innerHTML = equation;
    }
    else if (info != '+' && info != '-' && info != '*' && info != '/') {
        if (equation == 0) {
            equation = info;
        }
        else {
            equation = equation + "" + info;
        }
        document.getElementById("display").innerHTML = equation;
    }
    else { // +, -, *, and /;
        equation = equation + " " + info + " ";
        document.getElementById("display").innerHTML = equation;
    }
}