function reply(num) {
    $('#res_' + num).slideDown(400);
}

function submitRes(num) {
    var parent = document.getElementById('replyList_' + num);
    var child = document.createElement('li');
    child.setAttribute('class', 'list-group-item');
    child.innerHTML = document.getElementById('response_' + num).value;
    parent.appendChild(child);

    $('#res_' + num).hide(400, function () {
        $('#thanks_' + num).fadeIn(300, function () {
            document.getElementById('response_' + num).value = "";
            setTimeout(function () {
                $('#thanks_' + num).fadeOut(300);
            }, 2000);
        });
    });
}

function cancel(num) {
    $('#res_' + num).slideUp(400);
    document.getElementById('response_' + num).value = '';
}

function submitQuestion() {
    $('#progDiv').show();
    var i = 0;
    var progress = setInterval(function () {
        i++;
        document.getElementById('quesProg').setAttribute('aria-valuenow', i);
        document.getElementById('quesProg').style.width = i + '%';
        if (i == 100) {
            clearInterval(progress);
        }
    }, 10);
    setTimeout(function () {
        $('#progDiv').hide(0, function () {
            document.getElementById('quesProg').setAttribute('aria-valuenow', 0);
            document.getElementById('quesProg').style.width = '0%';
            $('#successQues').show();
            setTimeout(function () {
                document.getElementById('add_question').value = '';
                $('#successQues').fadeOut(300);
            }, 1000);
        });
    }, 1900);
}