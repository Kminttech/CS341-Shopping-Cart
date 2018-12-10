// main
window.onload=function(){
    domHandlers();
}

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
    addCartEntry(userId, itemId, quantity);
}

function updateCart() {
    var cartNotify = $("#cart-btn");
    cartNotify.fadeIn(100).fadeOut(100).fadeIn(100).fadeOut(100).fadeIn(100);
}

function removeItemFromCart(cartId, userId) {
    $.ajax({
        type: "POST",
        url: "/CartEntries/DeleteEntry",
        data: { cartId: cartId, userId: userId },
        success: function (data) {
            $("#main-content").html(data);
            domHandlers();
        },
        failure: function (data) {
            alert("Something went wrong :(");
        },
        error: function (data) {
            alert("Something went wrong :(");
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
            domHandlers();
        },
        failure: function (data) {
            alert("Something went wrong :(");
        },
        error: function (data) {
            alert("Something went wrong :(");
        }
    }).always(unblock());
}

function checkout() {
    //Checkout
    var userId = $("#user-id").val();
    var promo = $("#promo-amount").val();
     block("updating cart");
    $.ajax({
        type: "GET",
        url: "/CartEntries/Checkout",
        data: { id: userId, discount: promo },
        success: function (data) {
            $("#main-content").html(data);
            domHandlers();
        },
        failure: function (data) {
            alert("Something went wrong :(");
        },
        error: function (data) {
            alert("Something went wrong :(");
        }
    }).always(unblock());
}

function submitOrder() {
    //SubmitOrder
    var userId = $("#user-id").val();
     block("Checkout");
    $.ajax({
        type: "GET",
        url: "/CartEntries/SubmitOrder",
        data: { id: userId },
        success: function (data) {
            $("#main-content").html(data);
            domHandlers();
        },
        failure: function (data) {
            alert("Something went wrong :(");
        },
        error: function (data) {
            alert("Something went wrong :(");
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
            domHandlers();
        },
        failure: function (data) {
            alert("Something went wrong :(");
        },
        error: function (data) {
            alert("Something went wrong :(");
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
            domHandlers();
        },
        failure: function (data) {
            alert("Something went wrong :(");
        },
        error: function (data) {
            alert("Something went wrong :(");
        }
    }).always(unblock());
}

function filterResults(){
    var query = $("#searchQuery").val();
    var reg = new RegExp(query, 'i');
    $(".results-item").each(function(){
      console.log($(this));
      var name = $(this).find(".results-item-name").html();
      console.log(name);
      console.log(String(reg));
      if(!(String(name).match(reg)) && !($(this).hasClass("hide"))){
        $(this).addClass("hide");
      }else if(String(name).match(reg) && $(this).hasClass("hide")){
        $(this).removeClass("hide");
      }
    });
}

function domHandlers(){
    if(document.getElementById("usernameInput")){
        document.getElementById("usernameInput").addEventListener("keyup", function(event) {
          event.preventDefault();
          if (event.keyCode === 13) {
            document.getElementById("login-submit").click();
          }
        });
    }

    if(document.getElementById("passwordInput")){
        document.getElementById("passwordInput").addEventListener("keyup", function(event) {
          event.preventDefault();
          if (event.keyCode === 13) {
            document.getElementById("login-submit").click();
          }
        });
    }
    if(document.getElementById("registerUsername")){
        document.getElementById("registerUsername").addEventListener("keyup", function(event) {
          event.preventDefault();
          if (event.keyCode === 13) {
            document.getElementById("register-submit").click();
          }
        });
    }

    if(document.getElementById("registerPassword")){
        document.getElementById("registerPassword").addEventListener("keyup", function(event) {
              event.preventDefault();
              if (event.keyCode === 13) {
                document.getElementById("register-submit").click();
              }
            });
    }
    if(document.getElementById("searchQuery")){
            document.getElementById("searchQuery").addEventListener("keyup", function(event) {
                  event.preventDefault();
                  if (event.keyCode === 13) {
                    document.getElementById("search-submit").click();
                  }
                });
        }
}
