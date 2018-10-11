 var activeDetails = null;
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



