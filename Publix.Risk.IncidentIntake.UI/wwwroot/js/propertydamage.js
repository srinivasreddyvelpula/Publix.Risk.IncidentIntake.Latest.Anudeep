$("#btnPrimaryAdd").click(function () {
    $("#txtInvolvementType").val("Primary Customer");
    $("#lblHeading").text("Property Damage Persons Involved");
});
$("#IncidentAtLocation").change(function () {
    var value = $(this).val();

    if (value == yes) {
        $("#locationDiv").hide();
        $("#divCostCenter").show();
    }
    else if (value == no) {
        $("#locationDiv").show();
        $("#divCostCenter").hide();
    }
    else {
        $("#locationDiv").hide();
        $("#divCostCenter").hide();
    }
});
$("#associateInvolved").change(function () {
    var value = $(this).val();
    if (value == yes) {
        $(".divassociate").show();
    }
    else { $(".divassociate").hide(); }
});
