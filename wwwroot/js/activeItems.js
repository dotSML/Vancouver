$(document).ready(function () {
    var pathName = window.location.pathname;
    console.log($('#aboutActive'));

    if (pathName === "/about") {
    }

    switch (pathName) {
    case '/about':
        $(document).remove('active');
        $('#aboutNav').addClass('active');
        break;
    case '/index':
        $(document).remove('active');
        $('#indexNav').addClass('active');
        break;
    case '/tickettest':
        $(document).remove('active');
        $('#myTicketsNav').addClass('active');
        break;
    case '/MyAccount':
        $(document).remove('active');
        $('#myAccountNav').addClass('active');
        break;
    }
});