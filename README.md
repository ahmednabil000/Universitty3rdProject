# Online Shop APIs Documentation

Welcome to the Online Shop APIs documentation! This repository houses a collection of powerful APIs tailored to streamline the operations of your online shop. With endpoints designed for both retrieving and posting data, these APIs offer a comprehensive solution to manage your online store effortlessly.

## Table of Contents 

1. Introduction
2. Available Endpoints
3. Authentication
4. Usage Examples
5. Error Handling
6. Contact Information

### Introduction 

The Online Shop APIs are a set of RESTful web services meticulously crafted to facilitate the seamless management of your online store. From retrieving product information to processing orders, our APIs are designed to empower your e-commerce platform with efficiency and reliability.

### Available Endpoints 
#### GET Endpoints 

. '/products': Retrieve a list of all products available in the online shop.

. '/products/{id}': Retrieve details of a specific product by its unique identifier.

#### POST Endpoints
. '/orders': Place a new order in the online shop, specifying the products and quantities.

### Authentication 

To ensure secure access to our APIs, we employ a robust authentication mechanism using JSON Web Tokens (JWT). You'll need to include a valid JWT token in the headers of your requests to authorized endpoints. Please contact our team to obtain your authentication credentials.

### Usage Examples 

#### Retrieving Product Information 



  GET /products
  

  


#### Response 


    
        "id": 1,
        "name": "Product 1",
        "price": 19.99,
        "description": "Lorem ipsum dolor sit amet."
    ,
    
        "id": 2,
        "name": "Product 2",
        "price": 29.99,
        "description": "Consectetur adipiscing elit."
    

### Placing an Order 


POST /orders

#### Request Body 


    "products": 
        
            "id": 1,
            "quantity": 2
        ,
        
            "id": 2,
            "quantity": 1
        
    
#### Response 

 
    "order_id": 12345,
    "total_price": 69.97,
    "message": "Order successfully placed."


## Error Handling 

Our APIs return appropriate HTTP status codes and error messages to facilitate easy debugging and troubleshooting. Refer to our Error Handling Documentation for detailed information on handling errors




![Screenshot 2024-04-28 094928](https://github.com/ahmednabil000/Universitty3rdProject/assets/117235814/ac8fa07c-8d78-40f7-a16e-55dbffcc839e)






