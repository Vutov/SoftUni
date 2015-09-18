<?php

/**
 * Created by PhpStorm.
 * User: root
 * Date: 9/17/15
 * Time: 3:35 PM
 */
class Db
{

    private static $_instance = null;

    private function __construct()
    {

    }

    public static function getInstance(){
        if (self::$_instance == null) {
            self::$_instance = new PDO("mysql:host=localhost;dbname=translations", "root", "");
            self::$_instance->query("SET NAMES utf8");
        }

        return self::$_instance;
    }
}