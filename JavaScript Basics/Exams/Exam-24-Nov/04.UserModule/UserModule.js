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
            //console.log('in')
            json["students"].sort(function (x, y) {
                //console.log(x["firstname"]);
                if (x["firstname"] !== y['firstname']) {
                    //console.log('in');
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
    //console.log(json);
    console.log(JSON.stringify(json));
}