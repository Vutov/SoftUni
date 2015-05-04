<?php
date_default_timezone_set('UTC');
$page = intval($_GET['page']);
$pageSize = intval($_GET['pageSize']);
$conferences = $_GET['conferences'];
//Get all needed data via regex;
$regex = '/\[((?:\d{4}-\d{2}-\d{2})|(?:\d{4}\/\d{2}\/\d{2})), (#[a-zA-Z\.\-]+), \'(.*?)\', ([a-zA-z,-]+), ([0-9]+), ([0-9]+)\]/';
preg_match_all($regex, $conferences, $matches);
//Fill data array containing all the info for the events;
$data = [];
for ($i = 0; $i < count($matches[0]); $i++) {
    $left = intval($matches[5][$i]) - intval($matches[6][$i]);
    //Make DateTime class friendly date and ensure we are working with same dates;
    $date = str_replace('/', '-', $matches[1][$i]);
    $data[] = [
        'date' => $date, 'event' => $matches[2][$i],
        'hash' => $matches[2][$i], 'seatsLest' => $left,
        'location' => $matches[4][$i], 'name' => $matches[3][$i],
    ];
}
//Sort;
usort($data, function ($x, $y) {
    if (date_create($x['date']) == date_create($y['date'])) {
        if ($x['location'] === $y['location']) {
            if ($x['seatsLest'] == $y['seatsLest']) {
                return strcmp($x['name'], $y['name']);
            }
            return $x['seatsLest'] < $y['seatsLest'];
        }
        return strcmp($x['location'], $y['location']);
    }
    return date_create($x['date']) < date_create($y['date']);
});
//Get needed elements;
$start = $page * $pageSize - $pageSize;
$end = $page * $pageSize;
$neededStuff = [];
for ($i = $start; $i < $end; $i++) {
    if($i > count($data) - 1){
        break;
    }
    $neededStuff[] = $data[$i];
}
//Get dates and set rowspan length;
$dates = [];
for ($i = 0; $i < count($neededStuff); $i++) {
    $dates[$neededStuff[$i]['date']]++;
}
foreach ($dates as $key => $value) {
    $dates[$key] = ['len' => $value, 'used' => false];
}
//Print;
$now = date_create('2015-05-03');
echo "<table border=\"1\" cellpadding=\"5\"><tr><th>Date</th><th>Event name</th><th>Event hash</th><th>Days left</th><th>Seats left</th></tr>";
for ($i = 0; $i < count($neededStuff); $i++) {
    $date = $neededStuff[$i]['date'];
    $name = htmlspecialchars($neededStuff[$i]['name']);
    $tag = htmlspecialchars($neededStuff[$i]['hash']);
    $diff = date_diff($now, date_create($date));
    $diff = $diff->format('%R%a days');
    $seatsLeft = $neededStuff[$i]['seatsLest'];
    echo "<tr>";
    if (!$dates[$date]['used']) {
        $dates[$date]['used'] = true;
        $len = $dates[$date]['len'];
        if ($len > 1) {
            echo "<td rowspan=\"$len\">$date</td>";
        } else {
            echo "<td>$date</td>";
        }
    }
    echo "<td>$name</td><td>$tag</td><td>$diff</td><td>$seatsLeft seats left</td></tr>";
}
if (!count($neededStuff)) {
    echo "<tr><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td></tr>";
}
echo "</table>";