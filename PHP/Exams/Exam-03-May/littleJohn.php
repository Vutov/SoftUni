<?php
$arrows = $_GET['arrows'];
$arrows1 = $_GET['arrows1'];
$arrows2 = $_GET['arrows2'];
$arrows3 = $_GET['arrows3'];
$arrows.= '|' .$arrows1;
$arrows.= '|' .$arrows2;
$arrows.= '|' . $arrows3;
//var_dump($arrows);
$regex = '/(>>>----->>)|(>>----->)|(>----->)/';

preg_match_all($regex, $arrows, $matches);
//var_dump($matches);
$data = ['small' => 0, 'medium' => 0, 'large' => 0];
for ($i = 0; $i < count($matches[0]); $i++) {
    if ($matches[1][$i] != '') {
        $data['large']++;
    }
    if ($matches[2][$i] != '') {
        $data['medium']++;
    }
    if ($matches[3][$i] != '') {
        $data['small']++;
    }
}
//var_dump($data);
$num = intval($data['small'] . $data['medium'] . $data['large']);
$bin = decbin($num);
$rev = strrev($bin);
$result = $bin . $rev;
$end = bindec($result);
//var_dump($end);
echo $end;
//Func;