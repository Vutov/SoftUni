var c = document.getElementById("canvas");
var ctx = c.getContext("2d");

function problemOne() {
    ctx.font = "60px Verdana";
    ctx.fillStyle = '#cc5490';
    ctx.fillText("Spas", 30, 70);
    ctx.strokeStyle = '#00ff00';
    ctx.lineWidth = 2;
    ctx.strokeText("Spas", 30, 70);
}

function problemTwo() {
    //Using beginPath(), moveTo(), lineTo(), arc() and stroke()/fill() try to visualize the following image:

    ctx.save();
    ctx.fillStyle = "blue";
    ctx.strokeStyle = "black";

    ctx.beginPath();
    ctx.arc(80, 220, 40, 0, Math.PI * 2, true);
    ctx.fill();
    ctx.stroke();
    ctx.closePath();

    ctx.beginPath();
    ctx.moveTo(90, 210);
    ctx.lineTo(60, 230);
    ctx.moveTo(60, 230);
    ctx.lineTo(80, 230);
    ctx.moveTo(60, 210);
    ctx.arc(60, 210, 5, 0, Math.PI * 2, true);
    ctx.moveTo(100, 210);
    ctx.arc(100, 210, 5, 0, Math.PI * 2, true);
    ctx.fill();
    ctx.stroke();
    ctx.closePath();

    ctx.beginPath();
    ctx.scale(2, 1);
    ctx.lineWidth = 1;
    ctx.arc(40, 245, 8, 0, Math.PI * 2, false);
    ctx.fill();
    ctx.stroke();
    ctx.closePath();

    ctx.beginPath();
    ctx.arc(40, 120, 20, 0, Math.PI * 2, false);
    ctx.moveTo(20, 120);
    ctx.lineTo(20, 180);
    ctx.moveTo(60, 120);
    ctx.lineTo(60, 180);
    ctx.arc(40, 180, 20, 0, Math.PI, false);
    ctx.lineTo(20, 120);
    ctx.fill();
    ctx.stroke();
    ctx.closePath();
    ctx.restore();
}

function problemThree() {
    //Using beginPath(), moveTo(), lineTo(), fillRect(), arc() and stroke()/fill() try to visualize the following image:
    ctx.fillStyle = "brown";
    ctx.strokeStyle = "black";

    //Roof
    ctx.beginPath();
    ctx.moveTo(20, 350);
    ctx.lineTo(80, 300);
    ctx.lineTo(120, 350);
    ctx.lineTo(20, 350);
    ctx.stroke();
    ctx.fill();
    ctx.closePath();

    //Building
    ctx.fillRect(20, 350, 100, 100);
    ctx.strokeRect(20, 350, 100, 100);
    ctx.stroke();

    //Windows
    ctx.beginPath();
    ctx.fillStyle = "black";
    ctx.strokeStyle = "brown";
    ctx.fillRect(30, 380, 30, 20);
    ctx.moveTo(30, 390);
    ctx.lineTo(110, 390);
    ctx.fillRect(80, 380, 30, 20);
    ctx.fillRect(80, 410, 30, 20);
    ctx.moveTo(80, 420);
    ctx.lineTo(110, 420);
    ctx.moveTo(95, 380);
    ctx.lineTo(95, 430);
    ctx.moveTo(45, 380);
    ctx.lineTo(45, 420);
    ctx.stroke();
    ctx.closePath();

    //Door
    ctx.strokeStyle = "black";
    ctx.beginPath();
    ctx.moveTo(30, 450);
    ctx.lineTo(30, 435);
    ctx.moveTo(50, 450);
    ctx.lineTo(50, 435);
    ctx.arc(40, 435, 10, 0, Math.PI, true);
    ctx.stroke();
    ctx.closePath();

    //Door-things
    ctx.beginPath();
    ctx.arc(35, 440, 2, 0, Math.PI * 2, true);
    ctx.arc(45, 440, 2, 0, Math.PI * 2, true);
    ctx.fill();
    ctx.closePath();

    ctx.beginPath();
    ctx.moveTo(40, 425);
    ctx.lineTo(40, 450);
    ctx.stroke();
    ctx.closePath();
}

problemOne();
problemTwo();
problemThree();
