<?php
$html = $_GET['html'];
$opening = '/<div(.*?\s*)((?:id|class)\s*=\s*"(.*?)"\s*)(.*?\s*)>/';
$closing = '/<\/div>(\s*<!--\s*(.*?)\s*-->)/';
//var_dump($html);
preg_match_all($opening, $html, $openingMatches);
preg_match_all($closing, $html, $closingMatches);
//var_dump($openingMatches);
for ($i = 0; $i < count($openingMatches[0]); $i++) {
//    var_dump($openingMatches);
    $openTag = str_replace('div', $openingMatches[3][$i], $openingMatches[0][$i]);
//    var_dump($openTag);
    $openTag = str_replace($openingMatches[2][$i], ' ', $openTag);
//    var_dump($openTag);
    $openTag = preg_replace('/\s+/', ' ', $openTag);
    $openTag = preg_replace('/<\s+/', '<', $openTag);
    $openTag = preg_replace('/\s+>/', '>', $openTag);
    $html = str_replace($openingMatches[0][$i], $openTag, $html);
//    var_dump($html);
}
for ($i = 0; $i < count($closingMatches[0]); $i++) {
//    var_dump($closingMatches);
    $closingTag = str_replace('div', $closingMatches[2][$i], $closingMatches[0][$i]);
//    var_dump($closingTag);
    $closingTag = str_replace($closingMatches[1][$i], '', $closingTag);
    $html = str_replace($closingMatches[0][$i], $closingTag, $html);
//    var_dump($openTag);
}
//var_dump($html);
echo $html;