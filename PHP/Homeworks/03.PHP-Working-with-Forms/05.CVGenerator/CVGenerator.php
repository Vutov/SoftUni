<?php
function validateInformation()
{
    $firstName = htmlentities($_POST['firstName']);
    $lastName = htmlentities($_POST['lastName']);
    $companyName = htmlentities($_POST['company']);
    $phoneNumber = htmlentities($_POST['phone']);
    $email = htmlentities($_POST['email']);
    if (!preg_match('/[a-zA-Z]{2,20}/', $firstName)) {
        $firstName = 'not valid name';
    }
    if (!preg_match('/[a-zA-Z]{2,20}/', $lastName)) {
        $lastName = 'not valid name';
    }
    if (!preg_match('/\w{2,20}/', $companyName)) {
        $companyName = 'not valid name';
    }
    if (!preg_match('/[\d \-\+]+/', $phoneNumber)) {
        $phoneNumber = 'not valid phone';
    }
    if (!preg_match('/\w+@\w+\.\w+/', $email)) {
        $email = 'not valid email';
    }
    return ['first name' => $firstName, 'last name' => $lastName,
        'company' => $companyName, 'phone number' => $phoneNumber,
        'email' => $email];
}

function printPersonalInfo()
{
    $validatedData = validateInformation();
    //var_dump($validatedData);
    $firstName = $validatedData['first name'];
    $lastName = $validatedData['last name'];
    $email = $validatedData['email'];
    $phone = $validatedData['phone number'];
    $gender = htmlentities($_POST['gender']);
    $birthDay = htmlentities($_POST['birthDate']);
    $nationality = htmlentities($_POST['nationality']);
    echo '<div class="head">CV</div>';
    echo "
    <table>
        <thdea>
            <tr>
                <th colspan='2'>Personal Information</th>
            </tr>
        </thdea>
        <tbody>
            <tr>
                <td>First Name</td>
                <td>$firstName</td>
            </tr>
            <tr>
                <td>Last Name</td>
                <td>$lastName</td>
            </tr>
            <tr>
                <td>Email</td>
                <td>$email</td>
            </tr>
            <tr>
                <td>Phone Number</td>
                <td>$phone</td>
            </tr>
            <tr>
                <td>Gender</td>
                <td>$gender</td>
            </tr>
            <tr>
                <td>Birth Date</td>
                <td>$birthDay</td>
            </tr>
            <tr>
                <td>Nationality</td>
                <td>$nationality</td>
            </tr>
        </tbody>
    </table>
    ";
}

function printCompanyInfo()
{
    $validatedData = validateInformation();
    //var_dump($validatedData);
    $company = $validatedData['company'];
    $from = $_POST['start'];
    $to = $_POST['end'];
    echo "
    <table>
        <thdea>
            <tr>
                <th colspan='2'>Last Work Position</th>
            </tr>
        </thdea>
        <tbody>
            <tr>
                <td>Company Name</td>
                <td>$company</td>
            </tr>
            <tr>
                <td>From</td>
                <td>$from</td>
            </tr>
            <tr>
                <td>To</td>
                <td>$to</td>
            </tr>
        </tbody>
    </table>
    ";
}

function printSkills()
{
    $skillCount = $_POST['skillCounter'] - 1;
    $rows = $skillCount + 1;
    echo "
    <table>
        <thdea>
            <tr>
                <th colspan='3'>Computer skills</th>
            </tr>
        </thdea>
        <tbody>
            <tr>
                <td rowspan=$rows>Programming Languages</td>
                <th>Language</th>
                <th>Skill level</th>
            </tr>";
    for ($i = 1; $i <= $skillCount; $i++) {
        echo "
            <tr>
                <td>" . htmlentities($_POST['skill' . $i]) . "</td>
                <td>" . htmlentities($_POST['level' . $i]) . "</td>
            </tr>
        ";
    }
    echo "
        </tbody>
    </table>
    ";
}

function printOtherSkills()
{
    $skillCount = $_POST['langCounter'] - 1;
    $rows = $skillCount + 1;
    echo "
    <table>
        <thdea>
            <tr>
                <th colspan='5'>Other skills</th>
            </tr>
        </thdea>
        <tbody>
            <tr>
                <td rowspan=$rows>Languages</td>
                <th>Language</th>
                <th>Comprehension</th>
                <th>Reading</th>
                <th>Writing</th>
            </tr>";
    for ($i = 1; $i <= $skillCount; $i++) {
        echo "
            <tr>
                <td>" . htmlentities($_POST['language' . $i]) . "</td>
                <td>" . htmlentities($_POST['comprehension' . $i]) . "</td>
                <td>" . htmlentities($_POST['reading' . $i]) . "</td>
                <td>" . htmlentities($_POST['writing' . $i]) . "</td>
            </tr>
        ";
    }
    printDrivingLicense();
    echo "
        </tbody>
    </table>
    ";
}

function printDrivingLicense() {
    $licenses = [];
    if($_POST['drivingB']){
        $licenses[] = 'B';
    }
    if($_POST['drivingA']){
        $licenses[] = 'A';
    }
    if($_POST['drivingC']){
        $licenses[] = 'C';
    }
    $printLicenses = join(", ", $licenses);
    echo "
            <tr>
                <td>Driving's license</td>
                <td colspan='4'>$printLicenses</td>
            </tr>";
}

function printCV()
{
    printPersonalInfo();
    printCompanyInfo();
    printSkills();
    printOtherSkills();
}