<?php
header('Content-type: text/html; charset=utf-8');
$input = 'This is my cat! And this is my dog. We happily live in Paris – the most beautiful city in the world! Isn’t it great? Well it is :)';
$word = 'is';
preg_match_all('/([\w\s’–]*?)[\.!?]/', $input, $data);
$validLines = [];
foreach ($data[0] as $line) {
    if(preg_match('/\bis\b/', $line)){
        $validLines[] = $line;
    }
}
echo join($validLines, '<br />');