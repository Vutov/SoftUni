<?php
date_default_timezone_set('UTC');
$curDate = $_GET['currentDate'];
$text = $_GET['messages'];
//var_dump($curDate);
//var_dump($text);
$data = [];
preg_match_all('/(.*?)\s\/\s([\d-: ]*)/', $text, $matches);
for ($i = 0; $i < count($matches[1]); $i++) {
    $data[$matches[2][$i]] = $matches[1][$i];
}
uksort($data, function ($x, $y) {
    return strtotime($x) - strtotime($y);
});
//var_dump($data);
//Move to last element;
end($data);
//var_dump($data);
//Get it's key;
$lastKey = key($data);

$curDateSplited = preg_split('/-/', $curDate);
$lastDateSplited = preg_split('/-/', $lastKey);
$timeStamp = '';
if (intval($curDateSplited[0]) - intval($lastDateSplited[0]) === 1) {
    $timeStamp = 'yesterday';
} else if (intval($curDateSplited[0]) - intval($lastDateSplited[0]) > 1) {
    $timeStamp = date('d-m-Y', strtotime($lastKey));
} else {
    $hourdiff = floor((strtotime($curDate) - strtotime($lastKey)) / 3600);
    if ($hourdiff >= 1) {
        $timeStamp = "$hourdiff hour(s) ago";
    } else {
        $minDiff = floor((strtotime($curDate) - strtotime($lastKey)) / 60);
//        var_dump($minDiff);
        if ($minDiff >= 1) {
            $timeStamp = "$minDiff minute(s) ago";
        } else {
            $timeStamp = 'a few moments ago';
        }
    }
}
foreach ($data as $message) {
    echo "<div>". htmlspecialchars($message). "</div>\n";
}
echo "<p>Last active: <time>$timeStamp</time></p>";
//var_dump(date('h/i/s/d/m/y)', strtotime($curDate)));