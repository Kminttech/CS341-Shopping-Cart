// main

function toggleLogIn() {
  $("#login-content").toggleClass("hide");        
}

function logIn(id){
    var username = $("#usernameInput").val();
    var password = $("#passwordInput").val();
    $.get( 
      "/Home/Login",
      { username: username, password: password },
      function(data) {
         document.write(data);
      }
   );
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