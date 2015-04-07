<html>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>GetFormData</title>
    <style>
        input[type='text'], input[type='submit'] {
            display: block;
            margin: 10px 0;
        }
    </style>
</head>
<body>
<form action="" method="get">
    <input type="text" placeholder="Name..." name="name" required="required"/>
    <input type="text" placeholder="Age..." name="age" pattern="[0-9]+" required="required"/>
    <input type="radio" name="sex" id="male" value="male" required="required"/>
    <label for="male">Male</label>
    <input type="radio" name="sex" id="female" value="female" required="required"/>
    <label for="female">Female</label>
    <input type="submit" name="submit" value="Submit"/>
</form>
<?php
    if($_GET['submit']){
        $name = ucfirst(htmlentities($_GET['name']));
        $age = htmlentities($_GET['age']);
        $gender = $_GET['sex'];
        echo "My name is $name. I'm $age years old. I am $gender.";
    }
?>
</body>
</html>