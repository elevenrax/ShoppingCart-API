/*
    Helper script for ShoppingCart end points.
*/

function AppendToDebug(caller, status, result) {
    var oldText = $("#debug").text();
    var newText = oldText + caller + "[" + status + "]<br/>" + result + "<br/><br/>";
    $("#debug").text(newText);
}

function ShoppingCartHelper() {

    this.get = function (id) {
        $.get("/api/Basket/" + id), function (data, status) {
            AppendToDebug("get", status, data);
        }
    }

    this.getAll = function () {
        $.get("/api/Basket"), function (data, status) {
            AppendToDebug("getAll", status, data);
        }
    }

    this.getBasketTotal = function () {
        $.get("/api/Basket/total"), function (data, status) {
            AppendToDebug("getBasketTotal", status, data);
        }
    }

    this.AddProductToCart = function (id, qty) {
        $.post("/api/Basket", { Id: id, OrderQty: qty }, function (result) {
            AppendToDebug("AddProductToCart", status, result);
        });
    }
}