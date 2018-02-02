# Shopping Cart WebAPI Project

A sample WebAPI shopping cart with a JavaScript client library to utilise endpoints.
Using Dot Net framework 4.6.1.

A zipped version of the project can be obtained [here](https://drive.google.com/open?id=1jbf8NMRp-W37qxEdjKtPS-kwIf2A_7gv).
Otherwise, clone master from git.

## File Structure

The following files will be of interest:

PROJECT

|- Controllers

	|- BasketController.cs (The WebAPI Controller)

|- DAL

	|- CartDatase.cs (Singleton to store cart: see `Design Choices`)

	|- ProductDatabase.cs (A Stub represent a datastore of products available for sale)

	|- ProductDatabaseInterface.cs (Interface to allow interchangability of Product Data Store) 

|- Models

	|- ClientOrderItem.cs (A model for binding post backs of orders)

	|- OrderItem.cs (Represents an order for a single product, server side only)

	|- Product.cs (A model represent a Product in our ProductDatabase)

|- Scripts

	|- BasketHelper.js (The helper library for the client side)

## API Documentation

Run the project, then in your browser refer to the "API" button on the menu bar.

## JavaScript Documentation

Comments provided in: `~/Scripts/BasketHelper.js`.

## Key Design Choices

### CartDatabase.cs

A browser session is a good way to track a specific users cart. 
For example we could do the following:

```
var cart = HttpContext.Session["cart"] as CartDatabase;
if (null == CartDatabase) 
{
	cart = new CartDatabase();
	HttpContext.Session["cart"] = cart;
}
return cart;
```

The Session class on the server side corresponds with a browser session, so this would add the functionality of tracking a cart for multiple users (which this demo app doesn't do). However, to be a properly RESTful service, it must be `Stateless`.

The spec did not require user-cart management either, so it was assumed to not be necessary.

### Other

Other design choices have been placed in the comments of the code itself.

## Branches

  |- master			(ready for realease)

  |- pre-release	(integration of below two for integ. testing)

  |- dev			(back end dev)
  
  |- js-lib 		(front end dev)