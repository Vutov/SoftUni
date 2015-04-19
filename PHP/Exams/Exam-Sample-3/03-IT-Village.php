<?php
$input = preg_split('/\s\|\s/', $_GET['board'], 0, PREG_SPLIT_NO_EMPTY);
$beginning = preg_split('/\s+/', $_GET['beginning'], 0, PREG_SPLIT_NO_EMPTY);
$moves = preg_split('/\s+/', $_GET['moves'], 0, PREG_SPLIT_NO_EMPTY);
//var_dump($beginning);
$startingRow = $beginning[0] - 1;
$startingCol = $beginning[1] - 1;
$board = [];
//var_dump($input);
foreach ($input as $row) {
    $board[] = preg_split('/\s+/', $row, 0, PREG_SPLIT_NO_EMPTY);
}
//var_dump($board);
$field = $board[0][0] . $board[0][1] . $board[0][2] . $board[0][3] . $board[1][3] . $board[2][3] . $board[3][3] . $board[3][2] . $board[3][1] . $board[3][0] . $board[2][0] . $board[1][0];
//var_dump($field);
if ($startingRow <= $startingCol) {
    $pos = $startingRow + $startingCol;
} else {
    $pos = 12 - ($startingRow + $startingCol);
}
//var_dump($field[$pos]);
//var_dump($moves);
$allIns = 0;
for ($i = 0; $i < strlen($field); $i++) {
    if($field[$i] === 'I'){
        $allIns++;
    }
}
$coins = 50;
$ins = 0;
$nakov = false;
$gameOver = false;
for ($i = 0; $i < count($moves); $i++) {
    $pos = ($pos + $moves[$i]) % 12;
    $event = $field[$pos];
    $coins += intval($moves[$i]) * $ins * 20;
    switch ($event) {
        case 'P':
            $coins -= 5;
            break;
        case 'I':
            if($coins >= 100){
                $coins-=100;
                $ins++;
            }
            else {
                $coins -=10;
            }
            break;
        case 'F':
            $coins += 20;
            break;
        case 'S':
            $i += 2;
            break;
        case 'V':
            $coins *= 10;
            break;
        case 'N':
            $nakov = true;
            break;
    }
    if($coins < 0){
        echo '<p>You lost! You ran out of money!<p>';
        $gameOver = true;
        break;
    }
    if($nakov){
        echo '<p>You won! Nakov\'s force was with you!<p>';
        $gameOver = true;
        break;
    }
    if($ins === $allIns){
        echo "<p>You won! You own the village now! You have $coins coins!<p>";
        $gameOver = true;
        break;
    }
}
if (!$gameOver) {
    echo "<p>You lost! No more moves! You have $coins coins!<p>";
}