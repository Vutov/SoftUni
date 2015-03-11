function calcExp() {
    var argument = document.getElementById('evaluate').value;
    var evaluate = eval(argument);
    //console.log(evaluate);
    if (evaluate === undefined) {
        document.getElementById('display').innerHTML = 'Type something to evaluate.';
    }
    else {
        document.getElementById('display').innerHTML = evaluate;
        document.getElementById('evaluate').value = '';
    }
}