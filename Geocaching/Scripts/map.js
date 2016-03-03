function Initialize(e) {
    var latitude = $('#map_canvas').data('latitude');
    var longitude = $('#map_canvas').data('longitude');
    var latlng = new google.maps.LatLng(latitude, longitude);
    var options = {
        zoom: 15,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    var map = new google.maps.Map(document.getElementById("map_canvas"), options);

    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(latitude, longitude),
        map: map
    });
}

$(function () {
    Initialize();
});




