<html>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Document</title>
    <style>
        aside {
            border: 1px solid black;
            border-radius: 10px;
            width: 200px;
            margin: 10px;
            background: linear-gradient(#fff, aqua);
        }

        ul {
            list-style-type: circle;
        }

        li {
            text-decoration: underline;
        }

        h1 {
            text-decoration: underline;
            font-size: 1.5rem;
            text-align: center;
        }

        .category {
            margin: 10px 0;
        }
    </style>
</head>
<body>
<form action="" method="get">
    <div class="category">
        <label for="categories">Categories:</label>
        <input type="text" name="categories" id="categories"/>
    </div>
    <div class="category">
        <label for="tags">Tags:</label>
        <input type="text" name="tags" id="tags"/>
    </div>
    <div class="category">
        <label for="months">Months:</label>
        <input type="text" name="months" id="months"/>
    </div>
    <input type="submit" name="submit"/>
</form>
<?php
if (isset($_GET['submit'])):
    $sideBars['Categories'] = preg_split('/\W+/', htmlentities($_GET['categories']));
    $sideBars['Tags'] = preg_split('/\W+/', htmlentities($_GET['tags']));
    $sideBars['Months'] = preg_split('/\W+/', htmlentities($_GET['months']));
    //var_dump($sideBars);
    foreach ($sideBars as $key => $side) :?>
        <aside>
            <?php echo "<h1>$key</h1>"; ?>
            <ul>
                <?php foreach ($side as $category) {
                    echo "<li>$category</li>";
                }
                ?>
            </ul>
        </aside>
    <?php
    endforeach;
endif;
?>

</body>
</html>