$("#MinorId").on("click", function () {
    var value = $(this).val();
    if (value == yes) {
        $("#divGuardian").show();
        $("#divSpouse").hide();
    }
    else {
        $("#divGuardian").hide();
        $("#divSpouse").show();
    }
});

function incidentCoveredByVideoChange(obj) {
    var value = $(obj).val();
    if (value == yesUnknown) {
        $("#divcamera").show();
    }
    else {
        $("#divcamera").hide();
    }
}
function reasonChange(obj) {
    var value = $(obj).val();
    if (value == yes) {
        $("#divreasonexplanation").show();
    }
    else {
        $("#divreasonexplanation").hide();
    }

}
$("#btnnonassociatewitnessAdd").click(function () {
    $("#txtInvolvementType").val("Witness");
});