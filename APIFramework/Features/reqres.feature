Feature: Testing the Get, Put, Post, Delete, Patch requests on the reqres website

  Background: 
    Given User has the base URL

 Scenario: Testing the GET request
   Given User sets the endpoint as "/api/users?page=2"
   When User makes a "GET" request
   Then User should receive a status response as "200"

Scenario: Testing the GET request2
   Given User sets the endpoint as "/api/users?page=2"
   When User makes a "GET" requestt
   Then User should receive a status response in json format 




#put is update/replace(specific resource)
Scenario Outline: Testing the PUT request
Given User sets the endpoint as "/api/users/2"
When User makes a "PUT" request and sends the data as "<name>" and "<job>"
Then User should receive a status response as "200" and also print the response
Examples:
| name     | job          |
| Vegesh   | SDET         |
| Ram      | BA           |
| Chakri   | Data Engineer|
| Vivek    | SDE          |

#post is create/add(new resource)
Scenario Outline: Testing the POST request
Given User sets the endpoint as "/api/users"
When User makes a "POST" request and sends the data as "<name>" and "<job>"
Then User should receive a status response as "201" and also print the response
Examples:
| name     | job           |
| Boppana  | SDET          |
| Ramu     | BA            |
| Chakra   | Data Scientist|
| Varma    | SDE           |



#patch is update/modify(specific resource)

Scenario Outline: Testing the PATCH request
Given User sets the endpoint as "/api/users/2"
When User makes a "PATCH" request and sends the data as "<name>" and "<job>"
Then User should receive a status response as "200" and also print the response
Examples:
| name     | job          |
| Vegesh   | SDE          |
| Ram      | SDET         |
| Chakri   | MLE          |
| Vivek    | SDET         |

#POST for register succesfful


Scenario Outline: Testing the POST request for both successful and unsuccessful user registration
Given User sets the endpoint as "/api/register"
When User makes a "POST" request and sends the data with email "<email>" and password "<password>"
Then User should receive a status response as "<statusCode>"
Examples:
| email             | password | statusCode |
| eve.holt@reqres.in | pistol  | 200        |
|                    | 13412   | 200        |
| vegesh@gmail.com   |         | 200        |

#POST for login succesfful and unsuccesfful

Scenario Outline: Testing the POST request for both successful and unsuccessful user login
Given User sets the endpoint as "/api/login"
When User makes a "POST" request and sends the data with email "<email>" and password "<password>"
Then User should receive a status response as "<statusCode>"
Examples:
| email              | password   | statusCode |
| eve.holt@reqres.in | cityslicka | 200        |
|                    | 13412      | 200        |
| vegesh@gmail.com   |            | 200        |


