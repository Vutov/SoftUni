<?php
$text = $_GET['text'];
$mainFont = $_GET['minFontSize'];
$maxFont = $_GET['maxFontSize'];
$step = $_GET['step'];

//var_dump($text);
//var_dump($mainFont);
//var_dump($maxFont);
//var_dump($step);
$curFontStyle = $mainFont;
$increase = true;
for ($i = 0; $i < strlen($text); $i++) {
//    $weight = ord($text[$i]);
    if (ord($text[$i]) % 2 === 0) { //even
        echo "<span style='font-size:$curFontStyle;text-decoration:line-through;'>".htmlspecialchars($text[$i])."</span>";
    } else {
        echo "<span style='font-size:$curFontStyle;'>".htmlspecialchars($text[$i])."</span>";

    }
    if (
        ($text[$i] >= 'a' && $text[$i] <= 'z') ||
        ($text[$i] >= 'A' && $text[$i] <= 'Z')
    ) {
        if ($increase) {
            $curFontStyle += $step;
        } else {
            $curFontStyle -= $step;
        }
        if ($curFontStyle >= $maxFont) {
            $increase = false;
        } else if ($curFontStyle <= $mainFont) {
            $increase = true;
        }
    }
}