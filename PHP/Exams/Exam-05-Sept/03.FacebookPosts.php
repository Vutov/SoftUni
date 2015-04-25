<?php
date_default_timezone_set('UTC');
$text = $_GET['text'];
//var_dump($text);
$regex = '/\s*(.*?)\s*;\s*(.*?)\s*;\s*(.*?)\s*;\s*(.*?)\s*;\s*(.*)/';
preg_match_all($regex, $text, $matches);

$json = [];
//var_dump($matches);
for ($i = 0; $i < count($matches[0]); $i++) {
    $name = $matches[1][$i];
    $date = $matches[2][$i];
//    var_dump($date);
    $post = $matches[3][$i];
    $likes = $matches[4][$i];
    $comments = $matches[5][$i];
    $json[] = ['name' => $name, 'date' => $date, 'post' => $post, 'likes' => $likes, 'comments' => $comments];

}
usort($json, function($x, $y) {
   return strtotime($x['date']) < strtotime($y['date']);
});

foreach ($json as $post) {
    printPost($post);
}

function printPost($json)
{
    $name = $json['name'];
    $date = date('j F Y', strtotime($json['date']));;
    $post = $json['post'];
    $likes = $json['likes'];
    $comments = $json['comments'];
    $hasComments = false;
    if ($comments !== '') {
        $comments = preg_split('/\//', $comments, null, PREG_SPLIT_NO_EMPTY);
        $hasComments = true;
//        var_dump($comments);
    }
    echo "<article><header><span>" . htmlspecialchars($name) . "</span><time>" . htmlspecialchars($date) . "</time></header>";
    echo "<main><p>" . htmlspecialchars($post) . "</p></main>";
    echo "<footer><div class=\"likes\">" . htmlspecialchars($likes) . " people like this</div>";
    if ($hasComments) {
        echo "<div class=\"comments\">";
        foreach ($comments as $comment) {
            echo "<p>" . htmlspecialchars(trim($comment)) . "</p>";
        }
        echo "</div>";
    }
    echo "</footer></article>";
}
