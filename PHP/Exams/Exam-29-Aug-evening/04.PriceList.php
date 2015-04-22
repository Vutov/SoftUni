<?php
$input = $_GET['priceList'];
//print ($input);
$regex = '/\s*<td>\s*(.*?)\s*<\/td>\s*<td>\s*(.*?)\s*<\/td>\s*<td>\s*(.*?)\s*<\/td>\s*<td>\s*(.*?)\s*<\/td>\s*/';
preg_match_all($regex, $input, $data);
//var_dump($data);
$json = [];
for ($i = 0; $i < count($data[0]); $i++) {
    $product = html_entity_decode($data[1][$i]);
    $category = html_entity_decode($data[2][$i]);
    $price = html_entity_decode($data[3][$i]);
    $nomination = html_entity_decode($data[4][$i]);
    $json[$category][] = ['product' => $product, 'price' => $price, 'currency' => $nomination];
}
//var_dump($json);
ksort($json);
//var_dump($json);
foreach ($json as $key => $product) {
    usort($json[$key], function($x, $y) {
       return strcmp($x['product'], $y['product']);
    });
}
//var_dump($json);
echo json_encode($json);