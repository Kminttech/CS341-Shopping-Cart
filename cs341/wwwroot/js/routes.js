// routes
function route(page, id){
    $.ajax({
            type: "GET",
            url: page,
            data: {"data":id},
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

function logIn(){
    block("Logging In");
    var username = $("#usernameInput").val();
    var password = $("#passwordInput").val();
    $.ajax({
            type: "GET",
            url: "/Users/Login",
            data: {"username":username, "password":password},
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                document.close();
                document.write(data);
            },
            failure: function (data) {
                alert("Something went wrong");
            },
            error: function (data) {
                alert("Something went wrong");
            }
        });
}

function logOut(){
    block("Logging Out");
    $.ajax({
            type: "GET",
            url: "/Home/Index",
            data: {},
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                document.close();
                document.write(data);
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
    route("/Home/Home");
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

function routeToItem(id){
    route("/Home/GetItem", id);
}

function routeToAdmin(){
    route("/Home/Admin");
}

function dbRoute(path){
    route(path);
}
