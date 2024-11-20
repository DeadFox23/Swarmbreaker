// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


//Defaultmap

window.addEventListener('resize', reportWindowSize);
function reportWindowSize() {
    console.log("baum");
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
        var weapons = ["Slingshot", "Baum", "Knife", "Axe", "Bow"];

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



function loadPopupContent() {
        fetch('/Home/GetPopupData') // Replace with your action endpoint
            .then(response => response.json())
            .then(data => {
                const popupContent = document.querySelector('.popup-content');
                popupContent.innerHTML = `<h2>${data.title}</h2>`;

                data.items.forEach(item => {
                    const button = document.createElement("button");
                    button.classList.add("closePopupBtn");
                    button.textContent = item.name;
                    popupContent.appendChild(button);
                });

                // Open the popup
                popup.style.display = 'flex';

                // Reattach event listeners for closing
                const closePopupBtns = document.querySelectorAll('.closePopupBtn');
                closePopupBtns.forEach(button => {
                    button.addEventListener('click', () => {
                        popup.style.display = 'none';
                    });
                });
            })
            .catch(error => console.error('Error fetching popup data:', error));
}

