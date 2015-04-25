<?php
$text = $_GET['text'];
$red = getHex($_GET['red']);
$green = getHex($_GET['green']);
$blue = getHex($_GET['blue']);
$color = '#'.$red.$green.$blue;
$nth = $_GET['nth'];

var_dump($color);
var_dump('738f0d');

echo "<p>";
for ($i = 1; $i <= strlen($text); $i++) {
    if($i % $nth === 0){
        echo "<span style=\"color: $color\">" . htmlspecialchars($text[$i - 1]) . "</span>";
    }
    else {
        echo htmlspecialchars($text[$i - 1]);
    }
}
echo "</p>";

function getHex($color)
{
    $color = dechex($color);
    var_dump($color);
    if (strlen($color) === 1) {
        $color .= $color;
    }
    return $color;
}