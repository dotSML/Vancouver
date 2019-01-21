$(window).scroll(function (event) {
    var scrollPosition = $(window).scrollTop();

    if (scrollPosition > 95) {
        $('#searchBar').removeClass('flightSearchBox');
        $('#searchBar').addClass('fixedFlightSearchBox');
        $('#flightResults').addClass('pushFlightResultsDown');
        $('#flightResults').addClass('vertical-center');
    } else {
        $('#searchBar').removeClass('fixedFlightSearchBox');
        $('#searchBar').addClass('flightSearchBox');
        $('#flightResults').removeClass('pushFlightResultsDown');
    }
});


$(document).ready(function () {
    $('#searchBar').fadeIn();

    $('#fareOption').click(function selectChangedDatepicker() {
        if ($('#fareOption').val() === "One Way") {
            $('#datepickerInbound').val('');
            $('#datepickerInbound').attr('disabled', true);
        } else {
            $('#datepickerInbound').attr('disabled', false);
        }
    });

    $('#aspSearchBtn').on('click',
        function () {

            //if ($('#datepickerInbound').val('')) {
            //    $('#fareOption').val('One Way');
            //    $('#fareOption').change();
            //    $('#datepickerInbound').attr('disabled', true);
            //    $('#aspValidation').fadeOut();
            //    $('#flightResults').fadeOut();
            //    $('#loading').fadeIn();
            //} else {}
            $('#aspValidation').fadeOut();
            $('#flightResults').fadeOut();
            $('#loading').fadeIn();


        });

    var nowDate = new Date();
    var today = new Date(nowDate.getFullYear(), nowDate.getMonth(), nowDate.getDate(), 0, 0, 0, 0);

    $('#js_daterange').datepicker({
        startDate: today,
        format: 'yyyy-mm-dd',
        autoClose: true
    });
});
