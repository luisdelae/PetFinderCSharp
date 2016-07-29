$(document).ready(function () {



    $("#search").on("click", function (event) {
        var key = "8c5651bb1f65ed3b8e5163969b917f60";
        var baseURL = "http://api.petfinder.com/";
        var query = "pet.getRandom";
        var animalType = $("#animalTypes option:selected").val();
        var params = '?key=' + key + '&animal=' + animalType + '&output=basic&format=json';


        var request = { requestUrl: baseURL + query + params };
         
        //event.preventDefault();

        $.ajax({
            type: 'POST',
            url: '/RandomAnimal/Index',
            data: JSON.stringify(request),
            dataType: 'html',
            contentType: 'application/json',
            traditional: true,
            success: function (data) {
                console.log(data);
            },
            //error: function () {
            //    alert("error");
            //},
            async: false

        });
    });
});