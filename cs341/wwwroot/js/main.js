// main

function logIn() {
  $("#login-content").toggleClass("hide");        
}

function registerUser() {
    var username = $("#username-input").val();
    $("#register-user").html("<div>Thank You</div>");
    $("#username").html(username);
}
