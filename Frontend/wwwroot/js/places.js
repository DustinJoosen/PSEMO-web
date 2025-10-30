
window.initPlacesField = () => {
    placeField = new google.maps.places.Autocomplete(
        document.getElementById("enter-location-places-field"),
        {
            types: ['locality', 'political'],
            componentRestrictions: { 'country': ['NL'] },
            fields: ['place_id', 'geometry', 'name']
        }
    )

    google.maps.event.addListener(placeField, 'place_changed', () => {
        const place = placeField.getPlace();
        if (!place.geometry) {
            console.log("No location data available for the selected place.");
            return;
        }

        const lat = place.geometry.location.lat();
        const lng = place.geometry.location.lng();

        window.setMapView(lat, lng);
        window.dotnetHelper.invokeMethodAsync("OnSetCoordinates", lat.toString(), lng.toString());
    });
}
