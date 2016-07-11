$(document).ready(function () {
    var URL = 'GetAll';
    $.ajax({
        type: "Get",
        url: URL,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: successFunc,
        error: function (er) {
            console.error('Error happened!' + er);
        }
    });

    function successFunc(data, status) {
        data.beverages.forEach(function (item) {
            var color = '#' + (0x1000000 + (Math.random()) * 0xffffff).toString(16).substr(1, 6);
            var li = "<li><div class='thumbnail tile tile-medium col-md-3' style='background-color:" + color + "'><a href='#' id='"
                + item.Id + "'><h3 style='margin-top: 30px;'>" + item.Name + "</h3></a></div></li>";
            $('#beverage-menu').append(li);
        });
        handleEvents();

    }
});

function handleEvents() {
    $("#beverage-menu a").click(function (item) {
        item.preventDefault();
        var selectedID = this.id;
        var selectedText = this.text;
        var URL = 'GetRecipe';
        $.ajax({
            type: "POST",
            url: URL,
            data: JSON.stringify({ id: selectedID }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) { showRecipe(data.recipe, selectedText) },
            error: function (er) {
                console.error('Error happened!' + er);
            }
        });

        function showRecipe(recipe, selectedText) {
            recipe.push({ Title: 'Done!' });
            $("#progress-text").text('Preapering ' + selectedText + ':  ' + recipe[0].Title);
            var i = 1;
            var intervalId = setInterval(function () {
                $("#progress-text").text('Preapering ' + selectedText + ':  ' + recipe[i].Title);
                i++;
                if (i >= recipe.length) {
                    clearInterval(intervalId);
                };
            }, 1300);
        };
    });
};
