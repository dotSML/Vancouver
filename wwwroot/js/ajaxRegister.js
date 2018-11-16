$('#registerSubmit').on('click', function () {
    $('#ajaxRegisterError').hide();
    var userFirstName = $('#signup-firstName').val();
    var userLastName = $('#signup-lastName').val();
    var userEmail = $('#signup-email').val();
    var userPassword = $('#signup-password').val();
    var inputDob = new Date($('#signup-dateofbirth').val());
    var day = inputDob.getDate();
    var month = inputDob.getMonth() + 1;
    var year = inputDob.getFullYear();
    var userDayOfBirth = day + "/" + month + "/" + year;
    var userAcceptTerms = $('#accept-terms').val();


    var userObject = new Object();
    userObject.InputEmail = userEmail;
    userObject.InputPassword = userPassword;
    userObject.InputDateOfBirth = userDayOfBirth;
    userObject.InputFirstName = userFirstName;
    userObject.InputLastName = userLastName;
    userObject.InputAcceptTerms = userAcceptTerms;

    var userJson = JSON.stringify(userObject);

    console.log(userJson);
    $.ajax({
        type: 'POST',
        async: true,
        url: '/Identity/Account/Register?handler=AjaxRegister',
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: userJson,
        contentType: "application/json",
        success: function (response) {
            if (response === "Register Success!") {
                console.log("Success!");
                location.href = window.location.pathname;
            }
            if (response === "Register failed!") {
                console.log(response);
                $('#ajaxRegisterError').show();
            }
        }
    });
});