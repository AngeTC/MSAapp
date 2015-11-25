var FeedbackPostModule = (function () {
    // Return anything that you want to expose outside the closure
    return {
        getFeedbackPosts: function (callback) {
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://nandosoapp.azurewebsites.net/api/FeedbackPosts",
                success: function (data) {
                    console.log(data);
                    callback(data);
                }
            });
        },

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
                url: "http://nandosoapp.azurewebsites.net/api/FeedbackPosts",
                success: function (data) {
                    console.log(data);
                    alert("Feedback post successfully created.");
                }
            });
        }
    };
}());