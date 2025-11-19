Feature: Login feature
Como usuario
Quiero poder iniciar sesión en la aplicación
Para acceder a las funcionalidades de cada tipo de usuario

    @happy_path
    Scenario: Successful Employee login
        Given the user is on the login page
        When the user enters employee credentials
        Then the user should be redirected to the dashboard
        And the user should see Employee options

    @happy_path
    Scenario: Successful Manager login
        Given the user is on the login page
        When the user enters manager credentials
        Then the user should be redirected to the dashboard
        And the user should see Manager options

    @happy_path
    Scenario: Unsuccessful login with invalid credentials
        Given the user is on the login page
        When the user enters invalid username or password
        Then an error message should be displayed indicating invalid credentials

    @happy_path
    Scenario: Unsuccessful login with empty fields
        Given the user is on the login page
        When the user leaves the username and password fields empty
        Then an error message should be displayed indicating invalid credentials
