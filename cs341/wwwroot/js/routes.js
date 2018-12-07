// routes
function route(page, id){
    fadeoutContent("#main-content");
    $.ajax({
            type: "GET",
            url: page,
            data: {"id":id},
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

function register(){
    block("Getting you set up");
        var username = $("#registerUsername").val();
        var password = $("#registerPassword").val();
        $.ajax({
                type: "GET",
                url: "/Users/Register",
                data: {Username:username, Password:password, IsAdmin:"false", IsGuest:"false"},
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
            }).always(unblock);
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
        }).always(unblock);
}

function logOut(){
    block("Logging Out");
    $.ajax({
            type: "GET",
            url: "/Home/Logout",
            data: {},
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                document.close();
                document.write(data);
                user.isGuest == true;
            },
            failure: function (data) {
                alert("Something went wrong");
            },
            error: function (data) {
                alert("Something went wrong");
            }
        }).always(unblock);
}

function addCartEntry(userId, itemId, quantity) {
    $.ajax({
            type: "POST",
            url: "/CartEntries/AddEntry",
            data: {EntryItemId: itemId, UserId: userId, Quantity: quantity},
            success: function (data) {
                updateCart();
            },
            failure: function (data) {
                //alert("Something went wrong :(");
            },
            error: function (data) {
                //alert("Something went wrong :(");
            }
        });
}

function routeHome() {
    route("/Home/Home");
}

function routeToResults() {
    route("/Items/AllItems");
}

function routeToCart(){
    var userId = $("#user-id").val();
    fadeoutContent("#main-content");
        $.ajax({
                type: "GET",
                url: "/CartEntries/GetCart",
                data: {id:userId, discount:""},
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

function routeToRegister(){
    route("/Home/Register");
}

function routeToItem(id){
    route("/Items/ViewItem", id);
}

function routeToAdmin(){
    route("/Home/Admin");
}

function dbRoute(path){
    route(path);
}

function routeToPromotions() {
    route("/Promotions/GetPromoPage");
}

function routeToAccount() {
    var id = $("#user-id").val();
    route("/Users/GetAccount", id);
}

function routeToOrders(){
    var userId = $("#user-id").val();
    route("/CartEntries/GetOrders", userId);
}

function routeToManual(){
    route("/Home/GetManual");
}