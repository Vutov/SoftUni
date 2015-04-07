<?php

//Find first Sunday;
$firstSunday = 0;
for ($i = 1; $i < 8; $i++) {
    if(date("D", mktime(0, 0, 0,  date('m'), $i, date('Y'))) === 'Sun'){
        $firstSunday = $i;
        break;
    }
}
//Get all the rest;
while (date("D", mktime(0, 0, 0,  date('m'), $firstSunday, date('Y'))) === 'Sun' &&
        date("M", mktime(0, 0, 0,  date('m'), $firstSunday, date('Y'))) === date('M') ) {
    echo date("jS F, Y", mktime(0, 0, 0,  date('m'), $firstSunday, date('Y'))) . "</br>";
    $firstSunday += 7;
}

?>