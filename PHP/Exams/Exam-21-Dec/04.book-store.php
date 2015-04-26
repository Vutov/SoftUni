<?php
date_default_timezone_set('UTC');
$text = $_GET['text'];
$minPrice = floatval($_GET['min-price']);
$maxPrice = floatval($_GET['max-price']);
$sort = $_GET['sort'];
$order = $_GET['order'];
//print($text);
//var_dump($minPrice);
//var_dump($maxPrice);
//var_dump($sort);
//var_dump($order);
//var_dump($matches);
$data = [];
$lines = preg_split('/\n/', $text, null, PREG_SPLIT_NO_EMPTY);
//var_dump($lines);
for ($j = 0; $j < count($lines); $j++) {
    $matches = preg_split('/\//', trim($lines[$j]), null, PREG_SPLIT_NO_EMPTY);
        $author = trim($matches[0]);
        $name = trim($matches[1]);
        $genre = trim($matches[2]);
        $price = trim($matches[3]);
        $date = trim($matches[4]);
        $info = trim($matches[5]);
        $data[] = [
            'author' => $author,
            'name' => $name,
            'genre' => $genre,
            'price' => floatval($price), //format!
            'publish-date' => $date,
            'info' => $info
        ];
}
//var_dump($data);
$filteredData = array_filter($data, function ($x) use ($minPrice, $maxPrice) {
    if ($x['price'] >= $minPrice && $x['price'] <= $maxPrice) {
        return $x;
    }
});
usort($filteredData, function ($x, $y) use ($sort, $order) {
    if ($order === 'ascending') {
        if ($x[$sort] === $y[$sort] && $sort !== 'publish-date') {
            return strtotime($x['publish-date']) > strtotime($y['publish-date']);
        }
        return $x[$sort] > $y[$sort];
    } else {
        if ($x[$sort] === $y[$sort] && $sort !== 'publish-date') {
            return strtotime($x['publish-date']) > strtotime($y['publish-date']);
        }
        return $x[$sort] < $y[$sort];
    }

});
//var_dump($filteredData);
foreach ($filteredData as $book) {
//    var_dump($book);
    echo "<div><p>" . htmlspecialchars($book['name']) . "</p><ul><li>" . htmlspecialchars($book['author']) . "</li><li>" . htmlspecialchars($book['genre']) . "</li><li>" . htmlspecialchars(number_format($book['price'], 2, '.', '')) . "</li><li>" . htmlspecialchars($book['publish-date']) . "</li><li>" . htmlspecialchars($book['info']) . "</li>";
    echo "</ul>";
    echo "</div>";
}