<?php
$text = $_GET['text'];
$blackList = preg_split('/\s+/', $_GET['blacklist'], -1, PREG_SPLIT_NO_EMPTY);
$regex = "/([\w-\+_]+@[\w-]+\.[\w-\.]+)/";

preg_match_all($regex, $text, $matches);
foreach ($matches[0] as $match) {
    $site = '/(\..*)/';
    preg_match($site, $match, $dom);
    $dom = "*" . $dom[0];
    if(in_array($dom, $blackList) || in_array($match, $blackList)){
        $censor = str_pad('', strlen($match), '*');
        $text = str_replace($match, $censor, $text);
    }
}
$text = preg_replace_callback($regex, function ($email) {
    return "<a href=\"mailto:$email[1]\">$email[1]</a>";
}, $text);
echo "<p>$text</p>";
//var_dump($text);
?>