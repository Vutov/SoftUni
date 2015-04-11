<html>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Sum of Digits</title>
    <style>
        table, td, th, tr {
            border: 1px solid black;
        }
    </style>
</head>
<body>
<form action="" method="get">
    <label for="input">Input string:</label>
    <input type="text" name="input" id="input"/>
    <input type="submit" name="submit" id=""/>
</form>
<?php
if (isset($_GET['submit'])) :
    ?>
    <table>
        <tbody>
        <?php
        $input = preg_split('/[\s,]+/', htmlentities($_GET['input']));
        //$input = ['aa2',1];
        foreach ($input as $num) :
            $digits = str_split($num);
            $sum = 0;
            $foundLetter = false;
            foreach ($digits as $digit) {
                if ($digit !== '0' && intval($digit) !== 0) {
                    $sum += $digit;
                } else {
                    $foundLetter = true;
                }
            }
            ?>
            <tr>
                <?php
                if (!$foundLetter) {
                    echo "<td>$num</td><td>$sum</td>";
                } else {
                    echo "<td>$num</td><td>I cannot sum that</td>";
                }
                ?>
            </tr>
        <?php
        endforeach
        ?>
        </tbody>
    </table>
<?php
endif
?>
</body>
</html>