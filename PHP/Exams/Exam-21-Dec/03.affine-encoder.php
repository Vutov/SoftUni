<?php
$json = json_decode($_GET['jsonTable']);
//var_dump($json);
$maxLen = 0;
foreach ($json[0] as $key => $word) {
    $len = strlen($word);
    if ($len > $maxLen) {
        $maxLen = $len;
    }
//    var_dump($len);
    for ($i = 0; $i < strlen($word); $i++) {
        if ($word[$i] >= 'a' && $word[$i] <= 'z') {
            $pos = ord($word[$i]) - ord('a');
            $json[0][$key][$i] = chr(ord('A') + ($json[1][0] * $pos + $json[1][1]) % 26);
        } elseif ($word[$i] >= 'A' && $word[$i] <= 'Z') {
            $pos = ord($word[$i]) - ord('A');
            $json[0][$key][$i] = chr(ord('A') + ($json[1][0] * $pos + $json[1][1]) % 26);
        }

    }
}
//var_dump($json);
echo "<table border='1' cellpadding='5'>";
foreach ($json[0] as $word) {
    echo "<tr>";
//    var_dump($json);
    if($json[0][0] === ''){
        echo "<td></td>";
    }
    for ($i = 0; $i < $maxLen; $i++) {
        if ($word[$i] != null) {
            echo "<td style='background:#CCC'>" . htmlspecialchars($word[$i]) . "</td>";
        } else {
            echo "<td></td>";
        }
    }
    echo "</tr>";
}
echo "</table>";