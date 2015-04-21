<?php
$text = $_GET['text'];
$artist = $_GET['artist'];
$property = $_GET['property'];
$order = $_GET['order'];
//var_dump($text);
//var_dump($artist);
//var_dump($property);
//var_dump($order);
$data = [];
preg_match_all('/([^\n][^\|]*?)\s*\|\s*([^\|]*?)\s*\|\s*([^\|]*?)\s*\|\s*([^\|]*?)\s*\|\s*([^\n]*)/', $text, $matches);
//var_dump($matches);
for ($i = 0; $i < count($matches[0]); $i++) {
    $artists = preg_split('/,\s+/', $matches[3][$i]);
    asort($artists);
    $rating = trim($matches[5][$i]);
//    var_dump($rating);
    if (in_array($artist, $artists)) {
        $data[] = [$matches[1][$i], $matches[2][$i], join(', ', $artists), $matches[4][$i], $rating];
    }

}
//var_dump($matches);
//var_dump($data);
usort($data, function ($x, $y) {
    $property = $GLOBALS['property'];
    $order = $GLOBALS['order'];
    if ($property === 'name') {
        if ($order === 'ascending') {
            return $y[0] < $x[0];
        } else {
            return $y[0] > $x[0];
        }
    }
    if ($property === 'genre') {
        if ($y[1] === $x[1]) {
            return $y[0] < $x[0];
        }
        if ($order === 'ascending') {
            return $y[1] < $x[1];
        } else {
            return $y[1] > $x[1];
        }
    }
    if ($property === 'downloads') {
        if (floatval($y[3]) === floatval($x[3])) {
            return $y[0] < $x[0];
        }
        if ($order === 'ascending') {
            return $y[3] < $x[3];
        } else {
            return $y[3] > $x[3];
        }
    }
    if ($property === 'rating') {
        if (floatval($y[4]) === floatval($x[4])) {
            return $y[0] < $x[0];
        }
        if ($order === 'ascending') {
            return $y[4] < $x[4];
        } else {
            return $y[4] > $x[4];
        }
    }

});
//var_dump($data);
echo "<table>\n";
echo "<tr><th>Name</th><th>Genre</th><th>Artists</th><th>Downloads</th><th>Rating</th></tr>\n";
for ($i = 0; $i < count($data); $i++) {
    $rating = floatval($data[$i][4]);
    echo "<tr><td>" . htmlspecialchars($data[$i][0]) . "</td><td>" . htmlspecialchars($data[$i][1]) . "</td><td>" . htmlspecialchars($data[$i][2]) . "</td><td>" . htmlspecialchars($data[$i][3]) . "</td><td>" . htmlspecialchars($rating) . "</td></tr>\n";
}
echo "</table>";