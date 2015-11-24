var SpecialModule = (function () {
    // Return anything that you want to expose outside the closure
    return {
        getSpecials: function (callback) {
            $.ajax({
                type: "GET",
                dataType: "jsonp",
                url: "http://api.uinames.com/?amount=25",
                success: function (data) {
                    console.log(data);
                    callback(data);
                }
            });
        }
    };
}());