<?php

use Models\Localization;

include_once 'Localization.php';
include_once 'Db.php';

if (isset($_GET['lang'])) {
    $lang = $_GET['lang'];
    $db = Db::getInstance();
    $res = $db->query("SHOW COLUMNS FROM translations");
    $columns = $res->fetchAll(PDO::FETCH_ASSOC);
    $possibleLanguages = array();

    foreach ($columns as $column) {
        if (strpos($column['Field'], 'text_') === 0) {
            $possibleLanguages[] = explode('_', $column['Field'])[1];
        }
    }

    //if ($lang != Localization::LANG_BG && $lang != Localization::LANG_EN) {
    if (!in_array($lang, $possibleLanguages)) {
        throw new Exception('Invalid language');
    }

    setcookie('lang', $lang, 60 * 60 * 24);
    $_COOKIE['lang'] = $lang;
}

function __($tag)
{
    $lang = isset($_COOKIE['lang']) ? $_COOKIE['lang'] : Localization::LANG_DEFAULT;

    //return Localization::getData()[$tag][$lang];

    $query = Db::getInstance()->prepare("
            SELECT text_{$lang}
            FROM translations
            WHERE tag = ?;
        ");
    $query->bindParam(1, $tag, PDO::PARAM_STR);
    $query->execute();

    $row = $query->fetch(PDO::FETCH_NUM);
    return $row[0];
}

function getAllTranslations(){
    $db = Db::getInstance();
    $res = $db->query("SELECT id, tag, text_en, text_bg FROM translations ORDER BY id");
    $translations = $res->fetchAll(PDO::FETCH_ASSOC);
    return $translations;
}