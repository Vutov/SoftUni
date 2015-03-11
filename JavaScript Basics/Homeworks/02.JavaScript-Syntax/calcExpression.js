function calcExp() {
    var eva = document.getElementById("evaluate").value;
    var evaluate = eval(eva);
    console.log(evaluate);
    document.getElementById("display").innerHTML = evaluate;
}