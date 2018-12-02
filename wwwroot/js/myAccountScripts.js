var active = 0;
$(document).on('click',
    '.editTraveler',
    function () {
        if (active === 0) {
            var data = $($(this).data('target'));
            $('.travelerCardData').each(function () {
                var t = $(this).text();
                $(this).html($('<input class="form-control" value=' + t + ' />', { 'value': t }));
                active = 1;
            });
        }
        else if (active === 1) {
            var data = $($(this).data('target'));
            console.log(data);
            $('.travelerCardData').each(function () {
                var inp = $(this).find('input');
                if (inp.length) {
                    $(this).text(inp.val());
                    active = 0;
                }

            });
        }
    });

function closeEdit() {
    var data = $($(this).data('target'));
    console.log(data);
    $('.travelerCardData').each(function() {
        var inp = $(this).find('input');
        if (inp.length) {
            $(this).text(inp.val());
            active = 0;
        }

    });
}

$(document).on('click',
    '.saveTraveler',
    function () {
        var myElement = $($(this).data('target'));
        closeEdit(myElement);
        var travelerId = myElement.find('.travelerId').text();
        var travelerUser = myElement.find('.travelerUser').text();
        var travelerFirst = myElement.find('.travelerFirstName').text();
        var travelerLast = myElement.find('.travelerLastName').text();
        var travelerDob = myElement.find('.travelerDob').text();
        var travelerEmail = myElement.find('.travelerEmail').text();

        var passportNo = myElement.find('.passportNo').text();
        var passportDob = myElement.find('.passportDob').text();
        var passportIssue = myElement.find('.passportIssue').text();
        var passportExpiry = myElement.find('.passportExpiry').text();


        var postDataCustomer = {
            CustomerId: travelerId,
            ApplicationUserId: travelerUser,
            FirstName: travelerFirst,
            LastName: travelerLast,
            DateOfBirth: travelerDob,
            Email: travelerEmail,
            Passport: {
                PassportNumber: passportNo,
                DateOfBirth: passportDob,
                ValidFrom: passportIssue,
                ValidTo: passportExpiry

            }
        };



        $.ajax({
            type: "POST",
            url: "/MyAccount?handler=UpdateTraveler",
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify(postDataCustomer),
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            success: function (response) {
                
            },
            failure: function(response) {
                alert("Something went wrong...");
            }

        });
    });

$(document).on('click',
    '.closeTravelerCard', function () {
        var data = $($(this).data('target'));
        console.log(data);
        data.hide();
    });

$(document).on('click',
    '.openTravelerCard',
    function () {
        var data = $($(this).data('target'));
        data.slideToggle("fast");
    });


var i = 0;
var a = 0;
$('#addTraveler').on('click',
    function () {
        if (a === 0) {
            $('#addTraveler').html('Close').removeClass('btn-primary').addClass('btn-danger');
            $('.travelerForm').slideToggle("fast");
            a = 1;
        }
        else if (a === 1) {
            $('#addTraveler').html('Add Traveler').removeClass('btn-danger').addClass('btn-primary');
            $('.travelerForm').slideToggle("fast");
            a = 0;
        }
    });

$('.passportBtn').on('click',
    function () {
        if (i === 0) {
            $('.passportBtn').html('Close Passport').removeClass('btn-primary').addClass('btn-danger');
            $('.passportForm').slideToggle("fast");
            i = 1;
        }
        else if (i === 1) {
            $('.passportBtn').html('Add Passport').removeClass('btn-danger').addClass('btn-primary');
            $('.passportForm').slideToggle("fast");
            i = 0;
        }

    });

document.querySelector("html").classList.add('js');

var fileInput = document.querySelector(".input-file"),
    button = document.querySelector(".input-file-trigger"),
    the_return = document.querySelector(".file-return");

button.addEventListener("keydown", function (event) {
    if (event.keyCode === 13 || event.keyCode === 32) {
        fileInput.focus();
    }
});
button.addEventListener("click", function (event) {
    fileInput.focus();
    return false;
});
fileInput.addEventListener("change", function (event) {
    the_return.innerHTML = this.value;
    document.getElementById('submitImage').disabled = false;
    document.getElementById('submitImage').style.display = "inline";
});  


