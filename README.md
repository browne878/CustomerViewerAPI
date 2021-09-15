# **CustomerViewerAPI**
 This is a simple API that will allow you to Add, Delete, Modify and Get Customers from a database. This API will work with MySQL databases.

## Table of Contents
- [Creating the Database](https://github.com/browne878/CustomerViewerAPI#creating-the-database)
- [Preparing the API](https://github.com/browne878/CustomerViewerAPI#preparing-the-api)
- [Starting the API](https://github.com/browne878/CustomerViewerAPI#starting-the-api)
- [Requests](https://github.com/browne878/CustomerViewerAPI#requests)
  - [GET Request](https://github.com/browne878/CustomerViewerAPI#get-request)
  - [POST Request](https://github.com/browne878/CustomerViewerAPI#post-request)
  - [PUT Request](https://github.com/browne878/CustomerViewerAPI#put-request)
  - [DELETE Request](https://github.com/browne878/CustomerViewerAPI#delete-request)
- [POSTMAN Collection](https://github.com/browne878/CustomerViewerAPI#postman-collection)

## Creating the Database



## Preparing the API
To begin, download the [this](https://github.com/browne878/CustomerViewerAPI/tree/main/bin/Release/net5.0) file. You will then want to configure the [Config File](https://github.com/browne878/CustomerViewerAPI/blob/main/bin/Release/net5.0/Config/Config.json) with the database information from the previous section.


## Starting the API
Once the API has been prepared then all you have to do is run the [CustomerViewerAPI](https://github.com/browne878/CustomerViewerAPI/blob/main/bin/Release/net5.0/CustomerViewerAPI.exe) application you dowloaded and the API will be running.

You can exit the application with `CTRL+C` while the console is selected.


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

## POSTMAN Collection

I have compiled a list of useful request which can be easily accessed.

I have also included a POST request to allow you to populate the database with 10 customers to allow you to test the API is working correctly.

The collection is availible [here]().
