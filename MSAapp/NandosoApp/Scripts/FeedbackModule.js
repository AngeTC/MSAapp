var FeedbackModule = (function () {
    // Return anything that you want to expose outside the closure
    return {
        addFeedback: function (feedback) {
            $.ajax({
                type: "POST",
                dataType: "json",
                url: "https://acasnandoso.azurewebsites.net/api/Feedback",
                success: function (data) {
                    console.log(data);
                    //callback(data);
                }
            });
        }
    };
}());