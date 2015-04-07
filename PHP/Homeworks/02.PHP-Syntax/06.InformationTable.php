<html>
<head>
    <meta charset="UTF-8">
    <title>InformationTable</title>
    <style>
        table {
            margin: 10px;
            border-collapse: collapse;
        }

        td {
            padding: 5px;
            border: 1px solid black;
        }

        td:first-of-type {
            font-weight: 700;
            background: gold;
        }

        td:last-of-type {
            text-align: right;
        }
    </style>
</head>
<body>
<?php
$input = [['Gosho', '0882-321-423', 24, 'Hadji Dimitar'], ['Pesho', '0884-888-888', 67, 'Suhata Reka']];

foreach ($input as $data) {
    echo "
    <table>
        <tr>
            <td>Name</td>
            <td>$data[0]</td>
        </tr>
        <tr>
            <td>Phone number</td>
            <td>$data[1]</td>
        </tr>
        <tr>
            <td>Age</td>
            <td>$data[2]</td>
        </tr>
        <tr>
            <td>Address</td>
            <td>$data[3]</td>
        </tr>
    </table>
";
}
?>
</body>
</html>