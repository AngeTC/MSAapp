var FeedbackModule = (function () {
    // Return anything that you want to expose outside the closure
    return {
        addFeedbackPost: function (topic) {
            var jsonToPost = '{'
                    + '"FeedbackPostID" : "0",'
                    + '"topic" : '
                    + topic
                    + ' }';

            $.ajax({
                type: "POST",
                data: jsonToPost,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                url: "https://acasnandoso.azurewebsites.net/api/Feedback",
                success: function (data) {
                    console.log(data);
                    alert("Feedback post successfully created.");
                }
            });
        }
    };
}());