function ChangeImages(imageName) {
    if (imageName == "mustang") {
        document.getElementById("Image").src = "http://www.ford.com/ngbs-services/resources//ford/mustang/2014/highlights/mst_14_highlight_lg_shelbygt500.jpg";
    }
    else if (imageName == "bmw") {
        document.getElementById("Image").src = "http://pictures.topspeed.com/IMG/crop/201106/2012-bmw-m5-37_600x0w.jpg";
    }
    else if (imageName == "porsche") {
        document.getElementById("Image").src = "http://media.caranddriver.com/images/13q2/524198/2014-porsche-panamera-photo-524209-s-1280x782.jpg";
    }
    else if (imageName == "audi") {
        document.getElementById("Image").src = "http://upload.wikimedia.org/wikipedia/commons/b/b8/2012_Audi_RS5_near_the_Elephant_Rock_in_the_Valley_of_Fire.jpg";
    }
    else {
        document.getElementById("Image").src = "http://media.caranddriver.com/images/13q1/499739/2013-mercedes-benz-c63-amg-edition-507-photo-499740-s-1280x782.jpg";
    }
}