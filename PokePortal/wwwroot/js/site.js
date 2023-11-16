document.addEventListener('DOMContentLoaded', function () {
    // Add this script to enable Bootstrap functionality
    var myModal1 = new bootstrap.Modal(document.getElementById('myModal1'));

    // Uncomment the following line if you want to handle modal show event
    // myModal1.show();

    // Optional: If you want to handle modal dismissal
    // myModal1.hide();

    // Repeat the above lines for each modal
});

$(document).ready(function () {
    // Initialize the dropdown
    $('#Species').select2({
        placeholder: 'Select a Pokemon', // Set a placeholder text
        allowClear: true, // Allow clearing the selection
        minimumInputLength: 1, // Minimum number of characters before showing results
        ajax: {
            url: '/Pokemon/GetPokemonSpecies', // Your API endpoint to get Pokemon species
            dataType: 'json',
            delay: 250,
            processResults: function (data) {
                return {
                    results: data
                };
            },
            cache: true
        }
    });

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