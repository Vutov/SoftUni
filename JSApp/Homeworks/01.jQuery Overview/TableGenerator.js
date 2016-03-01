var table = {
    init: function() {
        var json = [
    { "manufacturer": "BMW", "model": "E92 320i", "year": 2011, "price": 50000, "class": "Family" },
    { "manufacturer": "Porsche", "model": "Panamera", "year": 2012, "price": 100000, "class": "Sport" },
    { "manufacturer": "Peugeot", "model": "305", "year": 1978, "price": 1000, "class": "Family" }
        ];

        var table = $("<table>");
        var header = $("<tr>");
        $("<th>Manufacturer</th>").appendTo(header);
        $("<th>Model</th>").appendTo(header);
        $("<th>Year</th>").appendTo(header);
        $("<th>Price</th>").appendTo(header);
        $("<th>Class</th>").appendTo(header);
        header.appendTo(table);

        json.forEach(function (r) {
            var row = $("<tr>");
            _(r).forIn(function (value, key) {
                $("<td>" + value + "</td>").appendTo(row);
            });
            row.appendTo(table);
        });

        table.appendTo($("#Container"));
    }
}

table.init();