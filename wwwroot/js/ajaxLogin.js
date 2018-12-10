$('#loginSubmit').on('click', function () {
    $('#ajaxLoginLoading').show();
    $('#ajaxLoginError').hide();
    var userUsername = $('#signin-username').val();
    var userPassword = $('#signin-password').val();
    var userRemember = $('#remember-me').val();
    var userObject = new Object();
    userObject.InputUsername = userUsername;
    userObject.InputPassword = userPassword;
    userObject.InputRemember = userRemember;

    var userJson = JSON.stringify(userObject);

    console.log(userJson);

    $.ajax({
        type: 'POST',
        async: true,
        url: '/Identity/Account/Login?handler=AjaxLogin',
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: userJson,
        contentType: "application/json",
        
        success: function (response) {
            //$('#ajaxLoginLoading').hide();
            if (response === "Login Success!") {
                console.log("Success!");
                location.href = window.location.pathname;
            }
            if (response === "Invalid Credentials.") {
                $('#ajaxLoginLoading').hide();
                $('#ajaxLoginError').show();
            }
        }
    });
});

