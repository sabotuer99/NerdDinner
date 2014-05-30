$(document).ready(function () {
    if (document.getElementById('map-canvas') != null) {

        var coords = new Array();
        $.getJSON("/dinner", function (json) {
            $.each(json, function (i, dinner) {
                coords.push(
                    {
                        latitude: dinner.Latitude,
                        longitude: dinner.Longitude,
                        dinnertitle: dinner.Title,
                        dinnerid: dinner.DinnerId
                    }
                );

                console.log(coords[i]);

                $('#dinnerlist').append($('<li/>')
                    .attr("class", "dinnerItem")
                    .append(dinner.Title)
                    .append($('<br/>'))
                    .append(dinner.EventDate)
                    .append(" with " + dinner.RSVPCount))
                //averageLat += Number(dinner.latitude);
                //averageLong += Number(dinner.longitude);
            });
        }).then(function () {
            //console.log("then");
            //console.log(coords);
            //alert();
            averageLat = 39;
            averageLong = 105.5;

            var pos = new google.maps.LatLng(averageLat,
                                             averageLong);

            //console.log(pos);
            var mapOptions = {
                zoom: 8,
                center: pos,
                draggable: true
            };

            map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

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

                console.log(marker);

                google.maps.event.addListener(marker, 'mouseover', function () {
                    //console.log(this);
                    infowindow.setContent(this.data);
                    infowindow.open(map, this);
                })

                google.maps.event.addListener(marker, 'mouseout', function () {
                    infowindow.close();
                })

                google.maps.event.addListener(marker, 'click', function () {
                    //console.log(this);
                    window.location.href = this.url;
                })


            }

                //autocenter?
                var bounds = new google.maps.LatLngBounds();
                $.each(markers, function (index, marker) {
                    bounds.extend(marker.position);
                });
                map.fitBounds(bounds);

                

            
        });
    }


    //datapicker
    //$("#dateinput").datepicker();
});
