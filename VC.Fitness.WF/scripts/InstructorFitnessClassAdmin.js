
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

    //Display Instructor name and set hidden field
    SetInstructorInfo();

    //Populate drop down
    PopulateFitnessClassDropDown();

    //Display list of fitness classes
    DisplayFitnessClassList();


});
function AddToDisplayTable(instructorFitnessClassId, fitnessClassName) {
    // Get table by Id
   
    var table = $('#FitnessClassTable');

    table.append('<tr><td class="CenterText"><button class="DeleteButton" value="'+instructorFitnessClassId +'">Delete</button></td><td>' + fitnessClassName + '</td></tr>');
}

function SetDeleteButtonProperties() {
    // Add button ui style
    $('.DeleteButton').button({
        classes: {
            "ui-button": "ui-corner-all"
        },
        icons: {
            primary: "ui-icon-trash"
        }
    });

    //Delete button event
    $('.DeleteButton').click(function (e) {
        // Get the Id value to use for delete functionality
        var instructorFitnessClassId = $(this).val();
        var trElement = $(this).closest('tr');

        //Add code to call web service to delete
        DeleteInstructorFitnessClass(instructorFitnessClassId);

        // prevent default submission when clicking button
        e.preventDefault();
    })
}

function DisplayFitnessClassList() {
    //Get the value of the Id from the hidden input field
    var instructorId = $('#InstructorId').val();
   
    $.ajax({
        type: "GET",
        url: _serviceBaseURL + "/FitnessClassService/FitnessClass/Collection/Instructor/" + instructorId,
        contentType: "application/json; charset=utf-8",
        dataType:"json"
    }).done(function (data) {
        //do on success of ajax call
        for (var x = 0; x < data.length; x++) {
            AddToDisplayTable(data[x].InstructorFitnessClassId, data[x].FitnessClassName);
        }
        //set the ui display and event handler for the delete button
        SetDeleteButtonProperties();

    }).fail(function(data) {
    //Show message to user on fail
    DisplayMessage(true, 'There was an error loading the Fitness Class List' , true);

    }).always(function() {
        //finally block-always gets run
    });
}

function SetInstructorInfo() {

    //get the value of the Id from the hidden field
    var instructorId = $('#InstructorId').val();
    if (instructorId > 0) {
        //AJAX web service call

        $.ajax({
            type: "GET",
            url: _serviceBaseURL + "/InstructorService/Instructor/Item/" + instructorId,
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (data) {
            //do on success of AJAX call
            $('#InstructorName').html(data.FirstName + ' ' + data.LastName);

        }).fail(function (data) {
            //show message to user on fail

            DisplayMessage(true, 'There was an error retrieving the Instructor');
        });

    }
    else
        DisplayMessage(true, 'Instructor Id can not be resolved. Please contact the administrator');

}

function ValidateClientForm() {

    var dropDown = $('#drpFitnessClass');
    var instructorId = $('#InstructorId').val();
    var fitnessClassId = dropDown.val();

    if (fitnessClassId > 0) {
        //Valid fitness Id
        $.ajax({
            type: "PUT",
            url: _serviceBaseURL + "/InstructorService/Item/AddFitnessClass/" + instructorId,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: '"'+fitnessClassId+'"',

        }).done(function (data) {
            var fitnessClassName = dropDown.children(':selected').text();

            // Success - Display message
            DisplayMessage(true, "Fitness Class" + fitnessClassName + "associated successfully.", true, true);

          //Call function to append a record to the table
           AddToDisplayTable(data, fitnessClassName);

                //Set the ui display and event handler for the delete buttons
                SetDeleteButtonProperties();

            }).fail(function(jqXHR, textStatus){
                DisplayMessage(true, "There was an error with your submission", true);
            });
        }
        else{
         DisplayMessage(true,"Please select a valid item from the Fitness Class drop down", true);
             }
     return false;
}

function DeleteInstructorFitnessClass(instructorFitnessClassId, trElement) {
    if (instructorFitnessClassId > 0) {
        if (confirm('Are you sure you want to Delete this Fitness Class?')) {
            $.ajax({
                type: "DELETE",
                url: _serviceBaseURL + "/InstructorService/Instructor/Item/DeleteFitnessClass/" + instructorFitnessClassId,
                contentType: "application/json; charset= utf-8",
                dataType: "json",
                data: '"'+instructorFitnessClassId+'"'
                
            }).done(function (data) {
               trElement.fadeOut();
               alert('Here');
            }).fail(function (jqXHR, textStatus) {
                DisplayMessage(true, "FitnessClass deletion failed", true, true);
            });
        }
    }
    else
        DisplayMessage(true, 'Deletion of Fitness Class failed. Invalid Id: ' + instructorFitnessClassId, true, true);
}

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

function DisplayMessage(showMessage, message, showButton) {
    if (showMessage) {
        // Clear any current messages

        if(clearCurrentMessages)
            $('#MessageAreaList').empty();

        $('#MessageArea').show();

        $('#MessageAreaList').append('<li>' + message + '</li>');

        //hide the associate fitness class button

        if(showButton)
            $('.AssociateFitnessClassButton').show();
        else
        $('.AssociateFitnessClassButton').hide();


    }
    else {
        $('#MessageArea').hide();
        $('.AssociateFittnessClassButton').show();
    }
}

