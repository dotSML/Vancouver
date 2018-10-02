$.getJSON("airportsData.json", function(data){
    var airports = [];
    var i = 0;
    $.each(data, function (key, val){
        if(val.code === '')
        {
            return true;
        }    
        else {
            //delete data[i]['lon'];
            //delete data[i]['lat'];
            //delete data[i]['state'];
            //delete data[i]['woeid'];
            //delete data[i]['tz'];
            //delete data[i]['type'];
            ////delete data[i]['phone'];
            ////delete data[i]['runway_length'];
            ////delete data[i]['elev'];
            ////delete data[i]['icao'];
            ////delete data[i]['direct_flights'];
            ////delete data[i]['carriers'];

            

        airports[i] = [];
            airports[i]['iata'] = val.code;
            airports[i]['city'] = val.city;
            airports[i]['name'] = val.name;
            airports[i]['country'] = val.country;
            i++;
        }

        
        
    });

var options = {
    shouldSort: true,
    threshold: 0.4,
    maxPatternLength: 32,
    keys: [{
        name: 'iata',
        weight: 0.5
    }, {
        name: 'name',
        weight: 0.3
    }, {
        name: 'city',
        weight: 0.2
    }]
};

var fuse = new Fuse(airports, options);
var autoCompleteObject = $('.js_airports_auto_complete');

if (autoCompleteObject.length) {
    var wraps = [];
    var lists = [];
    var wrap_id, list_id;

    $(document).on('mouseup', function (e) {
        var containers = $(".autocomplete-results");

        // if the target of the click isn't the container nor a descendant of the container
        containers.each(function (index, container) {
            container = $(container);
            if (!container.is(e.target) && container.find(e.target).length === 0 && $(e.target)[0] != $(container).parent().find('.js_airports_auto_complete')[0]) {
                clearResults(container, true);
            }
        });
    });

    autoCompleteObject
        .on('click', function (e) {
            e.stopPropagation();
        })
        .on('focus keyup', search)
        .on('keydown', onKeyDown);

    autoCompleteObject.each(function (index, item) {
        item = $(item);

        wrap_id = 'js_autocomplete_wrap_' + index;
        list_id = 'js_autocomplete_list_' + index;

        item.data('wrap_id', wrap_id)
            .data('list_id', list_id);

        wraps[index] = $('<div>')
            .addClass('autocomplete-wrapper')
            .insertBefore(item)
            .append(item)
            .attr('id', wrap_id);

        lists[index] = $('<div>')
            .addClass('autocomplete-results')
            .on('click', '.autocomplete-result', function (e) {
                e.preventDefault();
                e.stopPropagation();
                selectIndex($(this).data('index'), $(this).parent().parent().find('.js_airports_auto_complete'));
            })
            .appendTo(wraps[index])
            .attr('id', list_id);
    });
}

$(document)
    .on('mouseover', '.autocomplete-result', function (e) {
        var index = parseInt($(this).data('index'), 10);
        if (!isNaN(index)) {
            $(this).parent().attr('data-highlight', index);
        }
    });

function clearResults(listObject, forceClear) {
    if (typeof listObject !== typeof undefined) {
        if (typeof forceClear === typeof undefined || !forceClear) {
            results = [];
            numResults = 0;
        }

        listObject.empty();
    }
}

function selectIndex(index, object) {
    if (results.length >= index + 1) {
        var list = $('#' + object.data('list_id'));
        if (index === -1) {
            index = 0;
        }

        if (results[index].hasOwnProperty('iata')) {
            object.val(results[index].iata);
            clearResults(list);
        }
    }
}

var results = [];
var numResults = 0;
var selectedIndex = -1;

function search(e) {
    var list = $('#' + $(this).data('list_id'));

    if (e.which === 38 || e.which === 13 || e.which === 40) {
        return;
    }

    if ($(this).val().length > 0) {
        results = _.take(fuse.search($(this).val()), 7);
        numResults = results.length;

        var divs = results.map(function (r, i) {
            return '<div class="autocomplete-result" data-index="' + i + '">'
                + '<div><b>' + r.iata + '</b> - ' + r.name + '</div>'
                + '<div class="autocomplete-location">' + r.city + ', ' + r.country + '</div>'
                + '</div>';
        });

        selectedIndex = -1;
        list.html(divs.join(''))
            .attr('data-highlight', selectedIndex);

    } else {
        numResults = 0;
        list.empty();
    }
}

function onKeyDown(e) {
    var list = $('#' + $(this).data('list_id'));

    switch (e.which) {
        case 38: // up
            selectedIndex--;
            if (selectedIndex <= -1) {
                selectedIndex = -1;
            }
            list.attr('data-highlight', selectedIndex);
            break;
        case 13: // enter
            selectIndex(selectedIndex, $(this));
            break;
        case 9: // enter
            selectIndex(selectedIndex, $(this));
            e.stopPropagation();
            return;
        case 40: // down
            selectedIndex++;
            if (selectedIndex >= numResults) {
                selectedIndex = numResults - 1;
            }
            list.attr('data-highlight', selectedIndex);
            break;

        default: return; // exit this handler for other keys
    }
    e.stopPropagation();
    e.preventDefault(); // prevent the default action (scroll / move caret)
}

});