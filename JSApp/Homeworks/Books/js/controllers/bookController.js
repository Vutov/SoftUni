var app = app || {};

app.bookController = (function () {
    function BookController(model, viewBag) {
        this._model = model;
        this._viewBag = viewBag;
    }

    BookController.prototype.getAllBooks = function (selector) {
        this._model.getAllBooks()
            .then(function (books) {
                var result = {
                    books: []
                };

                books.forEach(function (book) {
                    result.books.push(new BookInputModel(book._id, book.title, book.author, book.isbn));
                });

                this._viewBag.showBooks(selector, result);
            }.bind(this))
            .done();
    };

    BookController.prototype.getCreateBook = function (selector) {
        this._viewBag.getCreateBook(selector);
    };

    BookController.prototype.createBook = function (data) {
        var bookOutputModel = {
            title: data.title,
            author: data.author,
            isbn: data.isbn
        };

        this._model.createBook(bookOutputModel)
            .then(function () {
                $.sammy(function () {
                    this.trigger('redirectUrl', {
                        url: "#/books"
                    });
                });
            });
    };

    BookController.prototype.deleteBook = function (data) {
        var id = data.id;

        this._model.deleteBook(id)
            .then(function () {
                $.sammy(function () {
                    this.trigger('redirectUrl', {
                        url: "#/books"
                    });
                });
            });
    };

    BookController.prototype.editBook = function (selector, id) {
        this._model.getBookById(id)
           .then(function (book) {

               this._viewBag.editBook(selector, book);
           }.bind(this))
           .done();
    };

    BookController.prototype.updateBook = function (selector, data) {
        this._model.updateBook(data)
            .then(function () {
                $.sammy(function () {
                    this.trigger('redirectUrl', {
                        url: "#/books"
                    });
                });
            });
    };

    return {
        load: function (model, viewBag, router) {
            return new BookController(model, viewBag, router);
        }
    }
}());