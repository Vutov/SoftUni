<?php
$errors = $_GET['errorLog'];
//var_dump($errors);
$regex = '/\s*.*?".*?"\s[a-zA-Z\.]*\.([A-Za-z]*):.*?\n\s*.*?at\s*.*?\.(.*?)\(([a-zA-Z]+.+?)\s*:\s*(\d+)\)/';
preg_match_all($regex, $errors, $matches);
//var_dump($matches);
echo "<ul>";
for ($i = 0; $i < count($matches[0]); $i++) {
    echo "<li>line <strong>".htmlspecialchars($matches[4][$i])."</strong> - <strong>".htmlspecialchars($matches[1][$i])."</strong> in <em>".htmlspecialchars($matches[3][$i]).":".htmlspecialchars($matches[2][$i])."</em></li>";

}
echo "</ul>";