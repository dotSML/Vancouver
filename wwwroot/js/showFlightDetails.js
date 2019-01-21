var activeDetails = null;

$(document).on('ready', function () {
    // Get height of all dds before hide() occurs.  Store height in heightArray, indexed based on the dd's position.
    heightArray = new Array();
    $('.flightResultContainer').each(function (i) {
        theHeight = $(this).height();
        heightArray[i] = theHeight;
    });

    // When a dt is clicked,
    $("dl.v_show_hide dt").click(function () {

        // Based on the dt's position in the dl, retrieve a height from heightArray, and re-assign that height to the sibling dd.
        $(this).next("dd").css({ height: heightArray[$("dl.v_show_hide dt").index(this)] });

        // Toggle the slideVisibility of the dd directly after the clicked dt
        $(this).next("dd").slideToggle("slow")

            // And hide any dds that are siblings of that "just shown" dd.
            .siblings("dd").slideUp("slow");

    });
});

    $(document).on('click', '.flightDetailsButton', function (e) {
        //if (activeDetails)
        //    activeDetails.hide();
        //    activeDetails = $($(this).data('target'));
        //    activeDetails.slideToggle("fast");
        if (activeDetails) {activeDetails.hide();
        }
        if (!activeDetails) {
            activeDetails = $($(this).data('target'));
            activeDetails.slideToggle("fast");
            console.log(activeDetails);
        }
        activeDetails = null;
    });



