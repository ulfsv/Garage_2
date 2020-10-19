// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

if (sessionStorage.getItem("msgToUser")!== null && sessionStorage.msgShown != true) {
    $("#alert-user").text(sessionStorage.msgToUser);
    sessionStorage.msgShown = true;
    $("#alert-user").show();
}
else {
    $("#alert-user").hide();
    sessionStorage.removeItem("msgToUser");
}

if (document.querySelector("#btn-park-vehicle")) {
    var btnParkVehicle = document.querySelector("#btn-park-vehicle");
    btnParkVehicle.addEventListener("click", onBtnParkVehicleClick);
}

if (document.querySelector("#btn-edit-vehicle")) {
    var btnEditVehicle = document.querySelector("#btn-edit-vehicle");
    btnEditVehicle.addEventListener("click", onBtnEditVehicleClick);
}

function onBtnParkVehicleClick() {
    sessionStorage.msgToUser = "Vehicle was parked";
    sessionStorage.msgShown = false;
}

function onBtnEditVehicleClick() {
    sessionStorage.msgToUser = "Vehicle was edited";
    sessionStorage.msgShown = false;
}