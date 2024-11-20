// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Referenzen zu den HTML-Elementen
const openPopupBtn = document.getElementById('openPopupBtn');
const popup = document.getElementById('popup');
const closePopupBtn = document.getElementById('closePopupBtn');

// Funktion, um das Popup zu öffnen
openPopupBtn.addEventListener('click', () => {
    popup.style.display = 'flex';
});

// Funktion, um das Popup zu schließen
closePopupBtn.addEventListener('click', () => {
    popup.style.display = 'none';
});

// Optional: Popup schließen, wenn außerhalb des Popups geklickt wird
window.addEventListener('click', (event) => {
    if (event.target === popup) {
        popup.style.display = 'none';
    }
});

window.onresize = reportWindowSize;
    function reportWindowSize() {
        heightOut.textContent = window.innerHeight;
        widthOut.textContent = window.innerWidth;
}
function tmp() {

    $.ajax({
        type: "GET",
        url: '/Index?handler=Tmp',
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).done(function (data) {
        console.log(data);
    })
}

// Write your JavaScript code.
