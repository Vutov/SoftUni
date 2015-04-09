<html>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Print Tags</title>
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
    //echo var_dump($data);
    foreach ($data as $key => $i) {
        echo "$key:$i</br>";
    }
}

?>
</body>
</html>



