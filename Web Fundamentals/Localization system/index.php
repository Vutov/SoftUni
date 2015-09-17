<?php
ini_set('display_startup_errors',1);
ini_set('display_errors',1);
error_reporting(-1);

require_once 'translation.php';
require_once 'Localization.php'; ?>

<html>
<head>
    <meta charset="UTF-8">
    <title>Localization system</title>
</head>
<body>
<header>
    <a href="?lang=bg">BG</a>
    <br>
    <a href="?lang=en">EN</a>
    <h1>
        <?= __("greeting_header_hello"); ?>
    </h1>
</header>

<div id="content">
    <p>
        <?=  __("welcome_message"); ?>
    </p>
</div>
</body>
</html>
