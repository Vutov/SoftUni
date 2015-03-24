var Ball = (function () {
    function Ball(x, y) {
        this.position = new Vector2(x, y);
        this.width = 29;
        this.height = 30;
        this.velocity = 1;
        this.velocityModifierX = 1;
        this.velocityModifierY = 1;
        this.image = new Animation(this.width, this.height, 0, 0, 1, "ball.PNG", 1, 1, 1);
        this.boundingBox = new Rectangle(x, y, this.width, this.height);
    }

    Ball.prototype.update = function () {
        this.position.x += (this.velocity + 10) * this.velocityModifierX;
        this.position.y += this.velocity - 5 * this.velocityModifierY;
        this.boundingBox.x = this.position.x;
        this.boundingBox.y = this.position.y;
        this.image.position.set(this.position.x, this.position.y);
        this.image.update();
    };

    Ball.prototype.draw = function (ctx) {
        this.image.draw(ctx);
    };

    return Ball;
})();

var Player = (function () {
    function Player(x, y, animRow) {
        this.position = new Vector2(x, y);
        this.width = 128;
        this.height = 48;
        this.velosity = 10;
        this.image = new Animation(this.width, this.height, animRow, 0, 1, "paddles.PNG", 1, 1, 2);
        this.boundingBox = new Rectangle(x, y, this.width, this.height);
        this.moveLeft = false;
        this.moveRight = false;
    }


    Player.prototype.update = function () {
        this.boundingBox.x = this.position.x;
        this.boundingBox.y = this.position.y;
        this.image.position.set(this.position.x, this.position.y);
        if (this.position.x < 7) {
            this.position.x = 7;
        }
        if (this.position.x > 670) {
            this.position.x = 670;
        }
        if (this.moveRight) {
            this.position.x += 10;
        }
        if (this.moveLeft) {
            this.position.x -= 10;
        }
        this.image.update();
    };
    Player.prototype.draw = function (ctx) {
        this.image.draw(ctx);
    };
    return Player;
})();

function main() {
    var canvas = document.getElementById("canvas");
    var ctx = canvas.getContext("2d");
    var player1Score = 0;
    var player2Score = 0;

    var input = new Input();
    attachListeners(input);

    var ball = new Ball(500, 500);
    var player1 = new Player(1, 1, 0);
    var player2 = new Player(1, 752, 1);


    function update() {
        tick();
        render(ctx);
        requestAnimationFrame(update);

    }

    function tick() {
        if (ball.position.x + ball.boundingBox.width >= canvas.width || ball.position.x <= 0) {
            ball.velocityModifierX *= -1;
        }
        if (input.d) {
            player1.moveRight = true;
            player2.moveRight = true;
        } else {
            player1.moveRight = false;
            player2.moveRight = false;
        }
        if (input.a) {
            player1.moveLeft = true;
            player2.moveLeft = true;
        } else {
            player1.moveLeft = false;
            player2.moveLeft = false;
        }
        if (player1.boundingBox.intersects(ball.boundingBox) || player2.boundingBox.intersects(ball.boundingBox)) {
            ball.velocityModifierY *= -1;
        }
        if (ball.position.y + ball.boundingBox.height > canvas.height) {
            player1Score++;
            document.getElementById('score').innerHTML = 'Score: Player1: ' + player1Score + ' Player2: ' + player2Score;
            ball.velocityModifierY *= -1;
        }
        if (ball.position.y < 0) {
            player2Score++;
            document.getElementById('score').innerHTML = 'Score: Player1: ' + player1Score + ' Player2: ' + player2Score;
            ball.velocityModifierY *= -1;
        }
        player1.update();
        player2.update();
        ball.update();
    }
    function render(ctx) {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ball.draw(ctx);
        player1.draw(ctx);
        player2.draw(ctx);
    }

    update();
}

main();