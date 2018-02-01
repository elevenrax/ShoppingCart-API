/*
    Helper script for ShoppingCart end points.
*/

function ShoppingCartHelper() {

    this.get = function (id) {
        $.get("/api/Basket/" + id), function (data, status) {
            var funcName = arguments.callee.toString();
            console.log(funcName + ": " + data + "[" + status + "]");
        }
    }

    this.getAll = function () {
        $.get("/api/Basket"), function (data, status) {
            var funcName = arguments.callee.toString();
            console.log(funcName + ": " + data + "[" + status + "]");
        }
    }

    this.getBasketTotal = function () {
        $.get("/api/Basket/total"), function (data, status) {
            var funcName = arguments.callee.toString();
            console.log(funcName + ": " + data + "[" + status + "]");
        }
    }

    this.AddProductToCart = function (id, qty) {
        $.post("/api/Basket",
            {
                Id: id,
                OrderQty: qty
            },
            function (result) {
                var status = "no_status";
                var funcName = arguments.callee.toString();
                console.log(funcName + ": " + data + "[" + status + "]");
            });
    }

    this.UpdateQtyOfProduct = function (id, qty) {
        $.ajax({
            url: '/api/Basket',
            type: 'PUT',
            success: function (result) {
                var status = "no_status";
                var funcName = arguments.callee.toString();
                console.log(funcName + ": " + data + "[" + status + "]");
            }
        });
    }
}