var SpecialModule = (function () {
    // Return anything that you want to expose outside the closure
    return {
        getSpecials: function (callback) {
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "https://acasnandoso.azurewebsites.net/api/Specials",
                success: function (data) {
                    console.log(data);
                    callback(data);
                }
            });
        }
    };
}());