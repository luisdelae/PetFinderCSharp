var currentRandomPet;

$(document).ready(function () {



    $("#search").on("click", function (event) {
        var key = "8c5651bb1f65ed3b8e5163969b917f60";
        var baseURL = "http://api.petfinder.com/";
        var query = "pet.getRandom";
        var animalType = $("#animalTypes option:selected").val();
        var params = '?key=' + key + '&animal=' + animalType + '&output=basic&format=json';
        var request = baseURL + query + encodeURI(params) + "&callback=?";

        event.preventDefault();

        $.ajax({
            type: "GET",
            dataType: "jsonp",
            url: request,
            async: true
        })
        .done(function (response) {
            currentRandomPet = response.petfinder.pet;
            showRandomAnimal();

        })
        .fail(function () {
            console.log("Failed");
        });
    });
});

var showRandomAnimal = function () {
    // location.href = "/Home/RandomAnimal"; //redirects to the page, but currently redirects after appending. Unsure how to fix.
    $('#animal').remove();
    console.log("Random: ", currentRandomPet);

    $('#randomPetPage').append('<div id="animal"></div>');
    if (currentRandomPet.media.photos !== undefined) {
        if (currentRandomPet.media.photos.photo !== undefined) {
            $('#animal').append('<img src=' + currentRandomPet.media.photos.photo[2].$t + '>');
        }
    }

    $('#animal').append('<p>' + currentRandomPet.name.$t + '</p>');
    $('#animal').append('<p>' + currentRandomPet.description.$t + '</p>');
};