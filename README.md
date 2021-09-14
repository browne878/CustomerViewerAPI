# **CustomerViewerAPI**
 This is a simple API that will allow you to Add, Delete, Modify and Get Customers from a database. This API will work with MySQL databases.

## Table of Contents
- [Creating the Database]()
- [Preparing the Application]()
- [Starting the Application]()
- [Requests]()
  - [GET Request]()
  - [POST Request]()
  - [PUT Request]()
  - [DELETE Request]()

## Creating the Database



## Starting the API



## Preparing the API



## Requests


 Once you have the API started and the database set up, all GET requests should be made to the following address.

```
https://localhost:5001/customer/api/customers
```

### GET Request
A GET request to the following address will return an array of all the customers in JSON format.

```
https://localhost:5001/customer/api/customers
```

Alternatively, you can select a customer by their ID as show below.

```
https://localhost:5001/customer/api/customers/{ID}
```

### POST Request
A POST request will add a new customer to the database. A customer should be added my making a POST request to the following address with the
customer object, in JSON format, in the body of the POST.

```
https://localhost:5001/customer/api/customers
```

### PUT Request
A PUT request will update a customers information. This can be done by making a PUT request to the following address with the customer object,
in JSON format, in the body of the PUT.

```
https://localhost:5001/customer/api/customers
```

### DELETE Request
A DELETE request will remove a customer from the database. This can be done by making a DELETE request to the following address with the customer ID
in the body of the DELETE.

```
https://localhost:5001/customer/api/customers
```