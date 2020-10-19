if (sessionStorage.getItem("msgToUser") !== null && sessionStorage.msgShown !== "true") {
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

if (document.querySelector(".link-fetch-vehicle")) {

    var fetchLinkes = document.getElementsByClassName("link-fetch-vehicle");

    // Loop through all the "Fetch vehicle"-links to add event listener
    for (var i = 0; i < fetchLinkes.length; i++) {
        fetchLinkes[i].addEventListener("click", onLinkFetchVehicleClick);
    }
}

/************************ onBtnParkVehicleClick ***********************************/
function onBtnParkVehicleClick() {
    sessionStorage.msgToUser = "Vehicle was parked";
    // TODO: Try to input reg number here 
    sessionStorage.msgShown = false;
}

/************************ onBtnEditVehicleClick ***********************************/
function onBtnEditVehicleClick() {
    sessionStorage.msgToUser = "Vehicle was edited";
    // TODO: Try to input reg number here 
    sessionStorage.msgShown = false;
}

/************************ onLinkFetchVehicleClick *********************************/
function onLinkFetchVehicleClick() {
    sessionStorage.msgToUser = "Vehicle was fetched";
    // TODO: Try to input reg number here 
    sessionStorage.msgShown = false;
}