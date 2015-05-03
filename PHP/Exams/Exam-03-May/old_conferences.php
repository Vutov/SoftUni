<?php
date_default_timezone_set('UTC');
$page = intval($_GET['page']);
$pageSize = intval($_GET['pageSize']);
$conferences = $_GET['conferences'];
//var_dump($conferences);
$regex = '/\[((?:\d{4}-\d{2}-\d{2})|(?:\d{4}\/\d{2}\/\d{2})), (#[a-zA-Z\.\-]+), \'(.*?)\', ([a-zA-z,-]+), ([0-9]+), ([0-9]+)\]/';
preg_match_all($regex, $conferences, $matches);
//var_dump($matches);
$data = [];
for ($i = 0; $i < count($matches[0]); $i++) {
    $left = intval($matches[5][$i]) - intval($matches[6][$i]);
//    if ($left < 0) {
//        $left = 0;
//    } //????
    $date = str_replace('/', '-', $matches[1][$i]);
//    if (validateDate($date)) {
        $data[] = [
            'date' => $date, 'event' => $matches[2][$i],
            'hash' => $matches[2][$i], 'seatsLest' => $left,
            'location' => $matches[4][$i], 'name' => $matches[3][$i],
            'len' => 1

        ];
//    }

}
//var_dump($data);
//var_dump(1);
usort($data, function ($x, $y) {
//    var_dump(date_create($x['date']));
//    var_dump(date_create($y['date']));
    if (strtotime($x['date']) == strtotime($y['date'])) {
        if ($x['location'] === $y['location']) {
            if ($x['seatsLest'] == $y['seatsLest']) {
                return strcmp($x['name'], $y['name']);
            }
            return $x['seatsLest'] < $y['seatsLest'];
        }
        return strcmp($x['location'], $y['location']);
    }
    return strtotime($x['date']) < strtotime($y['date']);
});
//var_dump($data);
//var_dump($page);
//var_dump($pageSize);
$start = $page * $pageSize - $pageSize;
$end = $page * $pageSize;
//var_dump($start);
//var_dump($end);
$startCel = 0;
$len = 1;
for ($i = 0; $i < count($data); $i++) {
    if (strtotime($data[$i]['date']) == strtotime($data[$i + 1]['date'])) {
        $len++;
    } else {
        $data[$startCel]['len'] = $len;
        $startCel = $i;
        $len = 1;
    }
}
//var_dump($data);
//$eventDate = date_format(date_create($data[0]['date']), 'Y-m-d');
//$eventDate = date('Y-m-d', strtotime($data[0]['date']));
//var_dump($eventDate);

$skip = 1;
echo "<table border=\"1\" cellpadding=\"5\"><tr><th>Date</th><th>Event name</th><th>Event hash</th><th>Days left</th><th>Seats left</th></tr>";
for ($i = $start; $i < $end; $i++) {
    echo "<tr>";
    if ($i > count($data) - 1) {
        echo "<td>-</td><td>-</td><td>-</td><td>-</td><td>-</td></tr>";
        break;
    } else {
        $eventDate = $data[$i]['date'];
        if ($skip > 1) {
            $skip--;
        } else if ($data[$i]['len'] > 1) {
            $len = $data[$i]['len'];
            if ($len > $pageSize) {
                $len = $pageSize;
            }
            echo "<td rowspan=\"$len\">$eventDate</td>";
            $skip = $data[$i]['len'];
        } else {
            echo "<td>$eventDate</td>";
        }
//    var_dump($data[$i]['name']);
        $name = $data[$i]['name'];
        $tag = $data[$i]['hash'];
        //http://stackoverflow.com/questions/2040560/finding-the-number-of-days-between-two-dates
        //str to date may fuck me!
        $now = time(); // or your date as well
        $your_date = strtotime($data[$i]['date']);
        $datediff = $now - $your_date;
        $daysLeft = floor($datediff / (60 * 60 * 24));
        $seatsLeft = $data[$i]['seatsLest'];
        if ($daysLeft < 0) {
            $daysLeft *= -1;
        }
//    var_dump($daysLeft);
        if (strtotime($data[$i]['date']) >= strtotime('2015-05-03')) {
            $strDaysLeft = "+$daysLeft days";
        } else {
            $strDaysLeft = "-$daysLeft days";
        }
        echo "<td>$name</td><td>$tag</td><td>$strDaysLeft</td><td>$seatsLeft seats left</td></tr>";
    }
}
echo "</table>";



//function validateDate($date)
//{
//    $d = DateTime::createFromFormat('Y-m-d', $date);
//    return $d && $d->format('Y-m-d') == $date;
//}