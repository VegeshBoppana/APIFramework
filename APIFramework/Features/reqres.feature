Feature: Testing the Get, Put, Post, Delete, Patch requests on the reqres website

Scenario: The user is testing the Get request on the reqres website 
Given User is requested the data from the reqres website
When User sends the Get request
Then User should get the response code 200
And User Should get the valid data
Then Test case is passed



Scenario: The user is testing the Put request on the reqres website
Given 