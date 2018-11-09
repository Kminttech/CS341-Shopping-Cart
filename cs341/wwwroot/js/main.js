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

function addToCart() {
    var addToCartBtn = $("#addToCartBtnIcon");
    if (addToCartBtn.length) {
        addToCartBtn.removeClass("fa-cart-plus");
        addToCartBtn.addClass("fa-check");
    }
    updateCart();
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