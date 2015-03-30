function solve(arr) {
    arr.forEach(function(line) {
        var data = line.split(/\s+/g);
        var car = data[0];
        var fuel = data[1];
        var route = data[2];
        var kg = data[3];
        var fuelPerHun = 10;
        if (fuel === 'gas') {
            fuelPerHun *= 1.2;
        }
        else if (fuel === 'diesel') {
            fuelPerHun *= 0.8;
        }
        var extraFuel = kg * 0.01;
        fuelPerHun += extraFuel;
        var totalFuel = 0;
        if (route === '1') {
            totalFuel += fuelPerHun;
            totalFuel += (fuelPerHun * 10 / 100) * 1.3;
        } else {
            totalFuel += fuelPerHun * 65 / 100;
            totalFuel += (fuelPerHun * 30 / 100) * 1.3;
        }
        console.log(car + " " + fuel +" " + route +" " + Math.round(totalFuel));
    });
}

solve([
    'BMW petrol 1 320.5',
    'Golf petrol 2 150.75',
    'Lada gas 1 202',
    'Mercedes diesel 2 312.54'
]);