function reply(num) {
    $('#res_' + num).slideDown(400);
}

function cancel(num) {
    $('#res_' + num).slideUp(400);
}

function ShowTools(id) {
    $(id).fadeIn(200);
}

function HideTools(id) {
    $(id).fadeOut(200);
}