
var _serviceBaseURL = "http://service.deploy";

$(document).ready(function (e) {
   
    //  Set manage button themes
    $('.ManageButton').button({
        classes: {
            "ui-button": "ui-corner-all"
        },
        icons: {
            primary: "ui-icon-gear"
        }
    });

    PopulateFitnessClassDropDown();

});

function PopulateFitnessClassDropDown() {

    $.ajax({
        type: "GET",
        url: _serviceBaseURL + "/FitnessClassService/FitnessClass/Collection/",
        contentType: "application/json; charset= utf-8",
        dataType: "json"

    }).done(function (data) {

        var dropDown = $('#drpFitnessClass');

        for (var x = 0; x < data.length; x++) {
            dropDown.append($('<option></option>').val(data[x].FitnessClassId).html(data[x].FitnessClassName));
        }


    }).fail(function (data) {
        DisplayMessage(true, 'There was an error loading the drop down list');

    }).always(function () {

    });
}

function DisplayMessage(showMessage, message) {
    if (showMessage) {
        $('#MessageArea').show();

        $('#MessageAreaList').append('<li>' + message + '</li>');

        $('.AssociateFitnessClassButton').hide();


    }
    else {
        $('#MessageArea').hide();
        $('.AssociateFittnessClassButton').show();
    }
}

