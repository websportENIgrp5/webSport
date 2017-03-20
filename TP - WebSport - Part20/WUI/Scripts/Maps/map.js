var map;
var arrayDepArr=[];
var waypts=[];
var directionsService;
var directionsDisplay;
var latCentre;
var lngCentre;
var idCourse;


function initMap() {
	
  var myOption={zoom:10, center : new google.maps.LatLng(latCentre, lngCentre), disableDefaultUI: true,};
  map = new google.maps.Map(document.getElementById('map'), myOption);
  directionsService = new google.maps.DirectionsService;
  directionsDisplay = new google.maps.DirectionsRenderer({
	  suppressMarkers : true,
	  map:map,
  });
	
}

$(function () {
    var reponseServer;
    var xmlhttp = new XMLHttpRequest();

    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == XMLHttpRequest.DONE) {
            if (xmlhttp.status == 200) {
                if (xmlhttp.responseText == "\"NoPar\"")
                {
                    document.getElementById("map").innerHTML = "<p>Aucun parcours defini pour cette course</p>";
                }
                else
                {
                    traceparcours(xmlhttp.responseText);
                }
                
            }
            else if (xmlhttp.status == 400) {
                alert('There was an error 400');
            }
            else {
                alert('something else other than 200 was returned');
            }
        }
    };

    var url = "http://localhost/WUI/Race/GetParcoursById?idCourse=" + idCourse;
    xmlhttp.open("GET", url , true);
    xmlhttp.send();

    
  /*  $.ajax({
        url: "/WUI/Race/GetParcoursById",
        type: "GET",
        dataType: "json",
        data: {
            idCourse: 2,
        },
        success: function (data) {
            console.log("datarecus : "+data);
            traceparcours(reponseServer);

        },
        error: function (data) {
            console.log(data);
        }
    });*/
   
});

function traceparcours(parcours) {

        var test = parcours.split('"')[1];
        var testarray = test.split(';');
        for (var i = 0; i < testarray.length; i++) {
            if (testarray[i] != "") {
                var typecoord = testarray[i].split(':');

                var coordonnees = typecoord[1].split(',');

                if (typecoord[0] === "c") {
                    createWayPoint(coordonnees[0], coordonnees[1]);
                }
                else if (typecoord[0] === "d") {
                    createPoi(coordonnees[0], coordonnees[1], "dep");
                }
                else if (typecoord[0] === "a") {
                    createPoi(coordonnees[0], coordonnees[1], "arr");
                }
                else if (typecoord[0] === "r") {
                    createRavito(coordonnees[0], coordonnees[1]);
                }
            }
        }
        calculateAndDisplayRoute();
    }
           
function calculateAndDisplayRoute()
{
	directionsService.route({
		origin :arrayDepArr[0].getPosition(),
		destination: arrayDepArr[1].getPosition(),
		waypoints : waypts,
		travelMode : google.maps.TravelMode.WALKING
	}, function (response, status){
		if(status == google.maps.DirectionsStatus.OK){
			directionsDisplay.setDirections(response);
		}else{
			window.alert('Directions request failed due to '+status);
		}
	});
}
function calcDistance(response)
{
	var totalDistance=0;
	for(var i=0; i<response.routes[0].legs.length; i++)
	{
		totalDistance+= parseInt(response.routes[0].legs[i].distance.value);
	}
	return (totalDistance/1000)+"km";
}

function createRavito(lat, lng)
{
	 var MarkerRavito = new google.maps.Marker({
	  position : new google.maps.LatLng(lat, lng),
	  title:"Ravito",
	  label:"R",
	  map:map,
	  draggable: false,
	  animation: google.maps.Animation.DROP,
	  //icon: "./image/ravito.jpg",
  });
  createWayPoint(lat, lng);
}

function createPoi(lat, lng, type)
{
	var marker;
	if(type === "dep")
	{
	  marker = new google.maps.Marker({
		  position : new google.maps.LatLng(lat, lng),
		  title : "Depart",
		  label : "D",
		  map: map,
		  draggable : false,
		  animation: google.maps.Animation.DROP,
	  });
	}
	else if(type === "arr")
	{
	  marker = new google.maps.Marker({
	  position : new google.maps.LatLng(lat, lng),
	  title : "Arrivee",
	  label : "A",
	  map: map,
	  draggable : false,
	  animation: google.maps.Animation.DROP,
	  }); 
	}
	arrayDepArr.push(marker);
}

function createWayPoint(lat, lng)
{
	waypts.push({
		location: new google.maps.LatLng(lat, lng),
		stopover:true,
	})
}