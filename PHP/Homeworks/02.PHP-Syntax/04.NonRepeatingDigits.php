<?php

$input = array(1234, 145, 15, 247);

foreach ($input as $num) {
    $uniqueNumbers = array();
    for ($i = 102; $i <= $num; $i++) {
        if ($i <= 999) {
            $firstDigit = ($i / 100) % 10;
            $secondDigit = ($i / 10) % 10;
            $thirdDigit = $i % 10;
            if ($firstDigit !== $secondDigit && $firstDigit !== $thirdDigit && $secondDigit !== $thirdDigit) {
                array_push($uniqueNumbers, $i);
            }
        } else {
            break;
        }
    }
    //Print;
    echo join(", ", $uniqueNumbers);
    if (count($uniqueNumbers) === 0) {
        echo "no";
    }
    echo "<hr> </br>";
}

?>