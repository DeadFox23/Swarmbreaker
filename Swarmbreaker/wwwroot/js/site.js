﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


//Defaultmap

window.addEventListener('resize', reportWindowSize);
function reportWindowSize() {
    $.ajax({
        type: "GET",
        url: '/DefaultMap?handler=Data',
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },

        data: { Height: window.innerHeight, Width: window.innerWidth },
        success:
            function (data) {
            console.log(data);
            console.log("hi");
        }
    })
}

//index
var index;
var upgrades;

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

function addHP() { statBaseHP + 1; }
function addDamage() { statBonusAttack + 1; }
function addArmor() { statBonusArmor + 1; }




document.addEventListener("DOMContentLoaded", function () {
    const openPopupBtn = document.getElementById('openPopupBtn'); // Select the open button
    const popup = document.getElementById('popup'); // Select the popup container
    const popupContent = document.querySelector('.popup-content'); // Select the content area


    openPopupBtn.addEventListener('click', () => {

        popupContent.innerHTML = "<h2>Level up</h2>"; 

        var stats = ["HP", "Damage", "Armor"];
        var weapons = ["Slingshot", "Tree", "Shotgun", "Knife", "Bow", "Axe"];

        for (let i = 0; i < 3; i++) {
            const newButton = document.createElement("button");
            newButton.classList.add("closePopupBtn");
            newButton.setAttribute("data-close", "true");
            

            if (randomBool() == 1) {
                index = randomIndex(2, stats, weapons);
                newButton.textContent = weapons[index];
                newButton.id = weapons[index];
                weapons.splice(index, 1);
            }
            else {
                index = randomIndex(1, stats, weapons);
                newButton.textContent = stats[index];
                newButton.id = stats[index];
                stats.splice(index, 1);
            }

            newButton.onclick = function () { btnClick_Click(newButton.id) };
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
}

function action(ButtonID) {
    $.ajax({
        type: "GET",
        url: '/DefaultMap?handler=Action',
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: { action: ButtonID },
        success: function (response) {
        },
        failure: function (response) {

            alert(response);
        }
    })
}
    




function btnClick_Click(ButtonID) {
    

    action(ButtonID)

//    let action = "";
//    switch (ButtonID) {
//        case "Speed":
//            action = "increaseSpeed()";
//            break;
//        case "HP":
//            action = "increaseHP()";
//            break;
//        case "Damage":
//            action = "increaseAttack()";
//            break;
//        case "Armor":
//            action = "increaseArmor()";
//            break;
//        case "Attackspeed":
//            action = "increaseAttackSpeed()";
//            break;

//        case "Slingshot":
//            action = "addWeapon(\"Slingshot\", \"Slingshot\", 1.3, 15, 3, 100, 1)";
//            break;
//        case "Tree":
//            action = "addWeapon(\"Tree\", \"Tree\", 1.5, 20, 1, 40, 0)";
//            break;
//        case "Shotgun":
//            action = "addWeapon(\"Shotgun\", \"Shotgun\", 1.2, 5, 3, 75, 3)";
//            break;
//        case "Knife":
//            action = "addWeapon(\"Knife\", \"Knife\", 0.7, 9, 2, 25, 0)";
//            break;
//        case "Bow":
//            action = "addWeapon(\"Bow\", \"Bow\", 1, 11, 3, 150, 1)";
//            break;
//        case "Axe":
//            action = "addWeapon(\"Axe\", \"Axe\", 0.9, 10, 1, 30, 0)";
//            break;
//    }
//    sendPlayerStats(action);

//    /*Ajax here*/

//    function sendPlayerStats(action) {
//        $.ajax({
//            type: "GET",
//            url: '/Index?handler=PlayerStats',
//            beforeSend: function (xhr) {
//                xhr.setRequestHeader("XSRF-TOKEN",
//                    $('input:hidden[name="__RequestVerificationToken"]').val());
//                console.log(JSON.stringify({ action }));
//            },
//            contentType: "application/json; charset=utf-8",
//            dataType: "json",
//            data: JSON.stringify({ action }),
//            success:
//                function (data) {
//                    console.log(data)
//                }
//        })
//    }
}

//Settings
function openSettings() {
    document.getElementById('openSettings').style.display = "flex";
}

function closeSettings() {
    document.getElementById('openSettings').style.display = "none";
}

//Credits
function openCredits() {
    document.getElementById('creditsModal').style.display = "flex";
}

function closeCredits() {
    document.getElementById('creditsModal').style.display = "none";
}



//VolumeSlider
//const music = document.getElementById('backgroundMusic');
//const volumeSlider = document.getElementById('volumeSlider');
//volumeSlider.addEventListener('input', (event) => {
//    music.volume = event.target.value;
//});


updateTimer();

function enemyPosition() {
    $.ajax({
        type: "GET",
        url: '/DefaultMap?handler=Enemy',
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {baum : 'hi'},
        success:
            function (data) {
                const { positions, nextInterval } = data;
                console.log(data);
                //if (data.isMatch(/positions/))
                //updateEnemyPosition(positions);
                //updateTimer(nextInterval);
            }
    })
}
function updateEnemyPosition(positions) {
    positions.forEach(({ id, top, left }) => {
        const img = document.getElementById(id);
        if (img) {
            img.style.top = `${top}px`;
            img.style.left = `${left}px`;
        }
    });
}
let timerID = null;
let currentInterval = setInterval(updateTimer, 2000);
function updateTimer() {
    enemyPosition();
}
