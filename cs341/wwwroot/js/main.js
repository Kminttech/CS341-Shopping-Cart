// main
function block(message){
    $.blockUI({ message: message + "  <i class='fa fa-spin fa-dice'></i>" });
}

function unblock(){
    $.unblockUI();
}

function toggleLogIn() {
  $("#login-content").toggleClass("hide");        
}

function fadeoutContent(elem){
    var fadable = $(elem);
    if(fadable.length){
        fadable.children().fadeOut();
    }
}

function addToCart(itemId) {
    var addToCartBtn = $("#addToCartBtnIcon");
    var quantity = $(".itemview-item-quantity>input").val();
    var userId = $("#user-id").val();
    if (addToCartBtn.length) {
        addToCartBtn.removeClass("fa-cart-plus");
        addToCartBtn.addClass("fa-check");
    }
    if(userId == -1){
        updateCart();
    } else{
        addCartEntry(userId, itemId, quantity);
    }
}

function updateCart() {
    var cartNotify = $("#cart-notify");
    var quantity = $(".itemview-item-quantity>input").val();

    if(cartNotify.hasClass("hide")){
        cartNotify.removeClass("hide");
    }

    var num = Number(cartNotify.text()) + 1;
    $("#cart-notify").text(num);
}

function removeItemFromCart(){
    alert("not implemented yet");
}

function checkOut() {
    alert("not implemented yet");
}