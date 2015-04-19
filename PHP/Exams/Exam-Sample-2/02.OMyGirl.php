<?php
$text = $_GET['text'];
//var_dump($text);
$key = $_GET['key'];
//var_dump($key);
$regex = preg_quote($key[0]);
$digits = '[0-9]*';
$lettersLow = '[a-z]*';
$lettersUp = '[A-Z]*';
$capture = '(.{2,6})';
for ($i = 1; $i < strlen($key) - 1; $i++) {
    if ($key[$i] >= 'a' && $key[$i] <= 'z') {
        $regex .= $lettersLow;
    } elseif ($key[$i] >= 'A' && $key[$i] <= 'Z') {
        $regex .= $lettersUp;
    } elseif ($key[$i] >= '0' && $key[$i] <= '9') {
        $regex .= $digits;
    } else {
        $regex .= preg_quote($key[$i]);
    }
}
$regex .= preg_quote($key[strlen($key) - 1]);
$finalRegex = '/' . $regex . $capture . $regex . '/';
//var_dump($finalRegex);
preg_match_all($finalRegex, $text, $matches);
echo join('', $matches[1]);