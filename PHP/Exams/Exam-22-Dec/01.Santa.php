<?php
$name = str_replace(' ', '-', trim($_GET['childName']));
$present = $_GET['wantedPresent'];
$riddles = preg_split('/;/', $_GET['riddles'], null, PREG_SPLIT_NO_EMPTY);
$len = strlen($name);
$riddleNum = $len % count($riddles);
$pickedRiddle = '';
if($riddleNum == 0) {
    $pickedRiddle = $riddles[count($riddles) - 1];
} else {
    $pickedRiddle = $riddles[$riddleNum - 1];
}
//var_dump($pickedRiddle);
//var_dump($name);
//var_dump($present);
//var_dump($riddles);
echo '$giftOf'. htmlspecialchars($name) . " = $[wasChildGood] ? '". htmlspecialchars($present) ."' : '". htmlspecialchars($pickedRiddle) .'\';';