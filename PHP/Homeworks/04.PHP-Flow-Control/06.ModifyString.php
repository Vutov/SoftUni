<html>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Modify String</title>
</head>
<body>
<form action="" method="get">
    <input type="text" name="input" id=""/>
    <input type="radio" name="choice" id="palindrome" value="palindrome"/>
    <label for="palindrome">Check Palindrome</label>
    <input type="radio" name="choice" id="reverse" value="reverse"/>
    <label for="reverse">Reverse String</label>
    <input type="radio" name="choice" id="split" value="split"/>
    <label for="split">Split</label>
    <input type="radio" name="choice" id="hash" value="hash"/>
    <label for="hash">Hash String</label>
    <input type="radio" name="choice" id="shuffle" value="shuffle"/>
    <label for="shuffle">Shuffle String</label>
    <input type="submit" name="submit"/>
</form>
<?php
if (isset($_GET['submit'])) {
    $choice = htmlentities($_GET['choice']);
    $input = htmlentities($_GET['input']);
    if ($choice === 'palindrome') {
        $data = str_split($input);
        $len = count($data);
        $pali = true;
        for ($i = 0; $i < $len / 2; $i++) {
            if($data[$i] !== $data[$len - $i - 1]){
                echo "$input is NOT palindrome!";
                $pali = false;
                break;
            }
        }
        if($pali){
            echo "$input is palindrome!";
        }
    }
    if ($choice === 'reverse') {
        echo join(array_reverse(str_split($input)), '');
    }
    if ($choice === 'split') {
        echo join(str_split($input), ' ');
    }
    if ($choice === 'hash') {
        echo crypt($input);
    }
    if ($choice === 'shuffle') {
        $data = str_split($input);
        shuffle($data);
        echo join($data, '');
    }
}
?>
</body>
</html>