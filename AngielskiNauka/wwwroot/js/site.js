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
    document.getElementById("loading").style.display = "block";
}
function generateWavePath() {
    const path = [];
    const amplitude = 30;
    const frequency = 0.04;

    for (let x = 0; x <= 1000; x++) {
        const y = 50 + Math.sin(x * frequency) * amplitude;
        path.push(`${x},${y}`);
    }

    const wave = "M" + path.join(" L");
    document.querySelector('.oscilloscope-wave path').setAttribute('d', wave);
}

function hideLoader() {
    document.getElementById("loading").style.display = "none";
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