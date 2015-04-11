<html>
<head>
    <meta charset="UTF-8">
    <title>Find Primes in Range</title>
</head>
<?php
//http://www.stoimen.com/blog/2012/05/08/computer-algorithms-determine-if-a-number-is-prime/
function isPrime($num)
{
    $i = 2;
    if ($num === 2) {
        return true;
    }
    while ($i < $num) {
        if ($num % $i == 0) {
            return false;
        }
        $i++;
    }
    return true;
}

?>
<body>
<form action="" method="get">
    <label for="start">Starting Index:</label>
    <input type="text" name="start" id="start"/>
    <label for="end">End:</label>
    <input type="text" name="end" id="end"/>
    <input type="submit" name='submit'/>
</form>
<?php
if (isset($_GET['submit'])) {
    $start = intval(htmlentities($_GET['start']));
    $end = intval(htmlentities($_GET['end']));
    $allNumbers = [];
    for ($i = $start; $i < $end; $i++) {
        if (isPrime($i)) {
            $allNumbers[] = "<b>$i</b>";
        } else {
            $allNumbers[] = $i;
        }
    }
    echo join($allNumbers, ', ');
}
?>
</body>
</html>