var app = app || {};

(function () {
    app.router = $.sammy(function () {
        var requester = app.requester.config('kid_Wkr8Qtqv1b', '3cd3230b13f24291be2c5d6746231554');
        var selector = '#content';

        var bookModel = app.bookModel.load(requester);
        var userModel = app.userModel.load(requester);

        var bookViewBag = app.bookViews.load();
        var homeViewBag = app.homeViews.load();
        var userViewBag = app.userViews.load();

        var bookController = app.bookController.load(bookModel, bookViewBag);
        var homeController = app.homeController.load(homeViewBag);
        var userController = app.userController.load(userModel, userViewBag);

        this.get('#/', function () {
            homeController.loadHomePage(selector);
        });

        this.get('#/login', function () {
            userController.loadLoginPage(selector);
        });

        this.get('#/register', function () {
            userController.loadRegisterPage(selector);
        });

        this.get('#/logout', function () {
            userController.logout()
                .then(function() {
                    this.redirect('#/');
                }.bind(this));
        });

        this.get('#/books', function () {
            bookController.getAllBooks(selector);
        });

        this.get('#/create-book', function () {
            bookController.getCreateBook(selector);
        });

        this.get('#/edit-book/:id', function () {
            bookController.editBook(selector, this.params['id']);
        });

        this.bind('redirectUrl', function(e, data) {
            this.redirect(data.url);
        });

        this.bind('login', function (e, data) {
            userController.login(data);
        });

        this.bind('register', function (e, data) {
            userController.register(data);
        });

        this.bind('create-book', function (e, data) {
            bookController.createBook(data);
        });

        this.bind('delete-book', function (e, data) {
            bookController.deleteBook(data);
        });

        this.bind('edit-book', function (e, data) {
            this.redirect('#/edit-book/' + data.id);
        });

        this.bind('update-book', function (e, data) {
            bookController.updateBook(selector, data);
        });
    });

    app.router.run('#/');
}());

