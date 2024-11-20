// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
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

// Write your JavaScript code.

const stats = ["HP", "Damage", "Armor"];

const weapons = ["Slingshot", "Baum", "Knife", "Axe", "Bow"];

const index;

function randomIndex(list)
{
    if (list == 1)
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
    for (let i = 0; i < 3; i++) {
        const newButton = document.createElement("button");
        newButton.classList.add("closePopupBtn");
        newButton.setAttribute("data-close", "true");

        // Here, you could use AJAX to fetch new data from the server or use random logic
       /* newButton.textContent = weapons[randomIndex(2)]; // Placeholder text*/
        var index;
        if (randomBool() === 1) {
            index = randomIndex(2);
            newButton.textContent = weapons[index];
            weapons.splice(index,1);
        }
        else {
            index = randomIndex(1);
            newButton.textContent = stats[randomIndindex];
            stats.splice(index,1);
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

<<<<<<< HEAD
=======

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
>>>>>>> master
