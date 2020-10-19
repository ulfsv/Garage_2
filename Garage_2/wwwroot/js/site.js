// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//let vehicleWasJustParked = false;

$(document).ready(function () {
    if (document.querySelector(".btn-park-vehicle")) {
        var btnParkVehicle = document.querySelector(".btn-park-vehicle");
        btnParkVehicle.addEventListener("click", onBtnParkVehicleClick);
    }

    $("#alert-user").text("Testa 222");
    $("#alert-user").css(display, none);
});

function onBtnParkVehicleClick() {
    showVehicleParkedAlert();
    vehicleWasJustParked = true;
}

function showVehicleParkedAlert() {
    $("#alert-user").text("The vehicle has been parked");
    console.log("Parked"); /////////////////
}

