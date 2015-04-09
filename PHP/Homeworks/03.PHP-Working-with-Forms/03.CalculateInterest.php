<html>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Calculate Interest</title>
    <style>
        .row {
            margin: 10px 0;
        }
    </style>
</head>
<body>
<form action="" method="post">
    <div class="row">
        <label for="amount">Enter Amount</label>
        <input type="text" name="amount" id="amount" required="required" pattern="[0-9]+"/>
    </div>
    <div class="row">
        <input type="radio" name="denomination" value="USD" id="usd" required="required"/>
        <label for="usd">USD</label>
        <input type="radio" name="denomination" value="EUR" id="eur" required="required"/>
        <label for="eur">EUR</label>
        <input type="radio" name="denomination" value="BGN" id="bgn" required="required"/>
        <label for="bgn">BGN</label>
    </div>
    <div class="row">
        <label for="interest">Compound Interest Amount</label>
        <input type="text" name="interest" id="interest" required="required" pattern="[0-9]+"/>
    </div>
    <div class="row">
        <select name="duration" required="required">
            <option value="6 Months">6 Months</option>
            <option value="1 Year">1 Year</option>
            <option value="2 Years">2 Years</option>
            <option value="5 Years">5 Years</option>
        </select>
        <input type="submit" name="submit" value="Calculate"/>
        <span>
            <?php
            //$amount = 1000;
            //$denomination = "USD";
            //$interest = 12;
            //$durationStr = "6 Months";
            if ($_POST['submit']) {
                $amount = htmlentities($_POST['amount']);
                $denomination = $_POST['denomination'];
                $interest = htmlentities($_POST['interest']);
                $durationStr = $_POST['duration'];
                $fv = 0;
                $interest /= 100;
                $duration = 0;
                //Check duration;
                if ($durationStr === '6 Months') {
                    $duration = 0.5;
                } else if ($durationStr === '1 Year') {
                    $duration = 1;
                } else if ($durationStr === '2 Years') {
                    $duration = 2;
                } else {
                    $duration = 5;
                }
                //Calc value;
                $fv = $amount * pow((1 + $interest / 12), 12 * $duration);
                //Check denomination;
                if ($denomination === 'USD') {
                    echo "$" . number_format($fv, 2, '.', '');
                } else if ($denomination === 'EUR') {
                    echo number_format($fv, 2, '.', '') . "€";
                } else {
                    echo number_format($fv, 2, '.', '') . "лв.";
                }
            }
            ?>
        </span>
    </div>
</form>
</body>
</html>