$(document).ready(function () {
  
    $(".search").on("click", function () {
        var key = "8c5651bb1f65ed3b8e5163969b917f60";
        var baseURL = "http://api.petfinder.com/";
        var query = "pet.getRandom";
        var animalType = $("#animalTypes option:selected").val();
        var params = '?key=' + key + '&animal=' + animalType + '&output=basic&format=json';
        var request = baseURL + query + encodeURI(params) + "&callback=?";

        $.ajax({
            type: "GET",
            dataType: "jsonp",
            url: request,
            async: true
        })
        .done(function (response) {
            console.log(response.petfinder.pet);
        })
        .fail(function () {
            console.log("Failed");
        });
    });
});

