<html>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Rich People's Problems</title>
</head>
<style>
    table, td, th, tr {
        border: 1px solid black;
    }
</style>
<body>
<form action="" method="get">
    <label for="input">Enter cars</label>
    <input type="text" name="input"/>
    <input type="submit" name="submit"/>
</form>
<?php
if (isset($_GET['submit'])) :
?>
<table>
    <thead>
    <tr>
        <th>Car</th>
        <th>Color</th>
        <th>Count</th>
    </tr>
    </thead>
    <tbody>
    <?php $input = preg_split('/[\s,]+/', htmlentities($_GET['input']));
    //$input = ['Mitsubishi', 'Maseratti', 'Maybach'];
    $colors = ['red', 'blue', 'green', 'pink', 'purple'];
    foreach ($input as $car) {
        $color = $colors[rand(0, count($colors) - 1)];
        $quantity = rand(0, 5);
        echo "
        <tr>
            <td>$car</td>
            <td style='color:$color'>$color</td>
            <td>$quantity</td>
        </tr>
        ";
    }
    endif
    ?>
    </tbody>
</table>
</body>
</html>