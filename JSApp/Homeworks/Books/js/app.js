var app = app || {};

(function () {
    app.router = $.sammy(function () {
        var requester = app.requester.config('kid_Wkr8Qtqv1b', 'fae367ca205d4279a046fad8fccd42b3');
        var selector = '#wrapper';

        var bookModel = app.bookModel.load(requester);

        var bookViewBag = app.bookViews.load();
        var homeViewBag =app.homeViews.load();

        var bookController = app.bookController.load(bookModel, bookViewBag);
        var homeController = app.homeController.load(homeViewBag);

        this.get('#/', function () {
            homeController.loadHomePage(selector);
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

