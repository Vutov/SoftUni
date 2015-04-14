<?php
$text = $_GET['text'];
$hashValue = intval($_GET['hashValue']);
$fontSize = intval($_GET['fontSize']);
$fontStyle = $_GET['fontStyle'];
for ($i = 0; $i < strlen($text); $i++) {
    if ($i % 2 === 0) {
        $text[$i] = chr(ord($text[$i]) + $hashValue);
    } else {
        $text[$i] = chr(ord($text[$i]) - $hashValue);
    }
}
if($fontStyle === 'bold'){
    echo "<p style=\"font-size:$fontSize;font-weight:bold;\">$text</p>";
} else {
    echo "<p style=\"font-size:$fontSize;font-style:$fontStyle;\">$text</p>";
}