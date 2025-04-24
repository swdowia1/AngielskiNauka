let confirmCallback = null;

function showGlobalConfirmModal(callback, customMessage = null) {
    confirmCallback = callback;

    if (customMessage) {
        $('#globalConfirmModal .modal-body').text(customMessage);
    } else {
        $('#globalConfirmModal .modal-body').text('Czy na pewno chcesz wykonać tę akcję?');
    }

    $('#globalConfirmModal').modal('show');
}
//$('#confirmModalOkBtn').on('click', function () {
//    alert('aaa');
//    if (typeof confirmCallback === 'function') {
//        confirmCallback();
//    }
//    $('#globalConfirmModal').modal('hide');
//});
$(document).on('click', '#confirmModalOkBtn', function () {

    if (typeof confirmCallback === 'function') {
        confirmCallback();
    }
    $('#globalConfirmModal').modal('hide');
});
function all() {
    alert('aa');
}

function textValue(id) {
    return $("#" + id + "").val()
}
function setValue(id, value) {
    $("#" + id + "").text(value)
}


postjson = function (n, t, i, r, u) {

    return $.ajax({

        url: n,

        type: "POST",

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        success: i,

        complete: u,

        error: r,

        data: JSON.stringify(t)

    })

};

getjson = function (n, t, i, r) {

    return $.ajax({

        url: n,

        type: "GET",

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        success: t,

        complete: r,

        error: i

    })

};

deletejson = function (n, t, i, r) {

    return $.ajax({

        url: n,

        type: "DELETE",

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        success: t,

        complete: r,

        error: i

    })

};

gethtml = function (n, t, i, r) {

    return $.ajax({

        url: n,

        type: "GET",

        success: t,

        complete: r,

        error: i

    })

};

postdata = function (n, t, i, r, u) {

    return $.ajax({

        url: n,

        type: "POST",

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        success: r,

        complete: i,

        error: u,

        data: JSON.stringify(t)

    })

};