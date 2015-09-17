<?php

use Models\Localization;

include_once 'Localization.php';

if (isset($_GET['lang'])) {
    $lang = $_GET['lang'];
    if ($lang != Localization::LANG_BG && $lang != Localization::LANG_EN) {
        throw new Exception('Invalid language');
    }

    setcookie('lang', $lang, 60*60*24);
    $_COOKIE['lang'] = $lang;
}

function __($tag){
    $lang = isset($_COOKIE['lang']) ? $_COOKIE['lang'] : Localization::LANG_DEFAULT;

    return Localization::getData()[$tag][$lang];
}