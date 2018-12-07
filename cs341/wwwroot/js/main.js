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

function removeItemFromCart(cartId, userId) {
    $.ajax({
        type: "POST",
        url: "/CartEntries/DeleteEntry",
        data: { cartId: cartId, userId: userId },
        success: function (data) {
            $("#main-content").html(data);
        },
        failure: function (data) {
            //alert("Something went wrong :(");
        },
        error: function (data) {
            //alert("Something went wrong :(");
        }
    });
}

function updateQuantityInCart(cartId, elem, userId) {
    var quantity = $(elem).val();
    block("updating cart");
    $.ajax({
        type: "POST",
        url: "/CartEntries/EditEntry",
        data: { cartId: cartId, quantity: quantity, userId: userId },
        success: function (data) {
            $("#main-content").html(data);
        },
        failure: function (data) {
            //alert("Something went wrong :(");
        },
        error: function (data) {
            //alert("Something went wrong :(");
        }
    }).always(unblock());
}

function checkOut() {
    //SubmitOrder
    var userId = $("#user-id").val();
     block("updating cart");
    $.ajax({
        type: "GET",
        url: "/CartEntries/SubmitOrder",
        data: { id: userId },
        success: function (data) {
            $("#main-content").html(data);
        },
        failure: function (data) {
            //alert("Something went wrong :(");
        },
        error: function (data) {
            //alert("Something went wrong :(");
        }
    }).always(unblock());
}

function addPromotion() {
var promoCode = $("#promotionInput").val();
var userId = $("#user-id").val();
block("Applying Promotion!");
$.ajax({
        type: "POST",
        url: "/Promotions/AddPromotionToCart",
        data: { promoCode: promoCode, userId: userId },
        success: function (data) {
            $("#main-content").html(data);
        },
        failure: function (data) {
            //alert("Something went wrong :(");
        },
        error: function (data) {
            //alert("Something went wrong :(");
        }
    }).always(unblock());
}

function cartQuantityChange() {
    alert("not implemented yet");
}

function editAccount(userid) {
    var password = $("#passwordChange").val();
    var billingAddress = $("#billingAddressChange").val();
    block("Updating Account");
    $.ajax({
        type: "GET",
        url: "/Users/UpdateAccount",
        data: { userId: userId, password: password, billingAddress: billingAddress },
        success: function (data) {
            $("#main-content").html(data);
        },
        failure: function (data) {
            //alert("Something went wrong :(");
        },
        error: function (data) {
            //alert("Something went wrong :(");
        }
    }).always(unblock());
}

function filterResults(){
    var query = $("#searchQuery").val();
    alert("not done yet");
}