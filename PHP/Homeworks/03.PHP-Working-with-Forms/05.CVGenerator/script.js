var skillCounter = 2;
var langCounter = 2;

function addSkill() {
    var parent = document.getElementById('containerSkills');
    var container = document.createElement('div');
    container.id = 'skill' + skillCounter;
    var input = document.createElement('input');
    input.type = 'text';
    input.name = 'skill' + skillCounter;
    container.appendChild(input);
    var select = document.createElement('select');
    select.name = 'level' + skillCounter;
    var optionOne = document.createElement('option');
    optionOne.value = 'Beginner';
    optionOne.innerHTML = 'Beginner';
    var optionTwo = document.createElement('option');
    optionTwo.value = 'Advanced';
    optionTwo.innerHTML = 'Advanced';
    var optionThree = document.createElement('option');
    optionThree.value = 'Master';
    optionThree.innerHTML = 'Master';
    select.appendChild(optionOne);
    select.appendChild(optionTwo);
    select.appendChild(optionThree);
    container.appendChild(select);
    parent.appendChild(container);
    skillCounter++;
    document.getElementById('skillCounter').value = skillCounter;
}

function removeSkill() {
    skillCounter--;
    document.getElementById('skillCounter').value = skillCounter;
    var parent = document.getElementById('containerSkills');
    var child = document.getElementById('skill' + skillCounter);
    parent.removeChild(child);
}

function addLang() {
    var parent = document.getElementById('containerLang');
    var container = document.createElement('div');
    container.id = 'lang' + langCounter;
    var input = document.createElement('input');
    input.type = 'text';
    input.name = 'language' + langCounter;
    container.appendChild(input);
    var comp = addOption('comprehension','-Comprehension-');
    container.appendChild(comp);
    var read = addOption('reading','-Reading-');
    container.appendChild(read);
    var write = addOption('writing','-Writing-');
    container.appendChild(write);
    parent.appendChild(container);
    langCounter++;
    document.getElementById('langCounter').value = langCounter;
}

function addOption(name, title) {
    var select = document.createElement('select');
    select.name = name + langCounter;
    var optionZero = document.createElement('option');
    optionZero.innerHTML = title;
    optionZero.disabled = 'disabled';
    optionZero.selected = 'selected';
    var optionOne = document.createElement('option');
    optionOne.value = 'Bad';
    optionOne.innerHTML = 'Bad';
    var optionTwo = document.createElement('option');
    optionTwo.value = 'Good';
    optionTwo.innerHTML = 'Good';
    var optionThree = document.createElement('option');
    optionThree.value = 'Excellent';
    optionThree.innerHTML = 'Excellent';
    select.appendChild(optionZero);
    select.appendChild(optionOne);
    select.appendChild(optionTwo);
    select.appendChild(optionThree);
    return select;
}

function removeLang() {
    langCounter--;
    document.getElementById('langCounter').value = langCounter;
    var parent = document.getElementById('containerLang');
    var child = document.getElementById('lang' + langCounter);
    parent.removeChild(child);
}