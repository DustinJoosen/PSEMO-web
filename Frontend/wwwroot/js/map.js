
// Global variables holding the viewable and clickable maps.
window.viewableMap = null;
window.editableMap = null;

// This one is here for the javascript->blazor connection.
window.setDotNetHelper = (value) => {
    window.dotnetHelper = value;
}


// Call this to initialize a viewing map, at a given latitude and longitude.
window.initializeViewableMap = (lat, lng) => {
    if (window.viewableMap != null) {
        return;
    }

    window.viewableMap = L.map("viewable-map").setView([lat, lng], 12);

    L.tileLayer("https://{s}.google.com/vt/lyrs=m&x={x}&y={y}&z={z}", {
        subdomains: ["mt0", "mt1", "mt2", "mt3"],
    }).addTo(window.viewableMap);
}

// Call this to initialize an editing map, at a given latitude and longitude.
window.initializeEditableMap = (lat, lng) => {
    if (window.editableMap != null) {
        return;
    }

    window.editableMap = L.map("editable-map").setView([lat, lng], 12);

    L.tileLayer("https://{s}.google.com/vt/lyrs=m&x={x}&y={y}&z={z}", {
        subdomains: ["mt0", "mt1", "mt2", "mt3"],
    }).addTo(window.editableMap);

    window.editableMap.addEventListener("click", function (e) {
        var coord = e.latlng;
        var lat = coord.lat;
        var lng = coord.lng;

        window.dotnetHelper.invokeMethodAsync("OnMapSelect", lat, lng)

    });
}



// Add a marker to the global map.
window.addMapMarker = (lat, lng, title) => {
    if (!window.editableMap) {
        console.error("Marker added before the map was initialized");
        return;
    }

    let marker = L.marker([lat, lng]).addTo(window.editableMap);
    marker.bindPopup("<b>" + title + "</b>")
}
