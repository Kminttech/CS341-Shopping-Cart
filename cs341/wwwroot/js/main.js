// main

function block(message){
    $.blockUI({ message: message });
}

function unblock(){
    $.unblockUI();
}

function toggleLogIn() {
  $("#login-content").toggleClass("hide");        
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

function updateCart() {
    var cartNotify = $("#cart-notify");
    var quantity = $("#itemview-item-quantity>input").value;

    if(cartNotify.hasClass("hide")){
        cartNotify.removeClass("hide");
    }

    var num = Number(cartNotify.text()) + 1;
    $("#cart-notify").text(num)
}