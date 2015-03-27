function solve(arr) {
    var criteia = arr[0].split('^');
    var json = { students: [], trainers: [] };
    for (var i = 1; i < arr.length; i++) {
        var data = JSON.parse(arr[i]);
        
        //console.log(data);
        if (data['role'] === 'student') {
            var totalGrades = 0;
            data['grades'].forEach(function (grade) {
                totalGrades += Number(grade);
            });
            //console.log(totalGrades);
            var averageGrade = (totalGrades / data['grades'].length).toFixed(2);
            json['students'].push({
                id: data['id'],
                firstname: data['firstname'],
                lastname: data['lastname'],
                averageGrade: averageGrade,
                certificate: data['certificate'],
                level: data['level']
        });
        } else {
            //console.log(data['courses'])
            var courses = data['courses'];
            json['trainers'].push({
                id: data['id'],
                firstname: data['firstname'],
                lastname: data['lastname'],
                courses: courses,
                lecturesPerDay: data['lecturesPerDay']
            });
        }

    }
    
    function sortStudents(criteria) {
        if (criteria === 'name') {
            console.log('in')
            json["students"].sort(function (x, y) {
                //console.log(x["firstname"]);
                if (x["firstname"] !== y['firstname']) {
                    console.log('in');
                    return x['firstname'] > y['firstname'];
                } else {
                    //console.log('else');
                    return x['lastname'] > y['lastname'];
                }
            });
        } else {
            json["students"].sort(function (x, y) {
                //console.log(x["firstname"]);
                if (x["level"] !== y['level']) {
                    //console.log('in');
                    return Number(x['level']) - Number(y['level']);
                } else {
                    return Number(x['id']) - Number(y['id']);
                }
            });
        }
    }
    
    function sortTrainers() {
        //console.log(json['trainers'])
        json['trainers'].sort(function (x, y) {
            //console.log(x['courses'].length)
            //console.log(y['courses'].length)
            if (x['courses'].length !== y['courses'].length) {
                //console.log('in');
                return x['courses'].length - y['courses'].length;
                
            } else {
                //console.log('else');
                //console.log(x['lecturesPerDay'])
                return Number(x['lecturesPerDay']) - Number(y['lecturesPerDay']);
            }
            //console.log(x['courses'])
        });
        //console.log(1);
        //console.log(json['trainers'])
    }
    
    sortTrainers();
    sortStudents(criteia[0]);
    //console.log(json);
    json['students'].map(function(x) {
        delete x['level'];
    });
    console.log(json["students"]);
    //console.log(JSON.stringify(json));
}

solve([
    'level^courses',
    '{"id":0,"firstname":"Angel","lastname":"Ivanov","town":"Plovdiv","role":"student","grades":["5.89"],"level":2,"certificate":false}',
    '{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad","role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
    '{"id":2,"firstname":"Bobi","lastname":"Georgiev","town":"Varna","role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
    '{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin","role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
    '{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia","role":"trainer","courses":["Database","JS Apps","Java"],"lecturesPerDay":2}'
]);

//solve([
//    'name^courses',
//    '{"id":3,"firstname":"Angel","lastname":"Avaa","town":"Vidin","role":"student","grades":["5.89"],"level":2,"certificate":false}',
//    '{"id":3,"firstname":"Angel","lastname":"Qvnova","town":"Vidin","role":"student","grades":["5.89"],"level":2,"certificate":false}',
//    '{"id":3,"firstname":"Angel","lastname":"Dvsasanova","town":"Vidin","role":"student","grades":["5.89"],"level":2,"certificate":false}',
//    '{"id":3,"firstname":"Angel","lastname":"Gvanova","town":"Vidin","role":"student","grades":["5.89"],"level":2,"certificate":false}',
//    '{"id":3,"firstname":"Angel","lastname":"Rvava","town":"Vidin","role":"student","grades":["5.89"],"level":2,"certificate":false}',
//    '{"id":4,"firstname":"Angel","lastname":"Betadasdrova","town":"Sofia","role":"student","grades":["5.89"],"level":2,"certificate":false}'
//]);
