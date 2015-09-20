<?php
ini_set('display_startup_errors', 1);
ini_set('display_errors', 1);
error_reporting(-1);

session_start();

if (!isset($_SESSION['name']) || (isset($_POST['name']) && $_POST['name'] != $_SESSION['name'])) {
    $_SESSION['name'] = $_POST['name'];
    $_SESSION['number'] = rand(0, 100);
}

if (!$_SESSION['name']) {
    header('Location: ' . 'index.php');
}
?>
<html>
<head>
    <meta charset="UTF-8">
    <title>Play</title>
</head>
<body>
<form action="#" method="post">
    <input type="number" min="0" , max="100" name="number"/>
    <input type="submit" value="Try"/>
</form>
<h1><?php
    if (isset($_POST['number'])) {
        $num = $_POST['number'];
        $sessionNumber = $_SESSION['number'];
        if ((int)$num < 0 || (int)$num > 100) {
            echo 'Invalid number!';
        } else if ((int)$num < (int)$sessionNumber) {
            echo 'Up';
        } else if ((int)$num > (int)$sessionNumber) {
            echo 'Down';
        } else {
            echo 'Congratulations, ' . $_SESSION['name'] . '!';
            $_SESSION['number'] = rand(0, 100);
            echo '<br>';
            echo 'New number generated!';
        }
    }
    ?></h1>
</body>
</html>