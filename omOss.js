// function myMap() {
//   var mapProp = {
//     center: new google.maps.LatLng(57.70639748043602, 11.924845076947278),
//     zoom: 14,
//   };
//   var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
// }

// Initialize and add the map
function initMap() {
  // The location of Uluru
  const uluru = { lat: 57.70639748043602, lng: 11.924845076947278 };
  // The map, centered at Uluru
  const map = new google.maps.Map(document.getElementById("googleMap"), {
    zoom: 12,
    center: uluru,
  });
  // The marker, positioned at Uluru
  const marker = new google.maps.Marker({
    position: uluru,
    map: map,
  });
}

window.initMap = initMap;
