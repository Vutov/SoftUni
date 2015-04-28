<?php
/**
 * http://stackoverflow.com/questions/5843322/php-create-a-spiral
 * Creates a 2D array with the given dimensions,
 * whose elements are numbers in increasing order
 * rendered in a 'spiral' pattern.
 */
function createSpiral($w, $h, $text)
{
//    var_dump($text);
    if ($w <= 0 || $h <= 0) return FALSE;

    $ar = Array();
    $used = Array();

    // Establish grid
    for ($j = 0; $j < $h; $j++) {
        $ar[$j] = Array();
        for ($i = 0; $i < $w; $i++)
            $ar[$j][$i] = '-';
    }

    // Establish 'used' grid that's one bigger in each dimension
    for ($j = -1; $j <= $h; $j++) {
        $used[$j] = Array();
        for ($i = -1; $i <= $w; $i++) {
            if ($i == -1 || $i == $w || $j == -1 || $j == $h)
                $used[$j][$i] = true;
            else
                $used[$j][$i] = false;
        }
    }

    // Fill grid with spiral
    $n = 0;
    $i = 0;
    $j = 0;
    $direction = 0; // 0 - left, 1 - down, 2 - right, 3 - up
    while (true) {
        $ar[$j][$i] = $text[$n++];
        $used[$j][$i] = true;
        // Advance
        switch ($direction) {
            case 0:
                $i++; // go right
                if ($used[$j][$i]) { // got to RHS
                    $i--;
                    $j++; // go back left, then down
                    $direction = 1;
                }
                break;
            case 1:
                $j++; // go down
                if ($used[$j][$i]) { // got to bottom
                    $j--;
                    $i--; // go back up, then left
                    $direction = 2;
                }
                break;
            case 2:
                $i--; // go left
                if ($used[$j][$i]) { // got to LHS
                    $i++;
                    $j--; // go back left, then up
                    $direction = 3;
                }
                break;
            case 3:
                $j--; // go up
                if ($used[$j][$i]) { // got to top
                    $j++;
                    $i++; // go back down, then right
                    $direction = 0;
                }
                break;
        }

        // if the new position is in use, we're done!
        if ($used[$j][$i])
            return $ar;
    }
}

$size = $_GET['size'];
//var_dump($size);
$text = $_GET['text'];

$ar = createSpiral($size, $size, $text);
//var_dump($ar);
$white = '';
$black = '';
for ($i = 0; $i < count($ar); $i++) {
    for ($j = 0; $j < count($ar[$i]); $j++) {
        if ($i % 2 === 1) { //odd
            if ($j % 2 === 1) { //odd
                if ($ar[$i][$j] === '') {
                    $white .= ' ';
                } else {
                    $white .= $ar[$i][$j];
                }
            } else {
                if ($ar[$i][$j] === '') {
                    $black .= ' ';
                } else {
                    $black .= $ar[$i][$j];
                }
            }
        } else { //even
            if ($j % 2 === 1) { //odd
                if ($ar[$i][$j] === '') {
                    $black .= ' ';
                } else {
                    $black .= $ar[$i][$j];
                }
            } else {
                if ($ar[$i][$j] === '') {
                    $white .= ' ';
                } else {
                    $white .= $ar[$i][$j];
                }
            }
        }
    }
}
$result = $white . $black;
$tmp = strtolower(preg_replace('/[^a-zA-Z]+/', '', $result ));
$rev = strrev($tmp);
//var_dump($tmp);
//var_dump($rev);
if ($tmp === $rev) {
    echo "<div style='background-color:#4FE000'>$result</div>";
} else {
    echo "<div style='background-color:#E0000F'>$result</div>";
}



