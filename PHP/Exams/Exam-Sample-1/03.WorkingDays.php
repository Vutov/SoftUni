<?php
date_default_timezone_set('UTC');
$start = preg_split('/-/', $_GET['dateOne']);
$end = preg_split('/-/', $_GET['dateTwo']);
//var_dump($_GET['dateOne']);
//var_dump($_GET['dateTwo']);
$holidays = preg_split('/\s+/', $_GET['holidays'], -1, PREG_SPLIT_NO_EMPTY);
$startDate = date('d/m/y', mktime(0, 0, 0, $start[1], $start[0], $start[2]));
$endDate = date('d/m/y', mktime(0, 0, 0, $end[1], $end[0], $end[2]));
//var_dump($holidays);

$firstDate = strtotime("$start[2]-$start[1]-$start[0]");
$secondDate = strtotime("$end[2]-$end[1]-$end[0]");
$datediff = $secondDate - $firstDate;
$datediff = floor($datediff/(60*60*24));
//var_dump($datediff);
$found = false;
$printed = true;
for ($i = 0; $i <= $datediff; $i++) {
    $currDate = date("d-m-Y", mktime(0, 0, 0, $start[1], $start[0], $start[2]));
    if (date("D", mktime(0, 0, 0, $start[1], $start[0], $start[2])) != 'Sun' &&
        date("D", mktime(0, 0, 0, $start[1], $start[0], $start[2])) != 'Sat'
    ) {
        if (!in_array($currDate, $holidays)) {
            $found = true;
            if($found){
                if($printed){
                    echo "<ol>";
                    $printed = false;
                }

            }
            echo "<li>" . date("d-m-Y", mktime(0, 0, 0, $start[1], $start[0], $start[2])) . "</li>";
        }
    }


    $start[0]++;
}
if($found){
    echo "</ol>";
}
else {
    echo "<h2>No workdays</h2>";
}