document.addEventListener('DOMContentLoaded', function () {
    // Add this script to enable Bootstrap functionality
    var myModal1 = new bootstrap.Modal(document.getElementById('myModal1'));
    var pokemonDetailsModal = new bootstrap.Modal(document.getElementById('pokemonDetailsModal'));

    // Uncomment the following line if you want to handle modal show event
    // myModal1.show();

    // Optional: If you want to handle modal dismissal
    // myModal1.hide();

    // Repeat the above lines for each modal
});

$(document).ready(function () {
    $("#Species").change(function () {
        var selectedSpecies = $(this).val();
        // Make AJAX request
        $.ajax({
            url: `https://pokeapi.co/api/v2/pokemon/${selectedSpecies}/`,
            method: "GET",
            success: function (data) {
                // Update form fields based on the response data
                $("#PokemonId").val(data.id);
                $("#Type1").val(data.types[0].type.name);
                $("#Type2").val(data.types.length > 1 ? data.types[1].type.name : "");
            },
            error: function (error) {
                console.error("Error fetching data:", error);
            }
        });
    });
});