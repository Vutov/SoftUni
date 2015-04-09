<html>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Most Frequent Tag</title>
    <style>
        label {
            display: block;
        }
    </style>
</head>
<body>
<form action="" method="post">
    <label for="input">Enter Tags:</label>
    <input type="text" name="input"/>
    <input type="submit" name="submit"/>
</form>
<?php
//$input = "Pesho, homework, homework, exam, course, PHP";
if ($_POST['submit']) {
    $input = $_POST['input'];
    $data = preg_split('/[\s,]+/', htmlentities($input));
//var_dump($data);
    $stackedData = [];
    foreach ($data as $i) {
        //var_dump($i);
        if ($stackedData[$i] === 1) {
            $stackedData[$i]++;
        } else {
            $stackedData[$i] = 1;
        }
    }
    arsort($stackedData);
    foreach ($stackedData as $key => $i) {
        echo "$key:$i</br>";
    }
//var_dump($stackedData);
}

?>
</body>
</html>

