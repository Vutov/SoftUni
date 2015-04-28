<?php
date_default_timezone_set('UTC');
$list = $_GET['list'];
$currDate = date_create(trim($_GET['currDate']));
//var_dump($list);
//var_dump($currDate);
$lines = preg_split('/\n/', $list, null, PREG_SPLIT_NO_EMPTY);
//var_dump($lines);
$dates = [];
foreach ($lines as $date) {
//    var_dump($date);
    $tmp = date_create($date);
    $dates[] = $tmp;
}
//var_dump($dates);
sort($dates);
echo "<ul>";
foreach ($dates as $date) {
    if ($date) {
        if ($date < $currDate) {
            echo "<li><em>" . $date->format('d/m/Y') . "</em></li>";
        } else {
            echo "<li>" . $date->format('d/m/Y') . "</li>";
        }
    }
}
echo "</ul>";
