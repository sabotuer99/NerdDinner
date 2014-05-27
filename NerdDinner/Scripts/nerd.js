// by Troy Whorten, Feb 28 2014 (though to be fair I didn't write much of it...)

function getLoc() {
    if (geoPosition.init()) {
        geoPosition.getCurrentPosition(geoSuccess, geoError);
    }
}

var map;

function geoSuccess(p) {
    //document.getElementById("latitude").innerHTML = p.coords.latitude;
    //document.getElementById("longitude").innerHTML = p.coords.longitude;
    //document.getElementById("accuracy").innerHTML = p.coords.accuracy;

    // from Google Maps API 
    // https://developers.google.com/maps/documentation/javascript/examples/map-simple
    // I just swaped out lat and long for Syndney, Australia for the geolocation info above
    var mapOptions = {
        zoom: 15,
        center: new google.maps.LatLng(p.coords.latitude, p.coords.longitude)
    };
    map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

    // this I copied from a different Google Maps API example
    // https://developers.google.com/maps/documentation/javascript/examples/map-geolocation
    var pos = new google.maps.LatLng(p.coords.latitude,
                                     p.coords.longitude);

    var infowindow = new google.maps.InfoWindow({
        map: map,
        position: pos,
        content: 'Location found using HTML5.'
    });

    //end Google API Code
}

function geoError() {
    document.getElementById("errormsg").innerHTML = "Could not find you!";
}