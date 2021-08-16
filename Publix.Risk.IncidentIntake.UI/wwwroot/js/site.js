$(document).ready(function () {
    $("#locationSearchBtn").click(function () {
        var number = $("#LocationSearchViewModel_LocationDescription").val();
        var city = $("#LocationSearchViewModel_City").val();
        var state = $("#LocationSearchViewModel_State").children("option:selected").val();
        $.ajax({
            type: "POST",
            url: "/AssociateInjury/LocationSearch",
            data: { "city": city, "number": number, "state": state },
            success: function (response) {
                alert("Hello: " + response.Name + " .\nCurrent Date and Time: " + response.DateTime);
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });
    $("#associateSearchBtn").click(function () {
        var PERNER = $("#txtPerner").val();
        var firstName = $("#txtFirstName").val();
        var LastName = $("#txtLastName").val();
        var costCenter = $("#txtCostCenter").val();
        $.ajax({
            type: "POST",
            url: "/Base/AssociateSearch",
            data: { "PERNER": PERNER, "firstName": firstName, "LastName": LastName, "costCenter": costCenter },
            success: function (response) {
                alert("success");
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });
});  
