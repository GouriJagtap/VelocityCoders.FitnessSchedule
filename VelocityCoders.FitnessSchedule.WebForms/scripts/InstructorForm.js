$(document).ready(function (e) {
    //When page loads - set focus in the first name textbox
    $('.ValidateFirstName').focus();

    //Attach event handler to save button

    $('.SaveButton').click(function () {
        return ValidateInstructor();
    });

   

    //Set datepicker by class name
    $('.ValidateDate').datepicker();

});
//Attach event handler to save button
$('.SaveButton').click(function () {
    return ValidateInstructor();
});


function isDate(txtDate) {
    var currVal = txtDate;
    if (currVal == '')
        return false;

    //Declare Regex  
    var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
    var dtArray = currVal.match(rxDatePattern); // is format OK?

    if (dtArray == null)
        return false;

    //Checks for mm/dd/yyyy format.
    dtMonth = dtArray[1];
    dtDay = dtArray[3];
    dtYear = dtArray[5];

    if (dtMonth < 1 || dtMonth > 12)
        return false;
    else if (dtDay < 1 || dtDay > 31)
        return false;
    else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31)
        return false;
    else if (dtMonth == 2) {
        var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
        if (dtDay > 29 || (dtDay == 29 && !isleap))
            return false;
    }
    return true;
}

function ValidateInstructor() {
    var returnValue = true;
    var nonDateValid = true;

    //Validate LastName

    if ($('.ValidateLastName').val().trim().length <= 0) {
        $('#ValidationMessageLastName').show();
        returnValue = false;
        nonDateValid = false;

        $('.ValidateLastName').focus();
    } else {
        $('#ValidationMessageLastName').hide();
    }


    //Validate FirstName

    if ($('.ValidateFirstName').val().trim().length <= 0) {
        $('#ValidationMessageFirstName').show();
        returnValue = false;
        nonDateValid = false;

        $('.ValidateFirstName').focus();

    } else {
        $('#ValidationMessageFirstName').hide();
    }

   

    //Iterate through all date validate fields 

    var dateFieldObject;

    

    $('.ValidateDate').each(function (index) {
        if ($(this).val().trim().length > 0) {

           

            //Has value - check for valid date
            if (isDate($(this).val())) {

                $('#' + $(this).data('validationMessageId')).hide();

            }
            else {
                

                $('#' + $(this).data('validationMessageId')).show();
                // Set focus to first date field only if required 
                // fields validation failed
                if (nonDateValid) {
                    if (dateFieldObject == undefined) {
                        dateFieldObject = $(this);
                        $(this).focus();
                    }
                }
                returnValue = false;
            }
        }
        else {
            $('#' + $(this).data('validationMessageId')).hide();
        }
    });

    return returnValue;


}
