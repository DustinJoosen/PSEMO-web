
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
        return;
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
        return;
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
window.addMapMarker = (lat, lng, title, isCoordinateMap = false) => {
    var layerGroup = isCoordinateMap
        ? window.coordinateMapLayerGroup
        : window.viewableMapLayerGroup;

    if (!layerGroup) {
        console.error("Marker added before the map was initialized");
        return;
    }

    let marker = L.marker([lat, lng]).addTo(layerGroup);
    if (title != null) {
        marker.bindPopup("<b>" + title + "</b>")
    }
}
