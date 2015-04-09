<?php
// Start the session
session_start();
//var_dump($_SESSION);
?>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>HTML Tags</title>
</head>
<body>
<form action="" method="post">
    <label for="input">Enter HTML tags:</label>
    <input type="text" name="input" id="input"/>
    <input type="submit" name="submit"/>
</form>
<?php
$validTags = ["!DOCTYPE", "a", "abbr", "acronym", "address", "applet", "area", "article", "aside", "audio", "b", "base", "basefont", "bdi",
    "bdo", "big", "blockquote", "body", "br", "button", "canvas", "caption", "center", "cite", "code", "col", "colgroup", "datalist", "dd",
    "del", "details", "dfn", "dialog", "dir", "div", "dl", "dt", "em", "embed", "fieldset", "figcaption", "figure", "font", "footer", "form",
    "frame", "frameset", "h1", "h2", "h3", "h4", "h5", "h6", "head", "header", "hgroup", "hr", "html", "i", "iframe", "img", "input", "ins",
    "kbd", "keygen", "label", "legend", "li", "link", "main", "map", "mark", "menu", "menuitem", "meta", "meter", "nav", "noframes", "noscript",
    "object", "ol", "optgroup", "option", "output", "p", "param", "pre", "progress", "q", "rp", "rt", "ruby", "s", "samp", "script", "section",
    "select", "small", "source", "span", "strike", "strong", "style", "sub", "summary", "sup", "table", "tbody", "td", "textarea", "tfoot", "th",
    "thead", "time", "title", "tr", "track", "tt", "u", "ul", "var", "video", "wbr"];

if ($_POST['submit']) {
    $tag = htmlentities($_POST['input']);
    if (in_array($tag, $validTags)) {
        $_SESSION["count"]++;
        echo '<b>Valid HTML tag!</b></br>';
    } else {
        echo '<b>Invalid HTML tag!</b></br>';
    }
}
if ($_SESSION["count"]) {
    echo "<b>Score: " . $_SESSION["count"] . '</b>';
} else {
    echo "<b>Score: 0 </b>";
}
?>
</body>
</html>