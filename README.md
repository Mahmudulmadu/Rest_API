.NET Web API with CRUD Operations with Database

This project is a simple .NET API demonstrating the following concepts and features:

RESTful API with CRUD operations
Data Annotations and Validation for model validation
Dependency Injection for services
Repository Pattern for data access
AutoMapper for object mapping
Custom API Responses for success and error
Pagination and Searching for managing large data sets
MS SQL Database for data persistence
Features

1. RESTful API with CRUD Operations
This API exposes endpoints for performing Create, Read, Update, and Delete (CRUD) operations on resources. In this example, the resource used is Category, but it can be easily extended to other entities.

2. Data Annotations and Validation
Data annotations are used for validating incoming requests. Common attributes such as [Required], [StringLength], and custom validation ensure data integrity.

3. Dependency Injection (DI)
The application uses Dependency Injection to manage the lifecycle of services. Services like CategoryService and CategoryRepository are injected into controllers to promote loose coupling and maintainability.

4. Repository Pattern
The Repository Pattern is used for abstracting data access logic. This design pattern promotes cleaner, more maintainable code and provides flexibility for future changes to the data layer.

5. AutoMapper
The AutoMapper library is used to map between domain models and DTOs (Data Transfer Objects). This helps to return optimized data in the API response and prevents unnecessary internal details from being exposed.

6. API Response: Success and Error
The API provides consistent responses for success and error cases. Successful responses contain the requested data, and error responses provide detailed error messages.

Example of Success Response:
json
Copy
{
    "status": "success",
    "data": {
        "id": 1,
        "name": "Category 1"
    }
}
Example of Error Response:
json
Copy
{
    "status": "error",
    "message": "Invalid input data"
}
7. Pagination and Searching
The API supports pagination and searching for managing large datasets. You can query Category data using parameters like page, pageSize, and searchTerm.

Example of Pagination:
bash
Copy
GET /api/categories?page=1&pageSize=10
Example of Searching:
bash
Copy
GET /api/categories?searchTerm=Category
8. Microsoft SQL Server Database
The application uses Microsoft SQL Server as the database for storing and managing Category data. It uses Entity Framework Core to handle database operations, including migrations, querying, and updates.

Getting Started
Prerequisites
.NET 6.0 or higher
Microsoft SQL Server (local or remote)
Visual Studio or Visual Studio Code
Installing
Clone the repository:

git clone https://github.com/Mahmudulmadu/Rest_API.git
Navigate to the project directory:

cd your-dotnet-api
Install required packages:

dotnet restore
Set up your database connection:
Open appsettings.json and configure the database connection string for your SQL Server.
json

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=yourserver;Database=yourdb;User Id=youruser;Password=yourpassword;"
  }
}
Replace yourserver, yourdb, youruser, and yourpassword with your actual SQL Server connection details.

Run the migrations (if using Entity Framework):

Make sure that your AppDbContext is set up correctly, then run the following command to apply the migrations:

dotnet ef database update
Run the application:

dotnet run
Once the application starts, you can access the API at http://localhost:5000 (or whichever port you configured).

API Endpoints
1. Create Category
POST /api/categories
Request:
json

{
    "name": "Category Name"
}
Response:
json
{
    "status": "success",
    "data": {
        "id": 1,
        "name": "Category Name"
    }
}
2. Get All Categories

GET /api/categories
Query Parameters:
page: The page number (default is 1).
pageSize: The number of items per page (default is 10).
searchTerm: A search term to filter categories by name.
Response:
json
{
    "status": "success",
    "data": [
        {
            "id": 1,
            "name": "Category 1"
        },
        {
            "id": 2,
            "name": "Category 2"
        }
    ]
}
3. Get Category By Id
bash
GET /api/categories/{id}
Response:
json

{
    "status": "success",
    "data": {
        "id": 1,
        "name": "Category 1"
    }
}
4. Update Category
bash

PUT /api/categories/{id}
Request:
json
{
    "name": "Updated Category"
}
Response:
json
C
{
    "status": "success",
    "data": {
        "id": 1,
        "name": "Updated Category"
    }
}
5. Delete Category
bash

DELETE /api/categories/{id}
Response:
json
Copy
{
    "status": "success",
    "message": "Category deleted successfully"
}
Technologies Used
ASP.NET Core - Framework for building APIs.
Entity Framework Core - ORM for database access with Microsoft SQL Server.
AutoMapper - Library for mapping between models and DTOs.
SQL Server - Database for storing category data.
Swagger - Tool for API documentation.
Contributing
If you'd like to contribute to this project, please fork the repository and submit a pull request. Contributions are welcome!

License
This project is licensed under the MIT License - see the LICENSE file for details.

Contact
If you have any questions, feel free to reach out:

Email: mahmudulmadu@gmail.com
GitHub: https://github.com/Mahmudulmadu/




