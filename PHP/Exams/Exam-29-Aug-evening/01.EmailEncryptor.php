<?php
$recipient = htmlspecialchars($_GET['recipient']);
$subject = htmlspecialchars($_GET['subject']);
$body = htmlspecialchars($_GET['body']);
$key = $_GET['key'];

//var_dump($recipient);
//var_dump($subject);
//var_dump($body);
//var_dump($key);
$email = "<p class='recipient'>$recipient</p><p class='subject'>$subject</p><p class='message'>$body</p>";
//var_dump($email);
//var_dump($key);


//$email = 'Hello PHP';
//$key = '3G@p';

$keyNum = 0;
$storedLetters = [];
//$email = preg_replace('/\s+/', '', $email);
//var_dump($email);
for ($i = 0; $i < strlen($email); $i++) {
    $storedLetters[] = dechex(ord($email[$i]) * ord($key[$keyNum]));
    $keyNum++;
    if($keyNum > strlen($key) - 1){
        $keyNum = 0;
    }
}
$result = '|' . join('|', $storedLetters) . '|';
echo $result;