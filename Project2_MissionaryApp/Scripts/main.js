$(function () {
    if (getCookie('dark') == "") {
        setCookie('dark', 'off', 7);
    }
    if (getCookie('dark') == 'off') {
        //document.getElementById('bootswatchStyle').setAttribute('href', '/Content/bootstrap.min.css');
        goLight();
        $('#toggleDark').prop('checked', true).change();
    }
    else if (getCookie('dark') == 'on') {
        //document.getElementById('bootswatchStyle').setAttribute('href', '/Content/bootstrap-dark.min.css');
        goDark();
        $('#toggleDark').prop('checked', false).change();
    }
})

$(function () {
    $('#toggleDark').change(function () {
        if ($('#toggleDark').prop('checked')) {
            setCookie('dark', 'off', 7);
            //document.getElementById('bootswatchStyle').setAttribute('href', '/Content/bootstrap.min.css');
            goLight();
        }
        else if (!$('#toggleDark').prop('checked')) {
            setCookie('dark', 'on', 7);
            //document.getElementById('bootswatchStyle').setAttribute('href', '/Content/bootstrap-dark.min.css');
            goDark();
        }
    })
})

function goLight() {
    document.body.style.backgroundColor = 'rgb(256,256,256)';
    document.body.style.color = 'rgb(90,90,90)';
    var jumbo = document.getElementsByClassName('jumbotron');
    for (var i = 0; i < jumbo.length; i++) {
        jumbo[i].style.backgroundColor = 'rgb(256,256,256)';
    }
    var card = document.getElementsByClassName('card');
    for (var i = 0; i < card.length; i++) {
        card[i].style.backgroundColor = 'rgb(256,256,256)';
    }
}

function goDark() {
    document.body.style.backgroundColor = 'rgb(0,0,0)';
    document.body.style.color = 'rgb(0, 128, 255)';
    var jumbo = document.getElementsByClassName('jumbotron');
    for (var i = 0; i < jumbo.length; i++) {
        jumbo[i].style.backgroundColor = 'rgb(0,0,0)';
    }
    var card = document.getElementsByClassName('card');
    for (var i = 0; i < card.length; i++) {
        card[i].style.backgroundColor = 'rgb(0,0,0)';
    }
}

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}