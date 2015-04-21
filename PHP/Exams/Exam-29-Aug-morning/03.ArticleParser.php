<?php
date_default_timezone_set('UTC');
$input = $_GET['text'];
preg_match_all('/\s*([a-zA-Z\s-]+?)\s*%\s*([a-zA-Z\s.-]+?)\s*;\s*(\d{2}-\d{2}-\d{4})\s*\-\s*([^\n]*)\s*/', $input, $matches);
for ($i =0 ; $i <count($matches[0]) ; $i++) {
//    var_dump($matches[$i]);
    $title = $matches[1][$i];
    $author = $matches[2][$i];
    $date = date('F', strtotime($matches[3][$i]));
    $text = $matches[4][$i];
    $text = trim($text);
    if(strlen($text) > 100){
        $text = substr($matches[4][$i], 0, 100);
    }
    $text = trim($text);
    $text .= '...';
//    var_dump($title);
//    var_dump($author);
//    var_dump($date);
//    var_dump($text);
    echo "<div>
<b>Topic:</b> <span>". htmlentities($title)."</span>
<b>Author:</b> <span>".htmlentities($author)."</span>
<b>When:</b> <span>".htmlentities($date)."</span>
<b>Summary:</b> <span>".htmlentities($text)."</span>
</div>\n";
}
