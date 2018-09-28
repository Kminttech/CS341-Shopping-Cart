// routes
function route(page){
    $.ajax({
            type: "GET",
            url: page,
            data: {"data":page},
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("#main-content").html(data);
            },
            failure: function (data) {
                alert("Something went wrong");
            },
            error: function (data) {
                alert("Something went wrong");
            }
        });
}
function routeToResults() {
    route("/Home/GetResults");
}

function routeToResults() {
    route("/Home/Index");
}
