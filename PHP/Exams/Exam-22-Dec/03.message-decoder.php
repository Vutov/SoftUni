<?php
$json = json_decode($_GET['jsonTable']);
//var_dump($json);
$pings = join($json[1], '\\');
preg_match_all('/time\s*=\s*(\d*)\s*ms/', $pings, $matches);
$message = '';
//var_dump($matches);
foreach ($matches[1] as $letter) {
//    var_dump($letter);
    $message .= chr($letter);
}
//var_dump($message);
$words = explode('*', $message);
//var_dump($words);
echo '<table border=\'1\' cellpadding=\'5\'>';
foreach ($words as $word) {
//    var_dump($word);
    $count = 0;
    if(strlen($word) % $json[0] !== 0){
        $len = strlen($word) + $json[0] - (strlen($word) % $json[0]);
    } else {
        $len = strlen($word);
    }
//    var_dump($len);
    $closed = false;
    for ($i = 0; $i < $len; $i++) {
        if($count === 0){
            echo "<tr>";
        }
        if($count === $json[0]){
            echo "</tr>";
            $i--;
            $count = 0;
            $close = true;
        }
        else {
            if ($word[$i] === ' ' || $word[$i] === '') {
                echo "<td></td>";
            } else {
                echo "<td style='background:#CAF'>" . $word[$i] . "</td>";
            }
            $count++;
        }
    }
    if(!$closed){
        echo "</tr>";
    }
}
echo '</table>';
//foreach ($matches[1] as $letter) {
//    $message[] = chr($letter);
//}
////var_dump($message);
//$count = 0;
////var_dump($json[0]);
//echo '<table border=\'1\' cellpadding=\'5\'>';
//for ($i = 0; $i < count($message); $i++) {
//    for ($j = 0; $j < $json[0]; $j++) {
////        var_dump($message[$i]);
//        if($message[$i] === '*' && $j === 0){
//            break;
//        }
//        if($j === 0){
//            echo '<tr>';
//        }
//        if ($message[$i] === '*' || $i >= count($message)) {
//            echo "<td></td>";
//        } else {
//            if ($message[$i] === ' ') {
//                echo "<td></td>";
//            } else {
//                echo "<td style='background:#CAF'>" . $message[$i] . "</td>";
//            }
//            if ($j < $json[0] - 1) {
//                $i++;
//            }
//        }
//        if($j === $json[0] - 1){
//            echo '</tr>';
//        }
//    }
//}
//echo '</table>';
