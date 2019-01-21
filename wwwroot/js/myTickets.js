$(document).on('click', '#addByReferenceBtn', function () {
    $('#itinerarySearchLoggedIn').slideToggle('fast');
    if ($(this).text() == "Add trip") {
        $(this).text("Close");
    }
    else {
        $(this).text("Add trip");
    }
});

$(document).on('click', '.showTicketsBtn', function () {
    var data = $($(this).data('target'));
    data.slideToggle('fast');
    console.log("details clicked");
    if ($(this).text() == "Details") {
        $(this).text("Close Details");
        $(this).css('background-color', '#1405a8');
    }
    else {
        $(this).text("Details");
        $(this).css('background-color', '#CA508B');
    }
});

$(document).on('click', '.toggleBoardingPasses', function (e) {
    console.log("clicked");
    var data = $($(this).data('target'));
    console.log(data);
    data.slideToggle('fast');
    if ($(this).text() == "Boarding passes") {
        console.log($(this).text());
        $(this).text("Close passes");
        $(this).css('background-color', '#1405a8');
    }
    else {
        console.log("Else if");
        $(this).text("Boarding passes");
        $(this).css('background-color', '#CA508B');
    }

});

$(document).on('click', '.togglePass', function () {
    var data = $($(this).data('target'));
    console.log(data);
    data.slideToggle('fast');
    if ($(this).text() == "Details") {
        $(this).text("Close Details")
    }
    else {
        $(this).text("Details");
    }
});

//$(document).on('click', function () {
//    $(document).each('.boardingPass').hide();
//})


