$(document).ready(function () {
    //$("#incidentLocationDrpdwnYes").hide();
    //$("#incidentLocationDrpdwnNo").hide();
    //$("#vendorInvolved").hide();
    //$("#nonRetailShiftDiv").hide();
    //$("#associateWearingPPDDiv").hide();
    //$("#floorType").hide();
    //$("#equipmentOrObjectDiv").hide();
    //$("#chemicalDiv").hide();
    //$("#medicalCareSoughtYesDiv").hide();
    //$("#cameraDiv").hide();
    $("#incidentLocation").change(function () {
        var selectedCountry = $(this).children("option:selected").val();
        if (selectedCountry == 5610) {
            $("#incidentLocationDrpdwnYes").show();
            $("#incidentLocationDrpdwnNo").hide();
        }
        else if (selectedCountry == 5611) {
            $("#incidentLocationDrpdwnYes").hide();
            $("#incidentLocationDrpdwnNo").show();
        }
        else {
            $("#incidentLocationDrpdwnYes").hide();
            $("#incidentLocationDrpdwnNo").hide();
        }
    });
    $("#vendorInvlovedDrpdwn").change(function () {
        var selectedCountry = $(this).children("option:selected").val();
        if (selectedCountry == 5610) {
            $("#vendorInvolved").show();
        }
        else {
            $("#vendorInvolved").hide();
        }
    });
    $("#locationTypeDrpdwn").change(function () {
        var selectedCountry = $(this).children("option:selected").val();
        if (selectedCountry == "Distribution") {
            $("#nonRetailShiftDiv").show();
        }
        else {
            $("#nonRetailShiftDiv").hide();
        }
    });
    $("#ppeInjuryDrpdwn").change(function () {
        var selectedCountry = $(this).children("option:selected").val();
        if (selectedCountry == 5610) {
            $("#associateWearingPPDDiv").show();
        }
        else {
            $("#associateWearingPPDDiv").hide();
        }
    });
    $("#incidentTypeDrpdwn").change(function () {
        var selectedCountry = $(this).children("option:selected").val();
        if (selectedCountry == "Slip") {
            $("#floorType").show();
        }
        else {
            $("#floorType").hide();
        }
    });
    $("#equipmentOrObjectDrpdwn").change(function () {
        var selectedCountry = $(this).children("option:selected").val();
        if (selectedCountry == 5610) {
            $("#equipmentOrObjectDiv").show();
        }
        else {
            $("#equipmentOrObjectDiv").hide();
        }
    });
    $("#chemicalDrpdwn").change(function () {
        var selectedCountry = $(this).children("option:selected").val();
        if (selectedCountry == 5610) {
            $("#chemicalDiv").show();
        }
        else {
            $("#chemicalDiv").hide();
        }
    });
    $("#medicareSoughtDrpdwn").change(function () {
        var selectedCountry = $(this).children("option:selected").val();
        if (selectedCountry == 5610) {
            $("#medicalCareSoughtYesDiv").show();
        }
        else {
            $("#medicalCareSoughtYesDiv").hide();
        }
    });
    $("#incidentCoveredByVideoDrpdwn").change(function () {
        var selectedCountry = $(this).children("option:selected").val();
        if (selectedCountry == 5610) {
            $("#cameraDiv").show();
        }
        else {
            $("#cameraDiv").hide();
        }
    });
    $("#btnLocationSearch").click(function () {
        $.ajax(
            {
                type: "GET", //HTTP POST Method  
                url: "AssociateInjury/SearchLocationsResultAsync", // Controller/View   
                data: { //Passing data  
                    state: $("#txtstate").val(), //Reading text box values using Jquery   
                    number: $("#txtNumber").val(),
                    city: $("#txtcity").val()
                }

            });
    });  
});