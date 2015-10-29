<?php

namespace Models;

class Localization
{
    const LANG_EN = 'en';
    const LANG_BG = 'bg';

    const LANG_DEFAULT = self::LANG_EN;

    private static $data = [
        'greeting_header_hello' => [
            self::LANG_EN => 'Hello',
            self::LANG_BG => 'Здравейте'
        ],
        'informal_hello' => [
            self::LANG_EN => 'Hello',
            self::LANG_BG => 'Здрасти'
        ],
        'welcome_message' => [
            self::LANG_EN => 'Welcome to our site',
            self::LANG_BG => 'Добре дошли в нашия сайт'
        ]
    ];

    public static function getData()
    {
        return self::$data;
    }
}