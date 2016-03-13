var app = app || {};

app.userController = (function () {
    function UserController(model, viewBag) {
        var _this = this;
        this._model = model;
        this._viewBag = viewBag;

    }

    UserController.prototype.loadLoginPage = function(selector) {
        this._viewBag.showLoginPage(selector);
    };

    UserController.prototype.loadRegisterPage = function (selector) {
        this._viewBag.showRegisterPage(selector);
    };

    UserController.prototype.login = function(data) {
        var userOutputModel = {
            username: data.username,
            password: data.password
        };

        this._model.login(userOutputModel)
            .then(function(success) {
                sessionStorage['sessionAuth'] = success._kmd.authtoken;
                sessionStorage['userId'] = success._id;
                sessionStorage['username'] = success.username;
                $.sammy(function() {
                    this.trigger('redirectUrl', { url: '#/books' });
                });
            }).done();
    };

    UserController.prototype.register = function (data) {
        var userOutputModel = {
            username: data.username,
            password: data.password
        };

        this._model.register(userOutputModel)
            .then(function (success) {
                sessionStorage['sessionAuth'] = success._kmd.authtoken;
                sessionStorage['userId'] = success._id;
                sessionStorage['username'] = success.username;
                $.sammy(function () {
                    this.trigger('redirectUrl', { url: '#/books' });
                });
            }).done();
    };

    UserController.prototype.logout = function() {
        return this._model.logout()
            .then(function() {
                sessionStorage.clear();
            });
    };

    return {
        load: function (model, viewBag) {
            return new UserController(model, viewBag);
        }
    }
}());