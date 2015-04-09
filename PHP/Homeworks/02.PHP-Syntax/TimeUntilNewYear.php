<?php
$today = getdate();
//var_dump($today);
$daysLeft = 365 - $today['yday'];
$hoursLeft = $daysLeft * 24 - $today['hours'];
$minsLeft = $hoursLeft * 60 - $today['minutes'];;
$secsLeft = $minsLeft * 60 - $today['seconds'];;
$left = [(24 - $today['hours']), 60 - $today['minutes'], 60 - $today['seconds']];

echo "Hours until new year : " .  number_format($hoursLeft, 0, ',', ' '). "</br>";
echo "Minutes until new year : " . number_format($minsLeft, 0, ',', ' ') . "</br>";
echo "Seconds until new year : " . number_format($secsLeft, 0, ',', ' ') . "</br>";
echo "Days:Hours:Minutes:Seconds : $daysLeft:$left[0]:$left[1]:$left[2]";

?>