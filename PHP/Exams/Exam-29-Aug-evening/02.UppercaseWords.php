<?php
$text = $_GET['text'];
//var_dump($text);
preg_match_all('/([a-zA-Z0-9]+)/', $text, $matches);
//var_dump($matches[1]);
foreach ($matches[1] as $word) {
    if ($word === strtoupper($word)) {
//        var_dump($word);
        preg_match('/[a-zA-Z]+/', $word, $onlyTheWord);
//        var_dump($onlyTheWord[0]);
        $revWord = strrev($onlyTheWord[0]);
        $finalWord = $revWord;
        if ($revWord === $onlyTheWord[0]) {
//            var_dump('in');
            $finalWord = '';
            for ($i = 0; $i < strlen($onlyTheWord[0]); $i++) {
                $finalWord .= $onlyTheWord[0][$i] . $onlyTheWord[0][$i];
            }
        }
        if(strlen($onlyTheWord[0]) !== strlen($word)){
//            var_dump($onlyTheWord[0]);
//            var_dump($finalWord);
            $finalWord = preg_replace("/$onlyTheWord[0]/", $finalWord, $word);
//            var_dump($finalWord);
        }
        $text = preg_replace("/\b$word\b/", $finalWord, $text);
//        $text = str_replace($word, $finalWord, $text);
    }
}
//var_dump($text);

echo "<p>" . htmlspecialchars($text) . "</p>";