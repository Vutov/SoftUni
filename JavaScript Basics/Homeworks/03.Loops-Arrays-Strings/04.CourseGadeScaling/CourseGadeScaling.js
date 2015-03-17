function solve(arr) {
    console.log(typeof arr);
    console.log(arr[0]['score']);
    var data = arr.map(function(x) {
        x['score'] = Math.round(x['score'] * 110) / 100;
        if (x['score'] >= 100) {
            x['hasPassed'] = true;
        } else {
            x['hasPassed'] = false;
        }
        return x;
    });
    data = data.sort(function(x, y) {
        return x['name'] > y['name'];
    });
    data = data.filter(function(x) {
        return x['hasPassed'];
    });
    console.log(data);
}

solve([{ 'name' : 'Пешо', 'score' : 91 }, { 'name' : 'Лилия', 'score' : 290 }, { 'name' : 'Алекс', 'score' : 343 }, { 'name' : 'Габриела', 'score' : 400 }, { 'name' : 'Жичка', 'score' : 70 }]);