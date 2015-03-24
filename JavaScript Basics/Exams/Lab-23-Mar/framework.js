/**
 * Created by Bi0GaMe on 21.7.2014 г..
 * Last modified on 21.3.2015 г.
 */

/**
 * @param elm
 * @returns {Number|number}
 * @constructor
 */
function GetLeft(elm) {
    var left = elm.offsetLeft;
    while (elm == elm.offsetParent)
        left += elm.offsetLeft;

    left -= window.pageXOffset;

    return left;
}

/**
 * @param elm
 * @returns {Number|number}
 * @constructor
 */
function GetTop(elm) {
    var top = elm.offsetTop;
    while (elm == elm.offsetParent)
        top += elm.offsetTop;

    top -= window.pageYOffset;

    return top;
}

/**
 * @param arg
 * @param all
 * @constructor
 */
Array.prototype.remove = function (arg, all) {
    for (var i = 0; i < this.length; i++) {
        if (this[i] == arg) {
            this.splice(i, 1);

            if (all == null || !all)
                break;
            else
                i--;
        }
    }
};

/**
 * @param position
 * @constructor
 */
Array.prototype.removeAt = function (position) {
    this.splice(position, 1);
};

/**
 * @constructor
 */
Array.prototype.clear = function () {
    this.length = 0;
};

/**
 * @param arg
 * @param position
 * @constructor
 */
Array.prototype.insertAt = function (arg, position) {
    this.splice(position, 0, arg);
};

/**
 * @param arg
 * @returns {boolean}
 * @constructor
 */
Array.prototype.contains = function (arg) {
    for (var i = 0; i < this.length; i++)
        if (this[i] == arg)
            return true;
    return false;
};

/**
 * @param arg
 * @returns {number}
 * @constructor
 */
Array.prototype.occurs = function (arg) {
    var counter = 0;

    for (var i = 0; i < this.length; i++) {
        if (this[i] == arg)
            counter++;
    }

    return counter;
};

var Vector2 = (function () {
    function Vector2(x, y) {
        if (x) {
            this.x = x;
        } else {
            this.x = 0;
        }
        if (y) {
            this.y = y;
        } else {
            this.y = 0;
        }
        this.previousX = 0;
        this.previousY = 0;
    }

    /**
     * @param x
     * @param y
     */
    Vector2.prototype.set = function (x, y) {
        if (!x && !y) {
            console.log("No x or y has been passed to Vector2's set function");
        } else {
            this.previousX = this.x;
            this.previousY = this.y;
            if (x && !y) {
                this.x = x;
                this.y = y;
            } else {
                if (x) {
                    this.x = x;
                }
                if (y) {
                    this.y = y;
                }
            }
        }
    };

    /**
     * @param vec2
     */
    Vector2.prototype.move = function (vec2) {
        this.x += vec2.x;
        this.y += vec2.y;
    };

    /**
     * @returns {Vector2}
     */
    Vector2.prototype.normalize = function () {
        var tmp = new Vector2(this.x, this.y);

        var mag = Math.sqrt(tmp.x * tmp.x + tmp.y * tmp.y);

        tmp.x = tmp.x / mag;
        tmp.y = tmp.y / mag;

        return tmp;
    };

    /**
     * @param vec2
     * @returns {number}
     */
    Vector2.prototype.distance = function (vec2) {
        if (vec2)
            return Math.sqrt(Math.pow(vec2.x - this.x, 2) + Math.pow(this.y - vec2.y, 2));
        else
            return Math.sqrt(Math.pow(this.previousX - this.x, 2) + Math.pow(this.previousY - this.y, 2));
    };

    /**
     * @returns {boolean}
     */
    Vector2.prototype.hasChanged = function () {
        return !!(this.x != this.previousX || this.y != this.previousY);
    };

    /**
     * @param vec2
     * @param invert
     * @returns {Vector2}
     */
    Vector2.prototype.difference = function (vec2, invert) {
        var inv = 1;

        if (invert) {
            inv = -1;
        }

        if (vec2) {
            return new Vector2((this.x - vec2.x) * inv, (this.y - vec2.y) * inv);
        } else {
            return new Vector2((this.x - this.previousX) * inv, (this.y - this.previousY) * inv);
        }
    };

    /**
     * @returns {string}
     */
    Vector2.prototype.toString = function () {
        return '[x = ' + this.x + ', y = ' + this.y + ']';
    };

    return Vector2;
}());

var Color = (function () {
    function Color(r, g, b, a) {
        this.g = g !== undefined ? g : 255;
        this.r = r !== undefined ? r : 255;
        this.b = b !== undefined ? b : 255;
        this.a = a !== undefined ? a : 1;
    }

    /**
     * @param noAlpha
     * @returns {string}
     */
    Color.prototype.toStandard = function (noAlpha) {
        if (!noAlpha)
            return "rgba(" + this.r + ", " + this.g + ", " + this.b + ", " + this.a + ")";
        else
            return "rgb(" + this.r + ", " + this.g + ", " + this.b + ")";
    };

    return Color;
}());

var Rectangle = (function () {
    function Rectangle(x, y, w, h) {
        if (!x || !y || !w || !h) {
            var errorMsg = "Missing:";
            if (!x) errorMsg += " 'x' ";
            if (!y) errorMsg += " 'y' ";
            if (!w) errorMsg += " 'w' ";
            if (!h) errorMsg += " 'h' ";

            throw new Error(errorMsg);
        }

        this.x = x;
        this.y = y;
        this.width = w;
        this.height = h;
        this.color = new Color();
    }

    /**
     * @param x
     * @param y
     * @returns {boolean}
     */
    Rectangle.prototype.contains = function (x, y) {
        return !!(x >= this.x && x <= this.x + this.width &&
        y >= this.y && y <= this.y + this.height);
    };

    /**
     * @param shape
     * @returns {boolean}
     */
    Rectangle.prototype.intersects = function (shape) {
        var offset = 0;

        if (shape.radius) {
            offset = shape.radius;
        }

        if (this.contains(shape.x - offset, shape.y - offset) ||
            this.contains(shape.x + shape.width - offset, shape.y - offset) ||
            this.contains(shape.x - offset, shape.y + shape.height - offset) ||
            this.contains(shape.x + shape.width - offset, shape.y + shape.height - offset)) {
            return true;
        } else if (shape.contains(this.x - offset, this.y - offset) ||
            shape.contains(this.x + this.width - offset, this.y - offset) ||
            shape.contains(this.x - offset, this.y + this.height - offset) ||
            shape.contains(this.x + this.width - offset, this.y + this.height - offset)) {
            return true;
        }
        return false;
    };

    /**
     * @param ctx
     */
    Rectangle.prototype.draw = function (ctx) {
        ctx.strokeStyle = this.color.toStandard();
        ctx.strokeRect(this.x, this.y, this.width, this.height);
    };

    return Rectangle;
}());

var Animation = (function () {
    function Animation(width, height, row, column, limit, imgSrc, fps, columns, rows) {
        if (!fps || fps >= 33) {
            this.fps = 1;
        } else {
            this.fps = 33 / fps;
        }

        this.fpsCounter = 0;
        //this.frame = 0;
        this.width = width;
        this.height = height;
        this.rowStart = row;
        this.columnStart = column;
        this.row = row;
        this.column = column;
        this.rows = rows;
        this.columns = columns;

        if (!limit) {
            this.limit = Number.POSITIVE_INFINITY;
        } else {
            this.limit = limit - 1;
        }

        this.limitCount = 0;
        this.image = new Image();
        this.image.src = imgSrc;
        this.position = new Vector2(0);
        this.cropPostion = new Vector2(0);
    }


    /**
     * @param limit
     */
    Animation.prototype.setLimit = function (limit) {
        this.limit = limit - 1;
    };

    /**
     * @param num
     */
    Animation.prototype.setRow = function (num) {
        this.row = num;
        this.rowStart = num;

        this.cropPostion.x = this.width * this.column;
        this.cropPostion.y = this.height * this.row;
    };

    /**
     * @param num
     */
    Animation.prototype.setColumn = function (num) {
        this.column = num;
        this.columnStart = num;

        this.cropPostion.x = this.width * this.column;
        this.cropPostion.y = this.height * this.row;
    };

    /**
     * @constructor
     */
    Animation.prototype.update = function () {
        this.cropPostion.x = this.width * this.column;
        this.cropPostion.y = this.height * this.row;

        if (!this.columns)
            this.columns = this.image.width / this.width;
        if (!this.rows)
            this.rows = this.image.height / this.height;

    };

    /**
     * @param ctx
     */
    Animation.prototype.draw = function (ctx) {
        if (this.fpsCounter == 0) {
            if (this.limitCount < this.limit) {
                this.limitCount++;
                this.column++;

                if (this.column >= this.columns) {
                    this.row++;
                    this.column = 0;

                    if (this.row >= this.rows) {
                        this.row = this.rowStart;
                        this.column = this.columnStart;
                        this.limitCount = 0;
                    }
                }
            } else {
                this.column = this.columnStart;
                this.row = this.rowStart;
                this.limitCount = 0;
            }
        }

        ctx.drawImage(this.image, this.cropPostion.x, this.cropPostion.y, this.width, this.height,
            this.position.x, this.position.y, this.width, this.height);

        this.fpsCounter++;

        if (this.fpsCounter >= this.fps) {
            this.fpsCounter = 0;
        }
    };

    return Animation;
}());

var Input = (function () {
    function Input() {
        this.a = false;
        this.b = false;
        this.c = false;
        this.d = false;
        this.e = false;
        this.f = false;
        this.g = false;
        this.h = false;
        this.i = false;
        this.j = false;
        this.k = false;
        this.l = false;
        this.m = false;
        this.n = false;
        this.o = false;
        this.p = false;
        this.q = false;
        this.r = false;
        this.s = false;
        this.t = false;
        this.u = false;
        this.v = false;
        this.w = false;
        this.x = false;
        this.y = false;
        this.z = false;
        this.left = false;
        this.right = false;
        this.up = false;
        this.down = false;
        this.enter = false;
        this.space = false;
        this.mouseIsDown = false;
        this.mousePosition = new Vector2();
        this.offset = new Vector2();
        this.clamp = new Vector2();
    }

    return Input;
}());

function attachListeners(input) {
    document.documentElement.onmousemove = function (e) {
        e = e || window.event;
        input.mousePosition.x = e.clientX;
        input.mousePosition.y = e.clientY;
    };

    document.documentElement.onmousedown = function (e) {
        input.mouseIsDown = true;
    };

    document.documentElement.onmouseup = function (e) {
        input.mouseIsDown = false;
    };

    document.documentElement.onkeydown = function (e) {
        var keycode;
        if (window.event)
            keycode = window.event.keyCode;
        else if (e)
            keycode = e.which;

        switch (keycode) {
            case 13:
                input.enter = true;
                break;
            case 32:
                input.space = true;
                break;
            case 37:
                input.left = true;
                break;
            case 38:
                input.up = true;
                break;
            case 39:
                input.right = true;
                break;
            case 40:
                input.down = true;
                break;
            case 65:
                input.a = true;
                break;
            case 66:
                input.b = true;
                break;
            case 67:
                input.c = true;
                break;
            case 68:
                input.d = true;
                break;
            case 69:
                input.e = true;
                break;
            case 70:
                input.f = true;
                break;
            case 71:
                input.g = true;
                break;
            case 72:
                input.h = true;
                break;
            case 73:
                input.i = true;
                break;
            case 74:
                input.j = true;
                break;
            case 75:
                input.k = true;
                break;
            case 76:
                input.l = true;
                break;
            case 77:
                input.m = true;
                break;
            case 78:
                input.n = true;
                break;
            case 79:
                input.o = true;
                break;
            case 80:
                input.p = true;
                break;
            case 81:
                input.q = true;
                break;
            case 82:
                input.r = true;
                break;
            case 83:
                input.s = true;
                break;
            case 84:
                input.t = true;
                break;
            case 85:
                input.u = true;
                break;
            case 86:
                input.v = true;
                break;
            case 87:
                input.w = true;
                break;
            case 88:
                input.x = true;
                break;
            case 89:
                input.y = true;
                break;
            case 90:
                input.z = true;
                break;
        }
    };

    document.documentElement.onkeyup = function (e) {
        var keycode;
        if (window.event)
            keycode = window.event.keyCode;
        else if (e)
            keycode = e.which;

        switch (keycode) {
            case 13:
                input.enter = false;
                break;
            case 32:
                input.space = false;
                break;
            case 37:
                input.left = false;
                break;
            case 38:
                input.up = false;
                break;
            case 39:
                input.right = false;
                break;
            case 40:
                input.down = false;
                break;
            case 65:
                input.a = false;
                break;
            case 66:
                input.b = false;
                break;
            case 67:
                input.c = false;
                break;
            case 68:
                input.d = false;
                break;
            case 69:
                input.e = false;
                break;
            case 70:
                input.f = false;
                break;
            case 71:
                input.g = false;
                break;
            case 72:
                input.h = false;
                break;
            case 73:
                input.i = false;
                break;
            case 74:
                input.j = false;
                break;
            case 75:
                input.k = false;
                break;
            case 76:
                input.l = false;
                break;
            case 77:
                input.m = false;
                break;
            case 78:
                input.n = false;
                break;
            case 79:
                input.o = false;
                break;
            case 80:
                input.p = false;
                break;
            case 81:
                input.q = false;
                break;
            case 82:
                input.r = false;
                break;
            case 83:
                input.s = false;
                break;
            case 84:
                input.t = false;
                break;
            case 85:
                input.u = false;
                break;
            case 86:
                input.v = false;
                break;
            case 87:
                input.w = false;
                break;
            case 88:
                input.x = false;
                break;
            case 89:
                input.y = false;
                break;
            case 90:
                input.z = false;
                break;
        }
    };
}