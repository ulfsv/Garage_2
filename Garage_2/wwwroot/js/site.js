if (sessionStorage.getItem("msgToUser") !== null && sessionStorage.msgShown !== "true") {
    $("#alert-user").text(sessionStorage.msgToUser); // TODO: Vanilla JS
    $("#alert-user").show(); // TODO: Vanilla JS
    sessionStorage.msgShown = true;
}
else {
    $("#alert-user").hide(); // TODO: Vanilla JS
    sessionStorage.removeItem("msgToUser");
}

//if (document.querySelector("#btn-park-vehicle")) {
//    var btnParkVehicle = document.querySelector("#btn-park-vehicle");
//    btnParkVehicle.addEventListener("click", onBtnParkVehicleClick);
//}

if (document.querySelector("#btn-edit-vehicle")) {
    var btnEditVehicle = document.querySelector("#btn-edit-vehicle");
    btnEditVehicle.addEventListener("click", onBtnEditVehicleClick);
}

if (document.querySelector(".link-fetch-vehicle")) {

    var fetchLinkes = document.getElementsByClassName("link-fetch-vehicle");

    // Loop through all the "Fetch vehicle"-links to add event listener
    for (var i = 0; i < fetchLinkes.length; i++) {
     //   fetchLinkes[i].addEventListener("click", onLinkFetchVehicleClick);
        fetchLinkes[i].addEventListener("click", showConfirmation);
    }
}

// Add new vehicle type
$("#add-vehic-type").click(function () {
    if ($("#add-vehic-type").is(":checked") == true) {
        $('#existing-vehicle-types-dropdown-select').fadeOut("slow");
        $('#existing-vehicle-types-label').fadeOut("slow", function () {
            $('#add-new-vehic-type-input').fadeIn("slow");
            $('#add-new-vehic-type-input-label').fadeIn("slow");
        });

    } else {
        $('#add-new-vehic-type-input').fadeOut("slow");
        $('#add-new-vehic-type-input-label').fadeOut("slow", function () {
            $('#existing-vehicle-types-dropdown-select').fadeIn("slow");
            $('#existing-vehicle-types-label').fadeIn("slow");
        });
    }
});

/************************ onBtnParkVehicleClick ***********************************/
//function onBtnParkVehicleClick() {
//    sessionStorage.msgToUser = "Vehicle was parked";
//    sessionStorage.msgShown = false;
//}

/************************ onBtnEditVehicleClick ***********************************/
function onBtnEditVehicleClick() {
    sessionStorage.msgToUser = "Vehicle was edited";
    sessionStorage.msgShown = false;
}

/************************ onLinkFetchVehicleClick *********************************/
function onLinkFetchVehicleClick() {
    sessionStorage.msgToUser = "Vehicle was fetched";
    sessionStorage.msgShown = false;
}

function showConfirmation() {
    document.querySelector("#popup-confirmation").style.display = "block";
    document.querySelector("#popup-confirmation").style.opacity = "1";

}