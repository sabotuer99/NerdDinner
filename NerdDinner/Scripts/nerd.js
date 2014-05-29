$(document).ready(function () {
    if (document.getElementById('map-canvas') != null) {

        var coords = new Array();
        var averageLat = 0;
        var averageLong = 0;

        var rows = $(".dinnerrow");
        for (var i = 0; i < rows.length; i++) {
            coords.push(
                {
                latitude : rows[i].getElementsByClassName("latitude")[0].innerText,
                longitude: rows[i].getElementsByClassName("longitude")[0].innerText,
                dinnertitle: rows[i].getElementsByClassName("dinnertitle")[0].innerText,
                dinnerid: rows[i].getAttribute("data-dinnerId")
                }
            );
            averageLat += Number(rows[i].getElementsByClassName("latitude")[0].innerText);
            averageLong += Number(rows[i].getElementsByClassName("longitude")[0].innerText);
            console.log(averageLat + '  ' + averageLong);
        }

        console.log(coords);
        averageLat = averageLat / rows.length;
        averageLong = averageLong / rows.length;

        var pos = new google.maps.LatLng(averageLat,
                                         averageLong);

        console.log(pos);
        var mapOptions = {
            zoom: 8,
            center: pos
        };

        map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

        //var infowindow = new google.maps.InfoWindow({
        //    map: map,
        //    position: pos,
        //    content: 'Find a Nerd Dinner'
        //});

        var markers = [];
        //var infowindows = [];

        for (var i = 0; i < coords.length; i++) {
            var dinnerpos = new google.maps.LatLng(coords[i].latitude,
                                         coords[i].longitude);

            var data = coords[i].dinnertitle;

            var infowindow = new google.maps.InfoWindow({
                content: data
            });
            

            marker = new google.maps.Marker({
                position: dinnerpos,
                map: map,
                title: coords[i].dinnertitle,
                url: "Dinner/Details/" + coords[i].dinnerid
                });

            marker.data = data;

            markers[i] = marker;

            google.maps.event.addListener(marker, 'mouseover', function () {
                    infowindow.setContent(this.data);
                    infowindow.open(map, this);                       
            })

            google.maps.event.addListener(marker, 'click', function () {
                window.location.href = this.url;
            })

            //autocenter?
            var bounds = new google.maps.LatLngBounds();
            $.each(markers, function (index, marker) {
                bounds.extend(marker.position);
            });
            map.fitBounds(bounds);

        }
    }



    
});
