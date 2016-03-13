var app = app || {};

app.bookViews = (function () {

    function addMenu() {
        $.get('templates/loggedMenu.html', function (templ) {
            var data = {username: sessionStorage['username']}
            var outputHtml = Mustache.render(templ, data);
            $("#navigation").html(outputHtml);
        });
    }

    function showBooks(parent, data) {
        addMenu();

        $.get('templates/books.html', function (templ) {
            var outputHtml = Mustache.render(templ, data);
            $(parent).html(outputHtml);
            $('.deleteBook').on('click', function () {
                var parent = $(this).parent(),
                    id = $(this).attr("book-id");
                $.sammy(function () {
                    this.trigger('delete-book', {
                        parent: parent,
                        id: id
                    });
                });
            });

            $('.editBook').on('click', function () {
                var parent = $(this).parent(),
                    id = $(this).attr("book-id");
                $.sammy(function () {
                    this.trigger('edit-book', {
                        parent: parent,
                        id: id
                    });
                });
            });
        });
    }

    function getCreateBook(parent) {
        addMenu();

        $.get('templates/create-book.html', function (templ) {
            $(parent).html(templ);
            $('#addBook').on('click', function () {
                var parent = $(this).parent(),
                    title = $("#title").val(),
                    author = $("#author").val(),
                    isbn = $("#isbn").val();
                $.sammy(function () {
                    this.trigger('create-book', {
                        parent: parent,
                        title: title,
                        author: author,
                        isbn: isbn
                    });
                });
            });
        });
    }

    function editBook(parent, data) {
        addMenu();

        $.get('templates/update-book.html', function (templ) {
            var outputHtml = Mustache.render(templ, data);
            $(parent).html(outputHtml);
            $("#title").val(data.title),
            $("#author").val(data.author),
            $("#isbn").val(data.isbn);
            $('#updateBook').on('click', function () {
                var parent = $(this).parent(),
                    id = $(this).attr("book-id"),
                    title = $("#title").val(),
                    author = $("#author").val(),
                    isbn = $("#isbn").val();
                $.sammy(function () {
                    this.trigger('update-book', {
                        parent: parent,
                        id: id,
                        title: title,
                        author: author,
                        isbn: isbn
                    });
                });
            });
        });
    }

    return {
        load: function () {
            return {
                showBooks: showBooks,
                getCreateBook: getCreateBook,
                editBook: editBook
            }
        }
    }
}());