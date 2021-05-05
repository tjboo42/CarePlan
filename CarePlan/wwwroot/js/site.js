var routeURL = location.protocol + "//" + location.host;

$(document).ready(function () {
    $("#startDate").kendoDateTimePicker({
        value: new Date(),
        dateInput: false
    })
    $("#targetDate").kendoDateTimePicker({
        value: new Date(),
        dateInput: false
    })
    $("#endDate").kendoDateTimePicker({
        value: new Date(),
        dateInput: false
    })
});

function onShowModal() {
    $("#recordInput").modal("show");//Opens Modal
}

function onCloseModal() {
    $("#recordInput").modal("hide");//Closes Modal
}

function onSubmitForm() {
    if (checkValidation()) {
        var requestData = {
            Id: parseInt($("#id").val()),
            RecordTitle: $("#title").val(),
            PatientName: $("#patientName").val(),
            UserName: $("#userName").val(),
            ActualStartDateTime: $("#startDate").val(),
            TargetDateTime: $("#targetDate").val(),
            Reason: $("#reason").val(),
            Action: $("#action").val(),
            Completed: $("#completed").val(),
            EndDateTime: $("#endDate").val(),
            Outcome: $("#outcome").val()
        };

        $.ajax({
            url: routeURL + '/api/Record/SaveRecordData',
            type: 'POST',
            data: JSON.stringify(requestData),
            contentType: 'application/json',
            success: function (response) {
                if (response.status === 1 || response.status === 2) {
                    $.notify(response.message, "success");
                    onCloseModal();
                }
                else {
                    $.notify(response.message, "error");
                }
            },
            error: function (xhr) {
                $.notify("Error", "error");
            }
        });
    }
}

function checkValidation() {
    var isValid = true;
    if ($("#title").val() === undefined || $("#title").val() === "") {
        isValid = false;
        $("#title").addClass('error');
    }
    else {
        $("#title").removeClass('error');
    }

    if ($("#patientName").val() === undefined || $("#patientName").val() === "") {
        isValid = false;
        $("#patientName").addClass('error');
    }
    else {
        $("#patientName").removeClass('error');
    }

    if ($("#userName").val() === undefined || $("#userName").val() === "") {
        isValid = false;
        $("#userName").addClass('error');
    }
    else {
        $("#userName").removeClass('error');
    }

    if ($("#startDate").val() === undefined || $("#startDate").val() === "") {
        isValid = false;
        $("#startDate").addClass('error');
    }
    else {
        $("#startDate").removeClass('error');
    }

    if ($("#targetDate").val() === undefined || $("#targetDate").val() === "") {
        isValid = false;
        $("#targetDate").addClass('error');
    }
    else {
        $("#targetDate").removeClass('error');
    }

    if ($("#reason").val() === undefined || $("#reason").val() === "") {
        isValid = false;
        $("#reason").addClass('error');
    }
    else {
        $("#reason").removeClass('error');
    }

    if ($("#action").val() === undefined || $("#action").val() === "") {
        isValid = false;
        $("#action").addClass('error');
    }
    else {
        $("#action").removeClass('error');
    }
    return isValid;
}