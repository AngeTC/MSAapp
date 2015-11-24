// This event triggers on page load
document.addEventListener("DOMContentLoaded", function () {
    loadSpecials();
});

function loadSpecials() {

    // We need a reference to the div/table that we are going to chuck our data into
    var specialsTable = document.getElementById("tblspecialcontent");

    SpecialModule.getSpecials(function (specialsList) {
        setupSpecialsTable(specialsList);
    });

    // This is the callback for when the data comes back in the specialmodule
    function setupSpecialsTable(specials) {
        console.log(specials);
        for (i = 0; i < specials.length; i++) {

            // Create row 
            var row = document.createElement('tr');

            // Add the columns in the row (td / data cells)
            var specialNameCol = document.createElement('td');
            specialNameCol.innerHTML = specials[i].specialName;
            row.appendChild(specialNameCol);

            var specialDescCol = document.createElement('td');
            specialDescCol.innerHTML = specials[i].specialDesc;
            row.appendChild(specialDescCol);

            var specialPriceCol = document.createElement('td');
            specialPriceCol.innerHTML = specials[i].specialPrice;
            row.appendChild(specialPriceCol);

            // Append the row to the end of the table
            specialsTable.appendChild(row);

        }
    }
}