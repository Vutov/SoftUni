<html>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>CV Generator</title>
    <link rel="stylesheet" href="styles.css" type="text/css"/>
    <script src="script.js"></script>
    <?php include 'CVGenerator.php'; ?>
</head>
<body>
<div class="wrapper">
    <form action="" method="post">
        <fieldset>
            <legend>Personal Information</legend>
            <input type="text" name="firstName" placeholder="First Name"/>
            <input type="text" name="lastName" placeholder="Last Name"/>
            <input type="email" name="email" placeholder="Email"/>
            <input type="tel" name="phone" placeholder="Phone Number"/>

            <div class="container">
                <label for="female">Female</label>
                <input type="radio" value="Female" name="gender" id="female"/>
                <label for="male">Male</label>
                <input type="radio" value="Male" name="gender" id="male"/>
            </div>
            <label for="birthDate">Birth Date</label>
            <input type="date" id="birthDate" name="birthDate"/>
            <label for="nationality">Nationality</label>
            <select name="nationality" id="nationality">
                <option value="Bulgarian">Bulgarian</option>
                <option value="American">American</option>
            </select>
        </fieldset>
        <fieldset>
            <legend>Last Work Position</legend>
            <div class="container">
                <label for="company">Company Name</label>
                <input type="text" name="company" id="company"/>
            </div>
            <div class="container">
                <label for="start">From</label>
                <input type="date" id="start" name="start"/>
            </div>
            <div class="container">
                <label for="end">To</label>
                <input type="date" id="end" name="end"/>
            </div>
        </fieldset>
        <fieldset>
            <legend>Computer Skills</legend>
            <div id="containerSkills">
                <div>Programming Languages</div>
                <div id="skill1">
                    <input type="text" name="skill1"/><!--
                    --><select name="level1">
                        <option value="Beginner">Beginner</option>
                        <option value="Advanced">Advanced</option>
                        <option value="Master">Master</option>
                    </select>
                </div>
            </div>
            <input type="hidden" value="2" name="skillCounter" id="skillCounter"/>
            <input type="button" value="Remove Language" onclick="removeSkill()"/>
            <input type="button" value="Add Language" onclick="addSkill()"/>
        </fieldset>
        <fieldset>
            <legend>Other Skills</legend>
            <div>Languages</div>
            <div id="containerLang">
                <div id="lang1">
                    <input type="text" name="language1" id="language"/><!--
                    --><select name="comprehension1" id="">
                        <option selected="selected" disabled="disabled">-Comprehension-</option>
                        <option value="bad">Bad</option>
                        <option value="good">Good</option>
                        <option value="excellent">Excellent</option>
                    </select><!--
                    --><select name="reading1" id="">
                        <option selected="selected" disabled="disabled">-Reading-</option>
                        <option value="bad">Bad</option>
                        <option value="good">Good</option>
                        <option value="excellent">Excellent</option>
                    </select><!--
                    --><select name="writing1" id="">
                        <option selected="selected" disabled="disabled">-Writing-</option>
                        <option value="bad">Bad</option>
                        <option value="good">Good</option>
                        <option value="excellent">Excellent</option>
                    </select>
                </div>
                <input type="hidden" value="2" name="langCounter" id="langCounter"/>
            </div>
            <input type="button" value="Remove Language" onclick="removeLang()"/>
            <input type="button" value="Add Language" onclick="addLang()"/>

            <div class="container">
                <div>Driver's License</div>
                <label for="drivingB">B</label>
                <input type="checkbox" name="drivingB" value="B" id="drivingB"/>
                <label for="drivingA">A</label>
                <input type="checkbox" name="drivingA" value="A" id="drivingA"/>
                <label for="drivingC">C</label>
                <input type="checkbox" name="drivingC" value="C" id="drivingC"/>
            </div>
        </fieldset>
        <input type="submit" value="Generate CV" name="submit"/>
    </form>
    <aside>
        <?php
        if ($_POST['submit']) {
            printCV();
        }
        ?>
    </aside>
</div>
</body>
</html>