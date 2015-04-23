<?php
$list = $_GET['list'];
$size = $_GET['maxSize'];
//var_dump($list);
//var_dump($size);
preg_match_all('/\s*([^\n]*)\s*/', $list, $lines);
//var_dump($lines);
echo '<ul>';
foreach ($lines[1] as $line) {
    if($line !== ''){
        $line = trim($line);
//        var_dump($line);
        $result = $line;
//        var_dump(strlen($line));
//        var_dump(intval($size));
        if(strlen($line) > intval($size)){
            $result = substr($line, 0, intval($size));
            $result .= '...';
        }
//        var_dump($result);
        echo '<li>'. htmlspecialchars($result) . '</li>';
    }
}
echo '</ul>';