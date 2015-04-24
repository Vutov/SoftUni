<?php
$text = $_GET['text'];
$len = $_GET['lineLength'];
//var_dump($text);
//var_dump($len);
$matrix = [];
$count = 0;
$row = [];
//Fill matrix;
for ($i = 0; $i < strlen($text); $i++) {
    if ($count < $len) {
        $row[] = $text[$i];
        $count++;
    } else {
        $matrix[] = $row;
        $row = [];
        $count = 0;
        $i--;
    }

}
//Last row;
if (count($row) < $len) {
    $pad = $len - count($row);
    for ($i = 0; $i < $pad; $i++) {
        $row[] = ' ';
    }
//    var_dump($row);
}
$matrix[] = $row;

//Move;
for ($i = 0; $i < 10; $i++) { //if multiple spaced after one an other;
    for ($row = count($matrix) - 1; $row >= 1; $row--) {
        for ($col = 0; $col < count($matrix[$row]); $col++) {
            if($matrix[$row][$col] == ' '){
                $temp = $matrix[$row][$col];
                $matrix[$row][$col] = $matrix[$row - 1][$col];
                $matrix[$row - 1][$col] = $temp;
            }
        }
//        printMatrix($matrix);
//        echo '-----------';
    }
}
//var_dump($matrix);
printMatrix($matrix);

function printMatrix($matrix)
{
    echo "<table>";
    for ($row = 0; $row < count($matrix); $row++) {
        echo "<tr>";
        for ($col = 0; $col < count($matrix[$row]); $col++) {
            if($matrix[$row][$col] === null){
                $matrix[$row][$col] = ' ';
            }
            echo "<td>" . htmlspecialchars($matrix[$row][$col]) . "</td>";
        }
        echo "</tr>";
    }
    echo "<table>";
}