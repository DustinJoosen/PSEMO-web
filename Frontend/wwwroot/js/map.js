
// Global variables holding the viewable and clickable maps, and their layer groups.
// The layer groups contain all the markers.
window.viewableMap = null;
window.viewableMapLayerGroup = null;

window.coordinateMap = null;
window.coordinateMapLayerGroup = null;

// This one is here for the javascript->blazor connection.
window.setDotNetHelper = (value) => {
    window.dotnetHelper = value;
}

// Call this to initialize a view map, at a given latitude and longitude.
window.initializeViewableMap = (lat, lng) => {
    if (window.viewableMap != null) {
        window.viewableMap.remove();
    }

    window.viewableMap = L.map("viewable-map").setView([lat, lng], 12);
    window.viewableMapLayerGroup = L.layerGroup().addTo(window.viewableMap);

    L.tileLayer("https://{s}.google.com/vt/lyrs=m&x={x}&y={y}&z={z}", {
        subdomains: ["mt0", "mt1", "mt2", "mt3"],
    }).addTo(window.viewableMap);
}

// Call this to initialize a coordinate map, at a given latitude and longitude.
window.initializeCoordinateMap = (lat, lng) => {
    if (window.coordinateMap != null) {
        window.coordinateMap.remove();
    }

    window.coordinateMap = L.map("coordinate-map").setView([lat, lng], 12);
    window.coordinateMapLayerGroup = L.layerGroup().addTo(window.coordinateMap);

    L.tileLayer("https://{s}.google.com/vt/lyrs=m&x={x}&y={y}&z={z}", {
        subdomains: ["mt0", "mt1", "mt2", "mt3"],
    }).addTo(window.coordinateMap);

    // When you click somewhere, invoke the OnMapSelect in blazor with the coordinates of that click.
    window.coordinateMap.addEventListener("click", function (e) {
        var coord = e.latlng;
        var lat = coord.lat;
        var lng = coord.lng;

        // Give the coordinates back to blazor.
        window.dotnetHelper.invokeMethodAsync("OnMapSelect", lat, lng);

        // Set a marker at where you clicked.
        window.clearMapMarkers(true);
        window.addMapMarker(lat, lng, null, true);
    });
}

// Remove all markers from the global map. True->coordinatemap. False->viewablemap.
window.clearMapMarkers = (isCoordinateMap) => {
    var layerGroup = isCoordinateMap
        ? window.coordinateMapLayerGroup
        : window.viewableMapLayerGroup;

    layerGroup.clearLayers();
}

// Add a marker to the map. True->coordinatemap. False->viewablemap
window.addMapMarker = (lat, lng, title, isCoordinateMap = false, isBlue = true) => {
    var layerGroup = isCoordinateMap
        ? window.coordinateMapLayerGroup
        : window.viewableMapLayerGroup;

    if (!layerGroup) {
        console.error("Marker added before the map was initialized");
        return;
    }

    if (isBlue) {
        var marker = L.marker([lat, lng]).addTo(layerGroup);
    } else {
        var marker = L.marker([lat, lng], { icon: redIcon }).addTo(layerGroup);
    }
    if (title != null) {
        marker.bindPopup("<b>" + title + "</b>")
    }
}

window.setMapView = (lat, lng) => {
    if (!window.viewableMap) {
        console.error("Map is not yet initialized");
        return;
    }

    window.viewableMap.setView([lat, lng]);
}

window.setMapViewCurrentLocation = () => {
    return new Promise((resolve, reject) => {
        if (!navigator.geolocation) {
            reject("Can't access geolocation");
            return;
        }
        navigator.geolocation.getCurrentPosition((pos) => {

            var lat = pos.coords.latitude;
            var lng = pos.coords.longitude;

            window.setMapView(lat, lng);
            window.addMapMarker(lat, lng, "Jouw locatie", false, false);
            resolve({ lat: lat.toString(), lng: lng.toString() })
        })
    })
}

const redIcon = new L.Icon({
    iconUrl: 'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-2x-red.png',
    iconSize: [25, 41],
    iconAnchor: [12, 41],
    popupAnchor: [1, -34],
    shadowSize: [41, 41]
});