<?php
$list = $_GET['list'];
$list = preg_split('/[,\s]+/', $list, 0, PREG_SPLIT_NO_EMPTY);
$list = array_count_values($list);
if (count($list) < 4) {
    $computers = 0;
} else {
    $computers = min($list);
}
$paid = 0;
$partsLeft = 0;
foreach ($list as $item => $quatnity) {
    switch ($item) {
        case 'CPU':
            $data = calculateParts($quatnity, $computers, $partsLeft, 85);
            $paid += $data['paid'];
            $partsLeft = $data['partsLeft'];
            break;
        case 'ROM':
            $data = calculateParts($quatnity, $computers, $partsLeft, 45);
            $paid += $data['paid'];
            $partsLeft = $data['partsLeft'];
            break;
        case 'RAM':
            $data = calculateParts($quatnity, $computers, $partsLeft, 35);
            $paid += $data['paid'];
            $partsLeft = $data['partsLeft'];
            break;
        case 'VIA':
            $data = calculateParts($quatnity, $computers, $partsLeft, 45);
            $paid += $data['paid'];
            $partsLeft = $data['partsLeft'];
            break;
    }
}
echo '<ul>';
echo "<li>$computers computers assembled</li>";
echo "<li>$partsLeft parts left</li>";

echo '</ul>';

if ($paid - $computers * 420 < 0) {
    $gained = abs($paid - $computers * 420);
    echo "<p>Nakov gained $gained leva</p>";
}else if ($paid - $computers * 420 == 0){
    echo "<p>Nakov lost $paid leva</p>";
}
else {
    echo "<p>Nakov lost -$paid leva</p>";
}

function calculateParts($quatnity, $computers, $partsLeft, $price) {
    $paid = 0;
    if ($quatnity >= 5) {
        $paid += ($price / 2) * $quatnity;
    } else {
        $paid += $price * $quatnity;
    }
    if ($quatnity > $computers) {
        $paid -= ($price / 2) * ($quatnity - $computers);
        $partsLeft += $quatnity - $computers;
    }

    return ['paid' => $paid, 'partsLeft' => $partsLeft];
}
