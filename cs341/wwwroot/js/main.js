// main

function toggleLogIn() {
  $("#login-content").toggleClass("hide");        
}

function registerUser() {
    var username = $("#username-input").val();
    $("#register-user").html("<div>Thank You</div>");
    $("#username").html(username);
}

function login(id){
    var username = $("#usernameInput");
    var password = $("#passwordInput");
    $.get( 
      "/Home/Login",
      { username: username, password: password },
      function(data) {
         // login stuff 
      }
   );
}