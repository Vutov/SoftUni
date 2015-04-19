<?php
date_default_timezone_set('UTC');
$name = $_GET['name'];
$gender = $_GET['gender'];
$pin = $_GET['pin'];
//var_dump($name);
//var_dump($gender);
//var_dump($pin);

$validPin = false;
if (strlen($pin) === 10) {
    $validPin = true;
}

$couples = str_split($pin, 2);
$validYear = validMonth($couples[0], $couples[1], $couples[2]);

//var_dump($validYear);
preg_match_all('/.{6}(.{3})(.)/', $pin, $remainder);

if (intval($remainder[1][0]) % 2 === 0) { //even
    $pinGender = 'male';
} else {
    $pinGender = 'female';
}
$validGender = false;
if ($gender == $pinGender) {
    $validGender = true;
}
$allDigits = str_split($pin);
//var_dump($allDigits);
$sum =
    intval($allDigits[0]) * 2 +
    intval($allDigits[1]) * 4 +
    intval($allDigits[2]) * 8 +
    intval($allDigits[3]) * 5 +
    intval($allDigits[4]) * 10 +
    intval($allDigits[5]) * 9 +
    intval($allDigits[6]) * 7 +
    intval($allDigits[7]) * 3 +
    intval($allDigits[8]) * 6;

//var_dump($sum);
$remaining = $sum % 11;
if ($remaining === 10) {
    $remaining = 0;
}
//var_dump($remaining);
$validLastDigit = false;
if ($remaining === intval($remainder[2][0])) {
    $validLastDigit = true;
}
//var_dump($validLastDigit);
preg_match('/[A-Z][a-z]+\s[A-Z][a-z]+/', $name, $match);
$validName = false;
//var_dump($match);
if (count($match) > 0) {
    $validName = true;
}
//var_dump($validYear);
if ($validPin && $validYear && $validGender && $validLastDigit && $validName) {
    $result = ['name' => $name, 'gender' => $gender, 'pin' => $pin];
    echo json_encode($result);
} else {
    echo '<h2>Incorrect data</h2>';
}
function validMonth($year, $month, $day)
{

    $month = intval($month);
//    var_dump($month);
    if ($month >= 21 && $month <= 32) {
        $month -= 20;
        $date = date('d/m/y', strtotime('18' . $year . '/' . $month . '/' . $day));
    } else if ($month >= 41 && $month <= 52) {
        $month -= 40;
        $date = date('d/m/y', strtotime('20' . $year . '/' . $month . '/' . $day));
    } else {
        $date = date('d/m/y', strtotime('19' . $year . '/' . $month . '/' . $day));
    }
    if ($date != '01/01/70') {
        return true;
    }

    return false;
}