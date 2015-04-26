<?php
$list = preg_split('/\n/', trim($_GET['list']), null, PREG_SPLIT_NO_EMPTY);
$len = intval($_GET['length']);
$show = $_GET['show'];

//var_dump($list);
//var_dump($len);
//var_dump($show);

echo '<ul>';
foreach ($list as $name) {
//    var_dump($name);
    $name = trim($name);
    if (strlen($name) < $len) {
        if ($show === 'on') {
            echo '<li style="color: red;">' . htmlspecialchars($name) . '</li>';
        }
    } else {
        echo '<li>' . htmlspecialchars($name) . '</li>';
    }

}
echo '</ul>';
