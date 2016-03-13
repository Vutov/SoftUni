var app = app || {};

app.homeViews = (function() {
    function showHomePage(selector) {
        $.get('templates/home.html', function(templ) {
            $(selector).html(templ);
        });
    }
   return {
       load: function() {
           return {
               showHomePage: showHomePage
           }
       }
   }
}());