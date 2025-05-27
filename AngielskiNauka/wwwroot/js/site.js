// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function all() {
    alert('aa');
}
function pobierzPDFPoziom(poziom) {
 
    fetch('/api/ang/pdf', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(poziom)
    })
        .then(response => {
            if (!response.ok) throw new Error("Błąd podczas pobierania PDF.");
            return response.blob();
        })
        .then(blob => {
            const url = window.URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.href = url;
            a.download = "fiszki_" + poziom + ".pdf";
            document.body.appendChild(a);
            a.click();
            a.remove();
            window.URL.revokeObjectURL(url);
        })
        .catch(error => {
            console.error("Błąd:", error);
            alert("Nie udało się pobrać fiszek.");
        });
}
function textValue(id) {
    return $("#" + id + "").val()
}
function setValue(id, value) {

    $("#" + id+"").text(value)
}
function load()
{
    window.location.reload();
}
function wait(title) {
    if (title && title.trim() !== "") {
       
        document.getElementById("loadtextid").textContent = title;

    }
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
