﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


//// Referenzen zu den HTML-Elementen
//const openPopupBtn = document.getElementById('openPopupBtn');
//const popup = document.getElementById('popup');
//const closePopupBtn = document.querySelectorAll('.closePopupBtn');

//// Funktion, um das Popup zu öffnen
//openPopupBtn.addEventListener('click', () => {
//    popup.style.display = 'flex';
//});

//// Funktion, um das Popup zu schließen
//closePopupBtn.forEach(button => {
//    button.addEventListener('click', () => {
//        popup.style.display = 'none';
//    });
//});

window.addEventListener('resize', reportWindowSize);
function reportWindowSize() {
    $.ajax({
        type: "GET",
        url: '/Index?handler=WindowSize',
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ Height: window.innerHeight, Width: window.innerWidth })
    }).done(function (data) {
        console.log(data);
        console.log("hi");
    })
}

// Write your JavaScript code.
