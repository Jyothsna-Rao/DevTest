Technology Used
1.Back End: Asp.Net core 2.1 Web API
2.Database: SQL Server
3.Unit Testing : XUnit and Postman

Steps to Set up and Run:
Run the sql file(DataAccessLayer\Script) in SQL Server  
Change the Connection string in appsettings.json
Build and Run the solution.
End Points:
1. As a user I want to create a payment request: APIUrl/api/Payment/CreatePayment
2. As a user I want to cancel a payment request : APIUrl/api/Payment/CancelPayment?PaymentId=&Reason=
3. As a user I want to process a payment request : APIUrl/api/Payment/ProcessPayment/{PaymentID}
4. As a user I want to see my balance and a list of payments: APIUrl/api/User/{UserID}

Solution Architecture:
The solution is designed using 3-Tier Architecture and Repository Pattern.The application is separated into 3 different layers with each one having its own task.
DATA ACCESS LAYER
This layer handles database interaction of the application.Functions related to CRUD are exposed publicly from this layer, where application can execute these methods. Then data access layer would connect to database, execute required query and return results to other layers, and thereby keeping other layers abstract from database integration. Typically data access layer is added as repositories.
BUSINESS LOGIC LAYER
This layer should handle all domain specific logic of the application, thereby complete logic is in a central location to be managed easily. 
Data access layer’s atomic CRUD methods can be used to make meaningful business scenarios, and these business logic layer is typically added as services.
PRESENTATION / UI LAYER
This layer is entry point for external interaction with the application.Here it is expected to be without any business logic, but rather directly forward the request to business logic layer
In thi solution presentation layer is added as controllers.
Repository Pattern:
The repository pattern is intended to create an Abstraction layer between the Data Access layer and Business Logic layer of an Application. 
It is a data access pattern that prompts a more loosely coupled approach to data access. 
Here I created a generic repository, which queries the data source for the data, maps the data from the data source to a business entity,
and persists changes in the business entity to the data source. 





