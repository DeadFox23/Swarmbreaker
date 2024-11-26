// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


//Defaultmap

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

//index
var index;

function randomIndex(listnum,stats, weapons)
{
    if (listnum == 1)
        index = Math.floor(Math.random() *stats.length);
    else
        index = Math.floor(Math.random() * weapons.length);
    return index;
}
function randomBool()
{
    return Math.floor(Math.random() * 2);
}

document.addEventListener("DOMContentLoaded", function () {
    const openPopupBtn = document.getElementById('openPopupBtn'); // Select the open button
    const popup = document.getElementById('popup'); // Select the popup container
    const popupContent = document.querySelector('.popup-content'); // Select the content area


    openPopupBtn.addEventListener('click', () => {
        // Clear any previous content
        popupContent.innerHTML = "<h2>Level up</h2>"; // Start with a fresh heading

        // Dynamically add content (can be based on server-side data if needed)
        var stats = ["HP", "Damage", "Armor"];
        var weapons = ["Slingshot", "Treegun", "Shotgun", "Pistol", "Bow"];

        for (let i = 0; i < 3; i++) {
            const newButton = document.createElement("button");
            newButton.classList.add("closePopupBtn");
            newButton.setAttribute("data-close", "true");

            if (randomBool() === 1) {
                index = randomIndex(2, stats, weapons);
                newButton.textContent = weapons[index];
                weapons.splice(index, 1);
            }
            else {
                index = randomIndex(1, stats, weapons);
                newButton.textContent = stats[index];
                stats.splice(index, 1);
            }


            popupContent.appendChild(newButton);
        }

        // Show the popup
        popup.style.display = 'flex';

        // Reattach close functionality
        const closePopupBtns = document.querySelectorAll('.closePopupBtn');
        closePopupBtns.forEach(button => {
            button.addEventListener('click', () => {
                popup.style.display = 'none';
            });
        });
    });
});

let timerID = null;
let currentInterval = 2000;

updateTimer();

function enemyPositionAndTimer() {
    $.ajax({
        type: "GET",
        url: '/Index?handler=enemyPositionAndTimer',
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ Timer: currentInterval })
    }).done(function (data) {
            const { positions, nextInterval } = data;
            updateEnemyPosition(positions);
            updateTimer(nextInterval);
    })
}
function updateEnemyPosition(positions) {
    positions.forEach(({ id, top, left }) => {
        const img = document.getElementById(id);
        if (img) {
            img.style.top = `${top} px`;
            img.style.left = `${left}px`;
        }
    });
}
function updateTimer(newInterval) {
    if (timerID) clearInterval(timerID);
    //currentInterval = newInterval;
    timerID = setInterval(enemyPositionAndTimer, currentInterval);
}
