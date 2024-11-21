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
        var buttons;
        upgrades = [];

        for (let i = 0; i < 3; i++) {
            const newButton = document.createElement("button");
            newButton.classList.add("closePopupBtn");
            newButton.setAttribute("data-close", "true");

            if (randomBool() === 1) {
                index = randomIndex(2, stats, weapons);
                newButton.textContent = weapons[index];
                switch (newButtontextContent) {
                    case "Slingshot":
                        upgrades.push(addSlingshot());
                        break;
                    case "Tree":
                        upgrades.push(addTree());
                        break;
                    case "Shotgun":
                        upgrades.push(addShotgun());
                        break;
                    case "Knife":
                        upgrades.push(addKnife());
                        break;
                    case "Bow":
                        upgrades.push(addBow());
                        break;
                    case "Axe":
                        upgrades.push(addAxe());
                        break;
                }
                weapons.splice(index, 1);
            }
            else {
                index = randomIndex(1, stats, weapons);
                newButton.textContent = stats[index];
                switch (newButtontextContent) {
                    case "HP":
                        upgrades.push(addHP());
                        break;
                    case "Damage":
                        upgrades.push(addDamage());
                        break;
                    case "Armor":
                        upgrades.push(addArmor());
                        break;
                }
                stats.splice(index, 1);
            }


            popupContent.appendChild(newButton);
            buttons.push(newButton);
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

        //add stats/weapons with function
    });
});
