/*
    Helper script for ShoppingCart end points.
    Dependencies: jQuery
*/

function ShoppingCartHelper() {

    /*
        Gets a specific item (by id) that is in the cart.
        PARAMS:
          - id: the id of the product to retreive
          - callback: A pointer to a function where the result will be returned.
        RETURNS:
            Callback returns a JsonObject of the schema: http://localhost:00000/Help/ResourceModel?modelName=OrderItem
    */
    this.get = function (id, callback) {
        $.ajax({
            url: "/api/Basket/" + id,
            type: "GET",
            dataType: "json",
            success: function (result) {
                callback(result);
            }
        });
    }

    /*
        Gets all items in the cart.
        PARAMS:
          - callback: A pointer to a function where the result will be returned.
        RETURNS:
            Callback returns a JsonArray of JsonObjects, of the schema: http://localhost:00000/Help/ResourceModel?modelName=OrderItem
    */
    this.getAll = function (callback) {
        $.ajax({
            url: "/api/Basket",
            type: "GET",
            dataType: "json",
            success: function (result) {
                callback(result);
            }
        });
    }

    /*
        Gets the total price of all items in the cart.
        PARAMS:
          - callback: A pointer to a function where the total will be returned.
        RETURNS:
            Callback returns a float value representing the total price.
    */
    this.getBasketTotal = function (callback) {
        $.ajax({
            url: "/api/Basket/total",
            type: "GET",
            dataType: "json",
            async: false,  // We want to block read/write access to cart when getting total.
            success: function (result) {
                callback(result);
            }
        });
    }


    /*
        Adds a product to the shopping cart.
        PARAMS:
          - id: The product's id you wish to add to the cart.
          - qty: The quantity of the product to order.
          - callback: A pointer to a function where the total will be returned.
        RETURNS:
            Callback returns the id of the product added, if successful.
    */
    this.AddProductToCart = function (id, qty, callback) {
        $.ajax({
            url: "api/Basket",
            type: "POST",
            dataType: "json",
            data: {
                Id: id,
                OrderQty: qty
            },
            success: function (result) {
                callback(result);
            }
        });
    }

    /*
        Updates the Quantity of a product already in the cart.
        PARAMS:
          - id: The id of the product (in cart) that you wish to increase in quantity.
          - qty: The new quantity.
          - callback: A pointer to a function where the response will be returned.
        RETURNS:
            Callback returns the id of the product updated, if successful.
    */
    this.UpdateQtyOfProduct = function (id, qty, callback) {
        $.ajax({
            url: '/api/Basket',
            type: 'PUT',
            data: {
                "Id": id,
                "OrderQty": qty
            },
            success: function (result, status, xhr) {
                callback(result);
            }
        });
    }

    /*
        Removed a product, with a given id, from the cart.
        PARAMS:
          - id: The id of the product (in cart) you wish to remove.
          - callback: A pointer to a function where the response will be returned.
        RETURNS:
            Callback returns the id of the product removed from the cart, if succesful.
    */
    this.removeProductFromCart = function (id, callback) {
        $.ajax({
            url: 'api/Basket/' + id,
            type: 'DELETE',
            success: function (result) {
                callback(result);
            }
        });
    }

    /*
        Empties the shopping cart. For the shopper who hates everything and wants to start again.
    */
    this.emptyCart = function () {
        $.ajax({
            url: 'api/Basket/',
            type: 'DELETE',
            success: function (result) {
                return result;
            }
        });
    }
}