$("#ClassBtn").click(function() {
    var value = $("#ClassId").val();
    if (value) {
        var elements = $("." + value);
        var color = $("#ClassColor").val();
        elements.each(function () {
            this.style.background = color;
        });
    }
});