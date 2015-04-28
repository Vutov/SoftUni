<?php
$list = $_GET['list'];
$minSeats = intval($_GET['minSeats']);
$maxSeats = intval($_GET['maxSeats']);
$filter = $_GET['filter'];
$order = $_GET['order'];

$list = preg_split('/\n/', $list, null, PREG_SPLIT_NO_EMPTY);
//var_dump($list);
//var_dump($minSeats);
//var_dump($maxSeats);
//var_dump($filter);
//var_dump($order);

$regex = '/\s*(.*?)\s*\(\s*(.*?)\s*\)\s*-\s*(.*?)\s*\/\s*(\d*)/';
$valid = [];
foreach ($list as $row) {
    preg_match_all($regex, $row, $matches);
//    var_dump($matches);
    if ($matches[2][0] === $filter || $filter === 'all') {
        $seats = intval($matches[4][0]);
        if ($seats >= $minSeats && $seats <= $maxSeats) {
            $valid[] = ['name' => $matches[1][0], 'genre' => $matches[2][0], 'actors' => $matches[3][0], 'seats' => $seats];
        }
    }
}
//var_dump($valid);
uksort($valid, function ($x, $y) use ($valid, $order) {
//    var_dump($valid[$x]);
    if ($valid[$x]['name'] === $valid[$y]['name']) {
        return $valid[$x]['seats'] > $valid[$y]['seats'];
    }
    if ($order === 'ascending') {
        return strcmp($valid[$x]['name'], $valid[$y]['name']);
    } else {
        return strcmp($valid[$y]['name'], $valid[$x]['name']);
    }
});
//var_dump($valid);
foreach ($valid as $key => $movie) {
    echo "<div class=\"screening\"><h2>" . htmlspecialchars($movie['name']) . "</h2><ul>";
    $actors = preg_split('/,\s/', $movie['actors']);
    foreach ($actors as $actor) {
        echo "<li class=\"star\">" . htmlspecialchars($actor) . "</li>";
    }
    echo "</ul><span class=\"seatsFilled\">" . $movie['seats'] . " seats filled</span></div>";
}