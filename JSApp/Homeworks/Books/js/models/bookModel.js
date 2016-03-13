var app = app || {};

app.bookModel = (function () {
    function BookModel(requester) {
        this.requester = requester;
        this.serviceUrl = this.requester.baseUrl +
            'appdata/' +
            this.requester.appId +
            '/books';
    }

    BookModel.prototype.getAllBooks = function () {
        return this.requester.get(this.serviceUrl, false);
    };

    BookModel.prototype.getBookById = function (id) {
        return this.requester.get(this.serviceUrl + "/" + id, false);
    };

    BookModel.prototype.createBook = function (data) {
        return this.requester.post(this.serviceUrl, data, false);
    };

    BookModel.prototype.deleteBook = function (id) {
        return this.requester.delete(this.serviceUrl, id, false);
    };

    BookModel.prototype.updateBook = function (data) {
        return this.requester.update(this.serviceUrl, data, false);
    };

    return {
        load: function(requester) {
            return new BookModel(requester);
        }
    }
}());

