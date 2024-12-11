// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


//Defaultmap

window.addEventListener('resize', reportWindowSize);
function reportWindowSize() {
    $.ajax({
        type: "GET",
        url: '/DefaultMap?handler=Window',
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },

        data: { Height: window.innerHeight, Width: window.innerWidth },
        success:
            function (data) {
        }
    })
}

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

document.addEventListener("DOMContentLoaded", generatePopUp);
function generatePopUp() {
    const openPopupBtn = document.getElementById('openLevelUp'); // Select the open button
    const popup = document.getElementById('levelUp'); // Select the popup container
    const popupContent = document.querySelector('.levelUp-content'); // Select the content area


    openPopupBtn.addEventListener('click', () => {

        popupContent.innerHTML = "<h2>Level up</h2>";
        //Weapons and stats
        var stats = ["Speed", "HP", "Damage", "Armor", "Attackspeed"];

        var weapons = ["Slingshot", "Tree", "Shotgun", "Knife", "Axe"];


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

function btnClick_Click(ButtonID) { action(ButtonID) }
function action(ButtonID) {
        $.ajax({
            type: "GET",
            url: '/DefaultMap?handler=Button',
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            data: { action: ButtonID },
            success: function (response) {},
            failure: function (response) {alert(response);}
        })
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




function enemyPosition() {
    $.ajax({
        type: "GET",
        url: '/DefaultMap?handler=Enemy',
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: {baum : "baum"},
        success:
            function (data) {
                updateEnemyPosition(data);
            }
    })
}
function updateEnemyPosition(data) {
    const response = JSON.parse(data.result);
    const enemies = response;
    //console.log(enemies);
    for(let i = 0; i <= enemies.length; i++) {
        const element = document.getElementById(`enemy_${i}`);
                if (element) {
                    element.style.left = `${enemies[i].x}px`;  
                    element.style.top = `${enemies[i].y}px`;
                    //console.log(element);
        }
        //console.log(enemy);
    }
}

window.addEventListener('load', function () {
    let currentInterval = setInterval(updateTimer, 50);
})


function updateTimer() {
    enemyPosition();
}


