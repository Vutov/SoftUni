<?php
date_default_timezone_set('UTC');
$startDate = $_GET['dateOne'];
$time = preg_split('/-/', $startDate);
$endDate = $_GET['dateTwo'];

$difference = strtotime($endDate) - strtotime($startDate);
if($difference < 0){
    $difference = strtotime($startDate) - strtotime($endDate);
    $time = preg_split('/-/', $endDate);
}

// getting the difference in minutes
$diff = $difference / (60 * 60 * 24);
$found = false;
$print = true;
for ($i = 0; $i <= $diff; $i++) {
    //echo date('D', mktime(0,0,0, $time[1],$time[0],$time[2]));
    if (date('D', mktime(0, 0, 0, $time[1], $time[0], $time[2])) === 'Thu') {
        if($print){
            if(!$found){
                echo '<ol>';
                $print = false;
                $found = true;
            }
        }
        echo "<li>" . date('d-m-Y', mktime(0, 0, 0, $time[1], $time[0], $time[2])) . "</li>";
    }

    $time[0]++;


}
if (!$found) {
    echo '<h2>No Thursdays</h2>';
} else {
    echo '</ol>';
}
