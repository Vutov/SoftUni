<?php
date_default_timezone_set("UTC");
$numbersString = $_GET['numbersString'];
$dateString = $_GET['dateString'];
//var_dump($numbersString);
//var_dump($dateString);
$numRegex = '/[^a-zA-Z](\d+)[^a-zA-Z]/';
preg_match_all($numRegex, $numbersString, $numMatchs);
$sum = 0;
foreach ($numMatchs[1] as $match) {
    $sum += $match;
}
$sum = (string) $sum;
$sum = strrev($sum);
$dateRegex = '/(\d{4}-\d{2}-\d{2})/';
preg_match_all($dateRegex, $dateString, $dateMatches);
$dates = [];
foreach ($dateMatches[1] as $match) {
    $date = new DateTime($match);
    $date->add(new DateInterval("P". $sum  . "D"));
//    var_dump($date);
    $dates[] = $date->format('Y-m-d');
}
if(!count($dates)){
    echo "<p>No dates</p>";
} else {
    echo "<ul>";
    foreach ($dates as $date) {
        echo "<li>$date</li>";
    }

    echo "</ul>";
}