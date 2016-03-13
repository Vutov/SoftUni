var BookInputModel = (function () {
    function BookInputModel(id, title, author, isbn) {
        this._id = id;
        this.title = title;
        this.author = author;
        this.isbn = isbn;
    }

    return BookInputModel;
}());