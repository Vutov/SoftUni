<?php
$board = $_GET['board'];
//var_dump($board);
$rows = preg_split('/\//', $board, -1, PREG_SPLIT_NO_EMPTY);
$result = [];
$failed = false;
foreach ($rows as $row) {
    $curRow = preg_split('/-/', $row, -1, PREG_SPLIT_NO_EMPTY);
//    var_dump($row);
//    var_dump($curRow);
    if(count($rows) != 8 || strlen($row) != 15){
        $failed = true;
    }
    foreach ($curRow as $figure) {
        if(count($curRow) != 8){
            $failed = true;
        }
        switch ($figure) {
            case 'B':
                $result['Bishop']++;
                break;
            case 'H':
                $result['Horseman']++;
                break;
            case 'K':
                $result['King']++;
                break;
            case 'P':
                $result['Pawn']++;
                break;
            case 'Q':
                $result['Queen']++;
                break;
            case 'R':
                $result['Rook']++;
                break;
        }
    }

}
if($failed){
    echo "<h1>Invalid chess board</h1>";
}
else {
    echo '<table>';

    foreach ($rows as $row) {
        echo "<tr>";
        $curRow = preg_split('/-/', $row, -1, PREG_SPLIT_NO_EMPTY);
        foreach ($curRow as $figure) {
            echo "<td>$figure</td>";
        }
        echo "</tr>";
    }
    echo '</table>';
    ksort($result);
    echo json_encode($result);
}