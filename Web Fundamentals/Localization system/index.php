<?php
ini_set('display_startup_errors', 1);
ini_set('display_errors', 1);
error_reporting(-1);

require_once 'translation.php';
require_once 'Localization.php';
?>

<html xmlns="http://www.w3.org/1999/html">
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
    <?php
    if (!isset($_SESSION)) {
        session_start();
    }

    if (array_key_exists('changes', $_SESSION)) {
        $changes = $_SESSION['changes'];
        foreach ($changes as $change) {
            echo '<div> ' . $change . '</div>';
        }
        unset($_SESSION['changes']);
    }
    ?>
    <p>
        <?= __("welcome_message"); ?>
    </p>
</div>

<form action="SaveData.php" method="post">
    <?php
    $translations = getAllTranslations();
    foreach ($translations as $translation) { ?>
        <div><?= $translation['text_' . \Models\Localization::LANG_DEFAULT] ?></div>
        <textarea name="<?= $translation['id'] ?>"><?= $translation['text_bg'] ?></textarea>
    <?php } ?>
    <input type="Submit" value="Save"/>
</form>
</body>
</html>
