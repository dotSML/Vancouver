$(document).on('click', '#addByReferenceBtn', function () {
    $('#itinerarySearchLoggedIn').slideToggle('fast');
});
var clickCount;
$(document).ready(function () {
    clickCount = 0;
})

$(document).on('click', '.showTicketsBtn', function () {
    if (clickCount = 0) {
        $(this).text('Close Details');
        var data = $($(this).data('target'));
        data.slideToggle('fast');
        clickCount = 1;

    } else if (clickCount = 1) {
        $(this).text('Details');
        var data = $($(this).data('target'));
        data.slideToggle('fast');
        clickCount = 0;
    }

    clickCount = 1;
});

$(document).on('click', '.toggleBoardingPasses', function () {
    console.log("clicked");
    var data = $($(this).data('target'));
    console.log(data);
    data.slideToggle('fast');
});

$(document).on('click', '.togglePass', function () {
    var data = $($(this).data('target'));
    console.log(data);
    data.slideToggle('fast');
});

$(document).on('click', function () {
    $(document).each('.boardingPass').hide();
})


