<?php
$numbersString = $_GET['numbersString'];
$regex = '/([A-Z]+[a-zA-Z]*)[^a-zA-Z\+]*?(\+?\d[\d\(\)\/\.\- ]{1,})/';
preg_match_all($regex, $numbersString, $matches);
$info = [];
//var_dump($numbersString);
for ($i = 0; $i < count($matches[0]); $i++) {
    $num = preg_replace('/[\(\)\/\.\- ]*/', '', $matches[2][$i]);
    if($num){
        $info[$matches[1][$i]] = $num;
    }
}
//var_dump($info);
if(count($info) > 0){
    echo "<ol>";
    foreach ($info as $name => $num) {
        echo "<li><b>{$name}:</b> $num</li>";
    }

    echo "</ol>";
} else {
    echo "<p>No matches!</p>";
}