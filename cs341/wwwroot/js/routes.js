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

function routeHome() {
    var page = "/Home/Home";
    $.ajax({
            type: "GET",
            url: page,
            data: {"data":page},
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                $("html").html(data);
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

function routeToCart(){
    route("/Home/GetCart");
}

function routeToRegister(){
    route("/Home/Register");
}