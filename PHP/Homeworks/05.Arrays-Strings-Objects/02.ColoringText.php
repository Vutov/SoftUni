<html>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Coloring Texts</title>
</head>
<body>
<form action="" method="get">
    <textarea name="input" id="" cols="60" rows="2"></textarea>
    <input type="submit" value="color text" name="submit" style="display: block; margin-top: 10px"/>
</form>
<?php
if(isset($_GET['submit'])){
    $input = htmlentities($_GET['input']);
    $letters = str_split($input);
    $result = [];
    foreach ($letters as $letter) {
        if(ord($letter) % 2 === 0){
            $result[] = "<span style='color: red'>$letter</span>";
        } else{
            $result[] = "<span style='color: blue'>$letter</span>";
        }
    }
    echo join($result, " ");
}
?>
</body>
</html>