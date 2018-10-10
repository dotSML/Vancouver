$('#searchBtn').on("click", function () {
    $('#flightResults').fadeOut();
    $('#errorMessage').hide();
    $('#loading').fadeIn();
    var apiKey = "DAI4hfrkFliQkgA6U4L04yImEuD9g06i";
    var origin = $('#autocompleteDepart').val();
    var destination = $('#autocompleteArrive').val();
    var outboundDate = $('#datepickerOutbound').val();
    var adultPassengers = $('#passengers').val();
    var fareCurrency = $('#fareCurrency').val();
    var fareClass = $('#fareClass').val();
    var numberOfResults = "30";
    outboundDate = outboundDate.replace(/\//g, "-");
    outboundDate = outboundDate.split('-');
    outboundDate = outboundDate[2] + '-' + outboundDate[0] + '-' + outboundDate[1];
    var inboundDate = '';
    if ($('#fareOption').val() === 'ONEWAY') {
        inboundDate = '';
    } else {
        inboundDate = $('#datepickerInbound').val();
    }



    if ($('#datepickerInbound').val() === '') {
        inboundDate = '';
        $('#fareOption').prop(2);
    } else {
        inboundDate = $('#datepickerInbound').val();
        inboundDate = inboundDate.replace(/\//g, "-");
        inboundDate = inboundDate.split("-");
        inboundDate = inboundDate[2] + '-' + inboundDate[0] + '-' + inboundDate[1];
        inboundDate = "&return_date=" + inboundDate;
    }



    var fareRequestUrl =
        "https://api.sandbox.amadeus.com/v1.2/flights/low-fare-search?apikey=" +
        apiKey +
        "&origin=" +
        origin +
        "&destination=" +
        destination +
        "&departure_date=" +
        outboundDate +
        inboundDate +
        "&adults=" +
        adultPassengers +
        "&currency=" +
        fareCurrency +
        "&travel_class=" +
        fareClass +
        "&number_of_results=" +
        numberOfResults;

    $.ajax({
        dataType: "json",
        url: fareRequestUrl,

        success: function (faresData) {
            var results = $('#flightResults');
            var itemsFound = faresData.results;
            var itemsFoundCount = itemsFound.length;
            var htmlRoundTrip = '';
            var htmlOneway = '';
            var layoverStopsSpanOutbound = '';
            var layoverStopsSpanInbound = '';

            var arrivalAirportOutbound,
                originAirportOutbound,
                departureTimeOutbound,
                arrivalTimeOutbound,
                layoverCitiesOutbound,
                airlineOutbound,
                tripDurationOutbound,
                layoverStopAmountOutbound;

            var arrivalAirportInbound,
                originAirportInbound,
                departureTimeInbound,
                arrivalTimeInbound,
                layoverCitiesInbound,
                airlineInbound,
                tripDurationInbound,
                layoverStopAmountInbound;

            var outboundLegAircraft,
                outboundLegDepartureTime,
                outboundLegArrivalTime,
                outboundLegFlightNumber,
                outboundLegMarketingAirline,
                outboundLegTerminal,
                outboundLegTravelClass,
                outboundLegOrigin,
                outboundLegDestination,
                outboundLegOperatingAirline;


            var inboundLegAircraft,
                inboundLegDepartureTime,
                inboundLegArrivalTime,
                inboundLegFlightNumber,
                inboundLegMarketingAirline,
                inboundLegTerminal,
                inboundLegTravelClass,
                inboundLegOrigin,
                inboundLegDestination,
                inboundLegOperatingAirline;


            var i;
            var farePriceTotal;
            var farePricePerPassenger;
            var farePriceTax;

            var flightLegsFoundOutbound = '';
            var flightLegsFoundCountOutbound = '';
            var flightLegsFoundInbound = '';
            var flightLegsFoundInboundCount = '';
            var flightLegsOutboundHtml = '';
            var flightLegsDetailsBtnId = 0;
            var airlineLogoId = 0;
            var airlineLogoApiKey = 'VDjfGgv8mxiTvvLLwGicD6VQhXXtgGND';
            var airlineLogoIcaoOutbound = '';
            var airlineLogoMd5Str = '';
            var airHexApiMd5 = '';
            var airlineLogoRequestUrlOutbound = '';
            var airlineLogoRequestUrlInbound = '';
            var airlineLogoIcaoInbound = '';

            var airlineLogoRequestUrlOutboundLeg = '';
            var airlineLogoRequestUrlInboundLeg = '';
            var airlineLogoIcaoOutboundLeg = '';
            var airlineLogoIcaoInboundLeg = '';

            console.log(faresData.results[0]);

            for (var k = 0; k < itemsFoundCount; ++k) {

                flightLegsFoundOutbound = faresData.results[k]['itineraries'][0]['outbound']['flights'];
                flightLegsFoundCountOutbound = flightLegsFoundOutbound.length;

                for (var l = 0; l < flightLegsFoundCountOutbound; l++) {

                    outboundLegDepartureTime =
                        faresData.results[k]["itineraries"][0]["outbound"]['flights'][l]['departs_at'];
                    outboundLegDepartureTime = outboundLegDepartureTime.split('T');
                    outboundLegDepartureTime = outboundLegDepartureTime[1];

                    outboundLegArrivalTime =
                        faresData.results[k]["itineraries"][0]["outbound"]['flights'][l]['arrives_at'];
                    outboundLegArrivalTime = outboundLegArrivalTime.split('T');
                    outboundLegArrivalTime = outboundLegArrivalTime[1];


                    outboundLegOrigin = faresData.results[k]["itineraries"][0]["outbound"]['flights'][l]['origin']['airport'];
                    outboundLegDestination = faresData.results[k]["itineraries"][0]["outbound"]['flights'][l]['destination']['airport'];
                    outboundLegAircraft = faresData.results[k]["itineraries"][0]["outbound"]['flights'][l]['aircraft'];
                    outboundLegFlightNumber =
                        faresData.results[k]["itineraries"][0]["outbound"]['flights'][l]['flight_number'];
                    outboundLegTravelClass =
                        faresData.results[k]["itineraries"][0]["outbound"]['flights'][l]['booking_info']
                        ['travel_class'];
                    outboundLegMarketingAirline =
                        faresData.results[k]["itineraries"][0]["outbound"]['flights'][l]["marketing_airline"];
                    outboundLegOperatingAirline = faresData.results[k]["itineraries"][0]["outbound"]['flights'][l]["operating_airline"];

                    airlineLogoIcaoOutbound = outboundLegOperatingAirline;
                    airlineLogoMd5Str = airlineLogoIcaoOutbound + '_50_50_s_VDjfGgv8mxiTvvLLwGicD6VQhXXtgGND';

                    airHexApiMd5 = $.MD5(airlineLogoMd5Str);
                    airlineLogoRequestUrlOutboundLeg =
                        'https://content.airhex.com/content/logos/airlines_' + airlineLogoIcaoOutbound + '_50_50_s.png?md5apikey=' + airHexApiMd5;


                    flightLegsOutboundHtml += '<div class="row" style="color: white; height: 7vh;">' +
                        '<div id="outboundLegsInfo">' +
                        '</div>' +
                        '<div id="flightLegInfoAirline" class="col-2 align-self-center">' +
                        '<div style="margin-left: 10px;">' +
                        '<img src=' + '"' + airlineLogoRequestUrlOutboundLeg + '"' + '>' +
                        '</div>' +
                        '</div>' +
                        '<div class="col-1 align-self-center">' +
                        '<span id="flightLegDepartureTime" class="itinerary-time">' +
                        outboundLegDepartureTime +
                        '</span><br/>' +
                        '<span id="flightLegOriginAirport">' +
                        outboundLegOrigin +
                        '</span>' +
                        '</div>' +
                        '<div class="col-1 align-self-center">' +
                        '<div id="flightLegDuration" style="font-size: 13px">' +
                            /*outboundLegDuration*/ 'N/A' + //add duration for individual leg, placeholder for now
                        '</div>' +
                        '</div>' +
                        '<div class="col-1 align-self-center">' +
                        '<span id="flightLegArrivalTime" class="itinerary-time">' +
                        outboundLegArrivalTime +
                        '</span><br/>' +
                        '<span id="flightLegArrivalAirport">' +
                        outboundLegDestination +
                        '</span>' +
                        '</div>' +
                        '<div class="col-1 align-self-center" style="margin-left: 5px;">' +
                        '<span style="font-size: 11px;">' +
                        'Flight No. ' +
                        '</span> <br>' +
                        '<span style="font-weight: bold; font-size: 13px;">' +
                        outboundLegFlightNumber +
                        '</span>' +
                        '</div>' +
                        '<div class="col-1 align-self-center" style="margin-left: 5px;">' +
                        '<span style="font-size: 11px;">' +
                        'Aircraft ' +
                        '</span> <br>' +
                        '<span style="font-weight: bold; font-size: 13px;">' +
                        outboundLegAircraft +
                        '</span>' +
                        '</div>' +
                        '<div class="col-1 align-self-center" style="margin-left: 5px;">' +
                        '<span style="font-size: 11px;">' +
                        'Travel Class' +
                        '</span> <br>' +
                        '<span style="font-weight: bold; font-size: 13px;">' +
                        outboundLegTravelClass +
                        '</span>' +
                        '</div>' +
                        '<div class="col-1 align-self-center">' +
                        '</div>' +
                        '</div>';

                }


                var flightLegsFoundInbound = '';
                var flightLegsFoundCountInbound = '';
                var flightLegsInboundHtml = '';

                if (inboundDate === '') { }
                else {
                    flightLegsFoundInbound = faresData.results[k]['itineraries'][0]['inbound']['flights'];
                    flightLegsFoundCountInbound = flightLegsFoundInbound.length;

                    for (var y = 0; y < flightLegsFoundCountInbound; y++) {

                        inboundLegDepartureTime =
                            faresData.results[k]["itineraries"][0]["inbound"]['flights'][y]['departs_at'];
                        inboundLegDepartureTime = inboundLegDepartureTime.split('T');
                        inboundLegDepartureTime = inboundLegDepartureTime[1];

                        inboundLegArrivalTime =
                            faresData.results[k]["itineraries"][0]["inbound"]['flights'][y]['arrives_at'];
                        inboundLegArrivalTime = inboundLegArrivalTime.split('T');
                        inboundLegArrivalTime = inboundLegArrivalTime[1];


                        inboundLegOrigin = faresData.results[k]["itineraries"][0]["inbound"]['flights'][y]['origin']['airport'];
                        inboundLegDestination = faresData.results[k]["itineraries"][0]["inbound"]['flights'][y]['destination']['airport'];
                        inboundLegAircraft = faresData.results[k]["itineraries"][0]["inbound"]['flights'][y]['aircraft'];
                        inboundLegFlightNumber =
                            faresData.results[k]["itineraries"][0]["inbound"]['flights'][y]['flight_number'];
                        inboundLegTravelClass =
                            faresData.results[k]["itineraries"][0]["inbound"]['flights'][y]['booking_info']
                            ['travel_class'];
                        inboundLegMarketingAirline =
                            faresData.results[k]["itineraries"][0]["inbound"]['flights'][y]["marketing_airline"];
                        inboundLegOperatingAirline = faresData.results[k]["itineraries"][0]["inbound"]['flights'][y]["operating_airline"];

                        airlineLogoIcaoInbound = inboundLegOperatingAirline;
                        airlineLogoMd5Str = airlineLogoIcaoInbound + '_50_50_s_VDjfGgv8mxiTvvLLwGicD6VQhXXtgGND';

                        airHexApiMd5 = $.MD5(airlineLogoMd5Str);
                        airlineLogoRequestUrlInboundLeg =
                            'https://content.airhex.com/content/logos/airlines_' + airlineLogoIcaoInbound + '_50_50_s.png?md5apikey=' + airHexApiMd5;

                        flightLegsInboundHtml += '<div class="row" style="color: white; height: 7vh;">' +
                            '<div id="inboundLegsInfo">' +
                            '</div>' +
                            '<div class="col-2 align-self-center">' +
                            '<div style="margin-left: 10px;">' +
                            '<img src=' + '"' + airlineLogoRequestUrlInboundLeg + '"' + '>' +
                            '</div>' +
                            '</div>' +
                            '<div class="col-1 align-self-center">' +
                            '<span class="itinerary-time">' +
                            inboundLegDepartureTime +
                            '</span><br/>' +
                            '<span id="flightLegOriginAirport">' +
                            inboundLegOrigin +
                            '</span>' +
                            '</div>' +
                            '<div class="col-1 align-self-center">' +
                            '<div id="flightLegDuration" style="font-size: 13px">' +
                            /*inboundLegDuration*/ 'N/A' + //add duration for individual leg, placeholder for now
                            '</div>' +
                            '</div>' +
                            '<div class="col-1 align-self-center">' +
                            '<span id="flightLegArrivalTime" class="itinerary-time">' +
                            inboundLegArrivalTime +
                            '</span><br/>' +
                            '<span id="flightLegArrivalAirport">' +
                            inboundLegDestination +
                            '</span>' +
                            '</div>' +
                            '<div class="col-1 align-self-center" style="margin-left: 5px;">' +
                            '<span style="font-size: 11px;">' +
                            'Flight No. ' +
                            '</span> <br>' +
                            '<span style="font-weight: bold; font-size: 13px;">' +
                            inboundLegFlightNumber +
                            '</span>' +
                            '</div>' +
                            '<div class="col-1 align-self-center" style="margin-left: 5px;">' +
                            '<span style="font-size: 11px;">' +
                            'Aircraft ' +
                            '</span> <br>' +
                            '<span style="font-weight: bold; font-size: 13px;">' +
                            inboundLegAircraft +
                            '</span>' +
                            '</div>' +
                            '<div class="col-1 align-self-center" style="margin-left: 5px;">' +
                            '<span style="font-size: 11px;">' +
                            'Travel Class ' +
                            '</span> <br>' +
                            '<span style="font-weight: bold; font-size: 13px;">' +
                            inboundLegTravelClass +
                            '</span>' +
                            '</div>' +
                            '<div class="col-5 align-self-center"></div>' +
                            '<div class="col-1 align-self-center">' +
                            '</div>' +
                            '</div>';

                    }

                }




                //marketingAirline OUTBOUND
                airlineOutbound =
                    faresData.results[k]['itineraries'][0]['outbound']['flights'][0]['marketing_airline'];

                //itinerary origin and destination OUTBOUND
                originAirportOutbound =
                    faresData.results[k]['itineraries'][0]['outbound']['flights'][0]['origin']['airport'];
                arrivalAirportOutbound =
                    faresData.results[k]['itineraries'][0]['outbound']['flights'][
                    faresData.results[k]['itineraries'][0]['outbound']['flights'].length - 1]['destination'][
                    'airport'];

                //itinerary departure and arrival times OUTBOUND
                departureTimeOutbound =
                    faresData.results[k]['itineraries'][0]['outbound']['flights'][0]['departs_at'].split('T')[1];
                arrivalTimeOutbound =
                    faresData.results[k]['itineraries'][0]['outbound']['flights'][0]['arrives_at'].split('T')[1];

                tripDurationOutbound = faresData.results[k]['itineraries'][0]['outbound']['duration'];
                tripDurationOutbound = tripDurationOutbound.split(':');
                tripDurationOutbound = tripDurationOutbound[0] + 'h ' + tripDurationOutbound[1] + 'm';

                //FarePrice
                farePriceTotal = faresData.results[k]['fare']['total_price'];
                farePricePerPassenger = faresData.results[k]['fare']['price_per_adult']['total_fare'];
                farePriceTax = faresData.results[k]['fare']['price_per_adult']['tax'];

                //add currency symbol
                switch (fareCurrency) {
                    case 'EUR':
                        farePricePerPassenger += "€";
                        farePriceTotal += "€";
                        farePriceTax += "€";
                        break;
                    case 'USD':
                        farePricePerPassenger = "$" + farePricePerPassenger;
                        farePriceTotal = "$" + farePriceTotal;
                        farePriceTax = "$" + farePriceTax;
                        break;
                }

                //correct display of stops OUTBOUND
                layoverStopAmountOutbound =
                    faresData.results[k]['itineraries'][0]['outbound']['flights'].length - 1;
                if (layoverStopAmountOutbound === 0) {
                    layoverStopAmountOutbound = 'DIRECT';
                    layoverStopsSpanOutbound = 'color: green; font-size: 10px;';
                } else {
                    layoverStopsSpanOutbound = 'color:red; font-size: 10px;';
                    if (layoverStopAmountOutbound === 1) {
                        layoverStopAmountOutbound = layoverStopAmountOutbound + ' stop';
                    }
                    else if (layoverStopAmountOutbound > 1) {
                        layoverStopAmountOutbound = layoverStopAmountOutbound + ' stops';
                    }
                }


                //layovers on outbound itinerary OUTBOUND
                layoverCitiesOutbound = '';
                for (i = 0; i < faresData.results[k]['itineraries'][0]['outbound']['flights'].length - 1; i++) {
                    layoverCitiesOutbound += faresData.results[k]['itineraries'][0]["outbound"]['flights'][i][
                        'destination']['airport'] +
                        ', ';
                }
                layoverCitiesOutbound = layoverCitiesOutbound.slice(0, -2);

                if (inboundDate === '') {
                } else {

                    //airline INBOUND
                    airlineInbound =
                        faresData.results[k]['itineraries'][0]['inbound']['flights'][0]['marketing_airline'];

                    //itinerary departure and arrival INBOUND
                    originAirportInbound =
                        faresData.results[k]['itineraries'][0]['inbound']['flights'][0]['origin']['airport'];
                    arrivalAirportInbound =
                        faresData.results[k]['itineraries'][0]["inbound"]['flights'][faresData.results[k]['itineraries'][0]['inbound']['flights'].length - 1]['destination']['airport'];

                    //itinerary departure and arrival time INBOUND
                    departureTimeInbound =
                        faresData.results[k]['itineraries'][0]['inbound']['flights'][0]['departs_at'].split('T')[1];
                    arrivalTimeInbound =
                        faresData.results[k]['itineraries'][0]['inbound']['flights'][0]['arrives_at'].split('T')[1];

                    //itinerary duration INBOUND
                    tripDurationInbound = faresData.results[k]['itineraries'][0]['inbound']['duration'];
                    tripDurationInbound = tripDurationInbound.split(':');
                    tripDurationInbound = tripDurationInbound[0] + 'h ' + tripDurationInbound[1] + 'm';

                    //correct display of stops INBOUND
                    layoverStopAmountInbound = faresData.results[k]['itineraries'][0]['inbound']['flights'].length - 1;
                    if (layoverStopAmountInbound === 0) {
                        layoverStopAmountInbound = 'DIRECT';
                        layoverStopsSpanInbound = 'color: green; font-size: 10px;';
                    } else {
                        layoverStopsSpanInbound = 'color: red; font-size: 10px;';
                        if (layoverStopAmountInbound === 1) {
                            layoverStopAmountInbound = layoverStopAmountInbound + ' stop';
                        }
                        else if (layoverStopAmountInbound > 1) {
                            layoverStopAmountInbound = layoverStopAmountInbound + ' stops';
                        }
                    }

                    //layover stop cities INBOUND
                    layoverCitiesInbound = '';
                    for (i = 0; i < faresData.results[k]['itineraries'][0]['inbound']['flights'].length - 1; i++) {
                        layoverCitiesInbound += faresData.results[k]['itineraries'][0]["inbound"]['flights'][i][
                            'destination']['airport'] +
                            ', ';
                    }
                    layoverCitiesInbound = layoverCitiesInbound.slice(0, -2);

                    //OUTBOUND FULL TRIP Logos
                    airlineLogoIcaoOutbound = airlineOutbound;
                    console.log(airlineLogoIcaoOutbound);
                    airlineLogoMd5Str = airlineLogoIcaoOutbound + '_50_50_s_VDjfGgv8mxiTvvLLwGicD6VQhXXtgGND';

                    airHexApiMd5 = $.MD5(airlineLogoMd5Str);
                    airlineLogoRequestUrlOutbound =
                        'https://content.airhex.com/content/logos/airlines_' + airlineLogoIcaoOutbound + '_50_50_s.png?md5apikey=' + airHexApiMd5;
                    console.log(airlineLogoRequestUrlOutbound);
                    //INBOUND FULL TRIP logos
                    airlineLogoIcaoInbound = airlineInbound;
                    airlineLogoMd5Str = airlineLogoIcaoInbound + '_50_50_s_VDjfGgv8mxiTvvLLwGicD6VQhXXtgGND';

                    airHexApiMd5 = $.MD5(airlineLogoMd5Str);
                    airlineLogoRequestUrlOutbound =
                        'https://content.airhex.com/content/logos/airlines_' + airlineLogoIcaoInbound + '_50_50_s.png?md5apikey=' + airHexApiMd5;

                    console.log(airlineLogoRequestUrlInbound);
                }

                if (inboundDate === '') {
                    htmlOneway += '<div id="flightResults" class="vertical-center" style="margin-top: 25px;">' +
                        '<div class="container acrylic" style="background-color: rgba(0, 0, 0, 0.3); border-radius: 7px;">' +
                        '<div class="row" style="color: white;">' +
                        '<div id="flightInfoAirline" class="col-2 align-self-center">' +
                        airlineOutbound +
                        '</div>' +
                        '<div class="col-1 align-self-center">' +
                        '<span id="flightInfoDepartureTime">' +
                        departureTimeOutbound +
                        '</span><br/>' +
                        '<span id="flightInfoOriginAirport">' +
                        originAirportOutbound +
                        '</span>' +
                        '</div>' +
                        '<div class="col-1 align-self-center">' +
                        '<div id="flightInfoDuration" style="font-size: 13px">' +
                        tripDurationOutbound +
                        '</div>' +
                        '<div style="font-size: 10px;">' +
                        '<span id="flightInfoLayovers" style="' + layoverStopsSpanOutbound + '">' +
                        layoverStopAmountOutbound +
                        '</span>' +
                        '<div id="flightInfoLayoverCities" style="font-weight: bold; font-size: 11px">' +
                        layoverCitiesOutbound +
                        '</div>' +
                        '</div>' +
                        '</div>' +
                        '<div class="col-1 align-self-center">' +
                        '<span id="flightInfoArrivalTime">' +
                        arrivalTimeOutbound +
                        '</span><br/>' +
                        '<span id="flightInfoArrivalAirport">' +
                        arrivalAirportOutbound +
                        '</span>' +
                        '</div>' +
                        '<div class="col-5 align-self-center"></div>' +
                        '<div class="col-1 align-self-center">' +
                        '<button class="btn btn-success" id="flightInfoPriceSpan" style="color:white; left: 50px">' +
                        farePricePerPassenger +
                        '</button>' +
                        '</div>' +
                        '</div>' +
                        '</div>';
                } else {



                    htmlRoundTrip += '<div id="flightResults" class="vertical-center" style="margin-top: 25px;">' +
                        '<div class="container acrylic" style="border-radius: 7px;">' +
                        '<div class="row" style="color: white; border-bottom: dotted; height: 8vh;">' +
                        '<div id="flightInfoAirline" class="col-2 align-self-center">' +
                        '<div style="margin-left: 10px;">' +
                        '<img src=' + '"' + airlineLogoRequestUrlOutbound + '"' + '>' +
                        '</div>' +
                        //airlineOutbound +
                        '</div>' +
                        '<div class="col-2 align-self-center" style="width: 60%">' +
                        '<span id="flightInfoDepartureTime" class="itinerary-time">' +
                        departureTimeOutbound +
                        '</span><br/>' +
                        '<span id="flightInfoOriginAirport" style="font-weight: bold;">' +
                        originAirportOutbound +
                        '</span>' +
                        '</div>' +
                        '<div class="col-2 align-self-center" style="width: 60%;">' +
                        '<div id="flightInfoDuration" style="font-size: 13px">' +
                        tripDurationOutbound +
                        '</div>' +
                        '<div style="font-size: 10px;">' +
                        '<span id="flightInfoLayovers" style="' +
                        layoverStopsSpanOutbound +
                        '">' +
                        layoverStopAmountOutbound +
                        '</span>' +
                        '<div id="flightInfoLayoverCitiesOutbound" style="font-size: 10px; font-weight: bold;">' +
                        layoverCitiesOutbound +
                        '</div>' +
                        '</div>' +
                        '</div>' +
                        '<div class="col-2 align-self-center" style="width: 60%">' +
                        '<span id="flightInfoArrivalTime" class="itinerary-time">' +
                        arrivalTimeOutbound +
                        '</span><br/>' +
                        '<span id="flightInfoArrivalAirport" style="font-weight: bold;">' +
                        arrivalAirportOutbound +
                        '</span>' +
                        '</div>' +
                        '<div class="col-2 align-self-center"></div>' +
                        '<div class="col-1 align-self-center">' +
                        '<button class="btn btn-success" id="flightInfoPriceSpan" style="color:white; left: 50px">' +
                        farePricePerPassenger +
                        '</button>' +
                        '</div>' +
                        '</div>' +
                        '<div id="outboundFlights" class="row" style="color: white; height: 8vh;">' +
                        '<div id="flightInfoAirline" class="col-2 align-self-center">' +
                        //airlineInbound +
                        '<div style="margin-left: 10px">' +
                        '<img src=' + '"' + airlineLogoRequestUrlOutbound + '"' + '>' +
                        '</div>' +
                        '</div>' +
                        '<div class="col-2 align-self-center">' +
                        '<span id="flightInfoDepartureTime" class="itinerary-time">' +
                        departureTimeInbound +
                        '</span><br/>' +
                        '<span id="flightInfoOriginAirport" style="font-weight: bold;">' +
                        originAirportInbound +
                        '</span>' +
                        '</div>' +
                        '<div class="col-2 align-self-center" style="width: 60%">' +
                        '<div id="flightInfoDuration" style="font-size: 13px">' +
                        tripDurationInbound +
                        '</div>' +
                        '<div style="font-size: 10px;">' +
                        '<span id="flightInfoLayovers" style="' +
                        layoverStopsSpanInbound +
                        '">' +
                        layoverStopAmountInbound +
                        '</span>' +
                        '<div id="flightInfoLayoverCitiesInbound" style="font-size: 10px; font-weight: bold;">' +
                        layoverCitiesInbound +
                        '</div>' +
                        '</div>' +
                        '</div>' +
                        '<div class="col-2 align-self-center" style="width: 60%">' +
                        '<span id="flightInfoArrivalTime" class="itinerary-time">' +
                        arrivalTimeInbound +
                        '</span><br/>' +
                        '<span id="flightInfoArrivalAirport" style="font-weight: bold;">' +
                        arrivalAirportInbound +
                        '</span>' +
                        '</div>' +
                        '<div class="col-2 align-self-center"></div>' +
                        '<div class="col-1 align-self-center">' +
                        '<button type="button" class="btn btn-info flightDetailsButton" data-target="#flight-' + flightLegsDetailsBtnId + '" style="color:white; left: 50px">Details</button>' +
                        '</div>' +
                        '</div>' +
                        '<div id="flightDetails">' +
                        '<div id="flight-' + flightLegsDetailsBtnId + '" class="flightDetailsClass" style="display: none;">' +
                        '<div class="row" style="border-bottom: solid 1px white; height: 15px;">' +
                        '<div class="col align-self-center" style="font-size: 10px; color: white;">' +
                        'Outbound flights' +
                        '</div>' +
                        '</div>' +
                        flightLegsOutboundHtml +
                        '<div class="row" style="border-bottom: solid 1px white; height: 15px;">' +
                        '<div class="col align-self-center" style="font-size: 10px; color: white;">' +
                        'Inbound flights' +
                        '</div>' +
                        '</div>' +
                        flightLegsInboundHtml +
                        '<div class="row" style="color: white; border-top: dotted;">' +
                        '<div id="farePriceDetailsTotal" class="col-3 align self-center" style="font-size: 11px;">' +
                        'Total price for all passengers: <span style="color: green; font-size: 12px">' +
                        farePriceTotal +
                        '</span>' +
                        '</div>' +
                        '<div id="farePriceDetailsPP" class="col-3 align self-center" style="font-size: 11px;">' +
                        'Price per passenger: <span style="color: green; font-size: 12px">' +
                        farePricePerPassenger +
                        '</span>' +
                        '</div>' +
                        '<div id="farePriceDetailsPPtax" class="col-3 align self-center" style="font-size: 11px;">' +
                        'Tax per passenger: ' +
                        '<span style="color: green; font-size: 12px">' +
                        farePriceTax +
                        '</span>' +
                        '</div>' +
                        '</div>' +
                        '</div>' +
                        //flightLegsOutboundHtml +
                        '</div>' +
                        '</div>';

                    airlineLogoId++;
                    flightLegsDetailsBtnId++;
                    flightLegsOutboundHtml = '';
                    flightLegsInboundHtml = '';
                }




            }

            if (inboundDate === '') {
                results.html(htmlOneway);
            } else {
                results.html(htmlRoundTrip);
            }



            $('#loading').hide();
            $('#flightResults').fadeIn();
        },
        error: function () {
            $('#errorMessage').fadeIn();
            $('#loading').hide();
        }
    });

});