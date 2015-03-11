function calcCylinderVol(array) {
    var radius = parseInt(array[0]);
    var height = parseInt(array[1]);
    var volume = Math.PI * Math.pow(radius, 2) * height;
    console.log(volume.toFixed(3));
}

calcCylinderVol([2, 4]);
calcCylinderVol([5, 8]);
calcCylinderVol([12, 3]);
