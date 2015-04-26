<?php
$regex = '/^([a-zA-Z_]+)\d.*?\d([a-zA-Z_]*)$/';
preg_match($regex, $_GET['keys'], $keys);
//var_dump($keys);
$start = preg_quote($keys[1]);
$end = preg_quote($keys[2]);
$searchRegex = "/$start(.*?)$end/";
//var_dump($searchRegex);
preg_match_all($searchRegex, $_GET['text'], $matches);
//var_dump($matches);
$sum = 0;
for ($i = 0; $i < count($matches[0]); $i++) {
    $sum += floatval($matches[1][$i]);
}
//var_dump($sum);
if ($start === '' || $end === '') {
    echo "<p>A key is missing</p>";
} else if ($sum === 0) {
    echo "<p>The total value is: <em>nothing</em></p>";
} else {
    echo "<p>The total value is: <em>$sum</em></p>"; //format
}