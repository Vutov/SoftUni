var app = app || {};

app.userViews = (function () {
    function addMenu() {
        $.get('templates/homeMenu.html', function (templ) {
            $("#navigation").html(templ);
        });
    }

    function showLoginPage(selector) {
        addMenu();

        $.get('templates/login.html', function(templ) {
            $(selector).html(templ);
            $('#login').on('click', function() {
                var username = $('#username').val(),
                    password = $('#password').val();

                $.sammy(function() {
                    this.trigger('login', { username: username, password: password });
                });
            });
        });
    }

    function showRegisterPage(selector) {
        addMenu();

        $.get('templates/register.html', function (templ) {
            $(selector).html(templ);
            $('#register').on('click', function () {
                var username = $('#username').val(),
                    password = $('#password').val();

                $.sammy(function () {
                    this.trigger('register', { username: username, password: password });
                });
            });
        });
    }

    return {
        load: function() {
            return {
                showLoginPage: showLoginPage,
                showRegisterPage: showRegisterPage
            }
        }
    }
}());