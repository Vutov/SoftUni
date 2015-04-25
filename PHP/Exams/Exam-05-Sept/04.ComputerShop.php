<?php
$list = $_GET['list'];
$minPrice = floatval($_GET['minPrice']);
$maxPrice = floatval($_GET['maxPrice']);
$filter = $_GET['filter'];
$order = $_GET['order'];
//var_dump($list);
//var_dump($minPrice);
//var_dump($maxPrice);
//var_dump($filter);
//var_dump($order);
$regex = '/\s*(.*?)\s*\|\s*(.*?)\s*\|\s*(.*?)\s*\|\s*(.*)\s*/';
preg_match_all($regex, $list, $matches);
//var_dump($matches);
$data = [];
for ($i = 0; $i < count($matches[0]); $i++) {
    $data[] = [
        'id' => $i + 1,
        'name' => trim($matches[1][$i]),
        'type' => trim($matches[2][$i]),
        'component' => trim($matches[3][$i]),
        'price' => trim($matches[4][$i]),
    ];
}
//var_dump($data);
$filteredData = array_filter($data, function ($x) use ($minPrice, $maxPrice, $filter) {
    if (floatval($x['price']) <= $maxPrice && floatval($x['price']) >= $minPrice) {
        if ($filter === 'all') {
            return $x;
        } else if ($x['type'] === $filter) {
            return $x;
        }
    }
});
usort($filteredData, function ($x, $y) use ($order) {
    if ($order === 'ascending') {
        if (floatval($x['price']) === floatval($y['price'])) {
            return $x['id'] > $y['id'];
        } else {
            return floatval($x['price']) > floatval($y['price']);
        }
    } else {
        if (floatval($x['price']) === floatval($y['price'])) {
            return $x['id'] > $y['id'];
        } else {
            return floatval($x['price']) < floatval($y['price']);
        }
    }
});
//var_dump($filteredData);
foreach ($filteredData as $product) {
    echo '<div class="product" id="product' . htmlspecialchars($product['id']) . '"><h2>' . htmlspecialchars($product['name']) . '</h2>';
    echo '<ul>';
    $components = preg_split('/,/', $product['component'], null, PREG_SPLIT_NO_EMPTY);
    foreach ($components as $component) {
        echo '<li class="component">' . htmlspecialchars(trim($component)) . '</li>';
    }
    echo '</ul>';
    echo '<span class="price">' . htmlspecialchars(number_format($product['price'], 2, '.', '')) . '</span></div>';
}