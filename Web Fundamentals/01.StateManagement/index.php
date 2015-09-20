<?php
ini_set('display_startup_errors', 1);
ini_set('display_errors', 1);
error_reporting(-1);
session_start();

?>

<html>
<head>
    <meta charset="UTF-8">
    <title>Index</title>
</head>
<body>
    <h1>Number will be between 1 and 100</h1>

    <form action="play.php" method="post">
        Enter your name:
        <input type="text" name="name"/>
        <input type="submit" value="Play"/>
    </form>
</body>
</html>