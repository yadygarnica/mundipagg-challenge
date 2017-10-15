# Repository for the Mundipagg Challange

## Challenge:
Create an application that will simulate the checkout screen of an ecommerce, ie the customer needs to choose a product and then go to the payment screen where they will need to enter some data to make the payment. The transaction must be submitted to the MundiPagg API.
 
Requirements:
- Have two highly decoupled Web and Api layers
- Web Layer Technologies: html, css and javascript
- Technologies of the api layer:
    - Backend: http://asp.net/web-api
    - BD: SQL Server or MongoDb
- The API must be written on the REST architecture
- Payment must be processed by the MundiPagg API in the test environment
 

The screen should contain the fields:

 
Name of cardholder.

Card number.

Year and expiration.

Month of maturity.

Cardboard Flag.

CVV.

Transaction value.
 
Every transaction must be saved in a database.

 
Comments:
- The code should be as clear and intuitive as possible, easy to read and understand
- Variables, class names, methods all in English

## Solution:

I created 2 projects, a Web API for the service of storage the transactions data and the communication with Mundipagg API, and the other project is a ASP.NET MVC Online Shop, that storage the products and when an user buy a product send a post request to the payment services to proccess the transaction. 

I used Asp.net Web API Cors(http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api)

I used MongoDb in both projects https://docs.mongodb.org/manual/. 

In the online shop project I used a javascript for card validation from https://github.com/stripe/jquery.payment .

In the service api I used the Mundipagg API from https://github.com/mundipagg/mundipagg-one-dotnet and I test with credit card numbers generated at http://www.getcreditcardnumbers.com/ .







 
