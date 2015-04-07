<?php

$firstNumer = 2;
$secondNumber = 5;
$sum = $firstNumer + $secondNumber;
echo '$firstNumber + $secondNumber  = ' . "$firstNumer + $secondNumber = " . number_format($sum, 2, '.', '') . "</br>";
$firstNumer = 1.567808;
$secondNumber = 0.356;
$sum = $firstNumer + $secondNumber;
echo '$firstNumber + $secondNumber  = ' . "$firstNumer + $secondNumber = " . number_format($sum, 2, '.', '') . "</br>";
$firstNumer = 1234.5678;
$secondNumber = 333;
$sum = $firstNumer + $secondNumber;
echo '$firstNumber + $secondNumber  = ' . "$firstNumer + $secondNumber = " . number_format($sum, 2, '.', '') . "</br>";

?>