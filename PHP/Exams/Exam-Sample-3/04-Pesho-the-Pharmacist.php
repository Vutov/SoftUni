<?php
date_default_timezone_set('UTC');
$today = preg_split('/\//', $_GET['today']);
//var_dump($today);
$data = $_GET['invoices'];
//var_dump($data);
$result = [];
foreach ($data as $line) {
    preg_match_all('/\s*(.*?)\s*\|\s*(.*?)\s*\|\s*(.*?)\s*\|\s*(\d*\.?\d*)/', $line, $match);
    //var_dump($match);
    $info = preg_split('/\//', $match[1][0]);
    $curDate = strtotime($info[2] . '/' . $info[1] . '/' . $info[0]);
    $deadLine = strtotime(($today[2] - 5) . '/' . $today[1] . '/' . $today[0]);
    if ($curDate >= $deadLine) {
        $date = $match[1][0];
        $company = $match[2][0];
        $product = $match[3][0];
        $price = $match[4][0];

        $result[$date][$company][$product] = $price;
    }
}
uksort($result, function($x, $y) {
    $first = preg_split('/\//', $x);
    $second = preg_split('/\//', $y);
    $f = strtotime($first[2] . '/' . $first[1] . '/' . $first[0]);
    $s = strtotime($second[2] . '/' . $second[1] . '/' . $second[0]);
    return $f - $s;
});
//var_dump($result);
echo "<ul>";
foreach ($result as $date => $companies) {
    //var_dump($companies);
    ksort($companies);
    echo '<li><p>' . $date . '</p>';
    foreach ($companies as $company => $values) {
        echo '<ul><li><p>' . $company . '</p>';
        ksort($values);
        $product = [];
        $sum = 0;
        foreach ($values as $key => $price) {
            $product[] = $key;
            $sum += floatval($price);
        }
//        var_dump(join($product, ','));
//        var_dump($sum);
        echo '<ul><li><p>' . join($product, ',') . '-' . $sum . 'lv' . '</p></li></ul>';
        echo '</li></ul>';
    }
    echo '</li>';
}
echo "</ul>";
//var_dump($result);
