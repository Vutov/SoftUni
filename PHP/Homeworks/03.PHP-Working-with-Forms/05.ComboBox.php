<html>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Combo Box</title>
    <style>
        select {
            width:150px;
        }
    </style>
</head>
<body>
<form action="" method="post">
    <select name="continents" id="continents" onchange="submit()">
        <option value="Europe">Europe</option>
        <option value="Asia">Asia</option>
        <option value="North America">North America</option>
        <option value="South America">South America</option>
        <option value="Australia">Australia</option>
        <option value="Africa">Africa</option>
        <input type="hidden" value="-1" id="selected"/>
    </select>
    <select name="countries" id="">
        <?php
        $continent = htmlentities($_POST['continents']);
        if ($continent === 'Europe') : ?>
            <script>document.getElementById('selected').value = 0;</script>
            <option value="bg">Bulgaria</option>
            <option value="ser">Serbia</option>
        <?php
        elseif ($continent === 'Asia') : ?>
            <script>document.getElementById('selected').value = 1;</script>
            <option value="ru">Russia</option>
            <option value="ch">China</option>
        <?php
        elseif ($continent === 'North America') : ?>
            <script>document.getElementById('selected').value = 2;</script>
            <option value="ca">Canada</option>
            <option value="mex">Mexico</option>
            <option value="usa">USA</option>
        <?php
        elseif ($continent === 'South America') : ?>
            <script>document.getElementById('selected').value = 3;</script>
            <option value="br">Brazil</option>
            <option value="arg">Argentina</option>
        <?php
        elseif ($continent === 'Australia') : ?>
            <script>document.getElementById('selected').value = 4;</script>
            <option value="au">Australia</option>
        <?php
        elseif ($continent === 'Africa') : ?>
            <script>document.getElementById('selected').value = 5;</script>
            <option value="leb">Libya</option>
            <option value="eg">Egypt</option>
        <?php
        endif;
        ?>
    </select>
</form>
<script>
    var selected = document.getElementById('selected').value;
    document.getElementById("continents").selectedIndex = selected;

    function submit() {
        document.querySelectorAll("input[type=submit]")[0].click();
    }
</script>
</body>
</html>