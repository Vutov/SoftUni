<?php
$criteria = $_GET['column'];
$order = $_GET['order'];
$students = $_GET['students'];

//var_dump($students);
//var_dump($order);
//var_dump($criteria);

$regex = '/\s*([^,]*?)\s*,\s*([^,]*?)\s*,\s*([^,]*?)\s*,\s*(\d+)\s*/';

preg_match_all($regex, $students, $matches);
//var_dump($matches);
$data = [];
for ($i = 0; $i < count($matches[0]); $i++) {
    $id = $i + 1;
    $username = $matches[1][$i];
    $email = $matches[2][$i];
    $type = $matches[3][$i];
    $result = intval($matches[4][$i]);
    $data[] = ['id' => $id, 'username' => $username, 'email' => $email, 'type' => $type, 'result' => $result];
}
//var_dump($data);
usort($data, function ($x, $y) use ($order, $criteria) {
    if ($order === 'ascending') {
        if ($x[$criteria] == $y[$criteria]) {
            return $x['id'] > $y['id'];
        } else {
            return $x[$criteria] > $y[$criteria];
        }
    } else {
        if ($x[$criteria] == $y[$criteria]) {
            return $x['id'] < $y['id'];
        } else {
            return $x[$criteria] < $y[$criteria];
        }
    }
});
//
echo '<table><thead><tr><th>Id</th><th>Username</th><th>Email</th><th>Type</th><th>Result</th></tr></thead>';
foreach ($data as $student) {
    echo "<tr><td>".htmlspecialchars($student['id'])."</td><td>".htmlspecialchars($student['username'])."</td><td>".htmlspecialchars($student['email'])."</td><td>".htmlspecialchars($student['type'])."</td><td>".htmlspecialchars($student['result'])."</td></tr>";
}
echo '</table>';