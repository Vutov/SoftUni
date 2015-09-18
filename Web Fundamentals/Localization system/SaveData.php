<head>
    <meta charset="UTF-8">
</head>
<?php
ini_set('display_errors',1);
ini_set('display_startup_errors',1);
error_reporting(-1);

if (!isset($_SESSION)) {
    session_start();
}

require_once 'translation.php';

if (isset($_POST)) {
    $data = $_POST;
    $translations = getAllTranslations();

    foreach ($data as $id => $newTranslation) {
        if ($translations[$id - 1]['text_bg'] != $newTranslation) {
            $oldTranslation = $translations[$id - 1]['text_bg'];
            $db = Db::getInstance();
            $query = $db->prepare("
                UPDATE translations
                SET text_bg = ?
                WHERE id = ?;
            ");
            $query->bindParam(1, $newTranslation, PDO::PARAM_STR);
            $query->bindParam(2, $id, PDO::PARAM_INT);
            $query->execute();

            $_SESSION['changes'][] = 'Changed "' . $oldTranslation . '" to "' . $newTranslation .'"';
       }
    }
}

header('Location: '. 'index.php');
?>