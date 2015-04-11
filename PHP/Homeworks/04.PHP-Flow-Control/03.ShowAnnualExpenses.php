<html>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Show Annual Expenses</title>
    <style>
        table, td, th, tr {
            border: 1px solid black;
        }
    </style>
</head>
<body>
<form action="" method="get">
    <label for="input">Enter number of years</label>
    <input type="text" name="input" id="input"/>
    <input type="submit" name="submit"/>
</form>
<?php
if (isset($_GET['submit'])):
    $year = (int)(date('Y'));
    $end = $year - htmlentities($_GET['input']);
    ?>
    <table>
        <thead>
        <tr>
            <th>Year</th>
            <th>Jan</th>
            <th>Feb</th>
            <th>Mar</th>
            <th>Apr</th>
            <th>May</th>
            <th>June</th>
            <th>Jul</th>
            <th>Aug</th>
            <th>Sept</th>
            <th>Oct</th>
            <th>Nov</th>
            <th>Dec</th>
            <th>Total:</th>
        </tr>
        </thead>
        <tbody>
        <?php
        for ($i = $year; $i > $end; $i--) {
            //Row;
            echo "<tr><td>$i</td>";
            //Fill Months;
            $sum = 0;
            for ($m = 0; $m < 12; $m++) {
                $month = rand(0, 999);
                $sum += $month;
                echo "<td>$month</td>";
            }
            echo "<td>$sum</td></tr>";
        }
        ?>
        </tbody>
    </table>
<?php
endif
?>
</body>
</html>