<?php
$luggage = $_GET['luggage'];
$typeLuggage = $_GET['typeLuggage'];
$minWeight = $_GET['minWeight'];
$maxWeight = $_GET['maxWeight'];
$room = $_GET['room'];
//var_dump($luggage);
//var_dump($typeLuggage);
//var_dump($minWeight);
//var_dump($maxWeight);
$regex = '/\s*(.*?)\s*;\s*(.*?)\s*;\s*(.*?)\s*;\s*(.*?)\s*kg\s*C\|_\|/';
preg_match_all($regex, $luggage, $matches);
//var_dump($matches);
$data = [];
for ($i = 0; $i < count($matches[0]); $i++) {
    if ($matches[2][$i] === $room && in_array($matches[1][$i], $typeLuggage)) {
        $data[$matches[1][$i]][$matches[2][$i]][$matches[3][$i]] = intval($matches[4][$i]);
    }
}
//var_dump($data);
$filteredData = array_filter($data, function ($x) use ($minWeight, $maxWeight, $room) {
    if (array_sum($x[$room]) >= $minWeight && array_sum($x[$room]) <= $maxWeight) {
        return $x;
    }
});
//var_dump($filteredData);
ksort($filteredData);
//var_dump($filteredData);
echo "<ul>";
foreach ($filteredData as $key => $type) {
//    var_dump($type);
    $sum = 0;
    $items = [];
    foreach ($type[$room] as $stuff => $kg) {
        $sum += $kg;
        $items[] = $stuff;
    }
//    var_dump($sum);
    sort($items);
    echo "<li><p>$key</p><ul><li><p>$room</p><ul><li><p>".join($items, ', ')." - {$sum}kg</p></li></ul></li></ul></li>";

}
echo "</ul>";