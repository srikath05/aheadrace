Feature: Amazon Login
    As a user
    I want to log into Amazon
    So that I can access my account

Scenario: Successful login to Amazon
    Given I navigate to the Amazon website
    When I enter username "ganjisrikanth@gmail.com" and password "Sri@2728"
    And I click on the login button
    Then I should be logged into my Amazon account

