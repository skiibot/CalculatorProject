# CalculatorProject
Names in this project is a bit confusing, so use this readme to get an understanding of what each file is:

CalcConsoleApplication2 is the console app, that uses both HttpClient to access the webapi and also uses the calculator class directly (using Autofac)

CalculatorApi is a class library containing the interfaces for both the diagnostics tool and the calculator. It also contains the implementation of Entity Framework so that each log can be uploaded to a database.

CalculatorWeb is the WebApi implementation of the calculator code. it allows the user to use GET requests to do calculations when it is running.

CalculatorTests is the test project that tests the methods of the calculatorapi
