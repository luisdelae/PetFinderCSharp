$(document).ready(function () {
  
    $("#search").on("click", function () {
        var key = "8c5651bb1f65ed3b8e5163969b917f60";
        var baseURL = "http://api.petfinder.com/";
        var query = "pet.getRandom";
        var animalType = $("#animalTypes option:selected").val();
        query += '?key=' + key;
        query += '&animal=' + animalType;
        query += '&output=basic';
        query += '&format=json';
        var request = baseURL + encodeURI(query) + "&callback=?";

        $.ajax({
            type: "GET",
            dataType: "jsonp",
            url: request
        })
        .done(function (response) {
            console.log(response.petfinder.pet);
        })
        .fail(function () {
            console.log("Failed");
        });
    });
});

