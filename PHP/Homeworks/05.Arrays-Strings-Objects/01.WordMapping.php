<html>
<head>
    <meta charset="UTF-8">
    <title>Word Mapping</title>
</head>
<body>
<form action="" method="get">
    <textarea name="input" id="" cols="60" rows="2"></textarea>
    <input type="submit" value="count words" name="submit" style="display: block; margin-top: 10px"/>
</form>
<?php
if (isset($_GET['submit'])):
    //$input = strtolower('The quick brows fox.!!! jumped over..// the lazy dog.!');
    $input = htmlentities($_GET['input']);
    $data = preg_split('/\W+/', $input, null, PREG_SPLIT_NO_EMPTY);
    $counted = array_count_values($data);
?>
<table>
    <tbody>
    <?php
    foreach ($counted as $key => $count) {
        echo "<tr><td>$key</td><td>$count</td></tr>";
    }
    ?>
    </tbody>
</table>
<?php
endif
?>
</body>
</html>
