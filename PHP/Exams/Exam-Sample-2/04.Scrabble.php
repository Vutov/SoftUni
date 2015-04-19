<?php
$mainWord = $_GET['mainWord'];
$words = $_GET['words'];
//var_dump($mainWord);
preg_match_all('/\D*(\d).*?:.*?(\w+)/', $mainWord, $match);
preg_match_all('/\w+/', $words, $words);
$row = $match[1][0];
//var_dump($row);
$mainWord = $match[2][0];
$col = strlen($mainWord);
$words = $words[0];
$validWord = function ($word) {
    if (strlen($word) <= $GLOBALS['col']) {
        return $word;
    }
};
$validWords = array_filter($words, $validWord);
uasort($validWords, function ($x, $y) {
    return strlen($y) - strlen($x);
});
//var_dump($validWords);
$data = [];
$maxlen = 0;
for ($i = 0; $i < $col; $i++) {
    foreach ($validWords as $word) {
        $wordLen = strlen($word);
        for ($x = 0; $x < $wordLen; $x++) {
            if (
                $mainWord[$i] === $word[$x] &&
                $wordLen - $x <= $row &&
                $row - $x - 1 >= 0
            ) {
                if ($wordLen > $maxlen) {
                    $maxlen = $wordLen;
                    $data = ['word' => $word, 'col' => $i, 'startRow' => $row - $x - 1];
                }
            }
        }

    }
}
//var_dump($data);
$currentLetter = 0;
echo '<table>';
for ($i = 0; $i < $col; $i++) {
    echo '<tr>';
    for ($j = 0; $j < $col; $j++) {
        if ($i >= $data['startRow'] && $j === $data['col']) {
            echo '<td>' . $data['word'][$currentLetter] . '</td>';
            $currentLetter++;
        } else if ($i === $row - 1) {
            echo '<td>' . $mainWord[$j] . '</td>';
        } else {
            echo '<td></td>';
        }
    }
    echo '</tr>';
}
echo '</table>';
$endResult = [];
foreach ($words as $word) {
    if ($word != $data['word']) {
        $sum = 0;
        for ($i = 0; $i < strlen($word); $i++) {
            $sum += ord($word[$i]);
        }
        if($endResult[$word]){
            $endResult[$word] += $sum;
        }else {
            $endResult[$word] = $sum;
        }

    }
}
ksort($endResult);
echo json_encode($endResult);