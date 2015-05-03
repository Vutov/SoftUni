<?php
$input = strtolower($_GET['data']);
//var_dump($input);
$mines = preg_split('/,/', $input, null, PREG_SPLIT_NO_EMPTY);
//var_dump($mines);
$result = ['Gold' => 0, 'Silver' => 0, 'Diamonds' => 0];
foreach ($mines as $mine) {
    preg_match('/mine\s+.+?\s+(.+?)\s+(\d+)/', $mine, $match);
//    var_dump($match);
    if ($match[1] === 'gold') {
        $result['Gold'] += $match[2];
    }
    if ($match[1] === 'silver') {
        $result['Silver'] += $match[2];
    }
    if ($match[1] === 'diamonds') {
        $result['Diamonds'] += $match[2];
    }
}
//var_dump($result);
foreach ($result as $type => $value) {
    echo "<p>*$type: $value</p>";
}

//1.no case sensitive!
//2.start with biggest arrow