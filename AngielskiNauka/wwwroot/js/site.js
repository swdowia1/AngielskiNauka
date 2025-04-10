// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function all() {
    alert('aa');
}

function textValue(id) {
    return $("#" + id + "").val()
}
function setValue(id, value) {
    $("#" + id+"").text(value)
}

function showLoader() {
    const loader = document.getElementById('loadingPanel');
    loader.style.display = 'flex';
    setTimeout(() => {
        loader.classList.add('show');
    }, 10); // małe opóźnienie, żeby triggerować transition
}

function hideLoader() {
    const loader = document.getElementById('loadingPanel');
    loader.classList.remove('show');
    setTimeout(() => {
        loader.style.display = 'none';
    }, 300); // dopasowane do CSS transition (0.3s)
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